using System.ComponentModel.DataAnnotations.Schema;
using Fido2NetLib.Objects;

namespace MealPlanner.Provider.Persistence.Models;

public class StoredCredential
{
    /// <summary>
    /// The Credential ID of the public key credential source.
    /// </summary>
    public required byte[] Id { get; set; }

    /// <summary>
    /// The credential public key of the public key credential source.
    /// </summary>
    public byte[] PublicKey { get; set; }

    /// <summary>
    /// The latest value of the signature counter in the authenticator data from any ceremony using the public key credential source.
    /// </summary>
    public uint SignCount { get; set; }

    /// <summary>
    /// The value returned from getTransports() when the public key credential source was registered.
    /// </summary>
    public AuthenticatorTransport[] Transports { get; set; }

    /// <summary>
    /// The value of the BE flag when the public key credential source was created.
    /// </summary>
    public bool IsBackupEligible { get; set; }

    /// <summary>
    /// The latest value of the BS flag in the authenticator data from any ceremony using the public key credential source.
    /// </summary>
    public bool IsBackedUp { get; set; }

    /// <summary>
    /// The value of the attestationObject attribute when the public key credential source was registered. 
    /// Storing this enables the Relying Party to reference the credential's attestation statement at a later time.
    /// </summary>
    public byte[] AttestationObject { get; set; }

    /// <summary>
    /// The value of the clientDataJSON attribute when the public key credential source was registered. 
    /// Storing this in combination with the above attestationObject item enables the Relying Party to re-verify the attestation signature at a later time.
    /// </summary>
    public byte[] AttestationClientDataJson { get; set; }

    public List<byte[]> DevicePublicKeys { get; set; }

    public byte[] Fido2Id { get; set; }

    /// <summary>
    /// Exposes a Descriptor Object for this credential, used as input to the library for certain operations.
    /// </summary>
    public PublicKeyCredentialDescriptor Descriptor { get; set; }

    public byte[] UserHandle { get; set; }

    public string AttestationFormat { get; set; }

    public DateTimeOffset RegDate { get; set; }

    public Guid AaGuid { get; set; }
    
    public User user { get; set; }
}