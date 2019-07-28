CREATE TABLE [Infra].[Roles] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
CREATE TABLE [Infra].[Roles] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
CREATE TABLE [Infra].[Users] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [UserName] nvarchar(50) NOT NULL,
    [Password] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
CREATE TABLE [Infra].[Users] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [UserName] nvarchar(50) NOT NULL,
    [Password] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
CREATE TABLE [Productivity].[Categories] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(25) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
CREATE TABLE [Productivity].[Categories] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(25) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
CREATE TABLE [Productivity].[Suppliers] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [ContactName] nvarchar(50) NULL,
    [Phone] nvarchar(20) NOT NULL,
    [EMail] nvarchar(50) NOT NULL,
    [Address] nvarchar(100) NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY ([Id])
);
CREATE TABLE [Productivity].[Suppliers] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [ContactName] nvarchar(50) NULL,
    [Phone] nvarchar(20) NOT NULL,
    [EMail] nvarchar(50) NOT NULL,
    [Address] nvarchar(100) NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY ([Id])
);
CREATE TABLE [Sales].[Invoices] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Number] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [Total] float NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([Id])
);
CREATE TABLE [Sales].[Invoices] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Number] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [Total] float NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([Id])
);
CREATE TABLE [Sales].[Orders] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [CustomerId] int NOT NULL,
    [Total] float NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);
CREATE TABLE [Sales].[Orders] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [CustomerId] int NOT NULL,
    [Total] float NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);
CREATE TABLE [Infra].[UserRoles] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Infra].[Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Infra].[Users] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Infra].[UserRoles] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Infra].[Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Infra].[Users] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[SubCategories] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(25) NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_SubCategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SubCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Productivity].[Categories] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[SubCategories] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(25) NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_SubCategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SubCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Productivity].[Categories] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[Product] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Price] float NOT NULL,
    [SubCategoryId] int NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_SubCategories_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [Productivity].[SubCategories] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[Product] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Price] float NOT NULL,
    [SubCategoryId] int NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_SubCategories_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [Productivity].[SubCategories] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[ProductImages] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [ProductId] int NOT NULL,
    [Label] nvarchar(50) NULL,
    [Path] nvarchar(256) NULL,
    [IsMainImage] bit NOT NULL,
    CONSTRAINT [PK_ProductImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductImages_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Productivity].[Product] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[ProductImages] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [ProductId] int NOT NULL,
    [Label] nvarchar(50) NULL,
    [Path] nvarchar(256) NULL,
    [IsMainImage] bit NOT NULL,
    CONSTRAINT [PK_ProductImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductImages_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Productivity].[Product] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[Stocks] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [ProductId] int NOT NULL,
    [SupplierId] int NOT NULL,
    [Amount] int NOT NULL,
    CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Stocks_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Productivity].[Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Stocks_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Productivity].[Suppliers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Productivity].[Stocks] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [ProductId] int NOT NULL,
    [SupplierId] int NOT NULL,
    [Amount] int NOT NULL,
    CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Stocks_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Productivity].[Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Stocks_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Productivity].[Suppliers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Sales].[Baskets] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [ProductId] int NOT NULL,
    [Amount] int NOT NULL,
    [CustomerId] int NOT NULL,
    [SupplierId] int NOT NULL,
    CONSTRAINT [PK_Baskets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Baskets_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Productivity].[Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Baskets_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Productivity].[Suppliers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Sales].[Baskets] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [ProductId] int NOT NULL,
    [Amount] int NOT NULL,
    [CustomerId] int NOT NULL,
    [SupplierId] int NOT NULL,
    CONSTRAINT [PK_Baskets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Baskets_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Productivity].[Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Baskets_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Productivity].[Suppliers] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_UserRoles_RoleId] ON [Infra].[UserRoles] ([RoleId]);
CREATE INDEX [IX_UserRoles_RoleId] ON [Infra].[UserRoles] ([RoleId]);
CREATE INDEX [IX_UserRoles_UserId] ON [Infra].[UserRoles] ([UserId]);
CREATE INDEX [IX_UserRoles_UserId] ON [Infra].[UserRoles] ([UserId]);
CREATE INDEX [IX_Product_SubCategoryId] ON [Productivity].[Product] ([SubCategoryId]);
CREATE INDEX [IX_Product_SubCategoryId] ON [Productivity].[Product] ([SubCategoryId]);
CREATE INDEX [IX_ProductImages_ProductId] ON [Productivity].[ProductImages] ([ProductId]);
CREATE INDEX [IX_ProductImages_ProductId] ON [Productivity].[ProductImages] ([ProductId]);
CREATE INDEX [IX_Stocks_ProductId] ON [Productivity].[Stocks] ([ProductId]);
CREATE INDEX [IX_Stocks_ProductId] ON [Productivity].[Stocks] ([ProductId]);
CREATE INDEX [IX_Stocks_SupplierId] ON [Productivity].[Stocks] ([SupplierId]);
CREATE INDEX [IX_Stocks_SupplierId] ON [Productivity].[Stocks] ([SupplierId]);
CREATE INDEX [IX_SubCategories_CategoryId] ON [Productivity].[SubCategories] ([CategoryId]);
CREATE INDEX [IX_SubCategories_CategoryId] ON [Productivity].[SubCategories] ([CategoryId]);
CREATE INDEX [IX_Baskets_ProductId] ON [Sales].[Baskets] ([ProductId]);
CREATE INDEX [IX_Baskets_ProductId] ON [Sales].[Baskets] ([ProductId]);
CREATE INDEX [IX_Baskets_SupplierId] ON [Sales].[Baskets] ([SupplierId]);
CREATE INDEX [IX_Baskets_SupplierId] ON [Sales].[Baskets] ([SupplierId]);