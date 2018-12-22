CREATE TABLE [dbo].[InstituteDetails] (
    [Address]           NVARCHAR (MAX) NULL,
    [Locality]          NVARCHAR (MAX) NULL,
    [LandMark]          NVARCHAR (MAX) NULL,
    [City]              NVARCHAR (MAX) NULL,
    [State]             NVARCHAR (MAX) NULL,
    [Country]           NVARCHAR (MAX) NULL,
    [AddressType]       INT            NOT NULL,
    [InstituteDetailId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [InstituteName]     NVARCHAR (MAX) NULL,
    [Website]           NVARCHAR (MAX) NULL,
    [Gender]            NVARCHAR (MAX) NULL,
    [AppUserId]         BIGINT         NOT NULL,
    CONSTRAINT [PK_InstituteDetails] PRIMARY KEY CLUSTERED ([InstituteDetailId] ASC),
    CONSTRAINT [FK_InstituteDetails_ApplicationUser_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [dbo].[ApplicationUser] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_InstituteDetails_AppUserId]
    ON [dbo].[InstituteDetails]([AppUserId] ASC);

