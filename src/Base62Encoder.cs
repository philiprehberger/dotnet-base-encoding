namespace Philiprehberger.BaseEncoding;

/// <summary>
/// Base62 encoder and decoder using the alphanumeric character set [0-9A-Za-z].
/// </summary>
public sealed class Base62Encoder : IBaseEncoder
{
    private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    /// <inheritdoc />
    public string Encode(byte[] data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (data.Length == 0)
        {
            return string.Empty;
        }

        var digits = new List<int> { 0 };

        foreach (var b in data)
        {
            var carry = (int)b;

            for (var i = 0; i < digits.Count; i++)
            {
                carry += digits[i] << 8;
                digits[i] = carry % 62;
                carry /= 62;
            }

            while (carry > 0)
            {
                digits.Add(carry % 62);
                carry /= 62;
            }
        }

        // Preserve leading zero bytes
        foreach (var b in data)
        {
            if (b != 0)
            {
                break;
            }

            digits.Add(0);
        }

        digits.Reverse();

        var chars = new char[digits.Count];

        for (var i = 0; i < digits.Count; i++)
        {
            chars[i] = Alphabet[digits[i]];
        }

        return new string(chars);
    }

    /// <inheritdoc />
    public byte[] Decode(string encoded)
    {
        ArgumentNullException.ThrowIfNull(encoded);

        if (encoded.Length == 0)
        {
            return [];
        }

        var bytes = new List<int> { 0 };

        foreach (var c in encoded)
        {
            var carry = CharToValue(c);

            for (var i = 0; i < bytes.Count; i++)
            {
                carry += bytes[i] * 62;
                bytes[i] = carry & 0xFF;
                carry >>= 8;
            }

            while (carry > 0)
            {
                bytes.Add(carry & 0xFF);
                carry >>= 8;
            }
        }

        // Preserve leading zero characters
        foreach (var c in encoded)
        {
            if (c != Alphabet[0])
            {
                break;
            }

            bytes.Add(0);
        }

        bytes.Reverse();

        var result = new byte[bytes.Count];

        for (var i = 0; i < bytes.Count; i++)
        {
            result[i] = (byte)bytes[i];
        }

        return result;
    }

    private static int CharToValue(char c)
    {
        return c switch
        {
            >= '0' and <= '9' => c - '0',
            >= 'A' and <= 'Z' => c - 'A' + 10,
            >= 'a' and <= 'z' => c - 'a' + 36,
            _ => throw new FormatException($"Invalid Base62 character: '{c}'.")
        };
    }
}
