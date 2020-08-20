--INSERT INTO [TestPersonalDb].[dbo].[Employee]
--([FirstName] ,[LastName] ,[FathersName] ,[BirthDate],[Phone],[Email], [CreatedDate], [UpdatedDate])
--VALUES
--('Παναγιώρης', 'Κατσιμπέρης', 'Χρήστος', '1990-10-20', '+306971234567', 'example@example.com', GETDATE(), GETDATE()) 

SELECT TOP (1000) * FROM [TestPersonalDb].[dbo].[Employee]