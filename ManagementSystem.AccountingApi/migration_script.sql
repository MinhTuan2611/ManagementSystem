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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230814180212_Innit_Accounting_db')
BEGIN
    CREATE TABLE [Recordingtransactions] (
        [Id] int NOT NULL IDENTITY,
        [TypeOfVoucherCode] nvarchar(max) NOT NULL,
        [TypeOfVoucherName] nvarchar(max) NOT NULL,
        [DebitAccountId] int NOT NULL,
        [CreditAccountId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Recordingtransactions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230814180212_Innit_Accounting_db')
BEGIN
    CREATE TABLE [TypesOfAccounts] (
        [AccountId] int NOT NULL IDENTITY,
        [AccountCode] nvarchar(max) NOT NULL,
        [AccountName] nvarchar(max) NOT NULL,
        [AccountParentId] int NOT NULL,
        [IsLiability] int NOT NULL,
        [LiabilityType] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_TypesOfAccounts] PRIMARY KEY ([AccountId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230814180212_Innit_Accounting_db')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230814180212_Innit_Accounting_db', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230815182058_update_is_null_column')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TypesOfAccounts]') AND [c].[name] = N'LiabilityType');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TypesOfAccounts] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [TypesOfAccounts] ALTER COLUMN [LiabilityType] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230815182058_update_is_null_column')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TypesOfAccounts]') AND [c].[name] = N'IsLiability');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TypesOfAccounts] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [TypesOfAccounts] ALTER COLUMN [IsLiability] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230815182058_update_is_null_column')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TypesOfAccounts]') AND [c].[name] = N'AccountParentId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TypesOfAccounts] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [TypesOfAccounts] ALTER COLUMN [AccountParentId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230815182058_update_is_null_column')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230815182058_update_is_null_column', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230815182823_add_account_rank_column')
BEGIN
    ALTER TABLE [TypesOfAccounts] ADD [AccountRank] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230815182823_add_account_rank_column')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230815182823_add_account_rank_column', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816084356_udpate_record_trans_table')
BEGIN
    ALTER TABLE [Recordingtransactions] ADD [Note] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816084356_udpate_record_trans_table')
BEGIN
    ALTER TABLE [Recordingtransactions] ADD [Status] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816084356_udpate_record_trans_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230816084356_udpate_record_trans_table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821044433_update_Type_of_account_table')
BEGIN
    EXEC sp_rename N'[TypesOfAccounts].[LiabilityType]', N'HasCosting', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821044433_update_Type_of_account_table')
BEGIN
    EXEC sp_rename N'[TypesOfAccounts].[IsLiability]', N'HasAccountItem', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821044433_update_Type_of_account_table')
BEGIN
    ALTER TABLE [TypesOfAccounts] ADD [BalanceType] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821044433_update_Type_of_account_table')
BEGIN
    ALTER TABLE [Recordingtransactions] ADD [DocumentType] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821044433_update_Type_of_account_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821044433_update_Type_of_account_table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821083128_update_recording_transaction_table')
BEGIN
    EXEC sp_rename N'[Recordingtransactions].[TypeOfVoucherName]', N'ReasonName', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821083128_update_recording_transaction_table')
BEGIN
    EXEC sp_rename N'[Recordingtransactions].[TypeOfVoucherCode]', N'ReasonGroup', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821083128_update_recording_transaction_table')
BEGIN
    ALTER TABLE [Recordingtransactions] ADD [ExpenseItem] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821083128_update_recording_transaction_table')
BEGIN
    ALTER TABLE [Recordingtransactions] ADD [ReasonCode] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821083128_update_recording_transaction_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821083128_update_recording_transaction_table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821100400_update_recording_transaction_table_1')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recordingtransactions]') AND [c].[name] = N'ExpenseItem');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Recordingtransactions] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Recordingtransactions] ALTER COLUMN [ExpenseItem] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821100400_update_recording_transaction_table_1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821100400_update_recording_transaction_table_1', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230925150643_AddDocumentInformation')
