using DomainDrivenDesign;

namespace Auth.Domain.Models;

/// <summary>
///     Refresh token for user.
/// </summary>
public class RefreshToken : Entity<Guid>
{
    /// <inheritdoc />
    public RefreshToken(Guid id) : base(id)
    {
    }

    /// <summary>
    ///     Refresh token value.
    /// </summary>
    public string? Token { get; init; }


    /// <summary>
    ///     DateTime when the refresh token was revoked.
    /// </summary>
    public DateTime? Revoked { get; init; }

    /// <summary>
    ///     DateTime when the refresh token expires.
    /// </summary>
    public DateTime Expires { get; init; }


    /// <summary>
    ///     Reason why token was revoked.
    /// </summary>
    public string? ReasonRevoked { get; init; }

    /// <summary>
    ///     Is this token Expired.
    /// </summary>
    public bool IsExpired => DateTime.UtcNow >= Expires;

    /// <summary>
    ///     Is this token revoked.
    /// </summary>
    public bool IsRevoked => Revoked != null;

    /// <summary>
    ///     Is this token active.
    /// </summary>
    public bool IsActive => !IsRevoked && !IsExpired;


    /// <summary>
    ///     User Id whose requested the refresh token.
    /// </summary>
    public Guid UserId { get; init; }
}