using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace tencentyun
{
    class TLSSigAPI
    {
        public const string DynamicLibPath =
            @"C:\Users\Administrator\tls-sig-api\Release\tlsignaturecs.dll";

        private string priKeyContent;
        private string pubKeyContent;
        private int sdkappid;

        public TLSSigAPI(int sdkappid, string priKeyContent, string pubKeyContent = "")
        {
            this.priKeyContent = priKeyContent;
            this.pubKeyContent = pubKeyContent;
            this.sdkappid = sdkappid;
        }

        public string genSig(string identifier, int expireTime = 3600 * 24 * 180)
        {
            StringBuilder sig = new StringBuilder(4096);
            StringBuilder errMsg = new StringBuilder(4096);
            int ret = tls_gen_sig_ex_with_expire((UInt32)sdkappid, identifier, (UInt32)expireTime,
                sig, 4096, priKeyContent, (UInt32)priKeyContent.Length, errMsg, 4096);
            return sig.ToString();
        }

        [DllImport(DynamicLibPath, EntryPoint = "tls_gen_sig", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int tls_gen_sig(
            UInt32 expire,
            string appid3rd,
            UInt32 sdkappid,
            string identifier,
            UInt32 acctype,
            StringBuilder sig,
            UInt32 sigBuffLen,
            string priKey,
            UInt32 priKeyLen,
            StringBuilder errMsg,
            UInt32 errMsgBuffLen
        );
        [DllImport(DynamicLibPath, EntryPoint = "tls_vri_sig", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int tls_vri_sig(
            string sig,
            string pub_key,
            UInt32 pub_key_len,
            UInt32 acctype,
            string appid3rd,
            UInt32 sdkappid,
            string identifier,
            StringBuilder errMsg,
            UInt32 errMsgBuffLen
        );
        [DllImport(DynamicLibPath, EntryPoint = "tls_gen_sig_ex_with_expire", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int tls_gen_sig_ex_with_expire(
            UInt32 sdkappid,
            string identifier,
            UInt32 expire,
            StringBuilder sig,
            UInt32 sigBuffLen,
            string priKey,
            UInt32 priKeyLen,
            StringBuilder errMsg,
            UInt32 errMsgBuffLen
        );
        [DllImport(DynamicLibPath, EntryPoint = "tls_vri_sig_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int tls_vri_sig_ex(
            string sig,
            string pubKey,
            UInt32 pubKeyLen,
            UInt32 sdkappid,
            string identifier,
            ref UInt32 expireTime,
            ref UInt32 initTime,
            StringBuilder errMsg,
            UInt32 errMsgBuffLen
        );
    }
}
