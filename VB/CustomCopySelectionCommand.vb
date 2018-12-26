Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.Office.Utils
Imports DevExpress.XtraRichEdit.API.Native
Imports System.Text

Namespace RichEditCustomCopyPaste
    Public Class CustomCopySelectionCommand
        Inherits CopySelectionCommand

        Public Sub New(ByVal control As IRichEditControl)
            MyBase.New(control)
        End Sub

        Private Sub Iterate(ByVal visitor As IDocumentVisitor, ByVal documentRange As DocumentRange)
            Dim iterator As New DocumentIterator(documentRange, True)
            Do While iterator.MoveNext()
                iterator.Current.Accept(visitor)
            Loop
        End Sub

        Protected Overrides Sub ExecuteCore()
            Dim richEditControl As RichEditControl = CType(Control, RichEditControl)
            Dim range As DocumentRange = richEditControl.Document.Selection

            Dim visitor As New PlainTextVisitor()
            Iterate(visitor, range)
            Dim plainText As String = visitor.Text

            Dim data As New DataObject()
            data.SetData(OfficeDataFormats.UnicodeText, plainText)
            data.SetData(OfficeDataFormats.Rtf, richEditControl.Document.GetRtfText(range))
            Clipboard.Clear()
            Clipboard.SetDataObject(data, False)
        End Sub
    End Class

    Public Class PlainTextVisitor
        Inherits DocumentVisitorBase

        Private ReadOnly buffer As StringBuilder
        Public ReadOnly Property Text() As String
            Get
                Return buffer.ToString()
            End Get
        End Property

        Public Sub New()
            Me.buffer = New StringBuilder()
        End Sub
        Public Overrides Sub Visit(ByVal cellBorder As DocumentTableCellBorder)
            Dim isFirstInRow As Boolean = cellBorder.TableCellBorderProperties.IsFirstInRow
            Dim isLastInTable As Boolean = cellBorder.TableCellBorderProperties.IsLastInTable
            If Not isFirstInRow AndAlso Not isLastInTable Then
                buffer.Length -= 2
                buffer.Append(vbTab)
            End If

            MyBase.Visit(cellBorder)
        End Sub
        Public Overrides Sub Visit(ByVal paragraphEnd As DocumentParagraphEnd)
            buffer.AppendLine()
            MyBase.Visit(paragraphEnd)
        End Sub
        Public Overrides Sub Visit(ByVal text As DocumentText)
            buffer.Append(text.Text)
            MyBase.Visit(text)
        End Sub
    End Class

End Namespace