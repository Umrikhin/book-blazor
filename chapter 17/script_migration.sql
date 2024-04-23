IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Regions] (
    [Id] int NOT NULL IDENTITY,
    [Nm] nvarchar(max) NOT NULL,
    [GIBDD] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Houses] (
    [Id] int NOT NULL IDENTITY,
    [Lot] nvarchar(450) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Notes] nvarchar(max) NULL,
    [IsExclusive] bit NOT NULL,
    [IsMortagege] bit NOT NULL,
    [Squeare] float NOT NULL,
    [NumOfRoms] int NOT NULL,
    [Price] float NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [RegionId] int NOT NULL,
    CONSTRAINT [PK_Houses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Houses_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Owners] (
    [Id] int NOT NULL IDENTITY,
    [Fio] nvarchar(max) NOT NULL,
    [StartTitul] datetime2 NOT NULL,
    [TypeTitul] nvarchar(max) NOT NULL,
    [NumTitul] nvarchar(450) NOT NULL,
    [EndTitul] datetime2 NULL,
    [HouseId] int NOT NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Owners_Houses_HouseId] FOREIGN KEY ([HouseId]) REFERENCES [Houses] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'GIBDD', N'Nm') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] ON;
INSERT INTO [Regions] ([Id], [GIBDD], [Nm])
VALUES (1, N'77', N'Москва'),
(2, N'50', N'Московская область'),
(3, N'78', N'Санкт-Петербург');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'GIBDD', N'Nm') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] OFF;
GO

CREATE UNIQUE INDEX [IX_Houses_Lot] ON [Houses] ([Lot]);
GO

CREATE INDEX [IX_Houses_RegionId] ON [Houses] ([RegionId]);
GO

CREATE INDEX [IX_Owners_HouseId] ON [Owners] ([HouseId]);
GO

CREATE UNIQUE INDEX [IX_Owners_NumTitul] ON [Owners] ([NumTitul]);
GO

CREATE UNIQUE INDEX [IX_Regions_GIBDD] ON [Regions] ([GIBDD]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231018081601_AddTableToDatabase', N'7.0.12');
GO

COMMIT;
GO

