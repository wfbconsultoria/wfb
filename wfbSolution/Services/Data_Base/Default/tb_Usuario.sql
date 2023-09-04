/****** Criar tabela de usuários  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tb_Usuario](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[Sobrenome] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Ddd] [char](2) NULL,
	[Celular] [varchar](11) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Cep] [char](8) NULL,
	[Endereco] [varchar](70) NULL,
	[Numero] [varchar](5) NULL,
	[Complemento] [varchar](100) NULL,
	[Bairro] [varchar](70) NULL,
	[Cidade] [varchar](50) NULL,
	[Uf] [varchar](50) NULL,
	[CodigoAcesso] [varchar](50) NOT NULL,
	[Valido] [tinyint] NOT NULL CONSTRAINT [DF_tb_Users_Valido]  DEFAULT ((0)),
	[Sessao] [varchar](100) NULL CONSTRAINT [DF_tb_Usuario_Sessao]  DEFAULT ((0)),
	[UltimoAcesso] [datetime] NULL,
 CONSTRAINT [PK_tb_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


