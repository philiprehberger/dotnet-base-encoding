# Changelog

## 0.2.0 (2026-04-05)

- Add `TryDecode(string encoded, out byte[]? result)` to `IBaseEncoder` interface
- Implement `TryDecode` in `Base32Encoder`, `Base62Encoder`, and `Base64UrlEncoder`
- Returns `false` instead of throwing on invalid input

## 0.1.2 (2026-03-31)

- Standardize README to 3-badge format with emoji Support section
- Update CI actions to v5 for Node.js 24 compatibility
- Add GitHub issue templates, dependabot config, and PR template
- Add GitHub issue templates, dependabot config, and PR template

## 0.1.1 (2026-03-26)

- Add Sponsor badge and fix License link format in README

## 0.1.0 (2026-03-21)

- Initial release
- Base32 encoding and decoding (RFC 4648, no padding)
- Base62 encoding and decoding (alphanumeric [0-9A-Za-z])
- Base64URL encoding and decoding (RFC 4648 section 5, no padding)
- IBaseEncoder interface for consistent API across all encoders
