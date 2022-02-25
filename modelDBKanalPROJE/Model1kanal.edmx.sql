
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/03/2022 19:39:17
-- Generated from EDMX file: C:\Users\STUDENT1\source\repos\entitty\modelDBKanalPROJE\Model1kanal.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [kanalDatamız];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_yayinkanal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[kanalSet] DROP CONSTRAINT [FK_yayinkanal];
GO
IF OBJECT_ID(N'[dbo].[FK_yayinsorumlu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sorumluSet] DROP CONSTRAINT [FK_yayinsorumlu];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[kanalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[kanalSet];
GO
IF OBJECT_ID(N'[dbo].[sorumluSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sorumluSet];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[yayinSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[yayinSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'kanalSet'
CREATE TABLE [dbo].[kanalSet] (
    [KanaIno] int IDENTITY(1,1) NOT NULL,
    [kanaladi] nvarchar(max)  NOT NULL,
    [ciro] int  NOT NULL,
    [adres] nvarchar(max)  NOT NULL,
    [reyting] int  NOT NULL,
    [yayinId] int  NOT NULL
);
GO

-- Creating table 'yayinSet'
CREATE TABLE [dbo].[yayinSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [yayinadi] nvarchar(max)  NOT NULL,
    [yayıntarih] datetime  NOT NULL,
    [reyting] int  NOT NULL,
    [kanalKanaIno] int  NOT NULL
);
GO

-- Creating table 'sorumluSet'
CREATE TABLE [dbo].[sorumluSet] (
    [sorumluno] int IDENTITY(1,1) NOT NULL,
    [asoyad] nvarchar(max)  NOT NULL,
    [gorevi] nvarchar(max)  NOT NULL,
    [maas] int  NOT NULL,
    [gorevsayisi] int  NOT NULL,
    [yayinId] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KanaIno] in table 'kanalSet'
ALTER TABLE [dbo].[kanalSet]
ADD CONSTRAINT [PK_kanalSet]
    PRIMARY KEY CLUSTERED ([KanaIno] ASC);
GO

-- Creating primary key on [Id] in table 'yayinSet'
ALTER TABLE [dbo].[yayinSet]
ADD CONSTRAINT [PK_yayinSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [sorumluno] in table 'sorumluSet'
ALTER TABLE [dbo].[sorumluSet]
ADD CONSTRAINT [PK_sorumluSet]
    PRIMARY KEY CLUSTERED ([sorumluno] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [yayinId] in table 'sorumluSet'
ALTER TABLE [dbo].[sorumluSet]
ADD CONSTRAINT [FK_yayinsorumlu]
    FOREIGN KEY ([yayinId])
    REFERENCES [dbo].[yayinSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_yayinsorumlu'
CREATE INDEX [IX_FK_yayinsorumlu]
ON [dbo].[sorumluSet]
    ([yayinId]);
GO

-- Creating foreign key on [kanalKanaIno] in table 'yayinSet'
ALTER TABLE [dbo].[yayinSet]
ADD CONSTRAINT [FK_kanalyayin]
    FOREIGN KEY ([kanalKanaIno])
    REFERENCES [dbo].[kanalSet]
        ([KanaIno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_kanalyayin'
CREATE INDEX [IX_FK_kanalyayin]
ON [dbo].[yayinSet]
    ([kanalKanaIno]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------