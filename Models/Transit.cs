using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

    public enum TransitStatus
    {
        Created, GivenToDriver, Executing, Delivered
    }

    /// <summary>
    /// БД таблица "Перевозки"
    /// </summary>
    public class Transit
    {
        public int Id { get; set; }

        public string DogorNum { get; set; }
        public string Comment { get; set; }

        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime DateCreat { get; set; }

        /// <summary>
        /// Дата отправки груза
        /// </summary>
        public DateTime DateSend { get; set; }


        /// <summary>
        /// Адрес отправителя
        /// </summary>
        public string SenderAdress { get; set; }

        /// <summary>
        /// Адрес получателя
        /// </summary>
        public string ReciverAdress { get; set; }

        /// <summary>
        /// ФИО получателя
        /// </summary>
        public string ReciverFio { get; set; }
        /// <summary>
        /// Номер телефона получателя
        /// </summary>
        public string ReciverPhone { get; set; }
        /// <summary>
        /// Дата получения груза
        /// </summary>
        public DateTime DateGetGruz { get; set; }

        public TransitStatus Status { get; set; }

        public int ContragentId { get; set; }
        public int TranspId { get; set; }
        public int DriverId { get; set; }
        public int RouteId { get; set; }
        public int GruzId { get; set; }

        public virtual Contragent Contragent { get; set; }
        public virtual Transp Transp { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Route Route { get; set; }
        public virtual Gruz Gruz { get; set; }
    }
}
