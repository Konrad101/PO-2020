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

CREATE TABLE SubmittingTheses (
  submittingId INT PRIMARY KEY,
  lecturerId INT,
  thesisTopic VARCHAR(2048),
  topicNumber INT, -- max 5
  thesisObjectives VARCHAR(2048),
  thesisScope VARCHAR(2048),
  FOREIGN KEY (lecturerId) REFERENCES Lecturers (lecturerId)
);

CREATE TABLE StudyFieldManagerSubmittings (
  managerId INT,
  submittingId INT,
  FOREIGN KEY (managerId) REFERENCES StudyFieldManager (managerId),
  FOREIGN KEY (submittingId) REFERENCES SubmittingTheses (submittingId)
);


CREATE TABLE FinalThesisForms (
  formId INT PRIMARY KEY,
  thesisTopic VARCHAR(2048),
  participantData VARCHAR(128),
  titleCompability VARCHAR(128),
  thesisStructureComment VARCHAR(128),
  newProblem VARCHAR(128),
  sourcesUse VARCHAR(128),
  sourcesCharacteristics VARCHAR(256),
  formalWorkSide VARCHAR(256),
  substantiveThesisGrade VARCHAR(2048),
  thesisGrade VARCHAR(16),
  formDate DATE
);

CREATE TABLE LecturerForms (
  lecturerId INT,
  submittingId INT,
  FOREIGN KEY (lecturerId) REFERENCES Lecturers (lecturerId),
  FOREIGN KEY (submittingId) REFERENCES SubmittingTheses (submittingId)
);


CREATE TABLE Editions (
  number INT PRIMARY KEY
);


CREATE TABLE FinalExams (
  examId INT PRIMARY KEY,
  examDate DATE,
  classroom VARCHAR(15),
  examCourse VARCHAR(127)
);

CREATE TABLE StudyFieldManagerExams (
  managerId INT,
  examId INT,
  FOREIGN KEY (managerId) REFERENCES StudyFieldManager (managerId),
  FOREIGN KEY (examId) REFERENCES FinalExams (examId)
);


CREATE TABLE Courses (
  courseId VARCHAR(15) PRIMARY KEY,
  courseName VARCHAR(63),
  ectsPoints INT,
  semester INT
);

CREATE TABLE ClassesUnits (
  classUnitId INT PRIMARY KEY,
  classBeginning DATE,
  classEnding DATE,
  classroomNumber VARCHAR(31),
  courseId INT,
  FOREIGN KEY (courseId) REFERENCES Courses (courseId)
);

CREATE TABLE Attendances (
  participantId INT,
  classUnitId INT,
  FOREIGN KEY (participantId) REFERENCES Participants (participantId),
  FOREIGN KEY (classUnitId) REFERENCES ClassesUnits (classUnitId)
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


