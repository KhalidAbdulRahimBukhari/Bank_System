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

