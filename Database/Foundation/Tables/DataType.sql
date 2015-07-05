CREATE TABLE [Foundation].[DataType] (
    [Name]         VARCHAR (50)  NOT NULL,
    [MSSQL]        VARCHAR (50)  NOT NULL,
    [dotNET]       VARCHAR (50)  NOT NULL,
    [XSD]          VARCHAR (50)  NOT NULL,
    [Length]       INT           NULL,
    [Precision]    INT           NULL,
    [Scale]        INT           NULL,
    [Pattern]      VARCHAR (250) NULL,
    [MinInclusive] VARCHAR (50)  NULL,
    [MaxInclusive] VARCHAR (50)  NULL,
    CONSTRAINT [PK_DataType] PRIMARY KEY CLUSTERED ([Name] ASC)
);