BEGIN
    CREATE TABLE [ActivityLog] (
        [ActivityId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [Action] nvarchar(max) NOT NULL,
        [Source] nvarchar(max) NOT NULL,
        [DateModified] datetime2 NOT NULL,
        CONSTRAINT [PK_ActivityLog] PRIMARY KEY ([ActivityId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230925150643_AddDocumentInformation')
BEGIN
    CREATE TABLE [InventoryVouchers] (
        [DocummentNumber] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [CustomerId] int NOT NULL,
        [EmployeeShift] int NOT NULL,
        [PurchasingRepresentive] nvarchar(max) NOT NULL,
        [RepresentivePhone] nvarchar(max) NOT NULL,
        [ReasonFor] nvarchar(max) NOT NULL,
        [TransactionDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [Note] nvarchar(max) NOT NULL,
        [PaymentMethodId] int NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_InventoryVouchers] PRIMARY KEY ([DocummentNumber])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230925150643_AddDocumentInformation')
BEGIN
    CREATE TABLE [PaymentVouchers] (
        [DocumentNumber] int NOT NULL IDENTITY,
        [BranchId] int NOT NULL,
        [DebitAccount] int NOT NULL,
        [CreditAccount] int NOT NULL,
        [Reason] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [TransactionDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_PaymentVouchers] PRIMARY KEY ([DocumentNumber])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230925150643_AddDocumentInformation')
BEGIN
    CREATE TABLE [Receipts] (
        [DocumentNumber] int NOT NULL IDENTITY,
        [CustomerId] int NOT NULL,
        [ForReason] nvarchar(max) NOT NULL,
        [TotalMoney] int NOT NULL,
        [UserId] int NOT NULL,
        [TransactionDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_Receipts] PRIMARY KEY ([DocumentNumber])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230925150643_AddDocumentInformation')
BEGIN
    CREATE TABLE [InventoryVoucherDetails] (
        [DocummentNumber] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Price] int NOT NULL,
        [DebitAccount] int NOT NULL,
        [CreditAccount] int NOT NULL,
        [TotalMoneyBeforeTax] int NOT NULL,
        [DebitAccountMoney] int NOT NULL,
        [CreditAccountMoney] int NOT NULL,
        [PaymentDiscountAccount] int NOT NULL,
        [PaymentDiscountMoney] int NOT NULL,
        [TaxAccount] int NOT NULL,
        [TaxMoney] int NOT NULL,
        [TotalMoneyAfterTax] int NOT NULL,
        [Note] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_InventoryVoucherDetails] PRIMARY KEY ([DocummentNumber], [ProductId]),
        CONSTRAINT [FK_InventoryVoucherDetails_InventoryVouchers_DocummentNumber] FOREIGN KEY ([DocummentNumber]) REFERENCES [InventoryVouchers] ([DocummentNumber]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230925150643_AddDocumentInformation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230925150643_AddDocumentInformation', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927124426_AddColumnShiftId')
BEGIN
    EXEC sp_rename N'[InventoryVouchers].[EmployeeShift]', N'ShiftId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927124426_AddColumnShiftId')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVouchers]') AND [c].[name] = N'CustomerId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVouchers] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [InventoryVouchers] ALTER COLUMN [CustomerId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927124426_AddColumnShiftId')
BEGIN
    CREATE TABLE [InventoryVoucherPaymentMethods] (
        [DocumentNumber] int NOT NULL,
        [PaymentMethodId] int NOT NULL,
        [InventoryVoucherDocummentNumber] int NULL,
        CONSTRAINT [PK_InventoryVoucherPaymentMethods] PRIMARY KEY ([DocumentNumber], [PaymentMethodId]),
        CONSTRAINT [FK_InventoryVoucherPaymentMethods_InventoryVouchers_InventoryVoucherDocummentNumber] FOREIGN KEY ([InventoryVoucherDocummentNumber]) REFERENCES [InventoryVouchers] ([DocummentNumber])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927124426_AddColumnShiftId')
BEGIN
    CREATE INDEX [IX_InventoryVoucherPaymentMethods_InventoryVoucherDocummentNumber] ON [InventoryVoucherPaymentMethods] ([InventoryVoucherDocummentNumber]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927124426_AddColumnShiftId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230927124426_AddColumnShiftId', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927141617_AddStorageColumn')
BEGIN
    ALTER TABLE [InventoryVoucherDetails] ADD [StorageId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927141617_AddStorageColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230927141617_AddStorageColumn', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927144256_UpdateReceiptType')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipts]') AND [c].[name] = N'CustomerId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Receipts] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Receipts] ALTER COLUMN [CustomerId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927144256_UpdateReceiptType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230927144256_UpdateReceiptType', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928114534_AddLegerTable')
BEGIN
    CREATE TABLE [Legers] (
        [LegerId] int NOT NULL IDENTITY,
        [TransactionDate] datetime2 NOT NULL,
        [CreditAccount] int NULL,
        [DepositAccount] int NULL,
        [DoccumentType] nvarchar(max) NOT NULL,
        [DoccumentNumber] int NOT NULL,
        [BillId] int NULL,
        [CustomerId] int NULL,
        [Amount] int NOT NULL,
        CONSTRAINT [PK_Legers] PRIMARY KEY ([LegerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928114534_AddLegerTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230928114534_AddLegerTable', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928121126_AddLegerUserId')
BEGIN
    ALTER TABLE [Legers] ADD [UserId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928121126_AddLegerUserId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230928121126_AddLegerUserId', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVouchers]') AND [c].[name] = N'PaymentMethodId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVouchers] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [InventoryVouchers] DROP COLUMN [PaymentMethodId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    ALTER TABLE [Legers] ADD [StorageId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVouchers]') AND [c].[name] = N'ShiftId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVouchers] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [InventoryVouchers] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVouchers]') AND [c].[name] = N'RepresentivePhone');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVouchers] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [InventoryVouchers] ALTER COLUMN [RepresentivePhone] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVouchers]') AND [c].[name] = N'ReasonFor');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVouchers] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [InventoryVouchers] ALTER COLUMN [ReasonFor] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVouchers]') AND [c].[name] = N'PurchasingRepresentive');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVouchers] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [InventoryVouchers] ALTER COLUMN [PurchasingRepresentive] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVouchers]') AND [c].[name] = N'Note');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVouchers] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [InventoryVouchers] ALTER COLUMN [Note] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'TotalMoneyBeforeTax');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [TotalMoneyBeforeTax] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'TotalMoneyAfterTax');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [TotalMoneyAfterTax] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'TaxMoney');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [TaxMoney] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'TaxAccount');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [TaxAccount] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'Quantity');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [Quantity] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'Price');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [Price] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'PaymentDiscountMoney');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [PaymentDiscountMoney] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'PaymentDiscountAccount');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [PaymentDiscountAccount] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'Note');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [Note] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'DebitAccountMoney');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [DebitAccountMoney] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'DebitAccount');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [DebitAccount] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'CreditAccountMoney');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [CreditAccountMoney] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'CreditAccount');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [InventoryVoucherDetails] ALTER COLUMN [CreditAccount] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230928133107_UpdateInventoryModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230928133107_UpdateInventoryModel', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230930123156_AddLegerSearchStore')
