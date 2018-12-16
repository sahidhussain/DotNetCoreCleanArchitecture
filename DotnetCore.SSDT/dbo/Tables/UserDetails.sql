CREATE TABLE [dbo].[UserDetails] (
    [UserDetailId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (MAX) NULL,
    [LastName]     NVARCHAR (MAX) NULL,
    [Gender]       NVARCHAR (MAX) NULL,
    [AppUserId]    BIGINT         NOT NULL,
    CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED ([UserDetailId] ASC),
    CONSTRAINT [FK_UserDetails_ApplicationUser_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [dbo].[ApplicationUser] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserDetails_AppUserId]
    ON [dbo].[UserDetails]([AppUserId] ASC);

