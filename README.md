# 说明
本仓库提供了腾讯云云通信账号 tls sig api 的 C# 版本，采用 C++ 扩展方式实现。在以下平台通过验证，
- Windows 10 x64，.NET Framework 4.6.1
- Mac 10.13.6，.NET Core 2.2.106
- Linux CentOS 7.2，.NET Core 2.2.203

# 集成说明
**首先**需要使用 C++ 项目构建需要的动态库，然后再通过源代码进行集成。

## 构建扩展
依赖 C++ 编写的动态库，需要首先使用 tls sig api [C++ 项目](https://github.com/tencentyun/tls-sig-api)进行构建。

## 源代码集成
将 TLSSigAPI.cs 下载开发者项目的目录下即可。

按需修改 `TLSSigAPI.cs` 中的动态库路径，
```C#
public const string DynamicLibPath = @"C:\Users\Administrator\tls-sig-api\Release\tlsignaturecs.dll";
```
Mac 下的文件名应该为 `libtlsignaturecs.dylib`，Linux 下的文件名应该为 `libtlsignaturecs.so`。

## 使用说明
### 使用默认过期时间
```C#
...
using tencentyun
...
// 私钥按照下载的格式读入
    string privKeyContent = @"-----BEGIN PRIVATE KEY-----
MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgkTfHxPa8YusG+va8
1CRztNQBOEr90TBEjlQBZ5d1Y0ChRANCAAS9isP/xLib7EZ1vS5OUy+gOsYBwees
PMDvWiTygPAUsGZv1PHLoa0ciqsElkO1fMGwNrzOKJx1Oo194Ri+SypV
-----END PRIVATE KEY-----";
    TLSSigAPI api = new TLSSigAPI(1400000000, privKeyContent, "");
    Console.WriteLine(api.genSig("xiaojun"));
    Console.ReadKey();
```

### 使用指定过期时间
```C#
...
using tencentyun
...
// 私钥按照下载的格式读入
    string privKeyContent = @"-----BEGIN PRIVATE KEY-----
MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgkTfHxPa8YusG+va8
1CRztNQBOEr90TBEjlQBZ5d1Y0ChRANCAAS9isP/xLib7EZ1vS5OUy+gOsYBwees
PMDvWiTygPAUsGZv1PHLoa0ciqsElkO1fMGwNrzOKJx1Oo194Ri+SypV
-----END PRIVATE KEY-----";
    TLSSigAPI api = new TLSSigAPI(1400000000, privKeyContent, "");
    // 使用指定 30 天有效期
    Console.WriteLine(api.genSig("xiaojun", 3600*24*30));
```
