
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/03/2014 18:42:47
-- Generated from EDMX file: C:\Users\Jonatas\SkyDrive\Projetos\DotNet\Projects\APPLICATION_BASE\BASE_APP\MODEL_DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ApplicationDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[APP_MODULES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[APP_MODULES];
GO
IF OBJECT_ID(N'[dbo].[APP_PROFILE_CLASS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[APP_PROFILE_CLASS];
GO
IF OBJECT_ID(N'[dbo].[APP_PROFILES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[APP_PROFILES];
GO
IF OBJECT_ID(N'[dbo].[APP_USERS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[APP_USERS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'APP_MODULES'
CREATE TABLE [dbo].[APP_MODULES] (
    [ModuleID] int IDENTITY(1,1) NOT NULL,
    [ModuleDescription] varchar(50)  NULL,
    [ParentModuleID] int  NULL,
    [AssociateForm] varchar(50)  NULL,
    [Activated] varchar(1)  NULL,
    [CloseForm] varchar(1)  NULL,
    [ParentModuleDescription] varchar(50)  NULL,
    [Ordem] int  NULL,
    [ImageIndex] int  NOT NULL
);
GO

-- Creating table 'APP_PROFILE_CLASS'
CREATE TABLE [dbo].[APP_PROFILE_CLASS] (
    [ClassID] int IDENTITY(1,1) NOT NULL,
    [ProfileID] int  NOT NULL,
    [ModuleID] int  NOT NULL
);
GO

-- Creating table 'APP_PROFILES'
CREATE TABLE [dbo].[APP_PROFILES] (
    [ProfileID] int IDENTITY(1,1) NOT NULL,
    [ProfileDescription] varchar(50)  NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'APP_USERS'
CREATE TABLE [dbo].[APP_USERS] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [UserDescription] varchar(100)  NULL,
    [Password] varchar(250)  NULL,
    [ProfileID] int  NOT NULL,
    [CreationDate] datetime  NULL,
    [CreatedBy] int  NULL,
    [Activated] varchar(1)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ModuleID] in table 'APP_MODULES'
ALTER TABLE [dbo].[APP_MODULES]
ADD CONSTRAINT [PK_APP_MODULES]
    PRIMARY KEY CLUSTERED ([ModuleID] ASC);
GO

-- Creating primary key on [ClassID] in table 'APP_PROFILE_CLASS'
ALTER TABLE [dbo].[APP_PROFILE_CLASS]
ADD CONSTRAINT [PK_APP_PROFILE_CLASS]
    PRIMARY KEY CLUSTERED ([ClassID] ASC);
GO

-- Creating primary key on [ProfileID] in table 'APP_PROFILES'
ALTER TABLE [dbo].[APP_PROFILES]
ADD CONSTRAINT [PK_APP_PROFILES]
    PRIMARY KEY CLUSTERED ([ProfileID] ASC);
GO

-- Creating primary key on [UserID] in table 'APP_USERS'
ALTER TABLE [dbo].[APP_USERS]
ADD CONSTRAINT [PK_APP_USERS]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------