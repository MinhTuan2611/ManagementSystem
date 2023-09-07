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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807171757_InitDb')
BEGIN
    CREATE TABLE [Branches] (
        [BranchId] int NOT NULL IDENTITY,
        [BranchCode] nvarchar(max) NOT NULL,
        [BranchName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [ManagerID] int NOT NULL,
        [Status] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Branches] PRIMARY KEY ([BranchId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807171757_InitDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230807171757_InitDb', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812180040_updateIsNullColumnInBranchTable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Branches]') AND [c].[name] = N'PhoneNumber');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Branches] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Branches] ALTER COLUMN [PhoneNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812180040_updateIsNullColumnInBranchTable')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Branches]') AND [c].[name] = N'ManagerID');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Branches] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Branches] ALTER COLUMN [ManagerID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812180040_updateIsNullColumnInBranchTable')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Branches]') AND [c].[name] = N'Address');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Branches] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Branches] ALTER COLUMN [Address] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812180040_updateIsNullColumnInBranchTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230812180040_updateIsNullColumnInBranchTable', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813051034_create_storage_table')
BEGIN
    CREATE TABLE [Storages] (
        [StorageId] int NOT NULL IDENTITY,
        [StorageCode] nvarchar(max) NOT NULL,
        [StorageName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [BranchId] int NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Storages] PRIMARY KEY ([StorageId]),
        CONSTRAINT [FK_Storages_Branches_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branches] ([BranchId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813051034_create_storage_table')
BEGIN
    CREATE INDEX [IX_Storages_BranchId] ON [Storages] ([BranchId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813051034_create_storage_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230813051034_create_storage_table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813163255_add_column_status_storage_table')
BEGIN
    ALTER TABLE [Storages] ADD [Status] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230813163255_add_column_status_storage_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230813163255_add_column_status_storage_table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE TABLE [Category] (
        [CategoryId] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(max) NOT NULL,
        [Status] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([CategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE TABLE [Unit] (
        [UnitId] int NOT NULL IDENTITY,
        [UnitName] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Unit] PRIMARY KEY ([UnitId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE TABLE [Products] (
        [ProductId] int NOT NULL IDENTITY,
        [ProductCode] nvarchar(max) NOT NULL,
        [ProductName] nvarchar(max) NOT NULL,
        [CategoryId] int NULL,
        [DefaultSalePrice] int NOT NULL,
        [DefaultPurchasePrice] int NOT NULL,
        [UnitId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId]),
        CONSTRAINT [FK_Products_Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [Unit] ([UnitId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE TABLE [ProductStorages] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [StorageId] int NOT NULL,
        [Quantity] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_ProductStorages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductStorages_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductStorages_Storages_StorageId] FOREIGN KEY ([StorageId]) REFERENCES [Storages] ([StorageId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE INDEX [IX_Products_UnitId] ON [Products] ([UnitId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE INDEX [IX_ProductStorages_ProductId] ON [ProductStorages] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    CREATE INDEX [IX_ProductStorages_StorageId] ON [ProductStorages] ([StorageId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819060726_add-product-and-unit')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230819060726_add-product-and-unit', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Unit_UnitId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    DROP INDEX [IX_Products_UnitId] ON [Products];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    EXEC sp_rename N'[Products].[UnitId]', N'Status', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    EXEC sp_rename N'[Products].[DefaultSalePrice]', N'Price', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    ALTER TABLE [Products] ADD [BarCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    ALTER TABLE [Products] ADD [Decription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    ALTER TABLE [Products] ADD [Tax] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    CREATE TABLE [ProductUnit] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [UnitId] int NOT NULL,
        [UnitExchange] int NOT NULL,
        [Price] int NOT NULL,
        [OldPrice] int NOT NULL,
        [IsPrimary] bit NOT NULL,
        [Barcode] nvarchar(max) NULL,
        [Status] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_ProductUnit] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductUnit_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductUnit_Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [Unit] ([UnitId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    CREATE INDEX [IX_ProductUnit_ProductId] ON [ProductUnit] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    CREATE INDEX [IX_ProductUnit_UnitId] ON [ProductUnit] ([UnitId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821164859_update-product-table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821164859_update-product-table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823174358_update-product')
BEGIN
    ALTER TABLE [Products] ADD [ProductType] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823174358_update-product')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230823174358_update-product', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823181210_create_supplier_table')
BEGIN
    CREATE TABLE [Suppliers] (
        [SupplierId] int NOT NULL IDENTITY,
        [SupplierCode] nvarchar(max) NOT NULL,
        [SupplierName] nvarchar(max) NOT NULL,
        [DisplayName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Status] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Suppliers] PRIMARY KEY ([SupplierId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823181210_create_supplier_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230823181210_create_supplier_table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827010516_fix_relationshift')
BEGIN
    CREATE TABLE [RequestSamples] (
        [RequestSampleId] int NOT NULL IDENTITY,
        [RequestSampleName] nvarchar(max) NOT NULL,
        [BranchId] int NOT NULL,
        [StorageId] int NOT NULL,
        [UserId] int NOT NULL,
        [Note] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_RequestSamples] PRIMARY KEY ([RequestSampleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827010516_fix_relationshift')
BEGIN
    CREATE TABLE [RequestSampleItem] (
        [RequestSampleItemId] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [UnitId] int NOT NULL,
        [Note] nvarchar(max) NULL,
        [RequestSampleId] int NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_RequestSampleItem] PRIMARY KEY ([RequestSampleItemId]),
        CONSTRAINT [FK_RequestSampleItem_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_RequestSampleItem_RequestSamples_RequestSampleId] FOREIGN KEY ([RequestSampleId]) REFERENCES [RequestSamples] ([RequestSampleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827010516_fix_relationshift')
BEGIN
    CREATE INDEX [IX_RequestSampleItem_ProductId] ON [RequestSampleItem] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827010516_fix_relationshift')
BEGIN
    CREATE INDEX [IX_RequestSampleItem_RequestSampleId] ON [RequestSampleItem] ([RequestSampleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827010516_fix_relationshift')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230827010516_fix_relationshift', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE TABLE [BillDetails] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [UnitId] int NOT NULL,
        [DiscountAmount] int NOT NULL,
        [DiscountPercentage] int NOT NULL,
        [DiscountByPercentage] bit NOT NULL,
        [Quantity] int NOT NULL,
        [Amount] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_BillDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BillDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_BillDetails_Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [Unit] ([UnitId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE TABLE [Customers] (
        [CustomerId] int NOT NULL IDENTITY,
        [CustomerCode] nvarchar(max) NOT NULL,
        [CustomerName] nvarchar(max) NOT NULL,
        [CustomerPoint] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE TABLE [PaymentMethods] (
        [PaymentMethodId] int NOT NULL IDENTITY,
        [PaymentMethodName] nvarchar(max) NOT NULL,
        [Status] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_PaymentMethods] PRIMARY KEY ([PaymentMethodId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE TABLE [Bills] (
        [BillId] int NOT NULL IDENTITY,
        [totalAmount] int NOT NULL,
        [totalPaid] int NOT NULL,
        [totalChange] int NOT NULL,
        [CustomerId] int NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Bills] PRIMARY KEY ([BillId]),
        CONSTRAINT [FK_Bills_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE TABLE [BillPayments] (
        [Id] int NOT NULL IDENTITY,
        [BillId] int NOT NULL,
        [PaymentMethodId] int NOT NULL,
        [Amount] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_BillPayments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BillPayments_Bills_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([BillId]) ON DELETE CASCADE,
        CONSTRAINT [FK_BillPayments_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods] ([PaymentMethodId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE INDEX [IX_BillDetails_ProductId] ON [BillDetails] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE INDEX [IX_BillDetails_UnitId] ON [BillDetails] ([UnitId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE INDEX [IX_BillPayments_BillId] ON [BillPayments] ([BillId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE INDEX [IX_BillPayments_PaymentMethodId] ON [BillPayments] ([PaymentMethodId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    CREATE INDEX [IX_Bills_CustomerId] ON [Bills] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906155834_add-table-for-sale')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230906155834_add-table-for-sale', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    CREATE TABLE [Requests] (
        [RequestId] int NOT NULL IDENTITY,
        [VoucherNumber] int NOT NULL,
        [BranchId] int NOT NULL,
        [StorageId] int NOT NULL,
        [SupplierId] int NOT NULL,
        [BillNumber] int NOT NULL,
        [DeliverName] nvarchar(max) NOT NULL,
        [DeliverPhone] nvarchar(max) NOT NULL,
        [ReceiverName] nvarchar(max) NOT NULL,
        [ReceiverPhone] nvarchar(max) NOT NULL,
        [ReceivingDay] datetime2 NOT NULL,
        [PaymentMethod] int NOT NULL,
        [UserId] int NOT NULL,
        [Note] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_Requests] PRIMARY KEY ([RequestId]),
        CONSTRAINT [FK_Requests_Branches_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branches] ([BranchId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Requests_Storages_StorageId] FOREIGN KEY ([StorageId]) REFERENCES [Storages] ([StorageId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Requests_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([SupplierId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    CREATE TABLE [RequestItem] (
        [RequestItemId] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [UnitId] int NOT NULL,
        [UnitPrice] int NOT NULL,
        [Tax] real NOT NULL,
        [ProductAmount] decimal(18,2) NOT NULL,
        [TaxAmount] decimal(18,2) NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Note] nvarchar(max) NULL,
        [RequestId] int NULL,
        [CreateDate] datetime2 NOT NULL,
        [CreateBy] int NULL,
        [ModifyDate] datetime2 NOT NULL,
        [ModifyBy] int NULL,
        CONSTRAINT [PK_RequestItem] PRIMARY KEY ([RequestItemId]),
        CONSTRAINT [FK_RequestItem_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_RequestItem_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([RequestId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    CREATE INDEX [IX_RequestItem_ProductId] ON [RequestItem] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    CREATE INDEX [IX_RequestItem_RequestId] ON [RequestItem] ([RequestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    CREATE INDEX [IX_Requests_BranchId] ON [Requests] ([BranchId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    CREATE INDEX [IX_Requests_StorageId] ON [Requests] ([StorageId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    CREATE INDEX [IX_Requests_SupplierId] ON [Requests] ([SupplierId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906164639_update_request_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230906164639_update_request_table', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906170117_update-payment')
BEGIN
    ALTER TABLE [PaymentMethods] ADD [PaymentMethodCode] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906170117_update-payment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230906170117_update-payment', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906172641_update-bill-detail')
BEGIN
    ALTER TABLE [BillDetails] ADD [BillId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906172641_update-bill-detail')
BEGIN
    CREATE INDEX [IX_BillDetails_BillId] ON [BillDetails] ([BillId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906172641_update-bill-detail')
BEGIN
    ALTER TABLE [BillDetails] ADD CONSTRAINT [FK_BillDetails_Bills_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([BillId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906172641_update-bill-detail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230906172641_update-bill-detail', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906195102_update-storage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230906195102_update-storage', N'6.0.20');
END;
GO

COMMIT;
GO

