drop table [dbo].[StudyHours];
drop table [dbo].[Module];
drop table [dbo].[Semester];
drop table [dbo].[Student];

create table Student (
	StudentNum varchar(10) primary key not null,
	[Name] varchar(50) not null,
	[Password] varchar(max) not null
);

create table Semester (
	SemesterID varchar(60) primary key not null,
	SemesterName varchar(50) not null,
	NumWeeks int not null,
	StartDate datetime not null,
	EndDate datetime not null,
	StudentNum varchar(10) not null,
	foreign key (StudentNum) references [dbo].[Student](StudentNum) ON DELETE CASCADE
);

create table Module (
	ModuleID int identity(1,1) primary key not null,
	Code varchar(10) not null,
	[Name] varchar(50) not null,
	NumCredits int not null,
	ClassHoursPerWeek int not null,
	SelfStudyHoursPerWeek float not null,
	SemesterID varchar(60) not null,
	foreign key (SemesterID) references [dbo].[Semester](SemesterID) ON DELETE CASCADE
);

create table StudyHours (
	StudyHoursID int identity(1,1) primary key not null,
	[Week] smallint not null,
	RemainingStudyHours float not null,
	[Date] datetime not null,
	ModuleID int not null,
	foreign key (ModuleID) references [dbo].[Module](ModuleID) ON DELETE CASCADE
);

select * from [dbo].[Student];
select * from [dbo].[Semester];
select * from [dbo].[Module];
select * from [dbo].[StudyHours];

delete from [dbo].[StudyHours];
delete from [dbo].[Module];
delete from [dbo].[Semester];
delete from [dbo].[Student];