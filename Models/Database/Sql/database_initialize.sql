CREATE TABLE Users (
  userId INT PRIMARY KEY,
  userName VARCHAR(31),
  surname VARCHAR(31),
  email VARCHAR(63),
  birthdate DATE,
  mailingAddress VARCHAR(127),
  degree VARCHAR(31)
);

CREATE TABLE Participants (
  participantId INT PRIMARY KEY,
  userId INT,
  participantIndex VARCHAR(6),
  secondName VARCHAR(31),
  pesel VARCHAR(12),
  phoneNumber VARCHAR(15),
  birthdate DATE,
  mathersName VARCHAR(15),
  fathersName VARCHAR(15),
  startDate DATE,
  endDate DATE,
  activeParticipantStatus TINYINT,
  ifPassedFinalExam TINYINT,
  FOREIGN KEY (userId) REFERENCES Users (userId)
);

CREATE TABLE Kierownik (
  idKier INT PRIMARY KEY,
  idUzytkownika INT,
  podstawoweMiejsceZatrudnienia VARCHAR(127),
  FOREIGN KEY (idUzytkownika) REFERENCES Uzytkownicy (idUzytkownika)
);

CREATE TABLE Lecturer (
  lecturerId INT PRIMARY KEY,
  userId INT,
  FOREIGN KEY (userId) REFERENCES Users (userId)
);


CREATE TABLE Edycje (
  numer INT PRIMARY KEY
);


-- dac tu id jako sztuczny primary key?
CREATE TABLE EgzaminyKoncowe (
  termin DATE,
  sala VARCHAR(15),
  przebieg VARCHAR(127)
);


CREATE TABLE Formularze (
  id INT PRIMARY KEY,
  daneFormularza VARCHAR(255)[][]
);

/* zeby potem dodawac, to robimy jak ponizej
	INSERT INTO Formularze VALUES (1, '{{"imie", "Jan"}, "nazwisko", "Kowalski"}');
	(tablica dwuwymiarowa jako odpowiednik słownika)
*/


CREATE TABLE JednostkaZajec (
  poczatekZajec DATE,
  koniecZajec DATE,
  numerSali VARCHAR(31)
);


CREATE TABLE Kursy (
  idKursu VARCHAR(15) PRIMARY KEY,
  nazwa VARCHAR(63),
  punktyECTS INT,
  semestr INT
);


CREATE TABLE OcenyCzastkowe (
  data DATE,
  ocenaZajeciowa FLOAT,
  komentarz VARCHAR(255)
);


CREATE TABLE QuestionGrades (
  questionGradeId INT PRIMARY KEY,
  questionGrade FLOAT
);


CREATE TABLE Approaches (
  approacheId INT PRIMARY KEY,
  examGrade FLOAT
);


CREATE TABLE FinalTheses (
  finalThesisId INT PRIMARY KEY,
  deliveryDeadline DATE,
  topic VARCHAR(127),
  comments VARCHAR(255)[],
  ifTopicApproved TINYINT,
  ifDeclarationOfIndependentThesis TINYINT,
  ifDeclarationOfShareThesis TINYINT,
  ifDeclarationOfIdentityThesis TINYINT
);


CREATE TABLE Questions (
  questionId INT PRIMARY KEY,
  content VARCHAR(1023),
  points INT,
  answer VARCHAR(2047)
);


CREATE TABLE Reviews (
  reviewId INT PRIMARY KEY,
  thesisGrade FLOAT,
  reviewDate DATE
);


CREATE TABLE Passings (
  passingId INT PRIMARY KEY,
  passingDate DATE,
  passingGrade FLOAT,
  dateOfAssesment DATE,
  formOfPassing VARCHAR(31)
);


