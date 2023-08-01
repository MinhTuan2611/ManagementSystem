
CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(256) NOT NULL, 
    [Password] NVARCHAR(256) NOT NULL, 
    [PhoneNumber] NVARCHAR(11) NULL, 
    [FistName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Status] BIT NULL DEFAULT 1
)
