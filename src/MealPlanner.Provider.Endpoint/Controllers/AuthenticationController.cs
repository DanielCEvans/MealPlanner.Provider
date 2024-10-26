using System.Text;
using Fido2NetLib;
using Fido2NetLib.Objects;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Provider.Endpoint.Controllers;

[ApiController]
[Route("api/")]
public class AuthenticationController(IFido2 fido2, IUserRepository userRepository, IStoredCredential storedCredential)
    : Controller
{
    private readonly IFido2 _fido2 = fido2;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IStoredCredential _storedCredential = storedCredential;

    private string FormatException(Exception e)
    {
        return string.Format("{0}{1}", e.Message,
            e.InnerException != null ? " (" + e.InnerException.Message + ")" : "");
    }

    [HttpPost]
    [Route("/makeCredentialOptions")]
    public JsonResult MakeCredentialOptions([FromForm] string username,
        [FromForm] string attType,
        [FromForm] string authType,
        [FromForm] string residentKey,
        [FromForm] string userVerification)
    {

        try
        {
            // 1. Get user from DB by username (in our example, auto create missing users)
            var user = _userRepository.GetOrAddUser(username, () => new User
            {
                Username = username,
                UsernameEncoded = Encoding.UTF8.GetBytes(username) // byte representation of userID is required
            });

            // 2. Get user existing keys by username
            var existingKeys = _storedCredential.GetCredentialsByUser(user).Select(c => c.Descriptor).ToList();

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
                Id = user.UsernameEncoded
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
}