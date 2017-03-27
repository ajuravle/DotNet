
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/25/2017 13:40:52
-- Generated from EDMX file: C:\Users\andre\documents\visual studio 2015\Projects\DotNet\DotNet\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DotNet];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActorMovie_Actor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Actor];
GO
IF OBJECT_ID(N'[dbo].[FK_ActorMovie_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_MovieTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_CinemaTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_CinemaTicket];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cinemas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cinemas];
GO
IF OBJECT_ID(N'[dbo].[Movies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movies];
GO
IF OBJECT_ID(N'[dbo].[Actors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actors];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[ActorMovie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActorMovie];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cinemas'
CREATE TABLE [dbo].[Cinemas] (
    [CinemaId] int IDENTITY(1,1) NOT NULL,
    [NrRooms] smallint  NOT NULL,
    [City] nvarchar(30)  NOT NULL,
    [Address] nvarchar(100)  NOT NULL,
    [Name] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [MovieId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(30)  NOT NULL,
    [Genre] nvarchar(30)  NOT NULL,
    [Duration] smallint  NOT NULL,
    [AgeRestriction] smallint  NOT NULL
);
GO

-- Creating table 'Actors'
CREATE TABLE [dbo].[Actors] (
    [ActorId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(30)  NOT NULL,
    [LastName] nvarchar(30)  NOT NULL,
    [BirthDate] datetime  NOT NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [TicketId] int IDENTITY(1,1) NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Price] smallint  NOT NULL,
    [MovieMovieId] int  NOT NULL,
    [CinemaCinemaId] int  NOT NULL
);
GO

-- Creating table 'ActorMovie'
CREATE TABLE [dbo].[ActorMovie] (
    [Actors_ActorId] int  NOT NULL,
    [Movies_MovieId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CinemaId] in table 'Cinemas'
ALTER TABLE [dbo].[Cinemas]
ADD CONSTRAINT [PK_Cinemas]
    PRIMARY KEY CLUSTERED ([CinemaId] ASC);
GO

-- Creating primary key on [MovieId] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([MovieId] ASC);
GO

-- Creating primary key on [ActorId] in table 'Actors'
ALTER TABLE [dbo].[Actors]
ADD CONSTRAINT [PK_Actors]
    PRIMARY KEY CLUSTERED ([ActorId] ASC);
GO

-- Creating primary key on [TicketId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([TicketId] ASC);
GO

-- Creating primary key on [Actors_ActorId], [Movies_MovieId] in table 'ActorMovie'
ALTER TABLE [dbo].[ActorMovie]
ADD CONSTRAINT [PK_ActorMovie]
    PRIMARY KEY CLUSTERED ([Actors_ActorId], [Movies_MovieId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Actors_ActorId] in table 'ActorMovie'
ALTER TABLE [dbo].[ActorMovie]
ADD CONSTRAINT [FK_ActorMovie_Actor]
    FOREIGN KEY ([Actors_ActorId])
    REFERENCES [dbo].[Actors]
        ([ActorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Movies_MovieId] in table 'ActorMovie'
ALTER TABLE [dbo].[ActorMovie]
ADD CONSTRAINT [FK_ActorMovie_Movie]
    FOREIGN KEY ([Movies_MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActorMovie_Movie'
CREATE INDEX [IX_FK_ActorMovie_Movie]
ON [dbo].[ActorMovie]
    ([Movies_MovieId]);
GO

-- Creating foreign key on [MovieMovieId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_MovieTicket]
    FOREIGN KEY ([MovieMovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicket'
CREATE INDEX [IX_FK_MovieTicket]
ON [dbo].[Tickets]
    ([MovieMovieId]);
GO

-- Creating foreign key on [CinemaCinemaId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_CinemaTicket]
    FOREIGN KEY ([CinemaCinemaId])
    REFERENCES [dbo].[Cinemas]
        ([CinemaId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CinemaTicket'
CREATE INDEX [IX_FK_CinemaTicket]
ON [dbo].[Tickets]
    ([CinemaCinemaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------