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
	openingTime		TIME(0) NOT NULL,
	closingTime		TIME(0) NOT NULL,
	roomMap			IMAGE, --Same as building map
	tableQty		SMALLINT NOT NULL,
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

--CREATE TABLE tblReservation (
--	reservationID	INT IDENTITY(00001,1) PRIMARY KEY,
--	userID			INT NOT NULL,
--	tableID			INT NOT NULL,
--	reservationStartTime	DATETIME NOT NULL,
--	reservationFinishTime	DATETIME NOT NULL,
--	groupName				NVARCHAR(50) NOT NULL,
--
--	CONSTRAINT fk_ReserverID FOREIGN KEY (userID) REFERENCES tblUser(userID),
--	CONSTRAINT fk_ReservedTable FOREIGN KEY (tableID) REFERENCES tblTable(tableID)
--	)

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
('Beaus Basement', 'BB', 1, '27 Haddington Dr', 'Cardiff South', 'NSW', 'Australia'),
('Sogn Studentby', 'AF', 1, '9 Rolf E Steneres Alle', '0858 Oslo', 'Oslo', 'Norway')
go

INSERT INTO tblRoom(roomName, roomLabel, buildingID, openingTime, closingTime, tableQty)
VALUES ('Auchmuty Information Common', 'L-266', 001, '00:00:00', '23:59:59', 100), 
('Huxley Information Common Area', 'HA-157', 002, '08:00:00', '22:00:00', 140),
('Bedroom', 'Bed', 004, '08:00:00', '22:00:00', 2),
('Bathroom', 'WC', 004, '08:00:00', '22:00:00', 2),
('Amatøren', 'Ama', 005, '08:00:00', '22:00:00', 4),
('28B', '28B', 005, '08:00:00', '22:00:00', 4),
('Flower Room', 'FR', 001, '00:00:00', '23:59:59', 100)
go

--INSERT INTO tblTable(tableQR, roomID, personCapacity, category, reservable)
--VALUES ('18nvjwk89', 0001, 6, 'Large', 1), ('mvne439j0d', 0001, 2, 'Small', 0),
--('8jf74hn3j4', 0001, 6, 'Lounge', 1), ('mklpo098ik', 0002, 1, 'Computer', 0)
--go
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
('hayden.bartlett1@nerg.com', '123', 'baz', 'clide', 0, 2)
go

INSERT INTO tblIncidence(incDate, info, tableID, roomID, buildingID, userID, incLevel, incENDDate)
VALUES ('2018-09-14', 'I am a test incident level 0', 1, 0001, 001, 100002, 0, '2018-09-14'),
 ('2018-09-14', 'I am a test incident level 1', 1, 0001, 001, 100002, 0, '2018-09-14')
 go

--INSERT INTO tblReservation(userID, tableID, reservationStartTime, reservationFinishTime, groupName)
--VALUES (100001, 1, '2018-09-15 12:00:00', '2018-09-15 13:00:00', 'Keplers group, INFT3970'),
--(100003, 3, '2018-09-15 12:00:00', '2018-09-15 13:00:00', 'Michaels group, INFT3960')
--go

INSERT INTO tblSession(tableID, sessionStartTime, sessionFinishTime, sessionName)
VALUES (2, '2018-09-16 12:00:00', '2018-09-16 15:20:02', 'Beau'), 
(4, '2018-09-15 11:00:00', '2018-09-15 16:05:40', NULL)
go

---------------------------------------
--taken from
--https://www.mssqltips.com/sqlservertip/4054/creating-a-date-dimension-or-calendar-table-in-sql-server/

DECLARE @StartDate DATE = '20180914', @NumberOfYears INT = 1;

-- prevent set or regional settings from interfering with 
-- interpretation of dates / literals

SET DATEFIRST 7;
SET DATEFORMAT mdy;
SET LANGUAGE US_ENGLISH;

DECLARE @CutoffDate DATE = DATEADD(YEAR, @NumberOfYears, @StartDate);

-- this is just a holding table for intermediate calculations:

--DROP TABLE tblStatus
--DROP TABLE tblDates

CREATE TABLE tblDates
(
  [date]       DATE PRIMARY KEY, 
  [day]        AS DATEPART(DAY,      [date]),
  [month]      AS DATEPART(MONTH,    [date]),

  --FirstOfMonth AS CONVERT(DATE, DATEADD(MONTH, DATEDIFF(MONTH, 0, [date]), 0)),
  [MonthName]  AS DATENAME(MONTH,    [date]),
  --[week]       AS DATEPART(WEEK,     [date]),
  --[ISOweek]    AS DATEPART(ISO_WEEK, [date]),
  --[DayOfWeek]  AS DATEPART(WEEKDAY,  [date]),
  --[quarter]    AS DATEPART(QUARTER,  [date]),
  [year]       AS DATEPART(YEAR,     [date]),
  --FirstOfYear  AS CONVERT(DATE, DATEADD(YEAR,  DATEDIFF(YEAR,  0, [date]), 0)),
  --Style112     AS CONVERT(CHAR(8),   [date], 112),
  --Style101     AS CONVERT(CHAR(10),  [date], 101)
);

