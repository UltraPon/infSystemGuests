CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    RoleName NVARCHAR(20) NOT NULL
);

INSERT INTO Roles (RoleName)
VALUES
    ('Администратор'),
    ('Менеджер'),
    ('Ресепшн');

CREATE TABLE Staff (
    StaffID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    StaffName NVARCHAR(30) NOT NULL,
    Password NVARCHAR(20) NOT NULL,
    RoleID INT FOREIGN KEY REFERENCES Roles(RoleID) ON DELETE CASCADE NOT NULL
);

INSERT INTO Staff (StaffName, Password, RoleID)
VALUES
    ('admin', 'admin123', 1);

CREATE TABLE Guests (
    GuestID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Patronymic NVARCHAR(30) NULL,
    ContactNumber NVARCHAR(11) NOT NULL,
    Email NVARCHAR(30) NULL
);

CREATE TABLE RoomTypes (
    RoomTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    RoomTypeName NVARCHAR(20) NOT NULL
);

INSERT INTO RoomTypes (RoomTypeName)
VALUES
    ('Стандарт'),
    ('Люкс');

CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    RoomTypeID INT FOREIGN KEY REFERENCES RoomTypes(RoomTypeID) ON DELETE CASCADE NOT NULL,
    RoomNumber NVARCHAR(5) NOT NULL,
    Capacity INT NOT NULL,
    PricePerNight DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    GuestID INT FOREIGN KEY REFERENCES Guests(GuestID) ON DELETE CASCADE NOT NULL,
    RoomID INT FOREIGN KEY REFERENCES Rooms(RoomID) ON DELETE CASCADE NOT NULL,
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL
);

CREATE TABLE Cheques (
    ChequeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ReservationID INT FOREIGN KEY REFERENCES Reservations(ReservationID) ON DELETE CASCADE NOT NULL,
    IssueDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    StaffID INT FOREIGN KEY REFERENCES Staff(StaffID) ON DELETE CASCADE NOT NULL
);
