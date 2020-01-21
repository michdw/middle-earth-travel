--***this will delete all tables in the database***

ALTER TABLE [hazards] DROP CONSTRAINT [FK_56]
ALTER TABLE [comments] DROP CONSTRAINT [FK_17]
ALTER TABLE [comments] DROP CONSTRAINT [FK_53]

DROP TABLE [members];
GO

DROP TABLE [locations];
GO

DROP TABLE [hazards];
GO

DROP TABLE [comments];
GO