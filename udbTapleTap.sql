--CANNOT DROP DATABASE PROPERLY
use master
go
---Kills any existing DB sessions (Fixes drop issue) - HAYDEN: REMOVE IF YOUR DB BROKE
ALTER DATABASE udbTableTap SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

IF EXISTS(select * from sys.databases where name='udbTableTap')
DROP DATABASE udbTableTap
go

CREATE DATABASE udbTableTap
go

USE udbTableTap
go

--table creation
CREATE TABLE tblBuilding (
	buildingID		INT IDENTITY(001,1) PRIMARY KEY,
	buildingLabel	NVARCHAR(10) NOT NULL,
	buildingName	NVARCHAR(50) NOT NULL,
	roomQty			SMALLINT NOT NULL,
	street			NVARCHAR (200),
	suburb			NVARCHAR (50),
	provence		NVARCHAR (4),
	country			NVARCHAR (30)

	--buildingMap		IMAGE --temporarily Null since we haven't figured out how we're gonna make it interactive
	)

CREATE TABLE tblRoom (
	roomID			INT IDENTITY(0001,1) PRIMARY KEY,
	roomName		NVARCHAR(50) NOT NULL,
	roomLabel		NVARCHAR(10) NOT NULL,
	buildingID		INT NOT NULL,
	openingTime		TIME(0) NOT NULL DEFAULT '09:00:00',
	closingTime		TIME(0) NOT NULL DEFAULT '18:00:00',
	roomMap			IMAGE, --Same as building map
	tableQty		SMALLINT NOT NULL DEFAULT 10,
	tablesAvailable SMALLINT NOT NULL DEFAULT 0,

	CONSTRAINT fk_RoomBuilding FOREIGN KEY (buildingID) REFERENCES tblBuilding(buildingID)
	)

CREATE TABLE tblTable (
	tableID			INT IDENTITY(00001,1) PRIMARY KEY,
	--tableQR			NVARCHAR(50) NOT NULL,
	roomID			INT NOT NULL,
	personCapacity	SMALLINT NOT NULL,
	category		NVARCHAR(10) NOT NULL,
	--available		BIT NOT NULL DEFAULT 0,
	--reservable		BIT NOT NULL DEFAULT 0,

	CONSTRAINT fk_TableRoom FOREIGN KEY (roomID) REFERENCES tblRoom(roomID)
	)
		
CREATE TABLE tblUser (
	userID			INT IDENTITY(100001,1) PRIMARY KEY,
	emailAddress	NVARCHAR(100) NOT NULL,
	passcode		NVARCHAR(30) NOT NULL,
	firstName		NVARCHAR(40),
	lastName		NVARCHAR(40),
	adminPermission	BIT NOT NULL DEFAULT (0),
	phoneNum		NVARCHAR(30) NOT NULL,
	)

CREATE TABLE tblBooking (
	bookingID			INT IDENTITY(100001,1) PRIMARY KEY,
	tableID				INT NOT NULL,
	bookingDate			DATE NOT NULL,
	emailAddress		NVARCHAR(100) NOT NULL,
	bookingHour			INT NOT NULL,
	memberEmail1		NVARCHAR(40) DEFAULT ('No Email'),
	memberEmail2		NVARCHAR(40) DEFAULT ('No Email'),
	memberEmail3		NVARCHAR(40) DEFAULT ('No Email'),
	memberEmail4		NVARCHAR(40) DEFAULT ('No Email'),
	memberEmail5		NVARCHAR(40) DEFAULT ('No Email'),
	checkinStatus		BIT NOT NULL DEFAULT (0)


		CONSTRAINT fk_gettheTableID FOREIGN KEY (tableID) REFERENCES tblTable(tableID)
	)
	
CREATE TABLE tblIncidence(
    incidenceID INT IDENTITY(1000001,1) PRIMARY KEY,
    incDate DATE NOT NULL,
	info VARCHAR(300) NOT NULL,
	tableID INT,
	roomID INT,
	buildingID INT NOT NUll,
	userID INT NOT NULL,
	incLevel BIT NOT NULL,  -- determines who sees the notification
	incENDDate DATE NOT NULL,
	 
    CONSTRAINT fk_getabuildingID FOREIGN KEY (buildingID) REFERENCES tblBuilding(buildingID),
	CONSTRAINT fk_getaroomID FOREIGN KEY (roomID) REFERENCES tblroom(roomID),
    CONSTRAINT fk_getaTableID FOREIGN KEY (tableID) REFERENCES tblTable(tableID),
	CONSTRAINT fk_getaUserID FOREIGN KEY (userID) REFERENCES tblUser(userID)

  )