BEGIN

    				CREATE OR ALTER  PROCEDURE [dbo].[sp_SearchLegers]
    					@xmlString NVARCHAR(MAX)
    					,@pageNumber INT = 1
    					,@pageSize INT = 10
    				AS
    				BEGIN
    					DECLARE @sqlQuery VARCHAR(MAX)
    							,@sqlQuery_condition VARCHAR(MAX)
    							,@pagingString VARCHAR(MAX)
    							,@orderBy VARCHAR(MAX)

    					DECLARE @xml XML
    					SET @xml = CAST(@xmlString AS XML)

    					-- Create a table variable to store the parsed values
    					DECLARE @SearchCriteriaTable TABLE
    					(
    						[Key] NVARCHAR(255),
    						[Value] NVARCHAR(255)
    					)

    					-- Insert the values from XML into the table variable
    					INSERT INTO @SearchCriteriaTable ([Key], [Value])
    					SELECT
    						Criteria.value('(Key)[1]', 'NVARCHAR(255)') AS [Key],
    						Criteria.value('(Value)[1]', 'NVARCHAR(255)') AS [Value]
    					FROM @xml.nodes('/SearchCriteria/Criteria') AS SearchCriteria(Criteria)

    					-- Map to create dynamic condition
    					DROP TABLE IF EXISTS #web_column_mapping
    					CREATE TABLE #web_column_mapping
    					(
    						WEB_COLUMN VARCHAR(128)
    						,DB_COLUMN_ALIAS VARCHAR(MAX)
    						,DB_COLUMN_OPERATION VARCHAR(8) DEFAULT ' = '
    					)

    					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(l.TransactionDate, ''yyyy-MM-dd'')', '>=')
    					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(l.TransactionDate, ''yyyy-MM-dd'')', '<=')
    					INSERT INTO #web_column_mapping VALUES('BillId', 'l.BillId', '=')
    					INSERT INTO #web_column_mapping VALUES('CustomerName', 'c.CustomerName', '=')
    					INSERT INTO #web_column_mapping VALUES('CustomerCode', 'c.CustomerCode', '=')
    					INSERT INTO #web_column_mapping VALUES('CustomerId', 'c.CustomerId', '=')
    					INSERT INTO #web_column_mapping VALUES('Employee', 'u.UserName', '=')
    					INSERT INTO #web_column_mapping VALUES('DocumentType', 'l.DoccumentType', '=')
    					INSERT INTO #web_column_mapping VALUES('DoccumentNumber', 'l.DoccumentNumber', '=')

    					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
    										+ col_map.DB_COLUMN_ALIAS
    										+ col_map.DB_COLUMN_OPERATION
    										+ '''' + xml_parsed.[Value] + ''''
    										+ (CHAR(10)) )
    					FROM @SearchCriteriaTable xml_parsed
    					JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

    					-- Handle SpecialAccount
    					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
    										+ '(l.CreditAccount IN (' + CONVERT(VARCHAR(MAX), xml_parsed.[Value]) + ')'+ (CHAR(10)) )
    					FROM @SearchCriteriaTable xml_parsed
    					WHERE xml_parsed.[Key] = 'CreditAccount'

    					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '	
    										+ 'l.DepositAccount IN (' + CONVERT(VARCHAR(MAX), xml_parsed.[Value]) + '))' + (CHAR(10)) )
    					FROM @SearchCriteriaTable xml_parsed
    					WHERE xml_parsed.[Key] = 'DebitAccount'

    					-- Handle Pagination
    					SET @pagingString = CONCAT(@pagingString,' 
    														OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
    														FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
    					-- Handle OrderBy
    					SET @orderBy = 'ORDER BY l.TransactionDate DESC'

    					-- Return result
    					SET @sqlQuery = CONCAT('
    						SELECT  l.TransactionDate
    								,l.CreditAccount
    								,l.DepositAccount
    								,l.DoccumentType
    								,l.DoccumentNumber
    								,l.BillId
    								,l.CustomerId
    								,c.CustomerName
    								,l.Amount
    						FROM Legers l
    						JOIN AccountsDb.dbo.Users u ON l.UserId = u.UserId
    						LEFT JOIN StoragesDb.dbo.Customers c on l.CustomerId = c.CustomerId
    						LEFT JOIN StoragesDb.dbo.Storages s ON l.StorageId = s.StorageId
    						WHERE 1 = 1
    					', @sqlQuery_condition, @orderBy, @pagingString)

    					EXEC (@sqlQuery)
    				END
                
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230930123156_AddLegerSearchStore')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230930123156_AddLegerSearchStore', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    EXEC sp_rename N'[PaymentVouchers].[Status]', N'ShiftId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentVouchers]') AND [c].[name] = N'Reason');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [PaymentVouchers] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [PaymentVouchers] ALTER COLUMN [Reason] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentVouchers]') AND [c].[name] = N'Description');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [PaymentVouchers] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [PaymentVouchers] ALTER COLUMN [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentVouchers]') AND [c].[name] = N'DebitAccount');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [PaymentVouchers] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [PaymentVouchers] ALTER COLUMN [DebitAccount] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentVouchers]') AND [c].[name] = N'CreditAccount');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [PaymentVouchers] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [PaymentVouchers] ALTER COLUMN [CreditAccount] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentVouchers]') AND [c].[name] = N'BranchId');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [PaymentVouchers] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [PaymentVouchers] ALTER COLUMN [BranchId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    ALTER TABLE [PaymentVouchers] ADD [ExchangeRate] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    ALTER TABLE [PaymentVouchers] ADD [NTMoney] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    ALTER TABLE [PaymentVouchers] ADD [ReceiverName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    ALTER TABLE [PaymentVouchers] ADD [TotalMoneyVND] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    ALTER TABLE [PaymentVouchers] ADD [UserId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    CREATE TABLE [OtherAccountEntries] (
        [DocumentNumber] int NOT NULL IDENTITY,
        [BrandId] int NULL,
        [CustomerId] int NULL,
        [Amount] int NULL,
        [Reason] nvarchar(max) NULL,
        [PaymentDescription] nvarchar(max) NULL,
        [UserId] int NULL,
        [AccountId] int NULL,
        [Note] nvarchar(max) NULL,
        [TransactionDate] datetime2 NOT NULL,
        CONSTRAINT [PK_OtherAccountEntries] PRIMARY KEY ([DocumentNumber])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231003155155_AddPaymentVoucherAndAccountEntry')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231003155155_AddPaymentVoucherAndAccountEntry', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231014154327_UpdateInventoryTable')
BEGIN
    DROP TABLE [InventoryVoucherPaymentMethods];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231014154327_UpdateInventoryTable')
BEGIN
    ALTER TABLE [InventoryVouchers] ADD [BillId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231014154327_UpdateInventoryTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231014154327_UpdateInventoryTable', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231014164546_AddStorageInformationForInventoryTable')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventoryVoucherDetails]') AND [c].[name] = N'StorageId');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [InventoryVoucherDetails] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [InventoryVoucherDetails] DROP COLUMN [StorageId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231014164546_AddStorageInformationForInventoryTable')
BEGIN
    ALTER TABLE [InventoryVouchers] ADD [StorageId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231014164546_AddStorageInformationForInventoryTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231014164546_AddStorageInformationForInventoryTable', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231016031625_AddSearchingStore')
BEGIN

                    CREATE OR ALTER  PROCEDURE [dbo].[sp_SearchInventoryVoucher]
    				@xmlString NVARCHAR(MAX)
    				,@pageNumber INT = 1
    				,@pageSize INT = 10
    				AS
    				BEGIN
    					DECLARE @sqlQuery VARCHAR(MAX)
    							,@sqlQuery_condition VARCHAR(MAX)
    							,@pagingString VARCHAR(MAX)
    							,@orderBy VARCHAR(MAX)

    					DECLARE @xml XML
    					SET @xml = CAST(@xmlString AS XML)

    					-- Create a table variable to store the parsed values
    					DECLARE @SearchCriteriaTable TABLE
    					(
    						[Key] NVARCHAR(255),
    						[Value] NVARCHAR(255)
    					)

    					-- Insert the values from XML into the table variable
    					INSERT INTO @SearchCriteriaTable ([Key], [Value])
    					SELECT
    						Criteria.value('(Key)[1]', 'NVARCHAR(255)') AS [Key],
    						Criteria.value('(Value)[1]', 'NVARCHAR(255)') AS [Value]
    					FROM @xml.nodes('/SearchCriteria/Criteria') AS SearchCriteria(Criteria)

    					-- Map to create dynamic condition
    					DROP TABLE IF EXISTS #web_column_mapping
    					CREATE TABLE #web_column_mapping
    					(
    						WEB_COLUMN VARCHAR(128)
    						,DB_COLUMN_ALIAS VARCHAR(MAX)
    						,DB_COLUMN_OPERATION VARCHAR(8) DEFAULT ' = '
    					)

    					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(iv.TransactionDate, ''yyyy-MM-dd'')', '>=')
    					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(iv.TransactionDate, ''yyyy-MM-dd'')', '<=')

    					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
    										+ col_map.DB_COLUMN_ALIAS
    										+ col_map.DB_COLUMN_OPERATION
    										+ '''' + xml_parsed.[Value] + ''''
    										+ (CHAR(10)) )
    					FROM @SearchCriteriaTable xml_parsed
    					JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

    					-- Handle Pagination
    					SET @pagingString = CONCAT(@pagingString,' 
    														OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
    														FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
    					-- Handle OrderBy
    					SET @orderBy = 'ORDER BY iv.TransactionDate DESC'

    					-- Return result
    					SET @sqlQuery = CONCAT('
    											SELECT DISTINCT iv.DocummentNumber
    												,iv.CustomerId
    												,c.CustomerName
    												,iv.PurchasingRepresentive
    												,iv.RepresentivePhone
    												,iv.Note
    												,iv.UserId
    												,u.FirstName
    												,u.LastName
    												,u.Email
    												,u.PhoneNumber
    												,iv.ReasonFor
    									--            ,p.PaymentMethodName
    												--,p.PaymentMethodCode
    												--,bp.Amount AS PaymentAmount
    												,iv.TransactionDate
    												,s.StorageName
    												,r.CreditAccountId AS InventoryCreditAccout
    												,r.DebitAccountId AS InventoryDebitAccount
    												,iv.BillId
    										FROM InventoryVouchers iv
    										LEFT JOIN StoragesDb.dbo.BillPayments bp ON bp.BillId = iv.BillId
    										-- LEFT JOIN StoragesDb.dbo.PaymentMethods p On bp.PaymentMethodId = p.PaymentMethodId
    										LEFT JOIN StoragesDb.dbo.customers c ON iv.CustomerId = c.CustomerId
    										LEFT JOIN AccountsDb.dbo.Users u ON iv.UserId = u.UserId
    										LEFT JOIN StoragesDb.dbo.Storages s ON s.StorageId = iv.StorageId
    										LEFT JOIN Recordingtransactions r ON r.ReasonGroup = iv.ReasonFor
    						WHERE 1 = 1
    					', @sqlQuery_condition, @orderBy, @pagingString)

    					EXEC (@sqlQuery)
    				END
                
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231016031625_AddSearchingStore')
BEGIN

    				CREATE OR ALTER  PROCEDURE [dbo].[sp_SearchReceipts]
    					@xmlString NVARCHAR(MAX)
    					,@pageNumber INT = 1
    					,@pageSize INT = 10
    				AS
    				BEGIN
    					DECLARE @sqlQuery VARCHAR(MAX)
    							,@sqlQuery_condition VARCHAR(MAX)
    							,@pagingString VARCHAR(MAX)
    							,@orderBy VARCHAR(MAX)

    					DECLARE @xml XML
    					SET @xml = CAST(@xmlString AS XML)

    					-- Create a table variable to store the parsed values
    					DECLARE @SearchCriteriaTable TABLE
    					(
    						[Key] NVARCHAR(255),
    						[Value] NVARCHAR(255)
    					)

    					-- Insert the values from XML into the table variable
    					INSERT INTO @SearchCriteriaTable ([Key], [Value])
    					SELECT
    						Criteria.value('(Key)[1]', 'NVARCHAR(255)') AS [Key],
    						Criteria.value('(Value)[1]', 'NVARCHAR(255)') AS [Value]
    					FROM @xml.nodes('/SearchCriteria/Criteria') AS SearchCriteria(Criteria)

    					-- Map to create dynamic condition
    					DROP TABLE IF EXISTS #web_column_mapping
    					CREATE TABLE #web_column_mapping
    					(
    						WEB_COLUMN VARCHAR(128)
    						,DB_COLUMN_ALIAS VARCHAR(MAX)
    						,DB_COLUMN_OPERATION VARCHAR(8) DEFAULT ' = '
    					)

    					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(r.TransactionDate, ''yyyy-MM-dd'')', '>=')
    					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(r.TransactionDate, ''yyyy-MM-dd'')', '<=')

    					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
    										+ col_map.DB_COLUMN_ALIAS
    										+ col_map.DB_COLUMN_OPERATION
    										+ '''' + xml_parsed.[Value] + ''''
    										+ (CHAR(10)) )
    					FROM @SearchCriteriaTable xml_parsed
    					JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

    					-- Handle Pagination
    					SET @pagingString = CONCAT(@pagingString,' 
    														OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
    														FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
    					-- Handle OrderBy
    					SET @orderBy = 'ORDER BY r.TransactionDate DESC'

    					-- Return result
    					SET @sqlQuery = CONCAT('
    							SELECT r.DocumentNumber
    									,r.TransactionDate
    									,c.CustomerId
    									,c.CustomerName
    									,c.CustomerName AS Payer
    									,r.ForReason
    									,r.TotalMoney
    									,u.UserId
    									,u.UserName AS Cashier
    							FROM Receipts r
    							JOIN StoragesDB.dbo.Customers c ON r.CustomerId = c.CustomerId
    							JOIN AccountsDb.dbo.Users u ON u.UserId = r.UserId
    						WHERE 1 = 1
    					', @sqlQuery_condition, @orderBy, @pagingString)

    					EXEC (@sqlQuery)
    				END
    			
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231016031625_AddSearchingStore')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231016031625_AddSearchingStore', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    CREATE TABLE [ShiftEndReports] (
        [ShiftEndId] int NOT NULL IDENTITY,
        [UserId] int NULL,
        [ShiftId] int NULL,
        [ShiftEndDate] datetime2 NOT NULL,
        [CompanyMoneyTransferred] int NULL,
        CONSTRAINT [PK_ShiftEndReports] PRIMARY KEY ([ShiftEndId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    CREATE TABLE [InventoryAuditDetails] (
        [ShiftEndId] int NOT NULL,
        [ProductId] int NOT NULL,
        [UnitId] int NOT NULL,
        [ActualAmount] int NOT NULL,
        [SystemAmount] int NOT NULL,
        CONSTRAINT [PK_InventoryAuditDetails] PRIMARY KEY ([ShiftEndId], [ProductId], [UnitId]),
        CONSTRAINT [FK_InventoryAuditDetails_ShiftEndReports_ShiftEndId] FOREIGN KEY ([ShiftEndId]) REFERENCES [ShiftEndReports] ([ShiftEndId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    CREATE TABLE [ShiftHandoverCashDetails] (
        [ShiftEndId] int NOT NULL,
        [Denomination] int NOT NULL,
        [Amount] int NOT NULL,
        CONSTRAINT [PK_ShiftHandoverCashDetails] PRIMARY KEY ([ShiftEndId], [Denomination]),
        CONSTRAINT [FK_ShiftHandoverCashDetails_ShiftEndReports_ShiftEndId] FOREIGN KEY ([ShiftEndId]) REFERENCES [ShiftEndReports] ([ShiftEndId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    CREATE TABLE [ShiftHandovers] (
        [HandoverId] int NOT NULL IDENTITY,
        [StorageId] int NULL,
        [CashHandover] int NULL,
        [SenderUserId1] int NULL,
        [SenderUserI2] int NULL,
        [ReceiverUserId] int NULL,
        [TotalShiftMoney] int NULL,
        [CompanyMoneyTransferred] int NULL,
        [Note] nvarchar(max) NULL,
        [Status] nvarchar(max) NULL,
        [ShiftEndId] int NOT NULL,
        [HandoverTime] datetime2 NOT NULL,
        CONSTRAINT [PK_ShiftHandovers] PRIMARY KEY ([HandoverId]),
        CONSTRAINT [FK_ShiftHandovers_ShiftEndReports_ShiftEndId] FOREIGN KEY ([ShiftEndId]) REFERENCES [ShiftEndReports] ([ShiftEndId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    CREATE TABLE [ShiftReports] (
        [ReportId] int NOT NULL IDENTITY,
        [ShiftId] int NULL,
        [UserCreatedId] int NULL,
        [HandoverId] int NULL,
        [TotalBill] int NOT NULL,
        [TotalShiftInMoney] int NOT NULL,
        [TotalRevenue] int NOT NULL,
        [TotalCashAmount] int NOT NULL,
        [TotalVoucherAmount] int NOT NULL,
        [TotalInternalConsumption] int NOT NULL,
        [TotalMOMOAmount] int NOT NULL,
        [TotalExpenses] int NOT NULL,
        [OtherExpense] int NOT NULL,
        [ActualMoneyForNextShift] int NOT NULL,
        [RemindMoneyForNextShift] int NOT NULL,
        [ExcessMoney] int NOT NULL,
        [LackOfMoney] int NOT NULL,
        [ReportDate] datetime2 NOT NULL,
        CONSTRAINT [PK_ShiftReports] PRIMARY KEY ([ReportId]),
        CONSTRAINT [FK_ShiftReports_ShiftHandovers_HandoverId] FOREIGN KEY ([HandoverId]) REFERENCES [ShiftHandovers] ([HandoverId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    CREATE INDEX [IX_ShiftHandovers_ShiftEndId] ON [ShiftHandovers] ([ShiftEndId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    CREATE INDEX [IX_ShiftReports_HandoverId] ON [ShiftReports] ([HandoverId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017093302_AddKetCa')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231017093302_AddKetCa', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017114827_AddMissingReportFields')
BEGIN
    ALTER TABLE [ShiftReports] ADD [TotalCardAmount] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017114827_AddMissingReportFields')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231017114827_AddMissingReportFields', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018110417_AddShiftStore')
BEGIN

    				CREATE OR ALTER PROCEDURE dbo.sp_generate_shift_handover
    				(
    					@ShiftEndId INT
    					,@storateId INT
    					,@brandId INT
    				)
    				AS
    				BEGIN

    					DECLARE @shiftStart INT
    							,@shiftEnd INT
    							,@totalRevenue INT
    							,@totalBills INT
    							,@totalPayment INT
    							,@shiftInReceiveMoney INT
    							,@reportingUser INT
    							,@CompanyMoneyTransferred INT
    							,@handoverId INT = 0
    							,@shiftId INT
    							,@TotalRealAmountInShift INT
    							,@totalCash INT
    							,@totalRealReminingAmount INT
    							,@totalDiffAmount INT

    					SELECT @shiftStart = s.StartHour
    							,@shiftEnd = s.EndHour
    							,@reportingUser = se.UserId
    							,@CompanyMoneyTransferred = se.CompanyMoneyTransferred
    							,@shiftId = se.ShiftId
    					FROM dbo.ShiftEndReports se
    					JOIN AccountsDb.dbo.EmployeeShifts s ON s.ShiftId = se.ShiftId
    					WHERE ShiftEndId = @ShiftEndId

    						-- Tinh tien dau ca
    					;WITH cte
    					AS
    					(
    						SELECT TOP 1 CashHandover
    						FROM dbo.ShiftHandovers
    						ORDER BY HandoverId DESC
    					)

    					SELECT @shiftInReceiveMoney = CashHandover
    					FROM cte

    					-- Tinh tong tien theo tung loai thanh toan
    								-- Calculate total amout for each payment methods

    							DROP TABLE IF EXISTS #totalAmountByMethods
    							;WITH cte
    							AS
    							(
    								SELECT p.PaymentMethodCode
    									,SUM(bp.Amount) AS TotalAmount
    								FROM StoragesDb.dbo.Bills b
    								JOIN StoragesDb.dbo.BillPayments bp ON bp.BillId = b.BillId
    								JOIN StoragesDb.dbo.PaymentMethods p ON p.PaymentMethodId = bp.PaymentMethodId
    								WHERE FORMAT(b.CreateDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
    								AND DATEPART(HOUR, b.CreateDate) >= @shiftStart
    								AND DATEPART(HOUR, b.CreateDate) <= @shiftEnd
    								GROUP BY p.PaymentMethodCode
    							)

    							SELECT *
    							INTO #totalAmountByMethods
    							FROM
    							(
    								SELECT PaymentMethodCode
    										,TotalAmount
    								FROM cte
    							) AS t
    							PIVOT
    							(
    								SUM(TotalAmount)
    								FOR PaymentMethodCode IN (
    									[MOMO], [CASH], [CARD], [BANKING])
    							) AS pivot_table

    					-- Calculate total shift in cash money

    					-- Calculate Total Revenue
    					SELECT @totalRevenue = COALESCE(SUM(bp.Amount), 0)
    							,@totalBills = COALESCE(COUNT(DISTINCT b.BillId), 0)
    					FROM StoragesDb.dbo.Bills b
    					JOIN StoragesDb.dbo.BillPayments bp ON bp.BillId = b.BillId
    					WHERE FORMAT(b.CreateDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
    					AND DATEPART(HOUR, b.CreateDate) >= @shiftStart
    					AND DATEPART(HOUR, b.CreateDate) <= @shiftEnd

    					-- Calculate Total payment

    					SELECT @totalPayment = COALESCE(SUM(p.TotalMoneyVND), 0)
    					FROM dbo.PaymentVouchers p
    					WHERE FORMAT(p.TransactionDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
    					AND DATEPART(HOUR, p.TransactionDate) >= @shiftStart
    					AND DATEPART(HOUR, p.TransactionDate) <= @shiftEnd

    					-- Tinh tien thu duoc thuc te trong ca
    					SELECT @totalCash = COALESCE(SUM(Denomination * Amount), 0)
    					FROM dbo.ShiftHandoverCashDetails
    					WHERE ShiftEndId = @ShiftEndId

    					SET @TotalRealAmountInShift = COALESCE(@totalCash, 0) - COALESCE(@CompanyMoneyTransferred, 0) + COALESCE(@totalPayment, 0)

    					-- Tinh tien thuc te con lai
    					SET @totalRealReminingAmount = COALESCE(@TotalRealAmountInShift, 0) - COALESCE(@totalPayment, 0)

    					-- Tinh Tien thua thieu

    					SELECT @totalDiffAmount = COALESCE(@TotalRealAmountInShift, 0) - (COALESCE(CASH, 0) + COALESCE(@shiftInReceiveMoney, 0))
    					FROM #totalAmountByMethods

    					BEGIN TRY
    						BEGIN TRANSACTION
    		
    						-- Tao 3 phieu chi
    						DECLARE @OutputTbl TABLE (ID INT)

    						-- Phieu ket chuyen
    						INSERT INTO dbo.PaymentVouchers
    						(
    							BranchId,
    							DebitAccount,
    							CreditAccount,
    							Reason,
    							Description,
    							TransactionDate,
    							UpdatedDate,
    							ShiftId,
    							ExchangeRate,
    							NTMoney,
    							ReceiverName,
    							TotalMoneyVND,
    							UserId
    						)
    						SELECT @brandId
    								,td.AccountCode
    								,tc.AccountCode
    								,r.ReasonCode
    								,r.ReasonName
    								,GETDATE()
    								,GETDATE()
    								,@shiftId
    								,0
    								,0
    								,''
    								,@TotalRealAmountInShift
    								,@reportingUser
    						FROM dbo.Recordingtransactions r
    						LEFT JOIN dbo.TypesOfAccounts tc ON r.CreditAccountId = tc.AccountId
    						LEFT JOIN dbo.TypesOfAccounts td ON r.DebitAccountId = td.AccountId
    						WHERE r.ReasonCode = 'KETCHUYEN'

    						INSERT INTO @OutputTbl VALUES(@@IDENTITY)

    						-- Phieu but toan 2
    						INSERT INTO dbo.PaymentVouchers
    						(
    							BranchId,
    							DebitAccount,
    							CreditAccount,
    							Reason,
    							Description,
    							TransactionDate,
    							UpdatedDate,
    							ShiftId,
    							ExchangeRate,
    							NTMoney,
    							ReceiverName,
    							TotalMoneyVND,
    							UserId
    						)
    						SELECT @brandId
    								,td.AccountCode
    								,tc.AccountCode
    								,r.ReasonCode
    								,r.ReasonName
    								,GETDATE()
    								,GETDATE()
    								,@shiftId
    								,0
    								,0
    								,''
    								,@totalRealReminingAmount
    								,@reportingUser
    						FROM dbo.Recordingtransactions r
    						LEFT JOIN dbo.TypesOfAccounts tc ON r.CreditAccountId = tc.AccountId
    						LEFT JOIN dbo.TypesOfAccounts td ON r.DebitAccountId = td.AccountId
    						WHERE r.ReasonCode = 'TIEN'
    						INSERT INTO @OutputTbl VALUES(@@IDENTITY)

    						--	Tao phieu thua thieu
    						DECLARE @reportFilter VARCHAR(128) = 'THIEU'
    						IF @totalDiffAmount > 0
    						BEGIN
    							SET @reportFilter = 'THUA'
    						END

    						INSERT INTO dbo.PaymentVouchers
    						(
    							BranchId,
    							DebitAccount,
    							CreditAccount,
    							Reason,
    							Description,
    							TransactionDate,
    							UpdatedDate,
    							ShiftId,
    							ExchangeRate,
    							NTMoney,
    							ReceiverName,
    							TotalMoneyVND,
    							UserId
    						)
    						SELECT @brandId
    								,td.AccountCode
    								,tc.AccountCode
    								,r.ReasonCode
    								,r.ReasonName
    								,GETDATE()
    								,GETDATE()
    								,@shiftId
    								,0
    								,0
    								,''
    								,@totalDiffAmount
    								,@reportingUser
    						FROM dbo.Recordingtransactions r
    						LEFT JOIN dbo.TypesOfAccounts tc ON r.CreditAccountId = tc.AccountId
    						LEFT JOIN dbo.TypesOfAccounts td ON r.DebitAccountId = td.AccountId
    						WHERE r.ReasonCode = @reportFilter
    						INSERT INTO @OutputTbl VALUES(@@IDENTITY)

    						SELECT *
    						FROM @OutputTbl

    						-- Tao But toan
    						INSERT INTO dbo.Legers
    						(
    							TransactionDate,
    							CreditAccount,
    							DepositAccount,
    							DoccumentType,
    							DoccumentNumber,
    							BillId,
    							CustomerId,
    							Amount,
    							UserId,
    							StorageId
    						)
    						SELECT SYSDATETIME()
    								,P.CreditAccount
    								,p.DebitAccount
    								,'CHI'
    								,a.ID
    								,NULL
    								,NULL
    								,COALESCE(p.TotalMoneyVND, 0)
    								,p.UserId
    								,@storateId
    						FROM @OutputTbl a
    						JOIN dbo.PaymentVouchers p ON a.ID = p.DocumentNumber

    						IF NOT EXISTS (SELECT 1 FROM dbo.ShiftHandovers WHERE ShiftEndId = @ShiftEndId)
    						BEGIN
    						INSERT INTO dbo.ShiftHandovers
    						(
    							StorageId,
    							CashHandover,
    							SenderUserId1,
    							SenderUserI2,
    							ReceiverUserId,
    							TotalShiftMoney,
    							CompanyMoneyTransferred,
    							Note,
    							Status,
    							ShiftEndId,
    							HandoverTime
    						)
    						VALUES
    						(   @storateId,
    							COALESCE(@TotalRealAmountInShift, 0),         -- CashHandover - int
    							@reportingUser,         -- SenderUserId1 - int
    							NULL,         -- SenderUserI2 - int
    							NULL,         -- ReceiverUserId - int
    							COALESCE(@TotalRealAmountInShift, 0),  -- TotalShiftMoney - int
    							@CompanyMoneyTransferred,
    							NULL,         -- Note - nvarchar(max)
    							NULL,         -- Status - nvarchar(max)
    							@ShiftEndId,            -- ShiftEndId - int
    							SYSDATETIME() -- HandoverTime - datetime2(7)
    							)

    							SET @handoverId = @@IDENTITY
    						END

    						IF @handoverId > 0
    						BEGIN

    							INSERT INTO dbo.ShiftReports
    							(
    								ShiftId,
    								UserCreatedId,
    								HandoverId,
    								TotalBill,
    								TotalShiftInMoney,
    								TotalRevenue,
    								TotalCashAmount,
    								TotalVoucherAmount,
    								TotalInternalConsumption,
    								TotalMOMOAmount,
    								TotalExpenses,
    								OtherExpense,
    								ActualMoneyForNextShift,
    								RemindMoneyForNextShift,
    								ExcessMoney,
    								LackOfMoney,
    								ReportDate,
    								TotalCardAmount
    							)
    							SELECT @shiftId,         -- ShiftId - int
    								@reportingUser,         -- UserCreatedId - int
    								@handoverId,         -- HandoverId - int
    								@totalBills,            -- TotalBill - int
    								COALESCE(@shiftInReceiveMoney, 0),            -- TotalShiftInMoney - int
    								@totalRevenue,            -- TotalRevenue - int
    								COALESCE(CASH, 0),            -- TotalCashAmount - int
    								0,            -- TotalVoucherAmount - int
    								0,            -- TotalInternalConsumption - int
    								COALESCE(MOMO, 0),            -- TotalMOMOAmount - int
    								COALESCE(@totalPayment, 0),            -- TotalExpenses - int
    								@totalPayment,            -- OtherExpense - int
    								COALESCE(@TotalRealAmountInShift, 0),            -- ActualMoneyForNextShift - int
    								@totalCash + @shiftInReceiveMoney - @totalPayment,            -- RemindMoneyForNextShift - int
    								@totalDiffAmount,            -- ExcessMoney - int
    								@totalDiffAmount,            -- LackOfMoney - int
    								SYSDATETIME(), -- ReportDate - datetime2(7)
    								COALESCE(CARD, 0) + COALESCE(BANKING, 0)
    							FROM #totalAmountByMethods

    						END

    						COMMIT
    					END TRY
    					BEGIN CATCH
    						IF @@TRANCOUNT > 0
    						BEGIN
    							ROLLBACK
    			
    						END

    						DECLARE @ErrorMessage VARCHAR(MAX) = ERROR_MESSAGE();
    						THROW 51000, @ErrorMessage, 1;
    					END CATCH
    				END

    			
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018110417_AddShiftStore')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231018110417_AddShiftStore', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231019084454_updateLegerTable')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Legers]') AND [c].[name] = N'DepositAccount');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Legers] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [Legers] ALTER COLUMN [DepositAccount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231019084454_updateLegerTable')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Legers]') AND [c].[name] = N'CreditAccount');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Legers] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [Legers] ALTER COLUMN [CreditAccount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231019084454_updateLegerTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231019084454_updateLegerTable', N'6.0.20');
END;
GO

COMMIT;
GO

