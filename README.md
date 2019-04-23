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
// 私钥按照下载的格式读入
string privKeyContent = @"-----BEGIN PRIVATE KEY-----
MIGEAgEAMBAGByqGSM49AgEGBSuBBAAKBG0wawIBAQQgK55Mnxa+AH7tvzvAyfxW
aN1rZdL0Xv2hyg3k2eqjeHyhRANCAAQvkz6T2Or8EEzgF0lWBF0RtrxjJYUF6RqM
2JUDAP4UD/cIwhGTYlWC2ZRPZEvaXZJapz2Y2c2TwcgW13sAnIKZ
-----END PRIVATE KEY-----";
TLSSigAPI api = new TLSSigAPI(1400000000, privKeyContent, "");
Console.WriteLine(api.genSig("xiaojun"));
```

### 使用指定过期时间
```C#
...
using tencentyun
...
// 私钥按照下载的格式读入
string privKeyContent = @"-----BEGIN PRIVATE KEY-----
MIGEAgEAMBAGByqGSM49AgEGBSuBBAAKBG0wawIBAQQgK55Mnxa+AH7tvzvAyfxW
aN1rZdL0Xv2hyg3k2eqjeHyhRANCAAQvkz6T2Or8EEzgF0lWBF0RtrxjJYUF6RqM
2JUDAP4UD/cIwhGTYlWC2ZRPZEvaXZJapz2Y2c2TwcgW13sAnIKZ
-----END PRIVATE KEY-----";
TLSSigAPI api = new TLSSigAPI(1400000000, privKeyContent, "");
// 使用指定 30 天有效期
Console.WriteLine(api.genSig("xiaojun", 3600*24*30));
```

