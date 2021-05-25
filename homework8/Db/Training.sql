CREATE TABLE [dbo].[Training]
(
	 [Id] UNIQUEIDENTIFIER PRIMARY KEY,
	 [Name] NVARCHAR(64) NOT NULL,
	 [StartDate] DATE NOT NULL,
	 CONSTRAINT [Check_StartDate] CHECK ([StartDate] > '2001/01/01'),
	 [FinishDate] DATE NOT NULL,
	 CONSTRAINT [Check_FinishDate] CHECK ([FinishDate] > [StartDate]),
	 [Discription] NVARCHAR(max) NULL
)
