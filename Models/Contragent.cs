using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// БД таблица "Контрагент"
    /// </summary>
    public class Contragent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Страна регистрации
        /// </summary>
        public string Country { get; set; }


        public string GenDirector { get; set; }

        public string Phone { get; set; }

        public string Adres { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
