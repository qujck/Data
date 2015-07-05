CREATE TABLE [Foundation].[EntityDetail] (
    [Entity]      VARCHAR (100) NOT NULL,
    [Attribute]   VARCHAR (50)  NOT NULL,
    [Sequence]    INT           NOT NULL,
    [DataType]    VARCHAR (50)  NOT NULL,
    [Nullable]    CHAR (1)      NULL,
    [IsIdentity]  CHAR (1)      NULL,
    [PKSequence]  INT           NULL,
    [Enum]        VARCHAR (100) NULL,
    [Description] VARCHAR (MAX) NULL,
    [Annotation]  VARCHAR (MAX) NULL,
    CONSTRAINT [PK_EntityDetail] PRIMARY KEY CLUSTERED ([Entity] ASC, [Attribute] ASC),
    CONSTRAINT [FK_Entity_EntityDetail_Enum] FOREIGN KEY ([Enum]) REFERENCES [Foundation].[Entity] ([Name]),
    CONSTRAINT [FK_EntityDetail_DataType] FOREIGN KEY ([DataType]) REFERENCES [Foundation].[DataType] ([Name]),
    CONSTRAINT [FK_EntityDetail_Entity] FOREIGN KEY ([Entity]) REFERENCES [Foundation].[Entity] ([Name]),
    CONSTRAINT [FK_EntityDetail_IdentityInd] FOREIGN KEY ([IsIdentity]) REFERENCES [Foundation].[Ind] ([Value]),
    CONSTRAINT [FK_EntityDetail_NullableInd] FOREIGN KEY ([Nullable]) REFERENCES [Foundation].[Ind] ([Value])
);

