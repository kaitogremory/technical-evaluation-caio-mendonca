CREATE SCHEMA cm
GO


CREATE TABLE cm.Role (
  id_Role SMALLINT IDENTITY(1, 1) NOT NULL
, nm_Role VARCHAR(100) NOT NULL

, CONSTRAINT PK_Role PRIMARY KEY (id_Role) 
)

GO

CREATE TABLE cm.Employee (
  id_Employee SMALLINT IDENTITY(1, 1) NOT NULL
, nm_Employee VARCHAR(100) NOT NULL
, ds_Email VARCHAR(100) NOT NULL
, tp_Genre BIT NOT NULL  
, dt_Birth DATE NOT NULL
, id_Role SMALLINT NOT NULL

, CONSTRAINT PK_Employee PRIMARY KEY (id_Employee) 
, CONSTRAINT FK_Employee_Role FOREIGN KEY (id_Role) REFERENCES cm.Role (id_Role)
)
GO

CREATE TABLE cm.Dependent (
  id_Dependent SMALLINT IDENTITY(1, 1) NOT NULL
, nm_Dependent VARCHAR(100) NOT NULL
, id_Employee SMALLINT NOT NULL

, CONSTRAINT PK_Dependent PRIMARY KEY (id_Dependent) 
, CONSTRAINT FK_Dependent_Employee FOREIGN KEY (id_Employee) REFERENCES cm.Employee (id_Employee)
)

GO

CREATE TABLE cm.Employee_Dependent (
  id_Employee SMALLINT NOT NULL
, id_Dependent SMALLINT NOT NULL

, CONSTRAINT PK_Employee_Dependent PRIMARY KEY (id_Employee, id_Dependent) 
, CONSTRAINT FK_Employee_Dependent_Employee FOREIGN KEY (id_Employee) REFERENCES cm.Employee (id_Employee)
, CONSTRAINT FK_Employee_Dependent_Dependent FOREIGN KEY (id_Dependent) REFERENCES cm.Dependent (id_Dependent)
)

GO





