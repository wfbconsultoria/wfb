
Public Class clsPlanner
    ReadOnly m As New clsMaster
    Public Function sql_Calendario_Mes(ANO As String, MES As String, Optional DIA As Integer = 0) As String
        sql_Calendario_Mes = ""
        sql_Calendario_Mes &= "Select "
        sql_Calendario_Mes &= "DATAS.DATA_ID, DATAS.ANO, DATAS.MES, DATAS.DIA,"
        sql_Calendario_Mes &= "DATAS.DIA_SEMANA, DATAS.SEMANA_MES, DATAS.SEMANA_ANO,"
        sql_Calendario_Mes &= "DATAS.ULTIMO_DIA_MES, DATAS.ULTIMA_SEMANA_MES,"
        sql_Calendario_Mes &= "PLANNER.LOJA_SIGLA, PLANNER.EMAIL, PLANNER.PLANNER_SIGLA "
        sql_Calendario_Mes &= " From "
        sql_Calendario_Mes &= "(Select DATA_ID, ANO,MES,DIA, DIA_SEMANA, SEMANA_MES, SEMANA_ANO, ULTIMO_DIA_MES, ULTIMA_SEMANA_MES From TBL_DATAS "
        sql_Calendario_Mes &= "Where "
        sql_Calendario_Mes &= "(ANO = " & ANO & ") And (MES = " & MES & ") "
        If DIA > 0 Then sql_Calendario_Mes &= " and (DIA = " & DIA & ") "
        sql_Calendario_Mes &= ") as DATAS "
        sql_Calendario_Mes &= "Left OUTER JOIN "
        sql_Calendario_Mes &= "(Select LOJA_SIGLA,EMAIL,PLANNER_SIGLA, DATA_ID From TBL_PLANNER "
        sql_Calendario_Mes &= "Where (EMAIL = '" & HttpContext.Current.Session("EMAIL_LOGIN").ToString & "') "
        sql_Calendario_Mes &= " and (LOJA_SIGLA = '" & HttpContext.Current.Session("LOJA_SIGLA").ToString & "') "
        sql_Calendario_Mes &= ") as PLANNER "
        sql_Calendario_Mes &= "On DATAS.DATA_ID = PLANNER.DATA_ID "
        sql_Calendario_Mes &= "ORDER BY DATAS.DATA_ID"
    End Function

    Public Function Recupera_Sigla(ANO As String, MES As String, DIA As Integer) As String
        Recupera_Sigla = "0"
        Dim dtr As Data.SqlClient.SqlDataReader = m.ExecuteSelect(sql_Calendario_Mes(ANO, MES, DIA))
        If dtr.HasRows Then
            dtr.Read()
            Recupera_Sigla = dtr("PLANNER_SIGLA")
        End If
    End Function

End Class
