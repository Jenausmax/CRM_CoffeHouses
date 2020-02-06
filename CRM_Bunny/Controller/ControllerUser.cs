using CRM_Bunny.Core;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CRM_Bunny.Controller
{
    public class ControllerUser
    {
        //private CrmContext db = new CrmContext();
        /// <summary>
        /// Коллекция пользователей.
        /// </summary>
        private static List<User> users;
        /// <summary>
        /// Флаг роли. true-админ, false-пользователь.
        /// </summary>
        private static bool _flag;
        /// <summary>
        /// Активный пользователь.
        /// </summary>
        private static User User { get; set; }

        public ControllerUser()
        {

            users = Controller.controller.GetUsers() as List<User>;
            
            //foreach(var us in db.Users)
            //{
            //    users.Add(us);
            //}

        }

        /// <summary>
        /// Поиск и установка активного пользователя.
        /// </summary>
        /// <param name="name">Логин.</param>
        /// <returns>true-пользователь найден, false-пользователь не найден.</returns>
        public bool SearchUser(string name)
        {
            var user = Search(name);
            var result = false;

            if(user != null)
            {
                result = true;
                SetUser(user);
            }
            return result;
        }

        private User Search(string name)
        {
            User user = null;
            if (users != null)
            {
                var user2 = users.Find(x => x.Name == name);
                if (user2 != null)
                {
                    user = user2;
                }
            }
            return user;
        }

        private void SetUser(User name)
        {
            if (name != null)
            {
                User = name;
            }
        }

        /// <summary>
        /// Возвращает значение _flag
        /// </summary>
        /// <returns></returns>
        public bool GetFlag()
        {
            var result = false;
            if(User != null)
            {
                result = User.Role;
            }
            return result;
        }

        /// <summary>
        /// Проверка пароля активного пользователя.
        /// </summary>
        /// <param name="password">Пароль.</param>
        /// <returns>true-пароль верен, false-пароль не верен.</returns>
        public bool PasswordControl(string password)
        {
            var hashPass = GetHashString(password);
            var result = false;
            var pass = "";
            if (User != null)
            {
                pass = User.Password;
            }

            if(pass == hashPass)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Хеш для пароля.
        /// </summary>
        /// <param name="s">Строка для хеширования.</param>
        /// <returns>Хешированная строка.</returns>
        private string GetHashString(string s)
        {
           
            byte[] bytes = Encoding.Unicode.GetBytes(s);    
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();         
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

    }
}
