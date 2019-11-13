using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Telerik.WinForms.Documents.Model;
using Telerik.WinForms.Documents.UI;

namespace TelerikDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.radRichTextEditor1.ProviderUILayerInitialized += RadRichTextEditor1_ProviderUILayerInitialized;
            this.radRichTextEditor1.PanGesture += RadRichTextEditor1_PanGesture1;
            this.radRichTextEditor1.Document.DocumentElementAdded += Document_DocumentElementAdded;

            RadDocumentEditor documentEditor = new RadDocumentEditor(this.radRichTextEditor1.Document);
            
        }

        private void Document_DocumentElementAdded(object sender, Telerik.WinForms.Documents.Model.DocumentElementAddedEventArgs e)
        {
    
        }

        private void RadRichTextEditor1_PanGesture1(object sender, Telerik.WinControls.PanGestureEventArgs e)
        {
           
        }

        private void RadRichTextEditor1_ProviderUILayerInitialized(object sender, Telerik.WinControls.UI.ProviderUILayerInitilizedEventArgs e)
        {
            var b = e.Container;
            string bc = b.Text;
        }

        private void RadRichTextEditor1_PanGesture(object sender, Telerik.WinControls.PanGestureEventArgs e)
        {
            this.radRichTextEditor1.MouseDown += RadRichTextEditor1_MouseDown;

            RadPrintPreviewControl control = new RadPrintPreviewControl();



            RadPrintDocument radPrintDocument = new RadPrintDocument();

            
            
        }

        private void RadRichTextEditor1_MouseDown(object sender, MouseEventArgs e)
        {
            

            Telerik.WinForms.Documents.FormatProviders.Rtf.RtfFormatProvider r = new Telerik.WinForms.Documents.FormatProviders.Rtf.RtfFormatProvider();
            string c=r.Export(this.radRichTextEditor1.Document);

            var dd = r.Import(c);


            Telerik.WinForms.Documents.FormatProviders.Pdf.PdfFormatProvider p = new Telerik.WinForms.Documents.FormatProviders.Pdf.PdfFormatProvider();


            RadPrintDocument pp = new RadPrintDocument();
            RadDocumentEditor documentEditor = new RadDocumentEditor(radRichTextEditor1.Document);
            
        }

        private void radRichTextEditor1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), 5, 10, 400, 400);
        }
    }
}
