CREATE DATABASE [ContactManager]
GO 
USE [ContactManager]
GO

CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
	[Status] [bit] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Email], [Phone], [Status]) VALUES (1, N'John', N'Smith', N'john.smith@gmail.com', N'9000000000', 1)
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Email], [Phone], [Status]) VALUES (2, N'Ram', N'Singh', N'ram.singh@gmail.com', N'8521478523', 1)
SET IDENTITY_INSERT [dbo].[Contact] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE   PROCEDURE [dbo].[usp_CreateContact] 
@FirstName NVARCHAR(100),
@LastName NVARCHAR(100),
@Email NVARCHAR(50),
@Phone NVARCHAR(100),
@Status BIT,
@ReturnValue INT OUTPUT

AS 
	BEGIN 
		
	   INSERT INTO [dbo].[Contact]([FirstName],[LastName],[Email],[Phone],[Status])
	   VALUES(@FirstName,@LastName,@Email,@Phone,@Status)
		
	   SET @ReturnValue = 0
		
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteContact]    Script Date: 08/01/2019 12:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeleteContact] 
@Id INT,
@ReturnValue INT OUTPUT

AS 
	BEGIN 
		
	  DELETE FROM [dbo].[Contact]	 
	  WHERE Id = @Id	
	  
	  SET @ReturnValue = 0
		
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllContacts]    Script Date: 08/01/2019 12:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Manjunath Shete
-- Create date:     08/01/2019
-- Description:	Get All Contacts
-- =============================================
CREATE   PROCEDURE [dbo].[usp_GetAllContacts]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT [Id],[FirstName],[LastName],[Email],[Phone],[Status]
     FROM [dbo].[Contact]

END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateContact]    Script Date: 08/01/2019 12:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[usp_UpdateContact] 
@Id INT,
@FirstName NVARCHAR(100),
@LastName NVARCHAR(100),
@Email NVARCHAR(50),
@Phone NVARCHAR(100),
@Status BIT,
@ReturnValue INT OUTPUT

AS 
	BEGIN 
		
	  UPDATE [dbo].[Contact]
	  SET  FirstName = @FirstName,
		   LastName = @LastName,
		   Email = @Email,
		   Phone = @Phone,
		   [Status] = @Status
	   WHERE Id = @Id	
	   SET @ReturnValue = 0
		
	END

GO
USE [master]
GO
ALTER DATABASE [ContactManager] SET  READ_WRITE 
GO
