CREATE TABLE [Foundation].[Sql] (
    [Entity]     VARCHAR (100)  NOT NULL,
    [Query]      VARCHAR (50)   NOT NULL,
    [Type]       VARCHAR (50)   NOT NULL,
    [Statement]  VARCHAR (MAX)  NOT NULL,
    [Parameters] VARCHAR (1024) NULL,
    [Result]     VARCHAR (100)  NOT NULL,
    [ResultType] VARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_Sql] PRIMARY KEY CLUSTERED ([Entity] ASC, [Query] ASC),
    CONSTRAINT [FK_Sql_Entity] FOREIGN KEY ([Entity]) REFERENCES [Foundation].[Entity] ([Name]),
    CONSTRAINT [FK_Sql_SqlResultType] FOREIGN KEY ([ResultType]) REFERENCES [Foundation].[SqlResultType] ([Value]),
    CONSTRAINT [FK_Sql_SqlType] FOREIGN KEY ([Type]) REFERENCES [Foundation].[SqlType] ([Value])
);

