Imports System
Imports System.ComponentModel.Composition
Imports System.ComponentModel


Public Interface IExtensionContract
    Function GetUI() As Xml.XmlDocument
    Sub Loaded()
    'Sub Action(ByVal ID As String)
    Sub Action(ByVal ID As String, ByVal e As ActionEventArgs)
    Function Closing()
    Sub Pause()
    Sub Reactivate()
End Interface
