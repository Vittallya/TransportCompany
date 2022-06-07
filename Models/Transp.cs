using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// БД таблица "Транспортные средства"
    /// </summary>
    public class Transp
    {
        public int Id { get; set; }

        /// <summary>
        /// Марка
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// Номер авто
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Грузоподъемность
        /// </summary>
        public float? LoadCapasity { get; set; }

        /// <summary>
        /// Характеристика
        /// </summary>
        public string Characteristics { get; set; }

        /// <summary>
        /// Назначение ТС (ЕСЛИ IsSpecial = false!)
        /// </summary>
        public TransportPurpose TransportPurpose { get; set; }

        /// <summary>
        /// Транспорт является спецтехникой
        /// </summary>
        public bool IsSpecial { get; set; }
        /// <summary>
        /// Назначение спецтехники (ЕСЛИ IsSpecial = true!)
        /// </summary>
        public TransportSpecialPurpose TransportSpecialPurpose { get; set; }

        /// <summary>
        /// Стоимость руб/ч
        /// </summary>
        public decimal Cost { get; set; }


        /// <summary>
        /// Оплата водителю руб/ч
        /// </summary>
        public decimal PayToDriver { get; set; }

        public bool IsFree { get; set; }

    }

    public static class PurposeNames
    {
        public static readonly Dictionary<TransportPurpose, string> Purposes = new Dictionary<TransportPurpose, string>
        {
            { TransportPurpose.A, "Перевозка крупнотоннажных грузов" },
            { TransportPurpose.B, "Перевозка сыпучих или иных грузов" },
            { TransportPurpose.C, "Перевозка негабаритного груза" },
            { TransportPurpose.E, "Погрузка" },
            { TransportPurpose.F, "Перевозка, выгрузка грузов" },
            { TransportPurpose.G, "Перевозка грузов, не требующих соблюдения строгого температурного режима" },
            { TransportPurpose.I, "Перевозка различных грузов" },
            { TransportPurpose.J, "перевозка легковесных грузов" }
        };
        public static readonly Dictionary<TransportSpecialPurpose, string> PurposesSpec = new Dictionary<TransportSpecialPurpose, string>
        {
            { TransportSpecialPurpose.a, "Выполнение погрузочно-разгрузочных работ" },
            { TransportSpecialPurpose.b, "Проведение монтажных или демонтажных работ на высоте" },
            { TransportSpecialPurpose.c, "Землеройные работы" },
            { TransportSpecialPurpose.d, "Разработка и погрузка грунта" },
            { TransportSpecialPurpose.e, "Заглубление свайных элементов в землю и обработка материалов высокой прочности" },
            { TransportSpecialPurpose.f, "Бурение в грунте неглубоких ям, скважин и отверстий цилиндрической формы" },
            { TransportSpecialPurpose.g, "Выполнение ремонтностроительных работ" },
            { TransportSpecialPurpose.i, "Планировка и профилирование земляного полотна" },
            { TransportSpecialPurpose.j, "Рытье траншей прямоугольного профиля" },
            { TransportSpecialPurpose.k, "Очистка улиц, дорог, тротуаров и других участков от мусора, снега, песчаных наносов" },
            { TransportSpecialPurpose.l, "Сжатие и подача газов под давлением" },
            { TransportSpecialPurpose.m, "Укладка асфальта, уплотнение земляного полотна и бетона, Укатка рыхлого грунта, подготовка поверхности почвы перед обустройством дорожного покрытия" },
            { TransportSpecialPurpose.q, "Перемешивание и транспортировка бетона и других смесей" },
            { TransportSpecialPurpose.r, "Прием свежеприготовленной бетонной смеси в бункер от специализированных бетонотранспортных средств" },
            { TransportSpecialPurpose.s, "Перемещение грузов" }
        };

    }

    /// <summary>
    /// Назначение обычного ТС
    /// </summary>
    public enum TransportPurpose
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R
    }

    /// <summary>
    /// Назначение спецтехники
    /// </summary>
    public enum TransportSpecialPurpose
    {
        a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t
    }
}
