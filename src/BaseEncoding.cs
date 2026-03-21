namespace Philiprehberger.BaseEncoding;

/// <summary>
/// Provides access to Base32, Base62, and Base64URL encoders.
/// </summary>
public static class BaseEncoding
{
    private static readonly Base32Encoder Base32Instance = new();
    private static readonly Base62Encoder Base62Instance = new();
    private static readonly Base64UrlEncoder Base64UrlInstance = new();

    /// <summary>
    /// Gets the RFC 4648 Base32 encoder (no padding).
    /// </summary>
    public static IBaseEncoder Base32 => Base32Instance;

    /// <summary>
    /// Gets the Base62 encoder using alphanumeric characters [0-9A-Za-z].
    /// </summary>
    public static IBaseEncoder Base62 => Base62Instance;

    /// <summary>
    /// Gets the RFC 4648 section 5 Base64URL encoder (no padding).
    /// </summary>
    public static IBaseEncoder Base64Url => Base64UrlInstance;
}
