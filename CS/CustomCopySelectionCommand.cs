using System;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.Office.Utils;
using DevExpress.XtraRichEdit.API.Native;
using System.Text;

namespace RichEditCustomCopyPaste {
    public class CustomCopySelectionCommand : CopySelectionCommand {
        public CustomCopySelectionCommand(IRichEditControl control)
            : base(control) {
        }

        private void Iterate(IDocumentVisitor visitor, DocumentRange documentRange)
        {
            DocumentIterator iterator = new DocumentIterator(documentRange, true);
            while (iterator.MoveNext())
                iterator.Current.Accept(visitor);
        }
       
        protected override void ExecuteCore() {
            RichEditControl richEditControl = (RichEditControl)Control;
            DocumentRange range = richEditControl.Document.Selection;

            PlainTextVisitor visitor = new PlainTextVisitor();
            Iterate(visitor, range);
            string plainText = visitor.Text;

            DataObject data = new DataObject();
            data.SetData(OfficeDataFormats.UnicodeText, plainText);
            data.SetData(OfficeDataFormats.Rtf, richEditControl.Document.GetRtfText(range));
            Clipboard.Clear();
            Clipboard.SetDataObject(data, false);
        }
    }

    public class PlainTextVisitor : DocumentVisitorBase
    {
        readonly StringBuilder buffer;
        public string Text { get { return buffer.ToString(); } }

        public PlainTextVisitor()
        {
            this.buffer = new StringBuilder();
        }
        public override void Visit(DocumentTableCellBorder cellBorder)
        {
            bool isFirstInRow = cellBorder.TableCellBorderProperties.IsFirstInRow;
            bool isLastInTable = cellBorder.TableCellBorderProperties.IsLastInTable;
            if (!isFirstInRow && !isLastInTable)
            {
                buffer.Length -= 2;
                buffer.Append("\t");
            }
            
            base.Visit(cellBorder);
        }
        public override void Visit(DocumentParagraphEnd paragraphEnd)
        {
            buffer.AppendLine();
            base.Visit(paragraphEnd);
        }
        public override void Visit(DocumentText text)
        {
            buffer.Append(text.Text);
            base.Visit(text);
        }
    }

}