CREATE TABLE [Foundation].[Relationship] (
    [PKEntity]       VARCHAR (100) NOT NULL,
    [PKMultiplicity] CHAR (1)      NOT NULL,
    [FKEntity]       VARCHAR (100) NOT NULL,
    [FKMultiplicity] CHAR (1)      NOT NULL,
    [type]           VARCHAR (25)  NOT NULL,
    [cascadeDelete]  CHAR (1)      NULL,
    [sequence]       INT           CONSTRAINT [DF_Relationship_sequence] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Relationship] PRIMARY KEY CLUSTERED ([PKEntity] ASC, [FKEntity] ASC),
    CONSTRAINT [CK_PKMultiplicity] CHECK ([PKMultiplicity]='?' OR [PKMultiplicity]='.'),
    CONSTRAINT [FK_Relationship_FKEntity] FOREIGN KEY ([FKEntity]) REFERENCES [Foundation].[Entity] ([Name]),
    CONSTRAINT [FK_Relationship_FKMultiplicity] FOREIGN KEY ([FKMultiplicity]) REFERENCES [Foundation].[Multiplicity] ([Value]),
    CONSTRAINT [FK_Relationship_PKEntity] FOREIGN KEY ([PKEntity]) REFERENCES [Foundation].[Entity] ([Name]),
    CONSTRAINT [FK_Relationship_PKMultiplicity] FOREIGN KEY ([PKMultiplicity]) REFERENCES [Foundation].[Multiplicity] ([Value]),
    CONSTRAINT [FK_Relationship_RelationshipType] FOREIGN KEY ([type]) REFERENCES [Foundation].[RelationshipType] ([Value])
);