CREATE TABLE tblStatus
(
	[statusID]		INT IDENTITY(0001,1) PRIMARY KEY,
	[tableID]		INT,
	[date]			DATE,
	[hour00]			NVARCHAR(100) default 'Free', 
	[hour01]			NVARCHAR(100) default 'Free', 
	[hour02]			NVARCHAR(100) default 'Free', 
	[hour03]			NVARCHAR(100) default 'Free',
	[hour04]			NVARCHAR(100) default 'Free',
	[hour05]			NVARCHAR(100) default 'Free',
	[hour06]			NVARCHAR(100) default 'Free',
	[hour07]			NVARCHAR(100) default 'Free',
	[hour08]			NVARCHAR(100) default 'Free',
	[hour09]			NVARCHAR(100) default 'Free',
	[hour10]			NVARCHAR(100) default 'Free',
	[hour11]			NVARCHAR(100) default 'Free',
	[hour12]			NVARCHAR(100) default 'Free',
	[hour13]			NVARCHAR(100) default 'Free',
	[hour14]			NVARCHAR(100) default 'Free',
	[hour15]			NVARCHAR(100) default 'Free',
	[hour16]			NVARCHAR(100) default 'Free',
	[hour17]			NVARCHAR(100) default 'Free',
	[hour18]			NVARCHAR(100) default 'Free',
	[hour19]			NVARCHAR(100) default 'Free',
	[hour20]			NVARCHAR(100) default 'Free',
	[hour21]			NVARCHAR(100) default 'Free',
	[hour22]			NVARCHAR(100) default 'Free',
	[hour23]			NVARCHAR(100) default 'Free'

  CONSTRAINT fk_GETDATE FOREIGN KEY (date) REFERENCES tblDates(date),
  CONSTRAINT fk_GETTABLEID FOREIGN KEY (tableID) REFERENCES tblTable(tableID)
);
-- use the catalog views to generate as many rows as we need


	CREATE TABLE tblGroup (
	groupID			INT IDENTITY(100001,1) PRIMARY KEY,
	statusID		INT NOT NULL,
	gDate			DATE NOT NULL,
	emailAddress	NVARCHAR(100) NOT NULL,
	gHour			INT NOT NULL,
	memberEmail		NVARCHAR(40),
	memberEmail1	NVARCHAR(40),
	memberEmail2	NVARCHAR(40),
	memberEmail3	NVARCHAR(40),
	memberEmail4	NVARCHAR(40),

	    CONSTRAINT fk_getStatusID FOREIGN KEY (statusID) REFERENCES tblStatus(statusID)
	)



INSERT INTO tbldates([date]) 
SELECT d
FROM
(
  SELECT d = DATEADD(DAY, rn - 1, @StartDate)
  FROM 
  (
    SELECT TOP (DATEDIFF(DAY, @StartDate, @CutoffDate)) 
      rn = ROW_NUMBER() OVER (ORDER BY s1.[object_id])
    FROM sys.all_objects AS s1
    CROSS JOIN sys.all_objects AS s2
    -- on my system this would support > 5 million days
    ORDER BY s1.[object_id]
  ) AS x
) AS y;




--INSERT INTO  tblStatus(date)
--SELECT date
--FROM tblDates

--INSERT INTO tblStatus(tableID, date)


--select t.TableID, d.date 
--from tblTable t
--left JOIN tblStatus ts on (ts.tableID = t.tableID)
--left JOIN tblDates d on (d.date = ts.date)

--select t.TableID, d.date 
--from tblDates d
--left JOIN tblStatus ts on (d.date = ts.date)
--left JOIN tblStatus t on (ts.tableID = t.tableID)
DECLARE @i int = 0
WHILE @i <= (SELECT Count(tableID) FROM  tblTable ) 
BEGIN
INSERT INTO tblStatus(tableID, date) 
select t.TableID, d.date 
from tblDates d, tblTable t
where t.TableID = @i
--left JOIN tblStatus ts on (d.date = ts.date)
--left JOIN tblStatus t on (ts.tableID = t.tableID)
SET @i = @i + 1
END
--SELECT d.date
--      FROM tblStatus ts
--INNER JOIN tblDates d ON d.date = ts.date
--     WHERE ts.date = 2018-09-14



-- tableID
--FROM tblTable

--UPDATE tblStatus
--SET [00] ='test'
--WHERE [date] = '2018-09-14';
--go

SELECT * FROM tblStatus;
SELECT TableID FROM tblTable;
SELECT COUNT (TableID) FROM tblTable;
SELECT * FROM tblUser;
SELECT * FROM tblIncidence;
