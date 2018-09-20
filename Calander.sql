drop database TheCalander
go

create database TheCalander
go

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

DROP TABLE tblStatus
DROP TABLE tblDates

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
	[date]			DATE,
	[00]			CHAR(50), 
	[02]			CHAR,
	[03]			CHAR,
	[04]			CHAR,
	[05]			CHAR,
	[06]			CHAR,
	[07]			CHAR,
	[08]			CHAR,
	[09]			CHAR,
	[10]			CHAR,
	[11]			CHAR,
	[12]			CHAR,	
	[13]			CHAR,
	[14]			CHAR,
	[15]			CHAR,
	[16]			CHAR,
	[17]			CHAR,
	[18]			CHAR,
	[19]			CHAR,
	[20]			CHAR,
	[21]			CHAR,
	[22]			CHAR,
	[23]			CHAR,

  CONSTRAINT fk_GETDATE FOREIGN KEY (date) REFERENCES tblDates(date)
);
-- use the catalog views to generate as many rows as we need

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

INSERT INTO tblStatus (date)
SELECT date 
FROM tblDates

UPDATE tblStatus
SET [00] ='test'
WHERE [date] = '2018-09-14';
go

SELECT * FROM tblStatus;
SELECT * FROM tblDates;

