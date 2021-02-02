CREATE TABLE Users (
  userId INT PRIMARY KEY,
  name VARCHAR(31),
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
  mothersName VARCHAR(15),
  fathersName VARCHAR(15),
  startDate DATE,
  endDate DATE,
  activeParticipantStatus TINYINT,
  ifPassedFinalExam TINYINT,
  FOREIGN KEY (userId) REFERENCES Users (userId)
);

CREATE TABLE Lecturers (
  lecturerId INT PRIMARY KEY,
  userId INT,
  FOREIGN KEY (userId) REFERENCES Users (userId)
);

CREATE TABLE StudyFieldManager (
  managerId INT PRIMARY KEY,
  userId INT,
  primaryEmploymentPlace VARCHAR(127),
  FOREIGN KEY (userId) REFERENCES Users (userId)
);

CREATE TABLE Editions (
  edNumber INT PRIMARY KEY,
  managerId INT,
  FOREIGN KEY (managerId) REFERENCES StudyFieldManager (managerId)
);

CREATE TABLE FinalTheses (
  finalThesisId INT PRIMARY KEY,
  deliveryDeadline DATE,
  participantId INT,
  lecturerId INT,
  FOREIGN KEY (participantId) REFERENCES Participants (participantId),
  FOREIGN KEY (lecturerId) REFERENCES Lecturers (lecturerId)
);

-- formularz zg³oszenia
CREATE TABLE SubmissionTheses (
  submissionId INT PRIMARY KEY,
  thesisTopic VARCHAR(2048),
  topicNumber INT, -- max 5 cyfr
  thesisObjectives VARCHAR(2048),
  thesisScope VARCHAR(2048),
  submissionStatus INT,
  finalThesisId INT,
  edNumber INT,
  FOREIGN KEY (finalThesisId) REFERENCES FinalTheses (finalThesisId),
  FOREIGN KEY (edNumber) REFERENCES Editions (edNumber)
);

-- formularz recenzji pracy koñcowej
CREATE TABLE FinalThesesReview (
  formId INT PRIMARY KEY,
  titleCompability VARCHAR(128),
  thesisStructureComment VARCHAR(128),
  newProblem VARCHAR(128),
  sourcesUse VARCHAR(128),
  formalWorkSide VARCHAR(256),
  wayToUse VARCHAR(256),
  substantiveThesisGrade VARCHAR(2048),
  thesisGrade VARCHAR(15),
  formDate DATE,
  formStatus INT,
  finalThesisId INT,
  FOREIGN KEY (finalThesisId) REFERENCES FinalTheses (finalThesisId)
);

CREATE TABLE FinalExams (
  examId INT PRIMARY KEY,
  examDate DATE,
  classroom VARCHAR(15),
  managerId INT,
  FOREIGN KEY (managerId) REFERENCES StudyFieldManager (managerId)
);

CREATE TABLE Questions (
  questionId INT PRIMARY KEY,
  content VARCHAR(1023),
  points INT,
  answer VARCHAR(2047),
  examId INT,
  FOREIGN KEY (examId) REFERENCES FinalExams (examId)
);

CREATE TABLE Courses (
  courseId VARCHAR(15) PRIMARY KEY,
  courseName VARCHAR(63),
  ectsPoints INT,
  semester INT,
  edNumber INT,
  lecturerId INT,
  FOREIGN KEY (edNumber) REFERENCES Editions (edNumber),
  FOREIGN KEY (lecturerId) REFERENCES Lecturers (lecturerId)
);

CREATE TABLE ClassesUnits (
  classUnitId INT PRIMARY KEY,
  classBeginning DATETIME,
  classEnding DATETIME,
  classroomNumber VARCHAR(31),
  classForm INT,
  courseId VARCHAR(15),
  lecturerId INT,
  FOREIGN KEY (courseId) REFERENCES Courses (courseId),
  FOREIGN KEY (lecturerId) REFERENCES Lecturers (lecturerId)
);

-- obecnoœci studentów na zajeciach
CREATE TABLE Attendances (
  participantId INT,
  classUnitId INT,
  FOREIGN KEY (participantId) REFERENCES Participants (participantId),
  FOREIGN KEY (classUnitId) REFERENCES ClassesUnits (classUnitId)
);

-- lista ocen uczestnika z kursu
CREATE TABLE ParticipantGradeLists (
	participantGradeListId INT PRIMARY KEY
);

-- ocena cz¹stkowa
CREATE TABLE PartialCourseGrades (
  partialGradeId INT PRIMARY KEY,
  gradeDate DATE,
  gradeValue VARCHAR(15),
  comment VARCHAR(255),
  participantGradeListId INT,
  FOREIGN KEY (participantGradeListId) REFERENCES ParticipantGradeLists (participantGradeListId)
);

-- po³¹czenie miêdzy uczestnik - kurs
CREATE TABLE ParticipantsWithCourses (
	participantId INT,
	courseId VARCHAR(15),
	participantGradeListId INT,
	FOREIGN KEY (participantId) REFERENCES Participants (participantId),
	FOREIGN KEY (courseId) REFERENCES Courses (courseId),
	FOREIGN KEY (participantGradeListId) REFERENCES ParticipantGradeLists (participantGradeListId)
);


SELECT * FROM FinalExams FE JOIN StudyFieldManager SFM ON FE.managerId = SFM.managerId JOIN Editions ED ON ED.managerId = SFM.managerId WHERE ED.number = 0 AND SFM.managerId = 0
