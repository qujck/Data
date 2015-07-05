CREATE TABLE [Foundation].[View] (
    [Action] VARCHAR (50)  NOT NULL,
    [Name]   VARCHAR (100) NOT NULL,
    [Entity] VARCHAR (100) NOT NULL,
    [Type]   VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_View] PRIMARY KEY CLUSTERED ([Name] ASC),
    CONSTRAINT [FK_View_ViewType] FOREIGN KEY ([Type]) REFERENCES [Foundation].[ViewType] ([Value]),
    CONSTRAINT [FK_ViewEntity_Entity] FOREIGN KEY ([Entity]) REFERENCES [Foundation].[Entity] ([Name]),
    CONSTRAINT [FK_ViewName_Entity] FOREIGN KEY ([Name]) REFERENCES [Foundation].[Entity] ([Name])
);

