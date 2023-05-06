using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions; 

namespace Librarys
{
    public class StringLibrary
    {
        private static CultureInfo ci = new CultureInfo("en-US");
        public string DD = "dd/MM/yyyy";//dd/MM/yyyy HH:mm:ss
        public string DA = "yyyy-MM-dd HH:mm:ss";
        public string hexbody = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26\x10\x13\x09\x0d\x0a\x22\x2002\x2003\x2009\x200C\x200D\x200E\x200F\x2013\x2014\x2018\x2019\x201A\x201C\x201D\x201E\x2020\x2021\x2030\x2039\x203A\x20AC]";
        public static string hex_no_space = "[\x7b\x7c\x7d\x7e\x7f\x5b\x5c\x5d\x5e\x5f\x60\x3a\x3b\x3c\x3d\x3e\x3f\x40\x00\x01\x02\x03\x04\x05\x06\x07\x08\x09\x0a\x0b\x0c\x0d\x0e\x0f\x10\x11\x12\x13\x14\x15\x16\x17\x18\x19\x1a\x1b\x1c\x1d\x1e\x1f\x21\x22\x23\x24\x25\x26\x27\x28\x29\x2a\x2b\x2c\x2d\x2e\x2f\x00-\x08\x0B\x0C\x0E-\x1F\x26\x10\x13\x09\x0d\x0a\x22\x2002\x2003\x2009\x200C\x200D\x200E\x200F\x2013\x2014\x2018\x2019\x201A\x201C\x201D\x201E\x2020\x2021\x203A]";
        public static string hex_all = "[\x7b\x7c\x7d\x7e\x7f\x5b\x5c\x5d\x5e\x5f\x60\x3a\x3b\x3c\x3d\x3e\x3f\x40\x00\x01\x02\x03\x04\x05\x06\x07\x08\x09\x0a\x0b\x0c\x0d\x0e\x0f\x10\x11\x12\x13\x14\x15\x16\x17\x18\x19\x1a\x1b\x1c\x1d\x1e\x1f\x20\x21\x22\x23\x24\x25\x26\x27\x28\x29\x2a\x2b\x2c\x2d\x2e\x2f\x00-\x08\x0B\x0C\x0E-\x1F\x26\x10\x13\x09\x0d\x0a\x22\x2002\x2003\x2009\x200C\x200D\x200E\x200F\x2013\x2014\x2018\x2019\x201A\x201C\x201D\x201E\x2020\x2021\x203A]";
        #region Overturned      
        public bool StringSplit(string StrString, string text)
        {
            string[] words = StrString.Split(',');
            bool _return = false;
            for (int j = 0; j <= words.Length - 1; j++)
            {
                if (words[j].Trim() == text.Trim())
                {
                    _return = true;
                }
            }
            return _return;
        }
        public string Left(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);
            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        public string Right(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(value.Length - maxLength);
        }

        public string StringRep(string p_Text, string p_rep)
        {
            string[] words = p_rep.Split(',');
            for (int j = 0; j <= words.Length - 1; j++)
            {
                p_Text = p_Text.Replace(words[j].ToString(), "");
            }
            return p_Text;
        }
        public string OverturnedString(string StrString, string Special)
        {
            string str = "";
            StrString = StrString.Replace(Special, ",");
            string[] words = StrString.Split(',');
            for (int j = words.Length - 1; j >= 0; j--)
            {
                if (j != 0)
                {
                    if (words[j].Trim() == "" || string.IsNullOrEmpty(words[j].Trim()))
                    {
                        str += words[j].Trim();
                    }
                    else
                    {
                        str += words[j].Trim() + Special;
                    }
                }
                if (j == 0)
                {
                    str += words[j].Trim();
                }
            }
            return str;
        }
        public string OverturnedString2(string StrString, string Special)
        {
            string str = "";
            StrString = StrString.Replace(Special, ",");
            for (int j = 0; j <= StrString.Length - 1; j++)
            {
                str += (StrString[j]).ToString().Trim() + Special;
            }
            return str;
        }
        public string Firstchar(string StrString)
        {
            string res = "";
            string[] tu = StrString.Split(' ');
            int len = tu.Length;
            res += tu[len - 1];
            for (int i = 0; i < len - 1; i++)
            {
                res += tu[i].Substring(0, 1);
            }
            return res.ToLower();
        }
        public string TurnedString(string StrString, string Special, string No)
        {
            string charr = "";
            StrString = StrString.Replace(Special, ",");
            string[] words = StrString.Split(',');
            for (int j = 0; j <= words.Length - 1; j++)
            {
                if (No == "M")
                {
                    if (j == 0)
                    {

                    }
                    else if (j == words.Length - 1)
                    {

                    }
                    else
                    {
                        charr += (words[j]).ToString().Trim() + Special;
                    }
                }
                if (No == "F")
                {
                    charr = words[0].ToString().Trim();
                }

                if (No == "E")
                {
                    charr = words[words.Length - 1].ToString().Trim();
                }

            }
            return charr;
        }

