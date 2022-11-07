' The following settings must be added to your configuration file in order for 
' the new Indigo item added to your project to work correctly.

' <system.serviceModel>
'    <services>
'      <!-- Before deployment, you should remove the returnFaults behavior configuration to avoid disclosing information in exception messages -->
'      <service name=".MMManager" behaviorConfiguration="returnFaults">
'        <endpoint contract=".IMMManager" binding="wsHttpBinding"/>
'      </service>
'    </services>
'    <behaviors>
'      <serviceBehaviors>
'        <behavior name="returnFaults" >
'          <serviceDebug includeExceptionDetailInFaults="true" />
'        </behavior>
'       </serviceBehaviors>
'    </behaviors>
' </system.serviceModel>

' A WCF service consists of a contract (defined below), 
' a class which implements that interface, and configuration 
' entries that specify behaviors and endpoints associated with 
' that implementation (see <system.serviceModel> in your application
' configuration file).

Imports System
Imports System.ServiceModel

<ServiceContract()> _
Public Interface IPharmacyManager1

    <OperationContract()> _
    Function MyOperation1(ByVal myValue As String) As String

End Interface

Public Class PharmacyManager
    Implements IPharmacyManager1

    Public Function MyOperation1(ByVal myValue As String) As String Implements IPharmacyManager1.MyOperation1
        Return "Hello: " + myValue
    End Function

End Class