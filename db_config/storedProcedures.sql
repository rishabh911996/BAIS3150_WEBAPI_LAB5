CREATE TABLE [dbo].[Customers] (
    [CustomerID]   NCHAR (5)     NOT NULL,
    [CompanyName]  NVARCHAR (40) NOT NULL,
    [ContactName]  NVARCHAR (30) NULL,
    [ContactTitle] NVARCHAR (30) NULL,
    [Address]      NVARCHAR (60) NULL,
    [City]         NVARCHAR (15) NULL,
    [Region]       NVARCHAR (15) NULL,
    [PostalCode]   NVARCHAR (10) NULL,
    [Country]      NVARCHAR (15) NULL,
    [Phone]        NVARCHAR (24) NULL,
    [Fax]          NVARCHAR (24) NULL
);
GO

-- Stored Procedure for Get Customers (All)

CREATE PROCEDURE rgupta6.GetAllCustomers
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

BEGIN
    SELECT 
        CustomerID,
        CompanyName,
        ContactName,
        ContactTitle,
        Address,
        City,
        Region,
        PostalCode,
        Country,
        Phone,
        Fax
    FROM Customers

    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetAllCustomers - Select Error: Customers Table', 16, 1)
END

RETURN @ReturnCode
GO

-- Exec

EXEC rgupta6.GetAllCustomers
GO

-- Stored Procedure for Get Customer (By ID)
CREATE PROCEDURE rgupta6.GetCustomerByID
    @CustomerID NCHAR(5)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @CustomerID IS NULL
    RAISERROR('GetCustomerByID: Parameter Required', 16, 1)
ELSE
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Customers WHERE CustomerID = @CustomerID)
    BEGIN
        SELECT 
            CustomerID,
            CompanyName,
            ContactName,
            ContactTitle,
            Address,
            City,
            Region,
            PostalCode,
            Country,
            Phone,
            Fax
        FROM dbo.Customers
        WHERE CustomerID = @CustomerID

        IF @@ERROR = 0
            SET @ReturnCode = 0
        ELSE
            RAISERROR('GetCustomerByID - Select Error: Customers Table', 16, 1)
    END
    ELSE
        RAISERROR('GetCustomerByID - No Customer Found with the given ID', 16, 1)
END

RETURN @ReturnCode
GO

-- Exec GetCustomerByID

EXEC rgupta6.GetCustomerByID 'ALFKI'
GO