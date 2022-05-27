﻿USE TranspDb;
GO

INSERT INTO [Transps] VALUES
(N'Борт длинномер', N'',12, N'Длина борта 6-9 м ', 0, 0, 0, 1416, 1200, 1),
(N'Самосвал Камаз', N'',5, N'', 1, 0, 0, 1471, 1250, 1),
(N'Самосвал Зил, Газ', N'', 7, N'', 1, 0, 0, 862, 700, 1),
(N'Самосвал', N'', 20, N'', 1, 0, 0, 1652, 1400, 1),
(N'Самосвал', N'', 25, N'', 1, 0, 0, 1770, 1500, 1),
(N'Самосвал', N'', 30, N'', 1, 0, 0, 2124, 1800, 1),
(N'Трал', N'',25, N'Низкорамный ', 2, 0, 0, 2950, 2500, 1),
(N'Трал', N'',45, N'Низкорамный ', 2, 0, 0, 3540, 3000, 1),

(N'Фургон', N'',3, N'', 6, 0, 0, 767, 650, 1),
(N'Манипулятор', N'',5, N'Борт длинной 5-6 метров', 5, 0, 0, 1471, 1250, 1),
(N'Манипулятор', N'',12, N'Борт длиной 6-7 метров', 5, 0, 0, 1471, 1250, 1),
(N'Манипулятор', N'',20, N'Борт длиной 8-9,5 метров', 5, 0, 0, 1471, 1250, 1),
(N'Фургон', N'',5, N'', 6, 0, 0, 885, 750, 1),
(N'Фургон', N'',10, N'', 6, 0, 0, 1416, 1200, 1),
(N'Фура', N'',20, N'', 8, 0, 0, 1652, 1400, 1),

(N'Автокран', N'',5, N'Стрела 22 м', 0, 1, 0, 1465, 1250, 1),
(N'Автокран', N'',14, N'Стрела 14 м', 0, 1, 0, 1647, 1400, 1),
(N'Автокран', N'',16, N'Стрела 18 м', 0, 1, 0, 1770, 1500, 1),
(N'Автокран', N'',20, N'Стрела 21 м', 0, 1, 0, 2000, 1700, 1),
(N'Автокран', N'',25, N'Стрела 21 м', 0, 1, 0, 2124, 1800, 1),

(N'Автовышка', N'',0, N'Высота подъема до 15 м', 0, 1, 1, 941, 800, 1),
(N'Автовышка', N'',0, N'Высота подъема до 17 м', 0, 1, 1, 1118, 950, 1),
(N'Автовышка', N'',0, N'Высота подъема до 21-22 м', 0, 1, 1, 1294, 1100, 1),
(N'Автовышка', N'',0, N'Высота подъема до 25-26 м', 0, 1, 1, 1647, 1400, 1),
(N'Автовышка', N'',0, N'Высота подъема до 30 м', 0, 1, 1, 2000, 1700, 1),

(N'Mini фронтальный погрузчик (импортный)', N'',0, N'Объем 0,8 м - 1 м3', 0, 1, 2, 1411, 1200, 1),
(N'Фронтальный погрузчик (МТЗ - «Копай Нога»)', N'',0, N'Объем 0,8 м - 1 м3', 0, 1, 2, 941, 800, 1),

(N'Экскаватор-погрузчик (Terex, New holland, Komatsu) ', N'',0, N'Объем погрузчика 1,2 м3, объем ковша от 0,25 до 0,43 м3 ', 0, 1, 3, 1529, 1300, 1),
(N'Mini экскаватор', N'',0, N'Oбъем ковша 0,3 м 3, глубина копания 3 м', 0, 1, 3, 941, 800, 1),
(N'Экскаватор колесный (импортный)', N'',0, N'объем ковша 0,65 м3, глубина копания 4 м', 0, 1, 3, 1059, 900, 1),
(N'Экскаватор колесный (импортный)', N'',0, N'Объем ковша 0,8-1 м3, глубина копания 6 м', 0, 1, 3, 1412, 1200, 1),
(N'Экскаватор гусеничный', N'',0, N'Объем ковша 1,2 - 1,5 м3, глубина копания до 10 м', 0, 1, 3, 2000, 1700, 1),

(N'Гидромолот', N'',0, N'На базе экскаватора', 0, 1, 4, 2353, 2000, 1),
(N'Гидромолот', N'',0, N'На базе экскаватора', 0, 1, 4, 2941, 2500, 1),

(N'Ямобур', N'',0, N'Диаметр от 500 и выше, глубина от 3х метров', 0, 1, 5, 1176, 1000, 1),
(N'Ямобур', N'',0, N'Диаметр от 500 и выше, глубина от 3х метров ', 0, 1, 5, 1529, 1300, 1),

(N'Ямобур-кран', N'',0, N'Вездеход ', 0, 1, 6, 2235, 1900, 1),

(N'Грейдер', N'',13, N'на базе МТЗ', 0, 1, 8, 941, 800, 1),
(N'Бар', N'',0, N'на базе МТЗ', 0, 1, 9, 1059, 900, 1),
(N'Щетка', N'',0, N'', 0, 1, 10, 1176, 1000, 1),
(N'Бульдозер', N'',0, N'T-130, T-170', 0, 1, 2, 1176, 1000, 1),
(N'Ассенизатор', N'',0, N'10,0 куб. шланг 2550 м', 0, 1, 10, 941, 800, 1),
(N'Компрессор (дизель)', N'',0, N'2 молотка', 0, 1, 10, 1529, 1300, 1),
(N'Компрессор (дизель)', N'',0, N'4 молотка', 0, 1, 10, 1882, 1600, 1),

(N'Виброкаток', N'',0, N'3-4 тонны', 0, 1, 12, 1647, 1400, 1),
(N'Виброкаток', N'',0, N'7-10 тонн', 0, 1, 12, 2000, 1700, 1),
(N'Виброкаток', N'',0, N'13 тонн', 0, 1, 12, 2353, 2000, 1),
(N'Виброкаток', N'',0, N'18 тонн', 0, 1, 12, 2824, 2400, 1),

(N'Миксер', N'',0, N'Объем 2,5 м3', 0, 1, 16, 2706, 2300, 1),
(N'Миксер', N'',0, N'Объем 5 м3', 0, 1, 16, 2800, 2600, 1),
(N'Бетононасос', N'',0, N'Высота подъема 24- 26 м', 0, 1, 17, 3529, 3000, 1),
(N'Бетононасос', N'',0, N'Высота подъема 30- 38 м', 0, 1, 17, 4118, 3500, 1);


INSERT INTO [Routes] VALUES
(N'Пермь — Новосибирск',1440,20),
(N'Пермь — Бердск',2009,25),
(N'Пермь — Кемерово',2289,28),
(N'Пермь — Новокузнецк',1440,20),
(N'Пермь — Барнаул',2200,28),
(N'Пермь — Бийск',2329,29),
(N'Пермь — Абакан',2861,50),
(N'Пермь — Омск',1324,17),
(N'Пермь — Тюмень',689,10),
(N'Пермь — Красноярск',2750,35),
(N'Пермь — Сургут',1467,19),
(N'Пермь — Нижневартовск',1682,21),
(N'Пермь — Ханты-Мансийск',1175,15),
(N'Пермь — Ноябрьск',1774,22),
(N'Пермь — Нижний Новгород',970,15),
(N'Пермь — Санкт-Петербург',1869,25),
(N'Пермь — Москва',1440,19),
(N'Пермь — Екатеринбург',362,5),
(N'Пермь — Челябинск',569,7),
(N'Пермь — Ижевск',277,4);