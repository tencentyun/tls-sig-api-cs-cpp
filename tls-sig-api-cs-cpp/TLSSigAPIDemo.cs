using System;
using tencentyun;

namespace tls_sig_api_cs
{
    class TLSSigAPIDemo
    {
        static public void Main(String[] args)
        {
            string privKeyContent = @"-----BEGIN PRIVATE KEY-----
MIGEAgEAMBAGByqGSM49AgEGBSuBBAAKBG0wawIBAQQgK55Mnxa+AH7tvzvAyfxW
aN1rZdL0Xv2hyg3k2eqjeHyhRANCAAQvkz6T2Or8EEzgF0lWBF0RtrxjJYUF6RqM
2JUDAP4UD/cIwhGTYlWC2ZRPZEvaXZJapz2Y2c2TwcgW13sAnIKZ
-----END PRIVATE KEY-----";
            TLSSigAPI api = new TLSSigAPI(1400000000, privKeyContent, "");
            Console.WriteLine(api.genSig("xiaojun"));
            Console.ReadKey();
        }
    }
}
