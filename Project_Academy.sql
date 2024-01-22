CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Login] NVARCHAR(100) NOT NULL UNIQUE,
	[Password] NVARCHAR(100) NOT NULL,
	[UserName] NVARCHAR(70) NOT NULL,
	[Status] NVARCHAR(8) NOT NULL CHECK (Status IN ('Admin', 'Student')),
	[GroupId] INT NOT NULL,
	FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE CASCADE
)

CREATE TABLE [Groups](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL UNIQUE,
)

CREATE TABLE [Subjects](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(400) NOT NULL,
	[Image] NVARCHAR(200) NOT NULL,
	[GroupId] INT NOT NULL,
	FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE CASCADE
)


CREATE TABLE [HomeWorks](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150) NOT NULL,
	[SetHomeWork] DATE NOT NULL,
	[EndHomeWork] DATE NOT NULL,
	[AssignerId] INT NOT NULL,
	[Mark] INT NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[SubjectId] INT NOT NULL,
	FOREIGN KEY (SubjectId) REFERENCES Subjects(Id) ON DELETE CASCADE
)

CREATE TABLE [Comments](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Text] NVARCHAR(300) NOT NULL,
	[DateOfSending] DATETIME NOT NULL,
	[HomeWorkId] INT NOT NULL,
	[SenderId] INT NOT NULL,
	[OwnerId] Int NOT NULL,
	FOREIGN KEY (HomeWorkId) REFERENCES HomeWorks(Id),
	FOREIGN KEY (SenderId) REFERENCES Users(Id) ON DELETE CASCADE,
	FOREIGN KEY (OwnerId) REFERENCES Users(Id)
)

INSERT INTO Users(Login,Password,UserName,Status,GroupId)
VALUES
('Admin','Admin','MyAdmin','Admin',1)

INSERT INTO Groups(Name)
VALUES
('ABC-112'),
('DM-091')


INSERT INTO Subjects(Name,Description,Image,GroupId)
VALUES('Math','Basic Math','https://cdn.icon-icons.com/icons2/1351/PNG/512/icon-math_87982.png',1)

SELECT * FROM Subjects



SELECT * FROM HomeWorks

SELECT * FROM Users

SELECT * FROM Comments

INSERT INTO Comments(Text,DateOfSending,SenderId,HomeWorkId,OwnerId)
VALUES('my comment',GETDATE(),1,1,7)


INSERT INTO HomeWorks(Name,SetHomeWork,EndHomeWork,AssignerId,Mark,Description,SubjectId)
VALUES('Read War and Peace',GETDATE(),'2024-01-20',1,0,'Read roman of Tolstoy',1)

SELECT * FROM Groups

SELECT * FROM Users



