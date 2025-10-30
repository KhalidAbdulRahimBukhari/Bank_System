-- uncomment the code and run it to create stored procedures in your database 
-- this step is essential for the application to function correctly and call the correct data from SQL



--USE [MyBankSystem]

-----------------------------------------------------------------------------
----								GET All 
-----------------------------------------------------------------------------
--create procedure SP_GetAllUsers
--AS
--begin
--	select * from UserPersonView
--end


--create procedure SP_GetAllClients
--AS
--begin
--	select * from ClientPersonView
--end


--create procedure SP_GetAllTransactions
--AS
--begin
--	select * from Transaction_View
--end
--------------------------------------------------------------------------------------


-----------------------------------------------------------------------------
----							GET Client, User Or Transaction 
-----------------------------------------------------------------------------
--create procedure [dbo].[SP_GetClientByID]
--			@Client_ID INT
--AS
--begin
--	select * from ClientPersonView where Client_ID = @Client_ID
--end

--Create procedure SP_GetClientByAccountNumber
--			@AccountNumber NVARCHAR(50)
--AS
--begin
--	select * from ClientPersonView where AccountNumber = @AccountNumber
--end


--Create procedure SP_GetUserByID
--			@User_ID INT
--AS
--begin
--	select * from UserPersonView where User_ID = @User_ID
--end

--Create procedure SP_GetUserByUserName
--			@UserName Nvarchar(50)
--AS
--begin
--	select * from UserPersonView where UserName = @UserName
--end


--Create procedure SP_GetTransactionByID
--			@Transaction_ID INT
--AS
--begin
--	select * from Transactions where Transaction_ID = @Transaction_ID
--end


---------------------------------------------------------------------------
----							Update Client OR User  
---------------------------------------------------------------------------


--create PROCEDURE SP_UpdateClient
--    -- Parameters for the WHERE clause
--    @Client_ID INT,
    
--    -- Parameters for the Clients table update
--    @PinCode NVARCHAR(20),  -- Use appropriate length/type
--    @Balance DECIMAL(18, 2), -- Use appropriate precision/scale
    
--    -- Parameters for the Persons table update (NVARCHAR for strings is safest)
--    @FirstName NVARCHAR(50),
--    @LastName NVARCHAR(50),
--    @Email NVARCHAR(100),
--    @Phone NVARCHAR(20),
--    @Country NVARCHAR(50),
--    @City NVARCHAR(50),
--    @Street NVARCHAR(100)
--AS
--BEGIN

--    -- Update 1: The Clients table
--    UPDATE Clients
--    SET  
--        PinCode = @PinCode,
--        Balance = @Balance
--    WHERE
--        Client_ID = @Client_ID;
        
--    -- Update 2: The Persons table (Uses a JOIN for efficiency instead of a subquery)
--    UPDATE P
--    SET
--        FirstName = @FirstName,
--        LastName = @LastName,
--        Email = @Email,
--        Phone = @Phone,
--        Country = @Country,
--        City = @City,
--        Street = @Street
--    FROM
--        Persons P
--    INNER JOIN 
--        Clients C ON P.Person_ID = C.Person_ID
--    WHERE
--        C.Client_ID = @Client_ID;

--END




--create PROCEDURE SP_UpdateUser
--    -- Parameters for the WHERE clause (Primary Key/Identifier)
--    @User_ID INT,
    
--    -- Added @Person_ID as requested
--    @Person_ID INT, 
    
--    -- Parameters for the Users table
--    @UserName NVARCHAR(50),
--    @Password NVARCHAR(50), 
--    @Permissions INT,
    
--    -- Parameters for the Persons table
--    @FirstName NVARCHAR(50),
--    @LastName NVARCHAR(50),
--    @Email NVARCHAR(100),
--    @Phone NVARCHAR(20),
--    @Country NVARCHAR(50),
--    @City NVARCHAR(50),
--    @Street NVARCHAR(100)
--AS
--BEGIN

--    -- Update 1: The Users table
--    UPDATE Users
--    SET  
--        Person_ID = @Person_ID, -- Person_ID explicitly updated here
--        UserName = @UserName,
--        [Password] = @Password,
--        Permissions = @Permissions
--    WHERE
--        User_ID = @User_ID;
        
--    -- Update 2: The Persons table (Uses the provided @Person_ID in the WHERE clause)
--    UPDATE Persons
--    SET
--        FirstName = @FirstName,
--        LastName = @LastName,
--        Email = @Email,
--        Phone = @Phone,
--        Country = @Country,
--        City = @City,
--        Street = @Street
--    WHERE
--        Person_ID = @Person_ID;

--END


---------------------------------------------------------------------------
----							Delete Client OR User By ID  SPs
---------------------------------------------------------------------------

--CREATE PROCEDURE [dbo].[SP_DeleteUserByID]
--    @User_ID INT
--AS
--BEGIN

--    DECLARE @Person_ID INT;

--    -- Find the person related to the user (through Users table)
--    SELECT @Person_ID = u.Person_ID
--    FROM Users AS u
--    WHERE u.User_ID = @User_ID;

--    -- Delete the user first
--    DELETE FROM Users
--    WHERE User_ID = @User_ID;

--    -- Then delete the related person (if found)
--    IF @Person_ID IS NOT NULL
--    BEGIN
--        DELETE FROM Persons
--        WHERE Person_ID = @Person_ID;
--    END
--END


