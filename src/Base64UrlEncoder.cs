namespace Philiprehberger.BaseEncoding;

/// <summary>
/// RFC 4648 section 5 Base64URL encoder and decoder. Uses <c>-</c> and <c>_</c> instead of
/// <c>+</c> and <c>/</c>, and omits padding characters.
/// </summary>
public sealed class Base64UrlEncoder : IBaseEncoder
{
    /// <inheritdoc />
    public string Encode(byte[] data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (data.Length == 0)
        {
            return string.Empty;
        }

        return Convert.ToBase64String(data)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }

    /// <inheritdoc />
    public byte[] Decode(string encoded)
    {
        ArgumentNullException.ThrowIfNull(encoded);

        if (encoded.Length == 0)
        {
            return [];
        }

        var base64 = encoded
            .Replace('-', '+')
            .Replace('_', '/');

        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
}
