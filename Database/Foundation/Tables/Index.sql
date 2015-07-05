CREATE TABLE [Foundation].[Index] (
    [Code]   VARCHAR (100) NOT NULL,
    [Entity] VARCHAR (100) NOT NULL,
    [Type]   VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Index] PRIMARY KEY CLUSTERED ([Code] ASC, [Entity] ASC),
    CONSTRAINT [FK_Index_Entity] FOREIGN KEY ([Entity]) REFERENCES [Foundation].[Entity] ([Name]),
    CONSTRAINT [FK_IndexType_Index] FOREIGN KEY ([Type]) REFERENCES [Foundation].[IndexType] ([Value])
);

