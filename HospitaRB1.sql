create table Autorization_users
(
Id_users int not null identity,
email nvarchar(50),
password_users nvarchar(16),
isenable bit,
constraint CS_FK1 primary key (Id_users))



 create table HospitalInfo
 (
 Id_hospital int not null identity,
 name_hospital nvarchar(70),
 city_hospital nvarchar(20),
 adress_hospital nvarchar(50),
 id_fk_autorization int not null,
 constraint CS_FK2 primary key (Id_hospital),
 constraint CS_FK4 foreign key (id_fk_autorization) references Autorization_users(Id_users))



create table RegistrationPatient
(
Id_patient int not null identity ,
name_patient nvarchar(70),
pol nvarchar(10),
side nvarchar(3),
birthday nvarchar(10),
adress_patient nvarchar(70),
numberPhone_patient nvarchar(14),
constraint CS_FK3 primary key (Id_patient))


--select * from RegistrationPatient
--go
--create view RegPatientView
--as
--select Id_patient as 'Номер_по_журналу', name_patient as 'ФИО_пациента', birthday as 'Дата_рождения', adress_patient as 'Адрес_пациента', numberPhone_patient as 'Номер_телефона_пациента'
--from RegistrationPatient
--go

create table TicketList
( 
Id_ticket int not null identity,
number int,
FIO_patient nvarchar(70),
FIO_doctor nvarchar(70),
Pol nvarchar(10),
Old int,
Job_patient nvarchar(50),
Other nvarchar(50) null,
Specialty_doctor nvarchar(30),
Code_diseases nvarchar(10),
Date_vidachi date null,
Start_date_disease date,
End_date_disease date null,
id_fk_side int,
constraint CS_FK5 primary key (Id_ticket),
constraint CS_FK6 foreign key (id_fk_side) references RegistrationPatient(Id_patient))


create table NextDate
(
Id_next int not null identity,
next_number int,
fio_doctor nvarchar(70),
soec_doctor nvarchar(50),
star_date date null,
end_date date null,
close_date date null,
id_fk_next int,
constraint CS_FK8 primary key (Id_next),
constraint CS_FK7 foreign key (id_fk_next) references TicketList(Id_ticket))


create database GGG

