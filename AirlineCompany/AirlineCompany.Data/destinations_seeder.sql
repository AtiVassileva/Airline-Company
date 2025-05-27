USE AirlineCompany;

INSERT INTO [21180083].Destinations (Id, CityName, CountryName, AirportName, CreatedOn, LastModifiedOn)
VALUES
-- Балкани (15)
(NEWID(), N'София', N'България', N'Летище София', GETDATE(), GETDATE()),
(NEWID(), N'Варна', N'България', N'Летище Варна', GETDATE(), GETDATE()),
(NEWID(), N'Бургас', N'България', N'Летище Бургас', GETDATE(), GETDATE()),
(NEWID(), N'Пловдив', N'България', N'Летище Пловдив', GETDATE(), GETDATE()),
(NEWID(), N'Скопие', N'Северна Македония', N'Летище Скопие', GETDATE(), GETDATE()),
(NEWID(), N'Атина', N'Гърция', N'Елефтериос Венизелос', GETDATE(), GETDATE()),
(NEWID(), N'Солун', N'Гърция', N'Македония Интернешънъл', GETDATE(), GETDATE()),
(NEWID(), N'Белград', N'Сърбия', N'Никола Тесла', GETDATE(), GETDATE()),
(NEWID(), N'Загреб', N'Хърватия', N'Франьо Туджман', GETDATE(), GETDATE()),
(NEWID(), N'Подгорица', N'Черна гора', N'Летище Подгорица', GETDATE(), GETDATE()),
(NEWID(), N'Тирана', N'Албания', N'Майка Тереза', GETDATE(), GETDATE()),
(NEWID(), N'Букурещ', N'Румъния', N'Отопени', GETDATE(), GETDATE()),
(NEWID(), N'Клуж', N'Румъния', N'Аеропорт Аврам Янку', GETDATE(), GETDATE()),
(NEWID(), N'Сараево', N'Босна и Херцеговина', N'Летище Сараево', GETDATE(), GETDATE()),
(NEWID(), N'Любляна', N'Словения', N'Йоже Пучник', GETDATE(), GETDATE()),

-- Западна Европа (20)
(NEWID(), N'Берлин', N'Германия', N'Берлин Бранденбург', GETDATE(), GETDATE()),
(NEWID(), N'Франкфурт', N'Германия', N'Франкфурт Ам Майн', GETDATE(), GETDATE()),
(NEWID(), N'Мюнхен', N'Германия', N'Франц Йозеф Щраус', GETDATE(), GETDATE()),
(NEWID(), N'Париж', N'Франция', N'Шарл де Гол', GETDATE(), GETDATE()),
(NEWID(), N'Лион', N'Франция', N'Сент Екзюпери', GETDATE(), GETDATE()),
(NEWID(), N'Амстердам', N'Нидерландия', N'Схипхол', GETDATE(), GETDATE()),
(NEWID(), N'Брюксел', N'Белгия', N'Брюксел Завентем', GETDATE(), GETDATE()),
(NEWID(), N'Виена', N'Австрия', N'Летище Виена', GETDATE(), GETDATE()),
(NEWID(), N'Цюрих', N'Швейцария', N'Летище Цюрих', GETDATE(), GETDATE()),
(NEWID(), N'Женева', N'Швейцария', N'Летище Женева', GETDATE(), GETDATE()),
(NEWID(), N'Мадрид', N'Испания', N'Барахас', GETDATE(), GETDATE()),
(NEWID(), N'Барселона', N'Испания', N'Ел Прат', GETDATE(), GETDATE()),
(NEWID(), N'Рим', N'Италия', N'Фиумичино', GETDATE(), GETDATE()),
(NEWID(), N'Милано', N'Италия', N'Малпенса', GETDATE(), GETDATE()),
(NEWID(), N'Копенхаген', N'Дания', N'Каструп', GETDATE(), GETDATE()),
(NEWID(), N'Осло', N'Норвегия', N'Гардемуен', GETDATE(), GETDATE()),
(NEWID(), N'Хелзинки', N'Финландия', N'Вантаа', GETDATE(), GETDATE()),
(NEWID(), N'Стокхолм', N'Швеция', N'Арланда', GETDATE(), GETDATE()),
(NEWID(), N'Дъблин', N'Ирландия', N'Дъблин Интернешънъл', GETDATE(), GETDATE()),
(NEWID(), N'Лондон', N'Обединено кралство', N'Хийтроу', GETDATE(), GETDATE()),

-- САЩ (10)
(NEWID(), N'Ню Йорк', N'САЩ', N'Джон Ф. Кенеди', GETDATE(), GETDATE()),
(NEWID(), N'Чикаго', N'САЩ', N'О''Хеър', GETDATE(), GETDATE()),
(NEWID(), N'Лос Анджелис', N'САЩ', N'ЛАКС', GETDATE(), GETDATE()),
(NEWID(), N'Маями', N'САЩ', N'Маями Интернешънъл', GETDATE(), GETDATE()),
(NEWID(), N'Атланта', N'САЩ', N'Хартсфийлд-Джаксън', GETDATE(), GETDATE()),
(NEWID(), N'Сан Франциско', N'САЩ', N'Сан Франциско Интернешънъл', GETDATE(), GETDATE()),
(NEWID(), N'Далас', N'САЩ', N'Далас-Форт Уърт', GETDATE(), GETDATE()),
(NEWID(), N'Вашингтон', N'САЩ', N'Дълес Интернешънъл', GETDATE(), GETDATE()),
(NEWID(), N'Бостън', N'САЩ', N'Логан Интернешънъл', GETDATE(), GETDATE()),
(NEWID(), N'Сиатъл', N'САЩ', N'Сиатъл-Такома', GETDATE(), GETDATE()),

-- Останали (5)
(NEWID(), N'Дубай', N'Обединени арабски емирства', N'Дубай Интернешънъл', GETDATE(), GETDATE()),
(NEWID(), N'Токио', N'Япония', N'Нарита', GETDATE(), GETDATE()),
(NEWID(), N'Сеул', N'Южна Корея', N'Инчон', GETDATE(), GETDATE()),
(NEWID(), N'Хонконг', N'Китай', N'Чек Лап Кок', GETDATE(), GETDATE()),
(NEWID(), N'Сингапур', N'Сингапур', N'Чанги', GETDATE(), GETDATE());