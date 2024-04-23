CREATE TABLE [dbo].[Newbuildings](
Id int IDENTITY(1,1) primary key,
NameHouse nvarchar(50),
TypeHouse nvarchar(50),
[Address] nvarchar(250),
YearOfDelivery int,
NumOfApart int,
NumOfStoreys int,
IsParking bit
)
GO

insert into Newbuildings values (N'ЖК «Вместе»', N'Монолитно-кирпичный', N'Москва,  Лётная улица, 95Б', 2026, 215, 16, convert(bit, 1))
insert into Newbuildings values (N'ЖК «Союз»', N'Монолитный', N'Москва, Ленинградский проспект, 8', 2027, 306, 25, convert(bit, 1))
insert into Newbuildings values (N'ЖК «5 элемент»', N'Панельный', N'Москва, Дербеневская улица, 56', 2025, 1050, 22, convert(bit, 0))
insert into Newbuildings values (N'ЖК «Гринсайд»', N'Монолитно-кирпичный', N'Москва, Сельскохозяйственная улица, 315', 2025, 123, 25, convert(bit, 1))
insert into Newbuildings values (N'ЖК «Свобода»', N'Монолитно-кирпичный', N'Москва, улица Пресненский Вал, 12', 2028, 400, 24, convert(bit, 1))
GO