# 说明
本仓库提供了腾讯云云通信账号 tls sig api 的 C# 版本，采用 C++ 扩展方式实现。

## 构建扩展
依赖 C++ 编写的动态库，需要使用 tls sig api [C++ 项目](https://github.com/tencentyun/tls-sig-api)进行构建。

## 源代码集成
将 TLSSigAPI.cs 下载开发者项目的目录下即可。

按需修改 `TLSSigAPI.cs` 中的动态库路径，
```C#
public const string DynamicLibPath = @"C:\Users\Administrator\tls-sig-api\Release\tlsignaturecs.dll";
```

## 使用说明
### 使用默认过期时间
```C#
...
using tencentyun
...
// .net 导入私钥的接口与 openssl 不一致
// 这里私钥需要把下载到 pem 文件中的头尾去掉
string privKeyContent = 
    "MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgkTfHxPa8YusG+va8"
    + "1CRztNQBOEr90TBEjlQBZ5d1Y0ChRANCAAS9isP/xLib7EZ1vS5OUy+gOsYBwees"
    + "PMDvWiTygPAUsGZv1PHLoa0ciqsElkO1fMGwNrzOKJx1Oo194Ri+SypV";
TLSSigAPI api = new TLSSigAPI(1400000000, privKeyContent, "");
Console.WriteLine(api.genSig("xiaojun"));
```

### 使用指定过期时间
```C#
...
using tencentyun
...
// .net 导入私钥的接口与 openssl 不一致
// 这里私钥需要把下载到 pem 文件中的头尾去掉
string privKeyContent = 
    "MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgkTfHxPa8YusG+va8"
    + "1CRztNQBOEr90TBEjlQBZ5d1Y0ChRANCAAS9isP/xLib7EZ1vS5OUy+gOsYBwees"
    + "PMDvWiTygPAUsGZv1PHLoa0ciqsElkO1fMGwNrzOKJx1Oo194Ri+SypV";
TLSSigAPI api = new TLSSigAPI(1400000000, privKeyContent, "");
// 使用指定 30 天有效期
Console.WriteLine(api.genSig("xiaojun", 3600*24*30));
```

