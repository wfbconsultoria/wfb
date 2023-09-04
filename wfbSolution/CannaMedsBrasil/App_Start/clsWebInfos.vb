Imports System.Net
Imports System.IO
Imports System.Xml


Public Class clsWebInfos
    'Propriedades WEB E da Sessão
    Public Property Ip() As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString
    Public Property Ip2() As String
    Public Property IpCountryCode As String = ""
    Public Property IpCountry As String = ""
    Public Property IpState As String = ""
    Public Property IpCity As String = ""
    Public Property IpLatitude As String = ""
    Public Property IpLongitude As String = ""
    Public Property IpZip As String = ""
    Public Property IpTimeZone As String = ""
    Public Property IpStatusCode As String = ""
    Public Property IpStatusMessage As String = ""
    Public Property WebBrowser As String = HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT").ToString
    Public Property WebSessionId As String = ""

    Public Sub GetWebInfos()

        Dim KEY As String = ConfigurationManager.AppSettings("App.IpInfo.apiKey").ToString
        Dim sIP As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString
        Dim sFormat As String = "xml"
        Dim sUrl As String = "http://api.ipinfodb.com/v3/ip-city/?key=" & KEY & "&ip=" & sIP & "&format=" & sFormat
        Dim request As HttpWebRequest = CType(WebRequest.Create(sUrl), HttpWebRequest)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Dim stream As Stream = response.GetResponseStream()
        Dim xml As XmlDocument = New XmlDocument()
        xml.Load(stream)
        Dim nodeRoot As XmlNode = xml.DocumentElement

        Try
            For Each xn As XmlNode In nodeRoot

                Ip2 = xn.ParentNode("ipAddress").InnerText
                IpStatusCode = xn.ParentNode("statusCode").InnerText
                IpStatusMessage = xn.ParentNode("statusMessage").InnerText
                IpCountryCode = xn.ParentNode("countryCode").InnerText
                IpCountry = xn.ParentNode("countryName").InnerText
                IpState = xn.ParentNode("regionName").InnerText
                IpCity = xn.ParentNode("cityName").InnerText
                IpZip = xn.ParentNode("zipCode").InnerText
                IpLatitude = xn.ParentNode("latitude").InnerText
                IpLongitude = xn.ParentNode("longitude").InnerText
                IpTimeZone = xn.ParentNode("timeZone").InnerText
            Next
            WebBrowser = HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT").ToString()
            WebSessionId = HttpContext.Current.Session.SessionID.ToString
        Catch ex As Exception
            Ip = "WEb Info Error"
            Ip2 = "WEb Info Error"
            IpStatusCode = "WEb Info Error"
            IpStatusMessage = "WEb Info Error"
            IpCountryCode = "WEb Info Error"
            IpCountry = "WEb Info Error"
            IpState = "WEb Info Error"
            IpCity = "WEb Info Error"
            IpZip = "WEb Info Error"
            IpLatitude = "WEb Info Error"
            IpLongitude = "WEb Info Error"
            IpTimeZone = "WEb Info Error"
            WebBrowser = "WEb Info Error"
            WebSessionId = "WEb Info Error"
        End Try

    End Sub

End Class
