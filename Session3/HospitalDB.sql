create database General_Hospital

use General_Hospital

create table Drug
(
	code int primary key ,
	RecDosage varchar(25)
)

create table Drug_Brand (
	code int , 
	Brand varchar(20) ,
	constraint c1 foreign key(code) references Drug(code) ,
	constraint c2  primary key(code, Brand)
)

create table Consultant
(
	ID int primary key identity(1,1) , 
	Name varchar(20) not null
)

create table Nurse
(
	ID int primary key identity(1,1) , 
	Name varchar(20) not null ,
	ward_ID int 
)

create table Ward
(
	ID int primary key identity(1,1) , 
	Name varchar(20) not null ,
	SuperNurse_ID int  , 
	constraint c10 foreign key(SuperNurse_ID) references Nurse(ID)
)

alter table Nurse add constraint c12 foreign key(ward_ID) references Ward(ID)

create table patient
(
	ID int primary key identity(1,1) , 
	Name varchar(20) not null,
	DOB date , 
	consultant_ID int , 
	Ward_ID int ,
	constraint c13 foreign key(consultant_ID) references Consultant(ID) ,
	constraint c14 foreign key(Ward_ID) references Ward(ID)
)

create table Examine
(
	Patient_ID int , 
	Consultant_ID int ,
	Primary key(Patient_ID , Consultant_ID) , 
	constraint c6 foreign key(consultant_ID) references Consultant(ID) , 
	constraint c7 foreign key(Patient_ID) references Patient(ID)
)

create table Gives
(
	Patient_ID int , 
	Nurse_ID int , 
	Drag_code int , 
	Date date , 
	Time time , 
	Dosage varchar(20) , 
	primary key(Patient_ID , Date , Time ) , 
	constraint c21 foreign key(Patient_ID ) references Patient(ID) , 
	constraint c22 foreign key(Nurse_ID ) references Nurse(ID) , 
	constraint c23 foreign key(Drag_code ) references Drug(code) , 
)