        #endregion
        #region TitleCase
        /// <summary>
        /// Viết hoa đầu dòng hoạc viết hoa sau ký tự cách.
        /// </summary>       
        public string _titleCase(string str, string TitleCase)
        {
            str = str.ToLower();
            switch (TitleCase)
            {
                case "First":
                    var strArray = str.Split(' ');
                    if (strArray.Length > 1)
                    {
                        strArray[0] = ci.TextInfo.ToTitleCase(strArray[0]);
                        return string.Join(" ", strArray);
                    }
                    break;
                case "All":
                    return ci.TextInfo.ToTitleCase(str);
                default:
                    break;
            }
            return ci.TextInfo.ToTitleCase(str);
        }

        #endregion
        #region
        /// <summary>
        /// string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26\x10\x13\x09\x0d\x0a\x22]";
        /// Xóa hết các chuỗi ký tự đặc biệt.
        /// string Vreturn = "";            
        /// Vreturn = txt.Replace("&NBSP;", "");
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string _RegexHex(string txt, string hex)
        {
            return Regex.Replace(txt.Trim(), hex, "", RegexOptions.Compiled);
        }
        #endregion
        #region Conver To Un Sign 
        public string LocDau(string str)
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
        public string _convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public string _convertToUnSign1(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        private static readonly string[] VietNamChar = new string[]
         {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
       };
        #endregion
        /// <summary>
        /// Lấy chuỗi đầu tiên sau dấu ,
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetCode(string input)
        {
            var ret = string.Empty;
            if (string.IsNullOrEmpty(input))
            {
                return ret;
            }
            var index = input.IndexOf(',');
            ret = input.Substring(0, index);
            return ret;
        }
        /// <summary>
        /// Chuyển định dạng về dang tiền  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string StringCurrency(decimal input)
        {
            return input.ToString("#,##0.00");
        }

        public string String_Currency(decimal input)
        {
            return input.ToString("#,##0");
        }
        public string String_command(string input)
        {
            return string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-US"), "{0:#,0}", Convert.ToDecimal(input)); 
        }
        /// <summary>
        /// chuyển từ định dạng tiền về dạng decimal
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //DecimalParse(txtCuocChinh.Text)
        public decimal DecimalParse(string input)
        {
            return decimal.Parse(Regex.Match(input, @"-?\d{1,3}(,\d{3})*(\.\d+)?").Value);
        }
        public decimal Decimal_Parse(string input)
        {
            string inputs = input.Replace(@",", @"");
            inputs = inputs.Replace(@".", @"");
            if (IsNumber(inputs))
            {
                return Convert.ToDecimal(inputs);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Kiểm tra xem có phải số không.
        /// </summary>
        /// <param name="pText"></param>
        /// <returns></returns>
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        //  var regex = /^[A-Za-z0-9]+$/
        public bool IsChar(string pText)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]*$");
            return regex.IsMatch(pText);
        }
        public bool IsCharValue(string pText)
        {
            Regex regex = new Regex("^[A-Za-z0-9_.-]+$");
            return regex.IsMatch(pText);
        }
        public bool IsChars(string pText)
        {
            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");
            return regex.IsMatch(pText);
        }
        public bool IsPhones(string pText)
        {
            Regex regex = new Regex("^(05|03|04|07|08|01|09|024|028)[0-9]{8}$|(021[012345689]|023[23456789]|020[3456789]|022[0123456789]|029[01234679]|025[123456789]|026[01239]|027[01234567])[0-9]{7}$");
            // Regex("^[0-9 ]*$");          
            return regex.IsMatch(pText);
        }
        public string StringPhone(string pphone)
        {
            if (pphone.StartsWith("0084"))
            {
                pphone = "0" + pphone.Substring(4);
            }
            else if (pphone.StartsWith("840"))
            {
                pphone = "0" + pphone.Substring(3);
            }
            else if (pphone.StartsWith("84"))
            {
                pphone = "0" + pphone.Substring(2);
            }
            else if (pphone.StartsWith("+84"))
            {
                pphone = "0" + pphone.Substring(3);
            }
            else if (pphone.StartsWith("00"))
            {
                pphone = "0" + pphone.Substring(2);
            }
            else if (pphone.Length == 9)
            {
                if (!pphone.StartsWith("0"))
                {
                    pphone = "0" + pphone;
                }
            }
            return pphone;
        }
        public bool isValidNewPhoneNumber(string phone)
        {
            phone = StringPhone(phone);
            if (string.IsNullOrEmpty(phone))
            {
                return false;
            }
            else if (phone.Length < 7)
            {
                return false;
            }
            else if (phone.Length > 13)
            {
                return false;
            }
            if (!phone.StartsWith("0")) { return false; }
            if (IsPhones(phone))
            { return true; }
            else
            {
                return false;
            }
        }
        public bool IsViPhones(string pText)
        {
            if (pText.Length != 10)
            {
                return false;
            }
            else
            {
                Regex regex = new Regex("^[0-9 ]*$");
                return regex.IsMatch(pText);
            }
        }

        public string strDecode(string str)
        {
            return WebUtility.HtmlDecode(str);
        }
        public bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public static bool IsValidString(string value)
        {
            string pattern = @"^[a-zA-Z0-9]{1,25}$";
            return Regex.IsMatch(value, pattern);
        }
        public static bool IsValidStringText(string value)
        {
            string pattern = @"^[A-Za-z0-9\s$&+,:;=?@#|'<>.^*()%!-]{0,10}$";
            return Regex.IsMatch(value, pattern);
        }

        //
        public static bool IsValidEmail(string email)
        {
            Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }
        public static bool IsValidPhone(string value)
        {
            string pattern = @"^-*[0-9,\.?\-?\(?\)?\ ]+$";
            return Regex.IsMatch(value, pattern);
        }
        public bool isValidPass(string inputPass)
        {
            string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,20}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputPass))
                return (true);
            else
                return (false);

        }
        public static string GetRandomAlphanumericString(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }
        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
        public bool isValidPasss(string inputPass)
        {
            //if (inputPass.Length >= 8)
            //    return (true);
            //else
            //    return (false);
            string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{8,30}$"; // @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,36}$";// @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputPass))
                return (true);
            else
                return (false);
        }
        public bool isValiFullName(string inputPass)
        {
            //string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            //Regex re = new Regex(strRegex);
            //if (re.IsMatch(inputPass))
            //    return (true);
            //else
            //    return (false);
            return true;
        }
        public bool isValiAddress(string inputPass)
        {
            //string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            //Regex re = new Regex(strRegex);
            //if (re.IsMatch(inputPass))
            //    return (true);
            //else
            //    return (false);
            return true;
        }
        public bool isValidGroupName(string inputPass)
        {
            //string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            //Regex re = new Regex(strRegex);
            //if (re.IsMatch(inputPass))
            //    return (true);
            //else
            //    return (false);
            return true;
        }
        public bool isValidGroupvalue(string inputPass)
        {
            //string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            //Regex re = new Regex(strRegex);
            //if (re.IsMatch(inputPass))
            //    return (true);
            //else
            //    return (false);
            return true;
        }
        public bool isValidGroupDescribe(string inputPass)
        {
            //string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            //Regex re = new Regex(strRegex);
            //if (re.IsMatch(inputPass))
            //    return (true);
            //else
            //    return (false);
            return true;
        }
        public bool isValidDateTime(string inputDateTime, string formats)
        {
            DateTime dateValue;
            if (DateTime.TryParseExact(inputDateTime, formats, new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
                return true;
            else
                return false;
        } 
        public DateTime formatDatetime(string inputDate, string type)
        {
            return DateTime.ParseExact(inputDate, type, (IFormatProvider)CultureInfo.InvariantCulture);
        }
        public int timesTamp(DateTime inputdatetime)
        {
            Int32 unixTimestamp = (Int32)(inputdatetime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }
        public DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(unixTimeStamp);
            // The dateTime now contains the right date/time so to format the string,
            // use the standard formatting methods of the DateTime object.
            //dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
            return dateTime;
        }
        public string FindPhoneNumberVietNamFromText(string inputText)
        {
            var exp = new Regex(@"0(1\d{9}|9\d{8})", RegexOptions.IgnoreCase);

            var text = inputText.Replace(".", "").Replace(" ", "");

            var matchList = exp.Matches(text).Cast<Match>().Select(m => m.Groups[0].Value).ToArray();
            if (matchList.Length > 0)
            {
                return matchList[0];
            }
            else
            {
                return string.Empty;
            }
        }
        public string msgStatus(int numberHin)
        {
            string msg = "Hiện tại hệ thống đang nâng cấp (Xin vui lòng quay lại sau). ";
            switch (numberHin)
            {
                case 0:
                    msg = "Thực hiện thất bại. ";
                    break;
                case 1:
                    msg = "Thực hiện thành công. ";
                    break;
                case 2:
                    msg = "Định dạng email của bạn không đúng:(email@email.email) ";
                    break;
                case 3:
                    msg = "Định dạng thời gian của bạn không đúng: ";
                    break;
                case 4:
                    msg = "Định dạng số của bạn không đúng: ";
                    break;
                case 5:
                    msg = "Dữ liệu không được trống: ";
                    break;
                case 6:
                    msg = "Đã có trên hệ thống: ";
                    break;
                case 7:
                    msg = "Không tồn tại mã tỉnh/thành phố trên hệ thống: ";
                    break;
                case 8:
                    msg = "Không tồn tại mã quận/huyện trên hệ thống: ";
                    break;
                case 9:
                    msg = "Không tồn tại mã phường xã trên hệ thống: ";
                    break;
                case 10:
                    msg = "Không tồn tại trên hệ thống: ";
                    break;
                case 11:
                    msg = "OrderNumber không tồn tại trên hệ thống: ";
                    break;
                case 12:
                    msg = "Số điện thoại hoặc mật khẩu không đúng: ";
                    break;
                case 13:
                    msg = "Tài khoản hoạc mật khẩu không tồn tại!";
                    break;
            }
            return msg;
        }
        public static string vxrErrorMsg(string codeerror)
        {
            string result = "";
            switch (codeerror)
            {
                case "401": result = "Quá trình xác thực có lỗi!"; break;
                case "3100": result = "Dữ liệu truyền vào không hợp lệ!"; break;
                case "3101": result = "Mã đặt chỗ không hợp lệ!"; break;
                case "3102": result = "Mã giao dịch không hợp lệ!"; break;
                case "3103": result = "Mã công ty không hợp lệ!"; break;
                case "3104": result = "Mã chuyến đi không hợp lệ!"; break;
                case "3105": result = ""; break;
                case "3106": result = ""; break;
                case "3107": result = ""; break;
                case "3108": result = ""; break;
                case "3109": result = ""; break;
                case "3201": result = "Không tìm thấy mã đặt chỗ!"; break;
                case "3202": result = ""; break;
                case "3203": result = ""; break;
                case "3301": result = "Vé đã được thanh toán trước đó!"; break;
                case "3302": result = "Vé đã bị hủy trước đó!"; break;
                case "3303": result = ""; break;
                case "3308": result = ""; break;
                case "3117": result = ""; break;
                case "3118": result = ""; break;
                case "3119": result = ""; break;
                case "3120": result = ""; break;
                case "3317": result = "Mã đặt chỗ đã quá hạn, không thể thanh toán hay hủy vé!"; break;
                case "3318": result = ""; break;
                case "3316": result = ""; break;
                case "3403": result = ""; break;
                case "3121": result = ""; break;
                case "5000": result = "Không có tín hiệu phản hồi, vui lòng thử lại"; break;
                case "3110": result = ""; break;
                case "403": result = ""; break;
                case "3000": result = ""; break;
                case "3001": result = ""; break;
                default: break;
            }
            return result;
        }

        public string staticIcon(int No)
        {
            string msg = "zmdi-label";
            switch (No)
            {
                case 0:
                    msg = "zmdi zmdi-pin";
                    break;
                case 1:
                    msg = "zmdi zmdi-pin";
                    break;
                case 2:
                    msg = "zmdi zmdi-car";
                    break;
                case 3:
                    msg = "zmdi-close";
                    break;
                case 4:
                    msg = "zmdi-alert-triangle";
                    break;
                case 5:
                    msg = "zmdi-sun";
                    break;
                case 8:
                    msg = "zmdi-accounts-add";
                    break;
            }
            return msg;
        }

        public string staticClassIcon(int No)
        {
            string msg = "bg-info";
            switch (No)
            {
                case 0:
                    msg = "bg-blush";
                    break;
                case 1:
                    msg = "bg-blush";
                    break;
                case 2:
                    msg = "bg-green";
                    break;
                case 3:
                    msg = "bg-blush";
                    break;
                case 4:
                    msg = "bg-orange";
                    break;
                case 5:
                    msg = "bg-success";
                    break;
                case 8:
                    msg = "bg-info";
                    break;
            }
            return msg;
        }
        public string staticOrder(string No, int type)
        {
            string msg = "";
            if (type == 1)
            {
                switch (No)
                {
                    case "0":
                        msg = "Không được phép xem hàng!";
                        break;
                    case "1":
                        msg = "Cho khách xem hàng!";
                        break;
                }
                return msg;
            }
            else if (type == 2)
            {

            }
            return msg;
        }
    }
}