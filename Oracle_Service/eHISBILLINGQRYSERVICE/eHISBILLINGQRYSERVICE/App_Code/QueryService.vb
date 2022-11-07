'*************************************************************************************
'       File Name           : QueryService.vb
'		File Description	: This file will contain all the webmethods required
'                               for any type of queries
'		Date Created		: May 11, 2007
'		Author			    : Tata Consultancy Services
' ---------------------------------------------------------------------------------
' 		Change History      
'		Date Modified		: 
'		Changed By		    :
'		Change Description  : 
'
'*************************************************************************************

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml
Imports eHIS.Billing.Business.Process
Imports System.Data
Imports eHIS.Billing.Utility
Imports eHIS.Billing.Exceptions
Imports System




<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class QueryService
    Inherits System.Web.Services.WebService

    '***************************************************************************************
    ' Method Description	: This WebMethod will be called for type of queries
    ' Date Created		    : July 28, 2006
    ' Author			    : Tata Consultancy Services
    '***************************************************************************************

    <WebMethod()> _
    Public Function QueryDetails(ByVal requestXml As XmlDocument) As String
        Dim result As String
        Dim response As String
        Dim request As String
        Dim objBillingRequestProcessor As RequestProcessor
        response = String.Empty
        result = String.Empty
        Try
            request = requestXml.InnerXml
            objBillingRequestProcessor = New RequestProcessor
            objBillingRequestProcessor.ProcessQueryRequest(request, response)
            If Not (response = String.Empty) Then
                result = response
            End If
        Catch ex As Exception
            LoggingUtility.Log("Queryservice.Qyuerydetails: Message : " & ex.Message.ToString())
            LoggingUtility.Log("Queryservice.Qyuerydetails: Stack Trace : " & ex.StackTrace.ToString())
        End Try
        Return result
    End Function

    <WebMethod()> _
 Public Function AHCQueryDetails(ByVal requestXml As XmlDocument) As String
        Dim result As String
        Dim response As String
        Dim request As String
        Dim objBillingRequestProcessor As RequestProcessor
        response = String.Empty
        result = String.Empty
        Try
            request = requestXml.InnerXml
            objBillingRequestProcessor = New RequestProcessor
            objBillingRequestProcessor.ProcessAHCQueryRequest(request, response)
            If Not (response = String.Empty) Then
                result = response
            End If
        Catch ex As Exception
            LoggingUtility.Log("Queryservice.AHCQueryDetails: Message : " & ex.Message.ToString())
            LoggingUtility.Log("Queryservice.AHCQueryDetails: Stack Trace : " & ex.StackTrace.ToString())
        End Try
        Return result
    End Function
End Class
