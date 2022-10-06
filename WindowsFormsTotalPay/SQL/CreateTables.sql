   /*
   Правой кнопкой мыши по базе
   Задачи -> Сформировать скрипты..
    Из списка выбираешь свою таблицу(ы), выбираешь "Открыть в новом окне запроса"
    На этой же странице жмёшь кнопку "Дополнительно" и в параметре "Тип данных для внесения в скрипт" выбираешь значение "схема и данные" и жмёшь 2 раза "Далее"
	*/
USE [Beregovoj]
GO
/****** Object:  Table [dbo].[Hours]    Script Date: 06.10.2022 15:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hours](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [smalldatetime] NULL,
	[Hours] [int] NULL,
	[Messang] [nvarchar](50) NULL,
	[IDName] [int] NOT NULL,
 CONSTRAINT [PK_Hours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 06.10.2022 15:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 06.10.2022 15:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IDRole] [int] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hours]  WITH CHECK ADD  CONSTRAINT [FK_Hours_users] FOREIGN KEY([IDName])
REFERENCES [dbo].[users] ([ID])
GO
ALTER TABLE [dbo].[Hours] CHECK CONSTRAINT [FK_Hours_users]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_users] FOREIGN KEY([ID])
REFERENCES [dbo].[users] ([ID])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_users]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateUser]    Script Date: 06.10.2022 15:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateUser]
    @date smalldatetime,
    @hours int,
	@name nvarchar(50),
	@Messang nvarchar(50),
	@Idname int,
	@Id int out
AS
    INSERT INTO Hours([Date],[Name],[Hours],[Messang],[IDName])
    VALUES (@date, @hours,@name, @messang, @Idname)
  
    SET @Id=SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUser]    Script Date: 06.10.2022 15:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertUser]
    @name nvarchar(50),
    @age int
AS
    INSERT INTO Users1 (Name, Age)
    VALUES (@name, @age)
  
    SELECT SCOPE_IDENTITY()
GO
