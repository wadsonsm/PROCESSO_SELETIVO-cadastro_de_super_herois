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

CREATE TABLE [Herois] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [NomeHeroi] nvarchar(max) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Altura] real NOT NULL,
    [Peso] real NOT NULL,
    CONSTRAINT [PK_Herois] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [SuperPoderes] (
    [Id] int NOT NULL IDENTITY,
    [SuperPoder] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NULL,
    CONSTRAINT [PK_SuperPoderes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [HeroisSuperPoderes] (
    [Id] int NOT NULL IDENTITY,
    [HeroiId] int NOT NULL,
    [SuperPoderId] int NOT NULL,
    CONSTRAINT [PK_HeroisSuperPoderes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HeroisSuperPoderes_Herois_HeroiId] FOREIGN KEY ([HeroiId]) REFERENCES [Herois] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HeroisSuperPoderes_SuperPoderes_SuperPoderId] FOREIGN KEY ([SuperPoderId]) REFERENCES [SuperPoderes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_HeroisSuperPoderes_HeroiId] ON [HeroisSuperPoderes] ([HeroiId]);
GO

CREATE INDEX [IX_HeroisSuperPoderes_SuperPoderId] ON [HeroisSuperPoderes] ([SuperPoderId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231109142255_SuperPowersRelationship', N'5.0.17');
GO

COMMIT;
GO

