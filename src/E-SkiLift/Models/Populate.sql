--insert users data
INSERT INTO UserSet(Name, UserType, Login, Password)
VALUES ('Admin', 0, 'admin', 'root'),
	('Owner', 1, 'owner', 'root'),
	('Cashier', 2, 'cashier', 'root');
GO

--insert tickets data
SET IDENTITY_INSERT TicketSet ON;
GO

INSERT INTO TicketSet(ID, IsValid)
VALUES (1, 1),
	(2, 1),
	(3, 1),
	(4, 1),
	(5, 1),
	(6, 1);
GO

SET IDENTITY_INSERT TicketSet OFF;
GO

--insert point tickets data
INSERT INTO TicketSet_PointTicket(ID, Points)
VALUES (1, 10),
	(2, 20),
	(3, 30);
GO

--insert ski pass tickets data
INSERT INTO TicketSet_SkiPass(ID, ExpirationTime)
VALUES (4, CONVERT(datetime, '2020-06-01 18:00:00')),
	(5, CONVERT(datetime, '2020-06-02 18:00:00')),
	(6, CONVERT(datetime, '2020-06-03 18:00:00'));
GO

--insert ticket tariff data
INSERT INTO TicketTariffSet(BeginDate, EndDate, PointPrice, HourPrice)
VALUES (CONVERT(datetime, '2019-01-01 00:00:00'), CONVERT(datetime, '2019-12-31 23:59:59'), 10, 10),
	(CONVERT(datetime, '2020-01-01 00:00:00'), CONVERT(datetime, '2020-12-31 23:59:59'), 10, 10);
GO

--insert ski lifts data
SET IDENTITY_INSERT SkiLiftSet ON;
GO

INSERT INTO SkiLiftSet(ID, IsOpen)
VALUES (1, 1),
	(2, 1),
	(3, 1);
GO

SET IDENTITY_INSERT SkiLiftSet OFF;
GO

--insert ski lift schedule data
INSERT INTO SkiLiftScheduleSet(LiftID, DayOfTheWeek, BeginHour, EndHour, BeginDate, EndDate)
VALUES (1, 0, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(1, 1, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(1, 2, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(1, 3, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(1, 4, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(1, 5, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(1, 6, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(2, 0, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(2, 1, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(2, 2, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(2, 3, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(2, 4, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(2, 5, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(2, 6, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(3, 0, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(3, 1, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(3, 2, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(3, 3, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(3, 4, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(3, 5, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL),
	(3, 6, '06:00:00', '22:00:00', CONVERT(datetime, '2020-01-01'), NULL);
GO

--insert lift usage history data
INSERT INTO LiftUsageHistorySet(TicketID, SkiLiftID, Date)
VALUES (1, 1, CONVERT(datetime, '2020-05-27 13:24:14')),
	(3, 1, CONVERT(datetime, '2020-05-27 13:25:30')),
	(2, 3, CONVERT(datetime, '2020-05-27 13:25:31')),
	(6, 2, CONVERT(datetime, '2020-05-27 13:27:05')),
	(4, 2, CONVERT(datetime, '2020-05-27 13:27:53')),
	(5, 3, CONVERT(datetime, '2020-05-27 13:28:00'));
GO

--insert lift tariff data
INSERT INTO LiftTariffSet(BeginDate, EndDate, PointCost, SkiLiftID)
VALUES (CONVERT(datetime, '2019-01-01 00:00:00'), CONVERT(datetime, '2019-12-31 23:59:59'), 2, 1),
	(CONVERT(datetime, '2019-01-01 00:00:00'), CONVERT(datetime, '2019-12-31 23:59:59'), 3, 2),
	(CONVERT(datetime, '2019-01-01 00:00:00'), CONVERT(datetime, '2019-12-31 23:59:59'), 5, 3),
	(CONVERT(datetime, '2020-01-01 00:00:00'), NULL, 3, 1),
	(CONVERT(datetime, '2020-01-01 00:00:00'), NULL, 4, 2),
	(CONVERT(datetime, '2020-01-01 00:00:00'), NULL, 6, 3);
GO