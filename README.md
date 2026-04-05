# Philiprehberger.BaseEncoding

[![CI](https://github.com/philiprehberger/dotnet-base-encoding/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-base-encoding/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.BaseEncoding.svg)](https://www.nuget.org/packages/Philiprehberger.BaseEncoding)
[![Last updated](https://img.shields.io/github/last-commit/philiprehberger/dotnet-base-encoding)](https://github.com/philiprehberger/dotnet-base-encoding/commits/main)

Base32, Base62, and Base64URL encoding and decoding — URL-safe, padding-free alternatives to standard Base64.

## Installation

```bash
dotnet add package Philiprehberger.BaseEncoding
```

## Usage

```csharp
using Philiprehberger.BaseEncoding;

var encoded = BaseEncoding.Base32.Encode(new byte[] { 72, 101, 108, 108, 111 });
var decoded = BaseEncoding.Base32.Decode(encoded);
```

### Encode and Decode

```csharp
using Philiprehberger.BaseEncoding;

var data = System.Text.Encoding.UTF8.GetBytes("Hello, World!");

var base32 = BaseEncoding.Base32.Encode(data);
var original = BaseEncoding.Base32.Decode(base32);
// original == data

var base62 = BaseEncoding.Base62.Encode(data);
var restored = BaseEncoding.Base62.Decode(base62);
// restored == data
```

### Base64URL for Tokens

```csharp
using Philiprehberger.BaseEncoding;

var tokenBytes = new byte[32];
System.Security.Cryptography.RandomNumberGenerator.Fill(tokenBytes);

var token = BaseEncoding.Base64Url.Encode(tokenBytes);
// URL-safe string with no padding, safe for query strings and headers
var raw = BaseEncoding.Base64Url.Decode(token);
```

### Safe Decoding with TryDecode

```csharp
using Philiprehberger.BaseEncoding;

if (BaseEncoding.Base32.TryDecode("JBSWY3DP", out var result))
{
    // result contains the decoded bytes
}
else
{
    // input was invalid — no exception thrown
}
```

### Base62 Short URLs

```csharp
using Philiprehberger.BaseEncoding;

var id = BitConverter.GetBytes(123456789L);
var shortCode = BaseEncoding.Base62.Encode(id);
// Compact alphanumeric string suitable for short URLs
var decoded = BaseEncoding.Base62.Decode(shortCode);
```

## API

| Method / Type | Description |
|---------------|-------------|
| `BaseEncoding.Base32` | Static property returning an `IBaseEncoder` for RFC 4648 Base32 (no padding) |
| `BaseEncoding.Base62` | Static property returning an `IBaseEncoder` for alphanumeric [0-9A-Za-z] encoding |
| `BaseEncoding.Base64Url` | Static property returning an `IBaseEncoder` for RFC 4648 section 5 Base64URL (no padding) |
| `IBaseEncoder.Encode(data)` | Encodes a byte array into a string |
| `IBaseEncoder.Decode(encoded)` | Decodes a string back into a byte array |
| `IBaseEncoder.TryDecode(encoded, out result)` | Attempts to decode without throwing; returns `false` on invalid input |

## Development

```bash
dotnet build src/Philiprehberger.BaseEncoding.csproj --configuration Release
```

## Support

If you find this project useful:

⭐ [Star the repo](https://github.com/philiprehberger/dotnet-base-encoding)

🐛 [Report issues](https://github.com/philiprehberger/dotnet-base-encoding/issues?q=is%3Aissue+is%3Aopen+label%3Abug)

💡 [Suggest features](https://github.com/philiprehberger/dotnet-base-encoding/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement)

❤️ [Sponsor development](https://github.com/sponsors/philiprehberger)

🌐 [All Open Source Projects](https://philiprehberger.com/open-source-packages)

💻 [GitHub Profile](https://github.com/philiprehberger)

🔗 [LinkedIn Profile](https://www.linkedin.com/in/philiprehberger)

## License

[MIT](LICENSE)
