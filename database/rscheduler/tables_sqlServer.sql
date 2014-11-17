USE [enter_db_name_here]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[RSCHED_CUSTOM_JOBS]') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE [dbo].[RSCHED_CUSTOM_JOBS]
GO

CREATE TABLE [dbo].[RSCHED_CUSTOM_JOBS](
	[ID] [uniqueidentifier] NOT NULL,
	[NAME] [nvarchar](200) NOT NULL,
	[PARAMS] [nvarchar](max) NULL,
	[JOB_TYPE] [nvarchar](200) NOT NULL,
CONSTRAINT [PK_RSCHED_CUSTOM_JOBS] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	),
CONSTRAINT [NAME_JOBTYPE] UNIQUE NONCLUSTERED 
	(
		[NAME] ASC,
		[JOB_TYPE] ASC
	) 
)
GO