# IpAddress

[Back](../../../../)

IP Address Service.

**Class**: `IpAddressService`

### GetPublicIP

Returns the Public IP for the consumer based on the avaliblity of http://checkip.amazonaws.com

```c#
string GetPublicIP();
```

### GetLocalIPv4

Returns the Local IP for the consumer where NetworkInterfaceType is `NetworkInterfaceType.Ethernet`, and `OperationalStatus.Up`. Additionally AddressFamily is `AddressFamily.InterNetwork` (this last one is just means its IP v4)

```c#
string GetLocalIPv4();
```

