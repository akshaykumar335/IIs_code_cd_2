'*************************************************************************************
'       File Name           : QueryService.vb
'		File Description	: This file will contain all the webmethods required
'                               for any type of queries
'		Date Created		: July 28, 2006
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
'Imports eHIS.AT.BusinessAudit
Imports eHIS.AT.Business.Process
Imports eHIS.AT.Utility
Imports System.Data

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
        Dim objATRequestProcessor As RequestProcessor
        'eHIS.AT.Utility.LoggingUtility.Log("Request XMl")
        'LoggingUtility.Log(requestXml.InnerXml)
        response = String.Empty
        result = String.Empty
        request = requestXml.InnerXml
        objATRequestProcessor = New RequestProcessor
        'LoggingUtility.Log("entered in service")
        objATRequestProcessor.ProcessQueryRequest(request, response)
        'LoggingUtility.Log("after process")
        If Not (response = String.Empty) Then
            result = response
            'LoggingUtility.Log("response XMl")
            'LoggingUtility.Log(result)
        End If
        Return result
    End Function

End Class
