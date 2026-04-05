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

    /// <summary>
    /// Attempts to decode an encoded string back into a byte array without throwing on invalid input.
    /// </summary>
    /// <param name="encoded">The encoded string to decode.</param>
    /// <param name="result">When this method returns, contains the decoded byte array if decoding succeeded, or <c>null</c> if it failed.</param>
    /// <returns><c>true</c> if decoding succeeded; otherwise, <c>false</c>.</returns>
    bool TryDecode(string encoded, out byte[]? result);
}
