using System.Security.Cryptography;
using System.Text;

namespace do_an_nhom_15.Utilities
{
    public class Function
    {
        public static int _AdminId = 0;
        public static string _Username = string.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        public static string _FullName = string.Empty;
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
        //// Hàm MD5
        //public static string MD5Hash(string text)
        //{
        //    using (MD5 md5 = new MD5CryptoServiceProvider())
        //    {
        //        byte[] hashBytes = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
        //        StringBuilder strBuilder = new StringBuilder();
        //        for (int i = 0; i < hashBytes.Length; i++)
        //        {
        //            strBuilder.Append(hashBytes[i].ToString("x2"));
        //        }
        //        return strBuilder.ToString();
        //    }
        //}

        //// Hàm hash mật khẩu MD5
        //public static string MD5Password(string? text)
        //{
        //    if (string.IsNullOrEmpty(text)) return string.Empty;

        //    string str = MD5Hash(text);
        //    for (int i = 0; i < 5; i++) // Chạy 5 vòng lặp
        //    {
        //        str = MD5Hash(str + "_" + str);
        //    }
        //    return str;
        //}
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._Username) || string.IsNullOrEmpty(Function._Username) || (Function._AdminId <= 0))
                return false;
            return true;
        }
    }
}
