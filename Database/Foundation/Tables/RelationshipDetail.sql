CREATE TABLE [Foundation].[RelationshipDetail] (
    [PKEntity]    VARCHAR (100) NOT NULL,
    [PKAttribute] VARCHAR (50)  NOT NULL,
    [FKEntity]    VARCHAR (100) NOT NULL,
    [FKAttribute] VARCHAR (50)  NOT NULL,
    [Sequence]    INT           NOT NULL,
    CONSTRAINT [PK_RelationshipDetail] PRIMARY KEY CLUSTERED ([PKEntity] ASC, [FKEntity] ASC, [Sequence] ASC),
    CONSTRAINT [FK_RelationshipDetail_FKEntity] FOREIGN KEY ([FKEntity], [FKAttribute]) REFERENCES [Foundation].[EntityDetail] ([Entity], [Attribute]),
    CONSTRAINT [FK_RelationshipDetail_PKEntity] FOREIGN KEY ([PKEntity], [PKAttribute]) REFERENCES [Foundation].[EntityDetail] ([Entity], [Attribute])
);

