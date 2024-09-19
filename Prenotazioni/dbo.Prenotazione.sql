CREATE TABLE [dbo].[Prenotazione] (
    [IdPrenotazione] INT          IDENTITY (1, 1) NOT NULL,
    [Nome]           VARCHAR (25) NULL,
    [Cognome]        VARCHAR (25) NULL,
    [Data]           VARCHAR(50)         NULL,
    [Stato] VARCHAR(25) NULL, 
    PRIMARY KEY CLUSTERED ([IdPrenotazione] ASC)
);

