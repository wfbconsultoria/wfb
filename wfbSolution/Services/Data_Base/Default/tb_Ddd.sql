/****** Criar tabela de DDD's ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tb_Ddd](
	[Ddd] [char](2) NULL,
	[Ddi] [char](2) NOT NULL,
	[Uf] [char](2) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [ddd] UNIQUE NONCLUSTERED 
(
	[Ddd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

