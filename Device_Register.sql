use DeviceRegister

alter table AdsInfo

create table AdsInfo(
AdsId int primary key identity,
YoutubeURL varchar(50),
Gender varchar(20),
AddedOn datetime,
ExpiredOn datetime
);

create table Adslocation(
locationId int primary key identity,
AdsId int references AdsInfo(AdsId),
BusinessLocation varchar(20)
);


create table AdMapping(
MappingId int primary key identity,
AdsId int references AdsInfo(AdsId),
DeviceId int references DeviceDetail(deviceId)

);

insert into AdsInfo values ('url123','male',2022-12-28,2022-12-29);

insert into Adslocation values(1,'delhi')

insert into Adslocation values(1,'mumbai')