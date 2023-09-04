Imports System.Web.Optimization
Imports System.IdentityModel.Services

Public Class Global_asax
    Inherits HttpApplication

    Private Sub Application_Start(sender As Object, e As EventArgs)
        ' Código que é executado na inicialização do aplicativo
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class
