using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Services;
using System.Text;
using DevExpress.XtraRichEdit.API.Native;


namespace RichEditCustomCopyPaste {
    public partial class Form1 : Form {
        
        public Form1() {
            InitializeComponent();

            CustomRichEditCommandFactoryService commandFactory = new CustomRichEditCommandFactoryService(richEditControl1, richEditControl1.GetService<IRichEditCommandFactoryService>());
            richEditControl1.RemoveService(typeof(IRichEditCommandFactoryService));
            richEditControl1.AddService(typeof(IRichEditCommandFactoryService), commandFactory);
            richEditControl1.LoadDocument("testDocument.docx");
        }
    }

    public class CustomRichEditCommandFactoryService : IRichEditCommandFactoryService {
        readonly IRichEditCommandFactoryService service;
        readonly RichEditControl control;

        public CustomRichEditCommandFactoryService(RichEditControl control, IRichEditCommandFactoryService service) {
            DevExpress.Utils.Guard.ArgumentNotNull(control, "control");
            DevExpress.Utils.Guard.ArgumentNotNull(service, "service");
            this.control = control;
            this.service = service;
        }

        public RichEditCommand CreateCommand(RichEditCommandId id) {
            if (id == RichEditCommandId.CopySelection )
                return new CustomCopySelectionCommand(control);

            return service.CreateCommand(id);
        }
    }

   
}