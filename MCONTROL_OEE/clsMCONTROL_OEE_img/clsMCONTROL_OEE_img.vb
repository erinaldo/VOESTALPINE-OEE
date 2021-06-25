Imports System
Imports System.Text
Imports System.Reflection
Imports System.Globalization
Imports System.Drawing
Imports System.Collections
Imports System.IO
Imports System.Windows.Forms
Public Class clsMCONTROL_OEE_img

    Private Shared nameSp As String = ""
    Private Shared nameSpaceLenght As Integer
    Private Function GetImageNames() As String()

        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()

        nameSp = a.GetName().Name.ToString
        nameSpaceLenght = nameSp.Length + 1
        Return a.GetManifestResourceNames()

    End Function
    Public Function GetImage(ByVal resourceName As String) As Image

        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim my_namespace As String = a.GetName().Name.ToString

        Try

            Dim stream As Stream = a.GetManifestResourceStream(my_namespace + "." + resourceName)
            Return DirectCast(Bitmap.FromStream(stream), Bitmap)

        Catch ex As Exception

            Return Nothing

        End Try

    End Function
    Public Function GetIcon(ByVal resourceName As String) As Icon

        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim my_namespace As String = a.GetName().Name.ToString

        Try

            Dim stream As Stream = a.GetManifestResourceStream(my_namespace + "." + resourceName)
            Return DirectCast(New Drawing.Icon(stream), Icon)

        Catch ex As Exception

            Return Nothing

        End Try

    End Function
    Public Function FileList() As ArrayList

        Dim arrayFile As New ArrayList
        Dim AllFiles() As String = GetImageNames()

        For Each fname As String In AllFiles
            fname = Trim(fname.Remove(0, nameSpaceLenght))
            arrayFile.Add(fname)
        Next
        Return arrayFile

    End Function

End Class
