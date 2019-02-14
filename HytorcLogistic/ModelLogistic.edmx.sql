
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/13/2019 22:53:23
-- Generated from EDMX file: C:\Users\Software02\Documents\Visual Studio 2015\Projects\hytorcLogistic\HytorcLogistic\ModelLogistic.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [suffix] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClientsSet'
CREATE TABLE [dbo].[ClientsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [companyName] nvarchar(max)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [ext] nvarchar(max)  NOT NULL,
    [nameContact] nvarchar(max)  NOT NULL,
    [department] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [workCenter] nvarchar(max)  NOT NULL,
    [UsersId] int  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [credit_term] int  NOT NULL
);
GO

-- Creating table 'demoYassistanceSet'
CREATE TABLE [dbo].[demoYassistanceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [demo] bit  NOT NULL,
    [assistance] bit  NOT NULL,
    [workCenter] nvarchar(max)  NOT NULL,
    [dateStart] datetime  NOT NULL,
    [dateEnd] datetime  NOT NULL,
    [aplication] nvarchar(max)  NOT NULL,
    [toolsUsed] nvarchar(max)  NOT NULL,
    [Clients_Id] int  NOT NULL
);
GO

-- Creating table 'InvoicesSet'
CREATE TABLE [dbo].[InvoicesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [bills_num] nvarchar(max)  NOT NULL,
    [delivery_time] datetime  NOT NULL,
    [contract_num] nvarchar(max)  NOT NULL,
    [invoice_num] nvarchar(max)  NOT NULL,
    [creation_date] datetime  NOT NULL,
    [total_without_taxes] float  NOT NULL,
    [total_with_taxes] float  NOT NULL,
    [comments] nvarchar(max)  NOT NULL,
    [payment_status] nvarchar(max)  NOT NULL,
    [commission_status] nvarchar(max)  NOT NULL,
    [date_portal] datetime  NOT NULL,
    [ClientsId] int  NOT NULL
);
GO

-- Creating table 'VisitsSet'
CREATE TABLE [dbo].[VisitsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientsId] int  NOT NULL,
    [date] datetime  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [phone_number] nvarchar(max)  NOT NULL,
    [reason] nvarchar(max)  NOT NULL,
    [comments] nvarchar(max)  NOT NULL,
    [time_arrival] nvarchar(max)  NOT NULL,
    [effective_time] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientsSet'
ALTER TABLE [dbo].[ClientsSet]
ADD CONSTRAINT [PK_ClientsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'demoYassistanceSet'
ALTER TABLE [dbo].[demoYassistanceSet]
ADD CONSTRAINT [PK_demoYassistanceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvoicesSet'
ALTER TABLE [dbo].[InvoicesSet]
ADD CONSTRAINT [PK_InvoicesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VisitsSet'
ALTER TABLE [dbo].[VisitsSet]
ADD CONSTRAINT [PK_VisitsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsersId] in table 'ClientsSet'
ALTER TABLE [dbo].[ClientsSet]
ADD CONSTRAINT [FK_ClientsUsers]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[UsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsUsers'
CREATE INDEX [IX_FK_ClientsUsers]
ON [dbo].[ClientsSet]
    ([UsersId]);
GO

-- Creating foreign key on [Clients_Id] in table 'demoYassistanceSet'
ALTER TABLE [dbo].[demoYassistanceSet]
ADD CONSTRAINT [FK_demoYassistanceClients]
    FOREIGN KEY ([Clients_Id])
    REFERENCES [dbo].[ClientsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_demoYassistanceClients'
CREATE INDEX [IX_FK_demoYassistanceClients]
ON [dbo].[demoYassistanceSet]
    ([Clients_Id]);
GO

-- Creating foreign key on [ClientsId] in table 'InvoicesSet'
ALTER TABLE [dbo].[InvoicesSet]
ADD CONSTRAINT [FK_ClientsInvoices]
    FOREIGN KEY ([ClientsId])
    REFERENCES [dbo].[ClientsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsInvoices'
CREATE INDEX [IX_FK_ClientsInvoices]
ON [dbo].[InvoicesSet]
    ([ClientsId]);
GO

-- Creating foreign key on [ClientsId] in table 'VisitsSet'
ALTER TABLE [dbo].[VisitsSet]
ADD CONSTRAINT [FK_ClientsVisits]
    FOREIGN KEY ([ClientsId])
    REFERENCES [dbo].[ClientsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsVisits'
CREATE INDEX [IX_FK_ClientsVisits]
ON [dbo].[VisitsSet]
    ([ClientsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------