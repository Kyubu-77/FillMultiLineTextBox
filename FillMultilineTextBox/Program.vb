Imports System
Imports GemBox.Pdf
Imports GemBox.Pdf.Forms

Module Program
    Sub Main(args As String())
        'Using limited key here leads to "Free version limitation has been exceeded (Free version is limited to 2 pages). ..." error. 
        'Bug reproducible with normal key
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Fill_Multiline_Text_Box()
        Console.WriteLine("Done!")

    End Sub



    Function Fill_Multiline_Text_Box() As Integer
        Using document = PdfDocument.Load("..\..\..\Sample_Short.pdf")
            'Test with CR LF and CRLF

            Dim new_Test As String = "LineA" & Chr(13) & "Line2" & Chr(10) & "Line3" & vbCrLf & "Line4"
            'fill Textfeld 81 which shows the error
            Dim formField As PdfField = document.Form.Fields("Textfeld 81")
            Dim tmp As PdfTextField = formField
            tmp.Value = new_Test


            document.Save("..\..\..\Sample_Short_Filled.pdf")
            document.Close()
        End Using
        Return 0
    End Function

End Module
