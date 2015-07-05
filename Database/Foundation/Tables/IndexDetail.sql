CREATE TABLE [Foundation].[IndexDetail] (
    [Index]     VARCHAR (100) NOT NULL,
    [Entity]    VARCHAR (100) NOT NULL,
    [Attribute] VARCHAR (50)  NOT NULL,
    [Sequence]  INT           NOT NULL,
    CONSTRAINT [PK_IndexDetail] PRIMARY KEY CLUSTERED ([Index] ASC, [Sequence] ASC),
    CONSTRAINT [FK_IndexDetail_EntityDetail] FOREIGN KEY ([Entity], [Attribute]) REFERENCES [Foundation].[EntityDetail] ([Entity], [Attribute]),
    CONSTRAINT [FK_IndexDetail_Index] FOREIGN KEY ([Index], [Entity]) REFERENCES [Foundation].[Index] ([Code], [Entity])
);


GO
ALTER TABLE [Foundation].[IndexDetail] NOCHECK CONSTRAINT [FK_IndexDetail_Index];

