CREATE TABLE Uzytkownicy (
  idUzytkownika INT PRIMARY KEY,
  imie VARCHAR(31),
  nazwisko VARCHAR(31),
  email VARCHAR(63),
  dataUrodzenia DATE,
  adresKorespondencyjny VARCHAR(127),
  tytulNaukowy VARCHAR(31)
);

CREATE TABLE Uczestnicy (
  idU INT PRIMARY KEY,
  idUzytkownika INT,
  indeks VARCHAR(6),
  drugieImie VARCHAR(31),
  pesel VARCHAR(12),
  numerTelefonu VARCHAR(15),
  dataUrodzenia DATE,
  imieMatki VARCHAR(15),
  imieOjca VARCHAR(15),
  dataRozpoczecia DATE,
  dataZakonczenia DATE,
  statusAktywnegoUczestnika TINYINT,
  czyZdanyEgzaminKoncowy TINYINT,
  FOREIGN KEY (idUzytkownika) REFERENCES Uzytkownicy (idUzytkownika)
);

CREATE TABLE StudyFieldManager (
  managerId INT PRIMARY KEY,
  idUzytkownika INT,
  primaryEmploymentPlace VARCHAR(127),
  FOREIGN KEY (idUzytkownika) REFERENCES Uzytkownicy (idUzytkownika)
);

CREATE TABLE Prowadzacy (
  idKier INT PRIMARY KEY,
  idP INT,
  FOREIGN KEY (idUzytkownika) REFERENCES Uzytkownicy (idUzytkownika)
);


CREATE TABLE Editions (
  number INT PRIMARY KEY
);


-- dac tu id jako sztuczny primary key?
CREATE TABLE FinalExams (
  examId INT PRIMARY KEY,
  examDate DATE,
  classroom VARCHAR(15),
  examCourse VARCHAR(127)
);


CREATE TABLE Form (
  id INT PRIMARY KEY,
  formData VARCHAR(255)[][]
);

/* zeby potem dodawac, to robimy jak ponizej
	INSERT INTO Formularze VALUES (1, '{{"imie", "Jan"}, "nazwisko", "Kowalski"}');
	(tablica dwuwymiarowa jako odpowiednik słownika)
*/


CREATE TABLE ClassesUnits (
  classUnitId INT PRIMARY KEY,
  classBeginning DATE,
  classEnding DATE,
  classroomNumber VARCHAR(31)
);


CREATE TABLE Courses (
  courseId VARCHAR(15) PRIMARY KEY,
  courseName VARCHAR(63),
  ectsPoints INT,
  semester INT
);


CREATE TABLE PartialGrades (
  partialGradeId INT PRIMARY KEY,
  gradeDate DATE,
  gradeValue FLOAT,
  comment VARCHAR(255)
);


CREATE TABLE OcenyPytan (
  ocenaPyt FLOAT
);


CREATE TABLE Podejscia (
  ocenaEgzaminu FLOAT
);


CREATE TABLE PraceKoncowe (
  terminOddania DATE,
  temat VARCHAR(127),
  komentarze VARCHAR(255)[],
  czyTematZatwierdzony TINYINT,
  czyOswiadczenieSamodzielnaPraca TINYINT,
  czyOswiadczenieUdostepnieniePracy TINYINT,
  czyOswiadczenieTozsamoscPracy TINYINT
);


CREATE TABLE Pytania (
  idPytania INT PRIMARY KEY,
  tresc VARCHAR(1023),
  punkty INT,
  odpowiedz VARCHAR(2047)
);


CREATE TABLE Recenzje (
  ocenaPracy FLOAT,
  dataRecenzji DATE
);


CREATE TABLE Zaliczenia (
  terminZaliczenia DATE,
  ocenaZaliczenia FLOAT,
  dataWystawieniaOceny DATE,
  formaZaliczenia VARCHAR(31)
);


