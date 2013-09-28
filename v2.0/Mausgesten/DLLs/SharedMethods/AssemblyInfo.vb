Imports System.Reflection
Imports ExtensionContract

Public Class AssemblyInfo
    Property Extension As Lazy(Of IExtensionContract)

    Sub New(Extension As Lazy(Of IExtensionContract))
        Me.Extension = Extension
    End Sub

    ReadOnly Property Name As String
        Get
            Return Extension.Value.[GetType]().Assembly.GetName().Name
        End Get
    End Property

    ReadOnly Property Author As String
        Get
            Return DirectCast(
            Extension.Value.[GetType]().Assembly.GetCustomAttributes(
                GetType(AssemblyCompanyAttribute), False).First, 
                AssemblyCompanyAttribute).Company
        End Get
    End Property

    ReadOnly Property Version As String
        Get
            Return Extension.Value.[GetType]().Assembly.GetName().Version.ToString()
        End Get
    End Property

    ReadOnly Property Description As String
        Get
            Return DirectCast(
            Extension.Value.[GetType]().Assembly.GetCustomAttributes(
                GetType(AssemblyDescriptionAttribute), False).First, 
                AssemblyDescriptionAttribute).Description
        End Get
    End Property

    ReadOnly Property ExtensionIDRoot As String
        Get
            Return Author & "." & Name
        End Get
    End Property
End Class
