'*************************************************************************************
'  File Name           : QueryService.vb
'  File Description    : This file will contain all the webmethods required
'                               for any type of queries
'  Date Created        : July 28, 2006
'  Author              : Tata Consultancy Services
' ---------------------------------------------------------------------------------
'  Change History      
'  Date Modified       : 
'  Changed By          :
'  Change Description  : 
'
'*************************************************************************************

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml
Imports eHIS.AHC.BusinessAudit
Imports eHIS.AHC.Business.Process
Imports eHIS.AHC.Utility
Imports eHIS.AHC.DataAccess
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
        Dim result As String = Nothing
        Dim response As String
        Dim request As String
        Dim objAHCRequestProcessor As RequestProcessor
        Try
            response = String.Empty
            result = String.Empty
            request = requestXml.InnerXml
            objAHCRequestProcessor = New RequestProcessor
            'AHCUtility.Log("entered in Query service")
            objAHCRequestProcessor.ProcessQueryRequest(request, response)
            'AHCUtility.Log("after processing Query Request")
            If Not (response = String.Empty) Then
                result = response
            End If
        Catch ex As Exception
            AHCUtility.Log("QueryService.QueryDetails Message : " & ex.Message.ToString)
            AHCUtility.Log("QueryService.QueryDetails StackTrace : " & ex.StackTrace.ToString)
            Throw ex
        End Try
        
        Return result
    End Function


    <WebMethod()> _
     Public Function SearchQueryDetails(ByVal SystemType As Integer) As DataSet
        Dim resultSet As DataSet
        Dim objQueryServiceProvider As New eHIS.AHC.Business.QueryServiceProvider
        Try
            resultSet = objQueryServiceProvider.GetSystem(SystemType)
            Return resultSet
        Catch objException As Exception
            AHCUtility.Log("QueryService.SearchQueryDetails Message : " & objException.Message.ToString)
            AHCUtility.Log("QueryService.SearchQueryDetails StackTrace : " & objException.StackTrace.ToString)
            Throw objException
        Finally

            objQueryServiceProvider = Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function SearchLOVDetails(ByVal lovCode As String) As DataSet
        Dim resultSet As DataSet
        Dim objQueryServiceProvider As New eHIS.AHC.Business.QueryServiceProvider()
        Try
            resultSet = objQueryServiceProvider.GetLOVDetail(lovCode)
            Return resultSet
        Catch objException As Exception
            AHCUtility.Log("QueryService.SearchLOVDetails Message : " & objException.Message.ToString)
            AHCUtility.Log("QueryService.SearchLOVDetails StackTrace : " & objException.StackTrace.ToString)
            Throw objException
        Finally

            objQueryServiceProvider = Nothing
        End Try
    End Function

    <WebMethod()> _
   Public Function SearchAHCPACKAGEDEPARTMENTS(ByVal AHCNo As String, ByVal LocationId As Integer) As DataSet
        Dim resultSet As DataSet
        Dim objQueryServiceProvider As New eHIS.AHC.Business.QueryServiceProvider
        Try
            resultSet = objQueryServiceProvider.GETAHCPACKAGEDEPARTMENTS(AHCNo, LocationId)
            Return resultSet
        Catch objException As Exception
            AHCUtility.Log("QueryService.SearchAHCPACKAGEDEPARTMENTS Message : " & objException.Message.ToString)
            AHCUtility.Log("QueryService.SearchAHCPACKAGEDEPARTMENTS StackTrace : " & objException.StackTrace.ToString)
            Throw objException
        Finally

            objQueryServiceProvider = Nothing
        End Try
    End Function

    <WebMethod()> _
 Public Function SearchAHCDetails(ByVal AHCNo As String, ByVal LocationId As Integer) As DataSet
        Dim resultSet As DataSet
        Dim objQueryServiceProvider As New eHIS.AHC.Business.QueryServiceProvider
        Try
            resultSet = objQueryServiceProvider.GetAHCDetails(LocationId, AHCNo)
            Return resultSet
        Catch objException As Exception
            AHCUtility.Log("QueryService.SearchAHCDetails Message : " & objException.Message.ToString)
            AHCUtility.Log("QueryService.SearchAHCDetails StackTrace : " & objException.StackTrace.ToString)
            Throw objException
        Finally

            objQueryServiceProvider = Nothing
        End Try
    End Function
    <WebMethod()> _
      Public Function SearchSystemSymptom(ByVal SystemType As Integer, ByVal ChiefComplaint As Integer) As DataSet
        Dim resultSet As DataSet
        Dim objQueryServiceProvider As New eHIS.AHC.Business.QueryServiceProvider
        Try
            resultSet = objQueryServiceProvider.GetSystemSymptom(SystemType, ChiefComplaint)
            Return resultSet
        Catch objException As Exception
            AHCUtility.Log("QueryService.SearchSystemSymptom Message : " & objException.Message.ToString)
            AHCUtility.Log("QueryService.SearchSystemSymptom StackTrace : " & objException.StackTrace.ToString)
            Throw objException
        Finally

            objQueryServiceProvider = Nothing
        End Try
    End Function
   
End Class
