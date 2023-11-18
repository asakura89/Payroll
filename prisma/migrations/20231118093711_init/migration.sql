-- CreateTable
CREATE TABLE "m_Rate" (
    "RateId" TEXT NOT NULL PRIMARY KEY,
    "RateName" TEXT NOT NULL,
    "RateValue" DECIMAL NOT NULL,
    "RateType" TEXT NOT NULL,
    "CreatedAt" DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" DATETIME NOT NULL
);

-- CreateTable
CREATE TABLE "m_User" (
    "Username" TEXT NOT NULL PRIMARY KEY,
    "Password" TEXT NOT NULL,
    "Category" TEXT NOT NULL,
    "CreatedAt" DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" DATETIME NOT NULL
);

-- CreateTable
CREATE TABLE "d_Salary" (
    "SalaryId" TEXT NOT NULL PRIMARY KEY,
    "Username" TEXT NOT NULL,
    "BasicSalary" DECIMAL NOT NULL,
    "CreatedAt" DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" DATETIME NOT NULL,
    CONSTRAINT "d_Salary_Username_fkey" FOREIGN KEY ("Username") REFERENCES "m_User" ("Username") ON DELETE RESTRICT ON UPDATE CASCADE
);

-- CreateTable
CREATE TABLE "d_AdditionalSalary" (
    "AdditionalSalaryId" TEXT NOT NULL PRIMARY KEY,
    "Username" TEXT NOT NULL,
    "RateId" TEXT NOT NULL,
    "CreatedAt" DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" DATETIME NOT NULL,
    CONSTRAINT "d_AdditionalSalary_Username_fkey" FOREIGN KEY ("Username") REFERENCES "m_User" ("Username") ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT "d_AdditionalSalary_RateId_fkey" FOREIGN KEY ("RateId") REFERENCES "m_Rate" ("RateId") ON DELETE RESTRICT ON UPDATE CASCADE
);

-- CreateTable
CREATE TABLE "d_DayOff" (
    "DayOffId" TEXT NOT NULL PRIMARY KEY,
    "Username" TEXT NOT NULL,
    "DayOffDate" DATETIME NOT NULL,
    "CreatedAt" DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" DATETIME NOT NULL,
    CONSTRAINT "d_DayOff_Username_fkey" FOREIGN KEY ("Username") REFERENCES "m_User" ("Username") ON DELETE RESTRICT ON UPDATE CASCADE
);

-- CreateTable
CREATE TABLE "d_Payment" (
    "PaymentId" TEXT NOT NULL PRIMARY KEY,
    "Username" TEXT NOT NULL,
    "SalaryId" TEXT NOT NULL,
    "PaymentDate" DATETIME NOT NULL,
    "PaymentMonth" INTEGER NOT NULL,
    "PaymentYear" INTEGER NOT NULL,
    "Approved" BOOLEAN NOT NULL,
    "Note" TEXT,
    "CreatedAt" DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" DATETIME NOT NULL,
    CONSTRAINT "d_Payment_Username_fkey" FOREIGN KEY ("Username") REFERENCES "m_User" ("Username") ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT "d_Payment_SalaryId_fkey" FOREIGN KEY ("SalaryId") REFERENCES "d_Salary" ("SalaryId") ON DELETE RESTRICT ON UPDATE CASCADE
);

-- CreateIndex
CREATE UNIQUE INDEX "d_Salary_Username_key" ON "d_Salary"("Username");
