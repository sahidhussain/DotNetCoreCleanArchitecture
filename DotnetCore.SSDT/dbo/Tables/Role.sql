CREATE TABLE [dbo].[Role] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    [IsActive]         BIT            NOT NULL,
    [CreatedDate]      DATETIME2 (7)  NOT NULL,
    [ModifiedDate]     DATETIME2 (7)  NOT NULL,
    [CreatedBy]        BIGINT         NOT NULL,
    [ModifiedBy]       BIGINT         NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[Role]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);

