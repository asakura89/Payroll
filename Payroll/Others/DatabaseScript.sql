﻿CREATE DATABASE PAYROLL
GO

USE PAYROLL
GO

CREATE TABLE M_USER
(
	USERNAME VARCHAR(50) NOT NULL,
	USERPASS VARCHAR(50) NOT NULL,
	USER_CATEGORY CHAR(1),
	CONSTRAINT PK_M_USER PRIMARY KEY (USERNAME)
)
GO

CREATE TABLE M_EMP_SALARY
(
	SALARY_ID VARCHAR(50) NOT NULL,
	USERNAME VARCHAR(50) NOT NULL,
	BASIC_SALARY DECIMAL(18,0),
	CONSTRAINT PK_M_EMP_SALARY PRIMARY KEY (SALARY_ID),
	CONSTRAINT FK_SALARY_USER FOREIGN KEY (USERNAME) REFERENCES M_USER (USERNAME)
)
GO

CREATE TABLE M_RATES
(
	RATE_ID VARCHAR(50) NOT NULL,
	RATE_NAME VARCHAR(200) NOT NULL,
	RATE_VALUE DECIMAL(18,0),
    RATE_TYPE CHAR(1),
	CONSTRAINT PK_M_RATES PRIMARY KEY (RATE_ID)
)
GO

CREATE TABLE T_DAYOFF
(
	DAYOFF_ID VARCHAR(50) NOT NULL,
	USERNAME VARCHAR(50) NOT NULL,
	DAYOFF_DATE DATETIME NOT NULL,
	CONSTRAINT PK_T_DAYOFF PRIMARY KEY (DAYOFF_ID),
	CONSTRAINT FK_DAYOFF_USER FOREIGN KEY (USERNAME) REFERENCES M_USER (USERNAME)
)
GO

CREATE TABLE T_PAYMENT
(
	PAYMENT_ID VARCHAR(50) NOT NULL,
	PAYMENT_MONTH INT NOT NULL,
	PAYMENT_YEAR INT NOT NULL,
	USERNAME VARCHAR(50),
	CONSTRAINT PK_T_PAYMENT PRIMARY KEY (PAYMENT_ID),
	CONSTRAINT FK_PAYMENT_USER FOREIGN KEY (USERNAME) REFERENCES M_USER (USERNAME)
)
GO

CREATE TABLE T_ADDITIONAL_PAYMENT
(
	ADDITIONAL_ID VARCHAR(50) NOT NULL,
	PAYMENT_ID VARCHAR(50) NOT NULL,
	RATE_ID VARCHAR(50),
	NOTE VARCHAR(MAX),
	IS_APPROVED BIT,
	CONSTRAINT PK_T_ADDITIONAL_PAYMENT PRIMARY KEY (ADDITIONAL_ID),
	CONSTRAINT FK_ADDITIONAL_RATES FOREIGN KEY (RATE_ID) REFERENCES M_RATES (RATE_ID)
)
GO