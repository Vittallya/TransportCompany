using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// БД таблциа "Пользователь"
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public UserGroup UserGroup { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }


    public enum UserGroup
    {
        Manager, Driver, Contragent
    }
}
