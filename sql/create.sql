
-- ************************************** [members]

CREATE TABLE [members]
(
 [ID]          int IDENTITY (1, 1) NOT NULL ,
 [UserName]    varchar(50) NOT NULL ,
 [Password]    varchar(20) NOT NULL ,
 [About]       varchar(200) NULL ,
 [IsAdmin]     bit NULL ,
 [MemberSince] datetime NOT NULL , 


 CONSTRAINT [PK_members] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO


-- ************************************** [locations]

CREATE TABLE [locations]
(
 [ID]     int IDENTITY (1, 1) NOT NULL ,
 [Name]   varchar(50) NOT NULL ,
 [Region] varchar(50) NOT NULL ,


 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO


-- ************************************** [hazards]

CREATE TABLE [hazards]
(
 [ID]          int IDENTITY (1, 1) NOT NULL ,
 [LocationID]  int NOT NULL ,
 [Status]      int NOT NULL ,
 [TimeOf]      datetime NOT NULL ,
 [Description] varchar(50) NOT NULL ,


 CONSTRAINT [PK_hazards] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_56] FOREIGN KEY ([LocationID])  REFERENCES [locations]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_56] ON [hazards] 
 (
  [LocationID] ASC
 )

GO


-- ************************************** [comments]

CREATE TABLE [comments]
(
 [ID]          int IDENTITY (1, 1) NOT NULL ,
 [CommenterID] int NOT NULL ,
 [HazardID]  int NOT NULL ,
 [Content]     text NOT NULL ,
 [TimeOf]      datetime NOT NULL ,


 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_17] FOREIGN KEY ([CommenterID])  REFERENCES [members]([ID]),
 CONSTRAINT [FK_53] FOREIGN KEY ([HazardID])  REFERENCES [hazards]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_17] ON [comments] 
 (
  [CommenterID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_53] ON [comments] 
 (
  [HazardID] ASC
 )

GO












