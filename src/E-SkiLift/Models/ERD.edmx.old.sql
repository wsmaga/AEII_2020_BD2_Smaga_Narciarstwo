
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2020 19:29:26
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [UserType] varchar(32)  NOT NULL
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
    [EndDate] datetime  NOT NULL,
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
    [BeginHour] time  NOT NULL,
    [EndHour] time  NOT NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL
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