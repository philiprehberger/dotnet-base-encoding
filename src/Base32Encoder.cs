namespace Philiprehberger.BaseEncoding;

/// <summary>
/// RFC 4648 Base32 encoder and decoder without padding.
/// </summary>
public sealed class Base32Encoder : IBaseEncoder
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

    /// <inheritdoc />
    public string Encode(byte[] data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (data.Length == 0)
        {
            return string.Empty;
        }

        var output = new char[(data.Length * 8 + 4) / 5];
        var bitBuffer = 0;
        var bitsRemaining = 0;
        var index = 0;

        foreach (var b in data)
        {
            bitBuffer = (bitBuffer << 8) | b;
            bitsRemaining += 8;

            while (bitsRemaining >= 5)
            {
                bitsRemaining -= 5;
                output[index++] = Alphabet[(bitBuffer >> bitsRemaining) & 0x1F];
            }
        }

        if (bitsRemaining > 0)
        {
            output[index++] = Alphabet[(bitBuffer << (5 - bitsRemaining)) & 0x1F];
        }

        return new string(output, 0, index);
    }

    /// <inheritdoc />
    public byte[] Decode(string encoded)
    {
        ArgumentNullException.ThrowIfNull(encoded);

        var trimmed = encoded.TrimEnd('=');

        if (trimmed.Length == 0)
        {
            return [];
        }

        var output = new byte[trimmed.Length * 5 / 8];
        var bitBuffer = 0;
        var bitsRemaining = 0;
        var index = 0;

        foreach (var c in trimmed)
        {
            var value = CharToValue(c);
            bitBuffer = (bitBuffer << 5) | value;
            bitsRemaining += 5;

            if (bitsRemaining >= 8)
            {
                bitsRemaining -= 8;
                output[index++] = (byte)((bitBuffer >> bitsRemaining) & 0xFF);
            }
        }

        return output[..index];
    }

    private static int CharToValue(char c)
    {
        return c switch
        {
            >= 'A' and <= 'Z' => c - 'A',
            >= 'a' and <= 'z' => c - 'a',
            >= '2' and <= '7' => c - '2' + 26,
            _ => throw new FormatException($"Invalid Base32 character: '{c}'.")
        };
    }
}
