Imports System.IO
Imports System.Xml
Imports System.Reflection
Imports System.Globalization

Public Class PrepareMenu
    Const MultiLanguage As Boolean = True
    Public Shared Function Prepare(YourAssembly As Assembly) As Xml.XmlDocument
        Try
            Dim currentculture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName

            Dim Path As String = "Menus.xml"
            If MultiLanguage Then
                If YourAssembly.GetManifestResourceNames.Any(Function(Name) Name.Contains(String.Format("Menus-{0}.xml", currentculture))) Then
                    Path = String.Format("Menus-{0}.xml", currentculture)
                End If
            End If


            Dim MenuReader As New StreamReader(
                        YourAssembly.GetManifestResourceStream(
                            String.Format("{0}.{1}", YourAssembly.GetName.Name, Path)))

            Dim xmlDoc As New Xml.XmlDocument
            xmlDoc.LoadXml(MenuReader.ReadToEnd)

            For Each Menu As XmlNode In xmlDoc.SelectNodes("//Menu")
                Dim Action As String = Menu.Attributes("Action").Value
                If Not Action = "" Then Menu.Attributes("Action").Value = String.Format("{0}.{1}.{2}",
                    DirectCast(YourAssembly.GetCustomAttributes(GetType(AssemblyCompanyAttribute), False).First, AssemblyCompanyAttribute).Company,
                    YourAssembly.GetName.Name,
                    Action)
            Next

            Return xmlDoc
        Catch ex As Exception
            Throw New Exception(String.Format("Couldn't load UI of {0}.",
                                              YourAssembly.GetName.Name))
        End Try

    End Function
End Class