CREATE TABLE tblSession (
	sessionID		INT IDENTITY(000000001, 1) PRIMARY KEY,
	tableID			INT NOT NULL,
	sessionStartTime	DATETIME DEFAULT GETDATE(),
	sessionFinishTime	DATETIME NOT NULL,
	sessionName			NVARCHAR(50), --optional session name. session name will pop up on map and may help users find where their group/friends are sitting

	CONSTRAINT fk_OccupiedTable FOREIGN KEY (tableID) REFERENCES tblTable(tableID)
	)
go

--sets default value of tablesAvailable as tableQty when a room is created
CREATE TRIGGER tblRoom_AfterInsert_TRG
  ON tblRoom
AFTER INSERT
AS
  UPDATE tblRoom
  SET tblRoom.tablesAvailable = tblRoom.tableQty
  FROM Inserted AS i
  WHERE tblRoom.roomID = i.roomID ;
go

--Test values
INSERT INTO tblBuilding(buildingName, buildingLabel, roomQty, street, suburb, provence, country)
VALUES ('Auchmuty Library', 'L', 2, 'Auchmuty Library University Dr', 'Callaghan','NSW', 'Australia'), 
('Huxley Library', 'H', 1, 'Auchmuty Library', 'Callaghan', 'NSW', 'Australia'), 
('ICT Building', 'ICT', 1, 'ICT', 'Callaghan', 'NSW', 'Australia'),
('Basement Library', 'BL', 1, '27 Haddington Dr', 'Cardiff South', 'NSW', 'Australia'),
('Sogn Studentby', 'AF', 1, '9 Rolf E Steneres Alle', '0858 Oslo', 'Oslo', 'Norway')
go

INSERT INTO tblRoom(roomName, roomLabel, buildingID, openingTime, closingTime, tableQty)
VALUES ('Auchmuty Information Common', 'L-266', 001, '00:00:00', '23:59:59', 100), 
('Huxley Information Common Area', 'HA-157', 002, '08:00:00', '22:00:00', 140),
('Old Common Room', 'OCR', 004, '08:00:00', '22:00:00', 2),
('Reading Room', 'RR', 004, '08:00:00', '22:00:00', 2),
('Amatøren', 'Ama', 005, '08:00:00', '22:00:00', 4),
('28B', '28B', 005, '08:00:00', '22:00:00', 4),
('Flower Room', 'FR', 001, '00:00:00', '23:59:59', 100)
go


INSERT INTO tblTable(roomID, personCapacity, category)
VALUES ( 0001, 6, 'Large'), 
(0001, 2, 'Small'),
(0001, 6, 'Lounge'), 
(0002, 1, 'Computer'),
(0003, 1, 'Computer1'),
(0003, 1, 'Computer2'),
(0003, 4, 'Lounge'),
(0001, 6, 'Large'),
(0001, 6, 'Large'),
(0001, 6, 'Large'),
(0001, 2, 'Small'),
(0001, 2, 'Small'),
(0001, 2, 'Small'),
(0005, 2, 'Small'),
(0005, 4, 'Medium'),
(0006, 2, 'Small'),
(0006, 8, 'Large')
go

INSERT INTO tblUser(emailAddress, passcode, firstName, lastName, adminPermission, phoneNum)
VALUES ('admin@official.com', 'qwerty1', 'admin', 'admin', 1, 2),
('t@t', 't', 'fname', 'sname', 1, 0421505997),
('u@t', 't', 'ufname', 'usname', 0, 0421505997), 
('hayden.bartlett1@nerg.com', '123', 'baz', 'clide', 0, 2)
go

INSERT INTO tblIncidence(incDate, info, tableID, roomID, buildingID, userID, incLevel, incENDDate)
VALUES ('2018-09-14', 'I am a test incident level 0', 1, 0001, 001, 100002, 0, '2018-09-14'),
 ('2018-09-14', 'I am a test incident level 1', 1, 0001, 001, 100002, 0, '2018-09-14')
 go


INSERT INTO tblSession(tableID, sessionStartTime, sessionFinishTime, sessionName)
VALUES (2, '2018-09-16 12:00:00', '2018-09-16 15:20:02', 'Beau'), 
(4, '2018-09-15 11:00:00', '2018-09-15 16:05:40', NULL)
go




SELECT TableID FROM tblTable;
SELECT COUNT (TableID) FROM tblTable;
SELECT * FROM tblUser;
SELECT * FROM tblIncidence;
