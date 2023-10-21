IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230802074723_InitialCreate')
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230802074723_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230802074723_InitialCreate', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230803145146_updateColoumnUserTable')
BEGIN
    EXEC sp_rename N'[Users].[Username]', N'UserName', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230803145146_updateColoumnUserTable')
BEGIN
    ALTER TABLE [Users] ADD [FirstName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230803145146_updateColoumnUserTable')
BEGIN
    ALTER TABLE [Users] ADD [LastName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230803145146_updateColoumnUserTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230803145146_updateColoumnUserTable', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812075517_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230812075517_update', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812085113_role_update')
BEGIN
    CREATE TABLE [Roles] (
        [RoleId] int NOT NULL IDENTITY,
        [RoleCode] nvarchar(max) NOT NULL,
        [RoleName] nvarchar(max) NOT NULL,
        [Status] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812085113_role_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230812085113_role_update', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812143132_addrole')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230812143132_addrole', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812143814_addrole2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230812143814_addrole2', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813173001_add-userrole')
BEGIN
    CREATE TABLE [UserRole] (
        [id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [RoleId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_UserRole] PRIMARY KEY ([id]),
        CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813173001_add-userrole')
BEGIN
    CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813173001_add-userrole')
BEGIN
    CREATE INDEX [IX_UserRole_UserId] ON [UserRole] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813173001_add-userrole')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230813173001_add-userrole', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164641_update-product-table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821164641_update-product-table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230926191018_AddShiftTable')
BEGIN
    CREATE TABLE [EmployeeShifts] (
        [ShiftId] int NOT NULL IDENTITY,
        [ShiftName] nvarchar(max) NOT NULL,
        [StartTime] datetime2 NOT NULL,
        [EndTime] datetime2 NOT NULL,
        CONSTRAINT [PK_EmployeeShifts] PRIMARY KEY ([ShiftId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230926191018_AddShiftTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230926191018_AddShiftTable', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927013035_UpdateShiftTableTime')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmployeeShifts]') AND [c].[name] = N'EndTime');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [EmployeeShifts] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [EmployeeShifts] DROP COLUMN [EndTime];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927013035_UpdateShiftTableTime')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmployeeShifts]') AND [c].[name] = N'StartTime');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [EmployeeShifts] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [EmployeeShifts] DROP COLUMN [StartTime];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927013035_UpdateShiftTableTime')
BEGIN
    ALTER TABLE [EmployeeShifts] ADD [EndHour] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927013035_UpdateShiftTableTime')
BEGIN
    ALTER TABLE [EmployeeShifts] ADD [EndMinute] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927013035_UpdateShiftTableTime')
BEGIN
    ALTER TABLE [EmployeeShifts] ADD [StartHour] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927013035_UpdateShiftTableTime')
BEGIN
    ALTER TABLE [EmployeeShifts] ADD [StartMinute] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927013035_UpdateShiftTableTime')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230927013035_UpdateShiftTableTime', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    ALTER TABLE [UserRole] DROP CONSTRAINT [FK_UserRole_Roles_RoleId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    ALTER TABLE [UserRole] DROP CONSTRAINT [FK_UserRole_Users_UserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    ALTER TABLE [UserRole] DROP CONSTRAINT [PK_UserRole];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    EXEC sp_rename N'[UserRole]', N'UserRoles';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    EXEC sp_rename N'[UserRoles].[IX_UserRole_UserId]', N'IX_UserRoles_UserId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    EXEC sp_rename N'[UserRoles].[IX_UserRole_RoleId]', N'IX_UserRoles_RoleId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    ALTER TABLE [UserRoles] ADD CONSTRAINT [PK_UserRoles] PRIMARY KEY ([id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    ALTER TABLE [UserRoles] ADD CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    ALTER TABLE [UserRoles] ADD CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015161704_fix-db')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231015161704_fix-db', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015173150_fix-db-v1')
BEGIN
    DROP TABLE [EmployeeShifts];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015173150_fix-db-v1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231015173150_fix-db-v1', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015173644_fix-db-v2')
BEGIN
    CREATE TABLE [EmployeeShifts] (
        [ShiftId] int NOT NULL IDENTITY,
        [ShiftName] nvarchar(max) NOT NULL,
        [StartHour] int NOT NULL,
        [StartMinute] int NOT NULL,
        [EndHour] int NOT NULL,
        [EndMinute] int NOT NULL,
        CONSTRAINT [PK_EmployeeShifts] PRIMARY KEY ([ShiftId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015173644_fix-db-v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231015173644_fix-db-v2', N'6.0.20');
END;
GO

COMMIT;
GO

