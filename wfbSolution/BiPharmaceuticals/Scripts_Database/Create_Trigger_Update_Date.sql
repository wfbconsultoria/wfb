
/****** Script para criar Trigger de update para data de atualização******/
CREATE TRIGGER tg_Update_Date_tb_Template2
ON _tb_Template2
AFTER  UPDATE
AS
BEGIN
SET NOCOUNT ON;
update _tb_Template2
set Update_Date = dbo.getdate2()
where
ID = (select i.Id from inserted i)
END