USE [master]
GO

IF EXISTS(SELECT [name] FROM sys.databases WHERE name = 'Payroll')
BEGIN
    DROP DATABASE Payroll
END
GO

CREATE DATABASE Payroll
GO

USE Payroll
GO

CREATE TABLE dbo.m_Rate
(
    RateId VARCHAR(50) NOT NULL,
    RateName VARCHAR(300) NOT NULL,
    RateValue DECIMAL(18, 0) NOT NULL,
    RateType CHAR(1) NOT NULL,
    CONSTRAINT pk_m_rate PRIMARY KEY (RateId)
)

CREATE TABLE dbo.m_User
(
    [Username] VARCHAR(50) NOT NULL,
    [Password] VARCHAR(300) NOT NULL,
    Category CHAR(1) NOT NULL,
    CONSTRAINT pk_m_user PRIMARY KEY ([Username])
)

CREATE TABLE dbo.d_Salary
(
    SalaryId VARCHAR(50) NOT NULL,
    [Username] VARCHAR(50) NOT NULL,
    BasicSalary DECIMAL(18, 0) NOT NULL,
    CONSTRAINT pk_d_salary PRIMARY KEY (SalaryId),
    CONSTRAINT fk_d_empsalary FOREIGN KEY ([Username]) REFERENCES dbo.m_User ([Username])
)

CREATE TABLE dbo.d_AdditionalSalary
(
    AdditionalSalaryId VARCHAR(50) NOT NULL,
    [Username] VARCHAR(50) NOT NULL,
    RateId VARCHAR(50) NOT NULL,
    CONSTRAINT pk_d_additionalsalary PRIMARY KEY (AdditionalSalaryId),
    CONSTRAINT fk_d_empadditionalsalary FOREIGN KEY ([Username]) REFERENCES dbo.m_User ([Username]),
    CONSTRAINT fk_d_rateadditionalsalary FOREIGN KEY (RateId) REFERENCES dbo.m_Rate (RateId)
)

CREATE TABLE dbo.d_DayOff
(
    DayOffId VARCHAR(50) NOT NULL,
    [Username] VARCHAR(50) NOT NULL,
    DayOffDate DATETIME NOT NULL,
    CONSTRAINT pk_d_dayoff PRIMARY KEY (DayOffId),
    CONSTRAINT fk_d_empdayoff FOREIGN KEY ([Username]) REFERENCES dbo.m_User ([Username])
)

CREATE TABLE dbo.d_Payment
(
    PaymentId VARCHAR(50) NOT NULL,
    [Username] VARCHAR(50) NOT NULL,
    SalaryId VARCHAR(50) NOT NULL,
    PaymentDate DATETIME NOT NULL,
    PaymentMonth INT NOT NULL,
    PaymentYear INT NOT NULL,
    Approved BIT NOT NULL,
    Note VARCHAR(MAX) NULL,
    CONSTRAINT pk_d_payment PRIMARY KEY (PaymentId),
    CONSTRAINT fk_d_emppayment FOREIGN KEY ([Username]) REFERENCES dbo.m_User ([Username]),
    CONSTRAINT fk_d_salarypayment FOREIGN KEY (SalaryId) REFERENCES dbo.d_Salary (SalaryId)
)

GO

/*
    1: Admin, 2: Manager
*/
INSERT INTO m_User VALUES
    ('admin', 'ISMvKXpXpadDiUoOSoAfww==', 1),
    ('manager', 'HQJYwkQKjRnnFikrIx4xkA==', 2)

