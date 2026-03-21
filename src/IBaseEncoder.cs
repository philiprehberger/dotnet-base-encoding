namespace Philiprehberger.BaseEncoding;

/// <summary>
/// Defines the contract for encoding and decoding byte arrays to and from strings.
/// </summary>
public interface IBaseEncoder
{
    /// <summary>
    /// Encodes a byte array into a string representation.
    /// </summary>
    /// <param name="data">The byte array to encode.</param>
    /// <returns>The encoded string.</returns>
    string Encode(byte[] data);

    /// <summary>
    /// Decodes an encoded string back into a byte array.
    /// </summary>
    /// <param name="encoded">The encoded string to decode.</param>
    /// <returns>The decoded byte array.</returns>
    byte[] Decode(string encoded);
}
