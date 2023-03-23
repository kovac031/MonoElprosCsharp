CREATE TABLE [dbo].[Film] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Title]    VARCHAR (50)     NOT NULL,
    [Release]  INT              NOT NULL,
    [Genre]    VARCHAR (50)     NOT NULL,
    [Duration] INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

