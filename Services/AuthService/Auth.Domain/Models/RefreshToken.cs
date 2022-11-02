using Auth.Domain.Base;

namespace Auth.Domain.Models;

/// <summary>
///     Refresh token for user.
/// </summary>
public class RefreshToken : DomainEntity<Guid>
{
    /// <summary>
    ///     Refresh token value.
    /// </summary>
    public string? Token { get; set; }


    /// <summary>
    ///     DateTime when the refresh token was revoked.
    /// </summary>
    public DateTime? Revoked { get; set; }

    /// <summary>
    ///     DateTime when the refresh token expires.
    /// </summary>
    public DateTime Expires { get; set; }


    /// <summary>
    ///     Reason why token was revoked.
    /// </summary>
    public string? ReasonRevoked { get; set; }

    /// <summary>
    ///     Is this token Expired.
    /// </summary>
    public bool IsExpired
    {
        get => DateTime.UtcNow >= Expires;
    }

    /// <summary>
    ///     Is this token revoked.
    /// </summary>
    public bool IsRevoked
    {
        get => Revoked != null;
    }

    /// <summary>
    ///     Is this token active.
    /// </summary>
    public bool IsActive
    {
        get => !IsRevoked && !IsExpired;
    }


    /// <summary>
    ///     User Id whose requested the refresh token.
    /// </summary>
    public Guid UserId { get; private set; }

    
}