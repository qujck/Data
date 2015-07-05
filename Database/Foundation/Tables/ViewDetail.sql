CREATE TABLE [Foundation].[ViewDetail] (
    [View]      VARCHAR (100) NOT NULL,
    [Entity]    VARCHAR (100) NOT NULL,
    [Alias]     VARCHAR (5)   NULL,
    [Attribute] VARCHAR (50)  NOT NULL,
    [Name]      VARCHAR (50)  NULL,
    [Sequence]  INT           NOT NULL,
    CONSTRAINT [PK_ViewDetail] PRIMARY KEY CLUSTERED ([View] ASC, [Sequence] ASC),
    CONSTRAINT [FK_ViewDetail_EntityDetail] FOREIGN KEY ([Entity], [Attribute]) REFERENCES [Foundation].[EntityDetail] ([Entity], [Attribute])
);

