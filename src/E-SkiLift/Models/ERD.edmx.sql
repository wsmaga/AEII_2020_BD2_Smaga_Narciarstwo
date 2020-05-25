
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2020 11:42:03
-- Generated from EDMX file: C:\Users\Lenovo\source\repos\AEII_2020_BD2_Smaga_Narciarstwo\src\E-SkiLift\Models\ERD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SkiLiftDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LiftTariffSkiLift]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LiftTariffSet] DROP CONSTRAINT [FK_LiftTariffSkiLift];
GO
IF OBJECT_ID(N'[dbo].[FK_LiftUsageHistorySkiLift]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LiftUsageHistorySet] DROP CONSTRAINT [FK_LiftUsageHistorySkiLift];
GO
IF OBJECT_ID(N'[dbo].[FK_LiftUsageHistoryTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LiftUsageHistorySet] DROP CONSTRAINT [FK_LiftUsageHistoryTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_SkiLiftScheduleSkiLift]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkiLiftScheduleSet] DROP CONSTRAINT [FK_SkiLiftScheduleSkiLift];
GO
IF OBJECT_ID(N'[dbo].[FK_SkiPass_inherits_Ticket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSet_SkiPass] DROP CONSTRAINT [FK_SkiPass_inherits_Ticket];
GO
IF OBJECT_ID(N'[dbo].[FK_PointTicket_inherits_Ticket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSet_PointTicket] DROP CONSTRAINT [FK_PointTicket_inherits_Ticket];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TicketSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[TicketTariffSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketTariffSet];
GO
IF OBJECT_ID(N'[dbo].[LiftTariffSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LiftTariffSet];
GO
IF OBJECT_ID(N'[dbo].[SkiLiftSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkiLiftSet];
GO
IF OBJECT_ID(N'[dbo].[SkiLiftScheduleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkiLiftScheduleSet];
GO
IF OBJECT_ID(N'[dbo].[LiftUsageHistorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LiftUsageHistorySet];
GO
IF OBJECT_ID(N'[dbo].[TicketSet_SkiPass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketSet_SkiPass];
GO
IF OBJECT_ID(N'[dbo].[TicketSet_PointTicket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketSet_PointTicket];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TicketSet'
CREATE TABLE [dbo].[TicketSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsValid] bit  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(128)  NULL,
    [UserType] int  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TicketTariffSet'
CREATE TABLE [dbo].[TicketTariffSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [PointPrice] float  NOT NULL,
    [HourPrice] float  NOT NULL
);
GO

-- Creating table 'LiftTariffSet'
CREATE TABLE [dbo].[LiftTariffSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [PointCost] int  NOT NULL,
    [SkiLiftID] int  NOT NULL
);
GO

-- Creating table 'SkiLiftSet'
CREATE TABLE [dbo].[SkiLiftSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsOpen] bit  NOT NULL
);
GO

-- Creating table 'SkiLiftScheduleSet'
CREATE TABLE [dbo].[SkiLiftScheduleSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LiftID] int  NOT NULL,
    [DayOfTheWeek] tinyint  NOT NULL,
    [BeginHour] nvarchar(max)  NOT NULL,
    [EndHour] nvarchar(max)  NOT NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NULL
);
GO

-- Creating table 'LiftUsageHistorySet'
CREATE TABLE [dbo].[LiftUsageHistorySet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TicketID] int  NOT NULL,
    [SkiLiftID] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'TicketSet_SkiPass'
CREATE TABLE [dbo].[TicketSet_SkiPass] (
    [ExpirationTime] datetime  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'TicketSet_PointTicket'
CREATE TABLE [dbo].[TicketSet_PointTicket] (
    [Points] int  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [PK_TicketSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TicketTariffSet'
ALTER TABLE [dbo].[TicketTariffSet]
ADD CONSTRAINT [PK_TicketTariffSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LiftTariffSet'
ALTER TABLE [dbo].[LiftTariffSet]
ADD CONSTRAINT [PK_LiftTariffSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SkiLiftSet'
ALTER TABLE [dbo].[SkiLiftSet]
ADD CONSTRAINT [PK_SkiLiftSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SkiLiftScheduleSet'
ALTER TABLE [dbo].[SkiLiftScheduleSet]
ADD CONSTRAINT [PK_SkiLiftScheduleSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LiftUsageHistorySet'
ALTER TABLE [dbo].[LiftUsageHistorySet]
ADD CONSTRAINT [PK_LiftUsageHistorySet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TicketSet_SkiPass'
ALTER TABLE [dbo].[TicketSet_SkiPass]
ADD CONSTRAINT [PK_TicketSet_SkiPass]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TicketSet_PointTicket'
ALTER TABLE [dbo].[TicketSet_PointTicket]
ADD CONSTRAINT [PK_TicketSet_PointTicket]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SkiLiftID] in table 'LiftTariffSet'
ALTER TABLE [dbo].[LiftTariffSet]
ADD CONSTRAINT [FK_LiftTariffSkiLift]
    FOREIGN KEY ([SkiLiftID])
    REFERENCES [dbo].[SkiLiftSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LiftTariffSkiLift'
CREATE INDEX [IX_FK_LiftTariffSkiLift]
ON [dbo].[LiftTariffSet]
    ([SkiLiftID]);
GO

-- Creating foreign key on [SkiLiftID] in table 'LiftUsageHistorySet'
ALTER TABLE [dbo].[LiftUsageHistorySet]
ADD CONSTRAINT [FK_LiftUsageHistorySkiLift]
    FOREIGN KEY ([SkiLiftID])
    REFERENCES [dbo].[SkiLiftSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LiftUsageHistorySkiLift'
CREATE INDEX [IX_FK_LiftUsageHistorySkiLift]
ON [dbo].[LiftUsageHistorySet]
    ([SkiLiftID]);
GO

-- Creating foreign key on [TicketID] in table 'LiftUsageHistorySet'
ALTER TABLE [dbo].[LiftUsageHistorySet]
ADD CONSTRAINT [FK_LiftUsageHistoryTicket]
    FOREIGN KEY ([TicketID])
    REFERENCES [dbo].[TicketSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LiftUsageHistoryTicket'
CREATE INDEX [IX_FK_LiftUsageHistoryTicket]
ON [dbo].[LiftUsageHistorySet]
    ([TicketID]);
GO

-- Creating foreign key on [LiftID] in table 'SkiLiftScheduleSet'
ALTER TABLE [dbo].[SkiLiftScheduleSet]
ADD CONSTRAINT [FK_SkiLiftScheduleSkiLift]
    FOREIGN KEY ([LiftID])
    REFERENCES [dbo].[SkiLiftSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SkiLiftScheduleSkiLift'
CREATE INDEX [IX_FK_SkiLiftScheduleSkiLift]
ON [dbo].[SkiLiftScheduleSet]
    ([LiftID]);
GO

-- Creating foreign key on [ID] in table 'TicketSet_SkiPass'
ALTER TABLE [dbo].[TicketSet_SkiPass]
ADD CONSTRAINT [FK_SkiPass_inherits_Ticket]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[TicketSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'TicketSet_PointTicket'
ALTER TABLE [dbo].[TicketSet_PointTicket]
ADD CONSTRAINT [FK_PointTicket_inherits_Ticket]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[TicketSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------