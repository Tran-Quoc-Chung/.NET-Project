--CREATE DATABASE StoreProject;

USE StoreProject;

INSERT INTO StatusActive(StatusName) VALUES('Nhân viên bán hàng')

CREATE TABLE StatusActive(
	StatusID INT IDENTITY(1,1) PRIMARY KEY,
	StatusName NVARCHAR(50) UNIQUE,
)

CREATE TABLE Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(50) UNIQUE,
    UserPassword NVARCHAR(100) NOT NULL, 
    StatusActive INT NOT NULL,
    Phone NVARCHAR(20),
	FOREIGN KEY (StatusActive) REFERENCES StatusActive(StatusID)
);

CREATE TABLE Roles
(
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) UNIQUE,
    RoleDescription NVARCHAR(255)
);

CREATE TABLE Permission
(
    PermissionID INT IDENTITY(1,1) PRIMARY KEY,
    PermissionName NVARCHAR(50) UNIQUE,
    PermissionDescription NVARCHAR(255)
);

CREATE TABLE UserToRole
(
    UserID INT,
    RoleID INT,
    PRIMARY KEY (UserID, RoleID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

CREATE TABLE RoleToPermission
(
    RoleID INT,
    PermissionID INT,
    PRIMARY KEY (RoleID, PermissionID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (PermissionID) REFERENCES Permission(PermissionID)
);

