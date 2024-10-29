using System.Text;
using Fido2NetLib;
using Fido2NetLib.Objects;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Provider.Endpoint.Controllers;

[ApiController]
[Route("api/")]
public class AuthenticationController(IFido2 fido2, IUserRepository userRepository, IStoredCredentialRepository storedCredentialRepository)
    : Controller
{
    private readonly IFido2 _fido2 = fido2;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IStoredCredentialRepository _storedCredentialRepository = storedCredentialRepository;

    private string FormatException(Exception e)
    {
        return string.Format("{0}{1}", e.Message,
            e.InnerException != null ? " (" + e.InnerException.Message + ")" : "");
    }

    [HttpPost]
    [Route("makeCredentialOptions")]
    public JsonResult MakeCredentialOptions([FromForm] string username,
        [FromForm] string attType,
        [FromForm] string authType,
        [FromForm] string residentKey,
        [FromForm] string userVerification)
    {

        try
        {
            var sessionId = HttpContext.Session.Id;
            Console.WriteLine($"Session ID: {sessionId}");
            
            // 1. Get user from DB by username (in our example, auto create missing users)
            var user = _userRepository.GetOrAddUser(username, () => new User
            {
                Username = username,
                Email = "danielconnorevans@gmail.com",
                Fido2Id = Encoding.UTF8.GetBytes(username) // byte representation of userID is required
            });

            // 2. Get user existing keys by username
            var existingKeys = _storedCredentialRepository.GetCredentialsByUser(user).Select(c => c.Descriptor).ToList();

            // 3. Create options
            var authenticatorSelection = new AuthenticatorSelection
            {
                ResidentKey = residentKey.ToEnum<ResidentKeyRequirement>(),
                UserVerification = userVerification.ToEnum<UserVerificationRequirement>()
            };

            if (!string.IsNullOrEmpty(authType))
                authenticatorSelection.AuthenticatorAttachment = authType.ToEnum<AuthenticatorAttachment>();

            var exts = new AuthenticationExtensionsClientInputs()
            {
                Extensions = true,
                UserVerificationMethod = true,
                DevicePubKey = new AuthenticationExtensionsDevicePublicKeyInputs() { Attestation = attType },
                CredProps = true
            };

            Fido2User fidoUser = new Fido2User()
            {
                Name = user.Username,
                DisplayName = user.Username,
                Id = user.Fido2Id
            };

            var options = _fido2.RequestNewCredential(fidoUser, existingKeys, authenticatorSelection,
                attType.ToEnum<AttestationConveyancePreference>(), exts);

            // 4. Temporarily store options, session/in-memory cache/redis/db
            HttpContext.Session.SetString("fido2.attestationOptions", options.ToJson());

            // 5. return options to client
            return Json(options);
        }
        catch (Exception e)
        {
            return Json(new { Status = "error", ErrorMessage = FormatException(e) });
        }
    }
    
    [HttpPost]
    [Route("makeCredential")]
    public async Task<JsonResult> MakeCredential([FromBody] AuthenticatorAttestationRawResponse attestationResponse, CancellationToken cancellationToken)
    {
        try
        {
            var sessionId = HttpContext.Session.Id;
            Console.WriteLine($"Session ID: {sessionId}");
            
            // 1. get the options we sent the client
            var jsonOptions = HttpContext.Session.GetString("fido2.attestationOptions");
            var options = CredentialCreateOptions.FromJson(jsonOptions);
            
            // TODO: I removed the static keyword from the anonymous callback funtion, this might cause errors!?   

            // 2. Create callback so that lib can verify credential id is unique to this user
            IsCredentialIdUniqueToUserAsyncDelegate callback = async (args, cancellationToken) =>
            {
                var users = await _storedCredentialRepository.GetUsersByCredentialIdAsync(args.CredentialId,
                    cancellationToken);
                if (users.Count > 0)
                    return false;

                return true;
            };

            // 2. Verify and make the credentials
            var success = await _fido2.MakeNewCredentialAsync(attestationResponse, options, callback, cancellationToken: cancellationToken);

            // TODO: is it necessary to keep swapping between Fido2 users and my users in the database?
            User user = new User()
            {
                Username = options.User.Name,
                Fido2Id = options.User.Id
            };
            
            // 3. Store the credentials in db
            _storedCredentialRepository.AddCredentialToUser(user, new StoredCredential
            {
                Id = success.Result.Id,
                PublicKey = success.Result.PublicKey,
                UserHandle = success.Result.User.Id,
                SignCount = success.Result.SignCount,
                AttestationFormat = success.Result.AttestationFormat,
                RegDate = DateTimeOffset.UtcNow,
                AaGuid = success.Result.AaGuid,
                Transports = success.Result.Transports,
                IsBackupEligible = success.Result.IsBackupEligible,
                IsBackedUp = success.Result.IsBackedUp,
                AttestationObject = success.Result.AttestationObject,
                AttestationClientDataJson = success.Result.AttestationClientDataJson,
                DevicePublicKeys = [success.Result.DevicePublicKey],
            });

            // 4. return "ok" to the client
            return Json(success);
        }
        catch (Exception e)
        {
            return Json(new { status = "error", errorMessage = FormatException(e) });
        }
    }
    
    [HttpPost]
    [Route("assertionOptions")]
    public ActionResult AssertionOptionsPost([FromForm] string username, [FromForm] string userVerification)
    {
        try
        {
            var existingCredentials = new List<PublicKeyCredentialDescriptor>();

            if (!string.IsNullOrEmpty(username))
            {
                // 1. Get user from DB
                var user = _userRepository.GetUser(username) ?? throw new ArgumentException("Username was not registered");

                // 2. Get registered credentials from database
                existingCredentials = _storedCredentialRepository.GetCredentialsByUser(user).Select(c => c.Descriptor).ToList();
            }

            var exts = new AuthenticationExtensionsClientInputs()
            {
                Extensions = true,
                UserVerificationMethod = true,
                DevicePubKey = new AuthenticationExtensionsDevicePublicKeyInputs()
            };

            // 3. Create options
            var uv = string.IsNullOrEmpty(userVerification) ? UserVerificationRequirement.Discouraged : userVerification.ToEnum<UserVerificationRequirement>();
            var options = _fido2.GetAssertionOptions(
                existingCredentials,
                uv,
                exts
            );

            // 4. Temporarily store options, session/in-memory cache/redis/db
            HttpContext.Session.SetString("fido2.assertionOptions", options.ToJson());

            // 5. Return options to client
            return Json(options);
        }

        catch (Exception e)
        {
            return Json(new { Status = "error", ErrorMessage = FormatException(e) });
        }
    }
    
}