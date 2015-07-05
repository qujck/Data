CREATE TABLE [Foundation].[Entity] (
    [Name]        VARCHAR (100) NOT NULL,
    [Reference]   VARCHAR (100) NULL,
    [Type]        VARCHAR (100) NOT NULL,
    [Roles]       VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Entity_1] PRIMARY KEY CLUSTERED ([Name] ASC),
    CONSTRAINT [FK_Entity_EntityType] FOREIGN KEY ([Type]) REFERENCES [Foundation].[EntityType] ([Value])
);

