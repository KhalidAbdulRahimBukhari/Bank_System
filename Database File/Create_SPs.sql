-- uncomment the code and run it to create stored procedures in your database 
-- this step is essential for the application to function correctly and call the correct data from SQL



--USE [MyBankSystem]

---------------------------------------------------------------------------
--								GET All 
---------------------------------------------------------------------------
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


---------------------------------------------------------------------------
--							GET Client, User Or Transaction 
---------------------------------------------------------------------------
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
--							Update Client OR User  
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
--							Delete Client OR User By ID  SPs
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
