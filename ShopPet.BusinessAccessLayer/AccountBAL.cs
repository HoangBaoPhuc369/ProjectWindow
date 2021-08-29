using ShopPet.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.BusinessAccessLayer
{
    public class AccountBAL
    {
        private readonly AccountDAL _accountDAL;

        public AccountBAL()
        {
            _accountDAL = new AccountDAL();
        }

        public bool CheckLogin(string username, string password, out string error)
        {
            //Mã hóa mật khẩu trước khi kiểm tra
            return _accountDAL.CheckLogin(username, MD5Hash(password), out error);
        }

        public bool CheckEmployeeLogin(string username, string password, out string error)
        {
            //Mã hóa mật khẩu trước khi kiểm tra
            return _accountDAL.CheckEmployeeLogin(username, MD5Hash(password), out error);
        }
        public bool CheckPermission(string username, string password, out string error)
        {
            //Mã hóa mật khẩu trước khi kiểm tra
            return _accountDAL.CheckPermission(username, MD5Hash(password), out error);
        }
        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
