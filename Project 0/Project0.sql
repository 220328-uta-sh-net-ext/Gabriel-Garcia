--DROP TABLE UserData;
CREATE TABLE UserData (
    Name NVARCHAR(50),
    UserName NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(50)
);
--DROP TABLE Restaurant;
CREATE TABLE Restaurant (
    Name NVARCHAR(50) NOT NULL,
    Id NVARCHAR(20) NOT NULL PRIMARY KEY,
    Review INT NOT NULL,
    NReviews INT NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    State NVARCHAR(50) NOT NULL,
    Zipcode NVARCHAR(50) NOT NULL,
    TypeOf NVARCHAR(50) NOT NULL
);
--INSERT INTO Restaurant (Name, Id, Review, NReviews, Country, State, Zipcode, TypeOf) VALUES
--();
--ALTER TABLE UserData PRIMARY KEY (Name);
INSERT INTO UserData (Name,UserName,Password) VALUES
('Kitty K','Catty','Password'),
('Bone Rock Jr','KNine','Password'),
('Cheese White Sr','Mousey','Password');

SELECT * FROM UserData;
SELECT * FROM Restaurant;