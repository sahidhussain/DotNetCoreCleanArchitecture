﻿CREATE TABLE [dbo].[UserLogin] (
    [LoginProvider]       NVARCHAR (450) NOT NULL,
    [ProviderKey]         NVARCHAR (450) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              BIGINT         NOT NULL,
    CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_UserLogin_ApplicationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[ApplicationUser] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserLogin_UserId]
    ON [dbo].[UserLogin]([UserId] ASC);

