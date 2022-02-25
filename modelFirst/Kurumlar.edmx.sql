
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/30/2021 19:13:44
-- Generated from EDMX file: C:\Users\STUDENT1\source\repos\entitty\modelFirst\Kurumlar.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [haskurum];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KurumtableHizmet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HizmetSet] DROP CONSTRAINT [FK_KurumtableHizmet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[KurumtableSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KurumtableSet];
GO
IF OBJECT_ID(N'[dbo].[HizmetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HizmetSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KurumtableSet'
CREATE TABLE [dbo].[KurumtableSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KurumAdi] nvarchar(max)  NOT NULL,
    [CalisanSayisi] int  NOT NULL,
    [HizmetAlani] nvarchar(max)  NOT NULL,
    [Seltör] nvarchar(max)  NOT NULL,
    [yıl] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HizmetSet'
CREATE TABLE [dbo].[HizmetSet] (
    [HizmetNo] int IDENTITY(1,1) NOT NULL,
    [HizmetAdi] nvarchar(max)  NOT NULL,
    [Durum] nvarchar(max)  NOT NULL,
    [KurumtableId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'KurumtableSet'
ALTER TABLE [dbo].[KurumtableSet]
ADD CONSTRAINT [PK_KurumtableSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [HizmetNo] in table 'HizmetSet'
ALTER TABLE [dbo].[HizmetSet]
ADD CONSTRAINT [PK_HizmetSet]
    PRIMARY KEY CLUSTERED ([HizmetNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KurumtableId] in table 'HizmetSet'
ALTER TABLE [dbo].[HizmetSet]
ADD CONSTRAINT [FK_KurumtableHizmet]
    FOREIGN KEY ([KurumtableId])
    REFERENCES [dbo].[KurumtableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KurumtableHizmet'
CREATE INDEX [IX_FK_KurumtableHizmet]
ON [dbo].[HizmetSet]
    ([KurumtableId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------