CREATE TABLE [Foundation].[ViewJoin] (
    [View]        VARCHAR (100) NOT NULL,
    [LeftEntity]  VARCHAR (100) NOT NULL,
    [LeftAlias]   VARCHAR (5)   NOT NULL,
    [RightEntity] VARCHAR (100) NOT NULL,
    [RightAlias]  VARCHAR (5)   NOT NULL,
    [Filter]      VARCHAR (MAX) NULL,
    [Sequence]    INT           NOT NULL,
    CONSTRAINT [PK_ViewJoin] PRIMARY KEY CLUSTERED ([View] ASC, [Sequence] ASC),
    CONSTRAINT [FK_ViewJoin_View] FOREIGN KEY ([View]) REFERENCES [Foundation].[View] ([Name])
);

