Imports System.ComponentModel
Imports System.ComponentModel.Composition

Public Interface IExtensionMetadata
    <DefaultValue("No Name")> _
    ReadOnly Property Name As String

    <DefaultValue("No Author")> _
    ReadOnly Property Author As String

    <DefaultValue("?")> _
    ReadOnly Property Version As String

    <DefaultValue("No Description")> _
    ReadOnly Property Description As String

End Interface

<MetadataAttribute> _
Public Class ExtensionMetadataAttribute : Inherits Attribute
    Property Name As String
    Property Author As String
    Property Version As String
    Property Description As String

    Sub New(Author As String, Name As String, Description As String, Version As String)
        Me.Name = Name
        Me.Author = Author
        Me.Description = Description
        Me.Version = Version
    End Sub
End Class