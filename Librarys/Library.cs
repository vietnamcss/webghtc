using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Librarys
{
    public class Library
    {
        public string genDataPlan(string p_language, string p_tokenkey, string p_privateKey, string p_planid, string p_planhisid, string p_note)
        {
            string _token = "";
            try
            {
                List<Claim> _lC = new List<Claim>();
                Claim _c;
                _c = new Claim("language", p_language); _lC.Add(_c);
                _c = new Claim("tokenkey", p_tokenkey); _lC.Add(_c);
                _c = new Claim("planid", p_planid); _lC.Add(_c);
                _c = new Claim("planhisid", p_planhisid); _lC.Add(_c);
                _c = new Claim("note", p_note); _lC.Add(_c);
                _token = EncodeToken(_lC, p_privateKey).Replace("--", "minus");
            }
            catch (Exception ex)
            {
                _token = ex.Message;
            }
            return _token;
        }
        public static string Base64Encode(string plainText)
        { 
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            string encryptedtext = base64EncodedData.Replace(" ", "+");
            int mod4 = encryptedtext.Length % 4;
            if (mod4 > 0)
            {
                encryptedtext += new string('=', 4 - mod4);
            }
            var base64EncodedBytes = System.Convert.FromBase64String(encryptedtext);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string GetMD5Hash(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = ASCIIEncoding.Default.GetBytes(str);
            byte[] encoded = md5.ComputeHash(bytes); 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
                sb.Append(encoded[i].ToString("x2"));
            return sb.ToString();
        }
        public static string Encrypt(string plainText, string PasswordHash, string SaltKey, string VIKey)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            byte[] cipherTextBytes;
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string Decrypt(string encryptedText, string PasswordHash, string SaltKey, string VIKey)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        public static string GenerateHash(string input)
        {
            byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding("windows-874").GetBytes(input));
            return Convert.ToBase64String(array, 0, array.Length);
        }
        public string EncodeToken(List<Claim> claims, string privateRsaKey)
        {
            RSAParameters rsaParams;
            using (var tr = new StringReader(privateRsaKey))
            {
                var pemReader = new PemReader(tr);
                var keyPair = pemReader.ReadObject() as AsymmetricCipherKeyPair;
                if (keyPair == null)
                {
                    throw new Exception("Could not read RSA private key");
                }
                var privateRsaParams = keyPair.Private as RsaPrivateCrtKeyParameters;
                rsaParams = DotNetUtilities.ToRSAParameters(privateRsaParams);
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                Dictionary<string, object> payload = claims.ToDictionary(k => k.Type, v => (object)v.Value);
                return Jose.JWT.Encode(payload, rsa, Jose.JwsAlgorithm.RS256);
            }
        }
        public string DecodeToken(string token, string publicRsaKey)
        {
            RSAParameters rsaParams;
            using (var tr = new StringReader(publicRsaKey))
            {
                var pemReader = new PemReader(tr);
                var publicKeyParams = pemReader.ReadObject() as RsaKeyParameters;
                if (publicKeyParams == null)
                {
                    throw new Exception("Could not read RSA public key");
                }
                rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParams);
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                // This will throw if the signature is invalid
                return Jose.JWT.Decode(token, rsa, Jose.JwsAlgorithm.RS256);
            }
        }
        public string genDataReport(string p_language, string p_privateKey, string p_report_id, string p_user_id, string p_template, string p_report_name, string p_report_value, string p_parameter_text, string p_note)
        {
            string _token = "";
            try
            {
                List<Claim> _lC = new List<Claim>();
                Claim _c;
                _c = new Claim("report_id", p_report_id); _lC.Add(_c);
                _c = new Claim("user_id", p_user_id); _lC.Add(_c);
                _c = new Claim("template", p_template); _lC.Add(_c);
                _c = new Claim("report_name", p_report_name); _lC.Add(_c);
                _c = new Claim("report_value", p_report_value); _lC.Add(_c);
                _c = new Claim("parameter_text", p_parameter_text); _lC.Add(_c);
                _c = new Claim("note", p_note); _lC.Add(_c);
                _c = new Claim("language", p_language); _lC.Add(_c);
                _token = EncodeToken(_lC, p_privateKey).Replace("--", "95dbe2fec8c744888e2515b2b810a4ed");
            }
            catch (Exception ex)
            {
                _token = ex.Message;
            }
            return _token;
        }

        public string genDataCase(string p_language,string p_tokenkey, string p_privateKey, string p_caseid, string p_note, string p_processid, string p_tabid )
        {
            string _token = "";
            try
            {
                List<Claim> _lC = new List<Claim>();
                Claim _c;
                _c = new Claim("language", p_language); _lC.Add(_c);
                _c = new Claim("tokenkey", p_tokenkey); _lC.Add(_c); 
                _c = new Claim("caseid", p_caseid); _lC.Add(_c);
                _c = new Claim("processid", p_processid); _lC.Add(_c);
                _c = new Claim("tabid", p_tabid); _lC.Add(_c);
                _c = new Claim("note", p_note); _lC.Add(_c);
                _token = EncodeToken(_lC, p_privateKey).Replace("--", "minus");
            }
            catch (Exception ex)
            {
                _token = ex.Message;
            }
            return _token;
        }

        public string genDataFile(string p_language, string p_tokenkey, string p_privateKey, string attachment_id, string p_note, string case_id)
        {
            string _token = "";
            try
            {
                List<Claim> _lC = new List<Claim>();
                Claim _c;
                _c = new Claim("language", p_language); _lC.Add(_c);
                _c = new Claim("tokenkey", p_tokenkey); _lC.Add(_c);
                _c = new Claim("attachment_id", attachment_id); _lC.Add(_c); 
                _c = new Claim("note", p_note); _lC.Add(_c);
                _c = new Claim("case_id", case_id); _lC.Add(_c);
                _token = EncodeToken(_lC, p_privateKey).Replace("--", "minus");
            }
            catch (Exception ex)
            {
                _token = ex.Message;
            }
            return _token;
        }

        public string genDataProduct(string p_language, string p_tokenkey, string p_privateKey, string p_productid, string p_tabid, string p_note)
        {
            string _token = "";
            try
            {
                List<Claim> _lC = new List<Claim>();
                Claim _c;
                _c = new Claim("language", p_language); _lC.Add(_c);
                _c = new Claim("tokenkey", p_tokenkey); _lC.Add(_c);
                _c = new Claim("productid", p_productid); _lC.Add(_c);
                _c = new Claim("tabid", p_tabid); _lC.Add(_c);
                _c = new Claim("note", p_note); _lC.Add(_c);
                _token = EncodeToken(_lC, p_privateKey).Replace("--", "minus");
            }
            catch (Exception ex)
            {
                _token = ex.Message;
            }
            return _token;
        }

        public string genDataRefer(string p_language, string p_tokenkey, string p_privateKey, string p_referid, string p_tabid, string p_note)
        {
            string _token = "";
            try
            {
                List<Claim> _lC = new List<Claim>();
                Claim _c;
                _c = new Claim("language", p_language); _lC.Add(_c);
                _c = new Claim("tokenkey", p_tokenkey); _lC.Add(_c);
                _c = new Claim("referid", p_referid); _lC.Add(_c);
                _c = new Claim("tabid", p_tabid); _lC.Add(_c);
                _c = new Claim("note", p_note); _lC.Add(_c);
                _token = EncodeToken(_lC, p_privateKey).Replace("--", "minus");
            }
            catch (Exception ex)
            {
                _token = ex.Message;
            }
            return _token;
        }

    }
}