--CREATE PROCEDURE [dbo].[SP_DeleteClientByID]
--    @Client_ID INT
--AS
--BEGIN

--    DECLARE @Person_ID INT;

--    -- Find the person related to the client (through Clients table)
--    SELECT @Person_ID = c.Person_ID
--    FROM Clients AS c
--    WHERE c.Client_ID = @Client_ID;

--    -- Delete the user first
--    DELETE FROM Clients
--    WHERE Client_ID = @Client_ID;

--    -- Then delete the related person (if found)
--    IF @Person_ID IS NOT NULL
--    BEGIN
--        DELETE FROM Persons
--        WHERE Person_ID = @Person_ID;
--    END
--END


---------------------------------------------------------------------------
----							Add new Client OR User SPs
---------------------------------------------------------------------------
--CREATE PROCEDURE [dbo].[SP_AddNewClient]
--    @FirstName     NVARCHAR(100),
--    @LastName      NVARCHAR(100),
--    @Email         NVARCHAR(200),
--    @Phone         NVARCHAR(50),
--    @Country       NVARCHAR(100),
--    @City          NVARCHAR(100),
--    @Street        NVARCHAR(200),
--    @PinCode       NVARCHAR(50),
--    @Balance       DECIMAL(18, 2),

--    -- OUTPUT parameters
--    @NewPersonID   INT OUTPUT,
--    @AccountNumber NVARCHAR(50) OUTPUT,
--    @NewClientID   INT OUTPUT
--AS
--BEGIN

--    BEGIN TRY
--        BEGIN TRANSACTION;

--        -- 1️ Insert new person
--        INSERT INTO Persons (FirstName, LastName, Email, Phone, Country, City, Street)
--        VALUES (@FirstName, @LastName, @Email, @Phone, @Country, @City, @Street);

--        SET @NewPersonID = SCOPE_IDENTITY();

--        -- 2️ Generate Account Number
--        SET @AccountNumber = CAST(@NewPersonID + 1000 AS NVARCHAR(50));

--        -- 3️ Insert client linked to that person
--        INSERT INTO Clients (Person_ID, AccountNumber, PinCode, Balance)
--        VALUES (@NewPersonID, @AccountNumber, @PinCode, @Balance);

--        -- 4️ Get the new client ID
--        SET @NewClientID = SCOPE_IDENTITY();

--        COMMIT TRANSACTION;
--    END TRY
--    BEGIN CATCH
--        IF @@TRANCOUNT > 0
--            ROLLBACK TRANSACTION;

--        -- Optional: Return nulls or default values if error occurs
--        SET @NewPersonID = NULL;
--        SET @AccountNumber = NULL;
--        SET @NewClientID = NULL;

--        -- You can also raise the error to the C# layer for logging
--        THROW;
--    END CATCH
--END

--CREATE PROCEDURE [dbo].[SP_AddNewUser]
--    -- Input parameters for Person
--    @FirstName NVARCHAR(100),
--    @LastName NVARCHAR(100),
--    @Email NVARCHAR(200),
--    @Phone NVARCHAR(50),
--    @Country NVARCHAR(100),
--    @City NVARCHAR(100),
--    @Street NVARCHAR(200),

--    -- Input parameters for User
--    @UserName NVARCHAR(100),
--    @Password NVARCHAR(100),
--    @Permissions INT,

--    -- Output parameters
--    @NewPersonID INT OUTPUT,
--    @NewUserID INT OUTPUT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    BEGIN TRY
--        BEGIN TRANSACTION;

--        -- 1️⃣ Insert new Person
--        INSERT INTO Persons (FirstName, LastName, Email, Phone, Country, City, Street)
--        VALUES (@FirstName, @LastName, @Email, @Phone, @Country, @City, @Street);

--        SET @NewPersonID = SCOPE_IDENTITY();

--        -- 2️⃣ Insert User linked to that Person
--        INSERT INTO Users (Person_ID, UserName, [Password], Permissions)
--        VALUES (@NewPersonID, @UserName, @Password, @Permissions);

--        SET @NewUserID = SCOPE_IDENTITY();

--        COMMIT TRANSACTION;
--    END TRY
--    BEGIN CATCH
--        IF @@TRANCOUNT > 0
--            ROLLBACK TRANSACTION;

--        SET @NewPersonID = NULL;
--        SET @NewUserID = NULL;

--        THROW; -- rethrow error to C# for handling
--    END CATCH
--END



--CREATE PROCEDURE [dbo].[SP_AddNewTransaction]
--    @Transaction_Type_ID INT,
--    @Date                DATETIME,
--    @Sender_Acc          NVARCHAR(50),
--    @Receiver_Acc        NVARCHAR(50),
--    @Amount              DECIMAL(18,2),
--    @User_ID             INT,
--    @NewTransactionID    INT OUTPUT   -- return new ID
--AS
--BEGIN
--    SET NOCOUNT ON;

--    INSERT INTO Transactions
--        (Transaction_Type_ID, [Date], Sender_Acc, Receiver_Acc, Amount, User_ID)
--    VALUES
--        (@Transaction_Type_ID, @Date, @Sender_Acc, @Receiver_Acc, @Amount, @User_ID);

--    -- return the new transaction identity
--    SET @NewTransactionID = SCOPE_IDENTITY();
--END
--GO



