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

CREATE TABLE StudyFieldManager (
  managerId INT PRIMARY KEY,
  idUzytkownika INT,
  primaryEmploymentPlace VARCHAR(127),
  FOREIGN KEY (idUzytkownika) REFERENCES Uzytkownicy (idUzytkownika)
);

CREATE TABLE Lecturer (
  lecturerId INT PRIMARY KEY,
  userId INT,
  FOREIGN KEY (userId) REFERENCES Users (userId)
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
  formId INT PRIMARY KEY
);

CREATE TABLE FormData (
  formId INT,
  formFieldData VARCHAR(255),
  FOREIGN KEY (formId) REFERENCES Form (formId)
);


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
  comments VARCHAR(255),
  ifTopicApproved TINYINT,
  ifDeclarationOfIndependentThesis TINYINT,
  ifDeclarationOfShareThesis TINYINT,
  ifDeclarationOfIdentityThesis TINYINT
);

CREATE TABLE ThesisComments (
  finalThesisId INT,
  comment VARCHAR(255),
  FOREIGN KEY (finalThesisId) REFERENCES FinalTheses (finalThesisId)
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


