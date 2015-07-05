CREATE TABLE [Foundation].[Enumerator] (
    [Type]        VARCHAR (100) NOT NULL,
    [Value]       VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Enum] PRIMARY KEY CLUSTERED ([Type] ASC, [Value] ASC),
    CONSTRAINT [FK_Enumerator_Entity] FOREIGN KEY ([Type]) REFERENCES [Foundation].[Entity] ([Name])
);

