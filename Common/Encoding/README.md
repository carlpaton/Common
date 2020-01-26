# Encoding
Encoding is the conversion of these characters to a byte stream to transmit them over the wire or store them to disk. Some common encodings are ASCII, UTF-8, etc.

> A character encoding system consists of a code that pairs each character from a given repertoire with something else — such as a bit pattern ... to facilitate the transmission of data (generally numbers or text) through telecommunication networks or for data storage. - Wikipedia 

### IEncodingService

```IEncodingService
ToBase64String
```

Encodes the given `string`  to base 64 using the ASCII (7-bit) character set.

Example: `username:password` would be `dXNlcm5hbWU6cGFzc3dvcmQ=`