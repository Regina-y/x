using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.RichTextEditor.UI;
using Telerik.WinControls.UI;
using Telerik.WinForms.Documents;
using Telerik.WinForms.Documents.FormatProviders.OpenXml.Docx;
using Telerik.WinForms.Documents.FormatProviders.Rtf;
using Telerik.WinForms.Documents.Model;
using Telerik.WinForms.Documents.Model.Merging;
using Telerik.WinForms.Documents.TextSearch;
using Telerik.WinForms.Documents.UI.TextBlocks;

namespace TelerikDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DocxFormatProvider docxFormatProvider = new DocxFormatProvider();
            var document = docxFormatProvider.Import(new FileStream(@"D:\MyProject\TelerikDemo\cc.docx", FileMode.Open));
            this.radRichTextEditor1.Document = (RadDocument)document.CreateDeepCopy();
            //this.radRichTextEditor1.Document.MailMergeDataSource.ItemsSource = getFile(1);

            //Header header = new Header() { Body = document, IsLinkedToPrevious = false };
            //this.radRichTextEditor1.Document.Sections.First.Headers.Default = header;
            //this.radRichTextEditor1.UpdateHeader(this.radRichTextEditor1.Document.Sections.First, HeaderFooterType.Default, header);
            //this.radRichTextEditor1.Document.Sections.First.Headers.Default.Body = document;
            this.radRichTextEditor1.Document.Sections.First.Headers.Default.Body.MailMergeDataSource.ItemsSource = getFile(1);
            this.radRichTextEditor1.Document.Sections.First.Headers.Default.Body.MailMergeCurrentRecord();
            this.radRichTextEditor1.Document.Sections.First.Headers.Default.Body.ChangeAllFieldsDisplayMode(FieldDisplayMode.Result);
            this.radRichTextEditor1.PreviewFirstMailMergeDataRecord();

            this.radRichTextEditor1.ChangeAllFieldsDisplayMode(FieldDisplayMode.Result);
            this.radRichTextEditor1.InsertSectionBreak(SectionBreakType.NextPage);
            //    RtfFormatProvider rtfFormatProvider = new RtfFormatProvider();
            //   //FileStream fileStream = new FileStream(@"C:\Users\Administrator\Desktop\测试222.rtf", FileMode.Open);
            //    StreamReader sw = new StreamReader(@"C:\Users\Administrator\Desktop\测试222.rtf", Encoding.UTF8);
            //    var document = rtfFormatProvider.Import(sw.ReadToEnd());
            //    this.radRichTextEditor1.Document = document;
            //this.radRichTextEditor1.Document.HasDifferentEvenAndOddHeadersFooters = true;

            this.radRichTextEditor1.ProviderUILayerInitialized += radRichTextEditor1_ProviderUILayerInitialized;
            this.radRichTextEditor1.FocusHeader();

        }

        private List<string> list = new List<string>();

        private List<string> pageList = new List<string>();

        private void radRichTextEditor1_ProviderUILayerInitialized(object sender, ProviderUILayerInitilizedEventArgs e)
        {
            var layerName = e.Layer.Name;
            if (layerName == "PagesLayer")
            {
                //foreach (UIElement element in e.Container.Children)
                //{
                //    element.BackColor = Colors.White;
                //}
                //List<RadElement> headerFooters = this.radRichTextEditor1.RichTextBoxElement.GetDescendants(delegate (RadElement x)
                //{
                //    return x is HeaderFooterContainer;
                //}, TreeTraversalMode.BreadthFirst);
                //foreach (HeaderFooterContainer container in headerFooters)
                //{
                //    container.OverlayColor = System.Drawing.Color.FromArgb(128, 255, 255, 255);
                //}
                pageList.Clear();
            }
            pageList.Add(layerName);
            if (layerName == "LinesDocumentLayer")
            {
                list.Clear();
                foreach (UIElement element in e.Container.Children)
                {
                    float left = Canvas.GetLeft(element);
                    float bottom = Canvas.GetBottom(element);
                    float right = Canvas.GetRight(element);
                    float top = Canvas.GetTop(element);
                }
            }
            else
            {

            }

        }

        int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Section section = new Section();
            Table table = new Table
            {
                StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName
            };
            TableRow row1 = new TableRow();

            TableCell cell1 = new TableCell();
            Paragraph p1 = new Paragraph();
            Span s1 = new Span
            {
                Text = "姓名："
            };
            p1.Inlines.Add(s1);
            cell1.Blocks.Add(p1);
            row1.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            Paragraph p2 = new Paragraph();
            Span s2 = new Span
            {
                Text = "性别："
            };
            p2.Inlines.Add(s2);
            cell2.Blocks.Add(p2);
            row1.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            Paragraph p3 = new Paragraph();
            Span s3 = new Span
            {
                Text = "年龄："
            };
            p3.Inlines.Add(s3);
            cell3.Blocks.Add(p3);
            row1.Cells.Add(cell3);

            TableCell cell4 = new TableCell();
            Paragraph p4 = new Paragraph();
            Span s4 = new Span
            {
                Text = "床号："
            };
            p4.Inlines.Add(s4);
            cell4.Blocks.Add(p4);
            row1.Cells.Add(cell4);

            TableCell cell5 = new TableCell();
            Paragraph p5 = new Paragraph();
            Span s5 = new Span
            {
                Text = "住院号："
            };
            p5.Inlines.Add(s5);
            cell5.Blocks.Add(p5);
            row1.Cells.Add(cell5);

            table.Rows.Add(row1);
            table.StyleName = "TableNormal";//边框不可见

            //section.Blocks.Add(table);
            //radRichTextEditor1.Document.Sections.Add(section);
            //radRichTextEditor1.DocumentEditor.ChangeParagraphTextAlignment(Telerik.WinForms.Documents.Layout.RadTextAlignment.Center);

            radRichTextEditor1.DocumentEditor.InsertParagraph();
            radRichTextEditor1.Commands.InsertTextCommand.Execute("南京康复医院");
            radRichTextEditor1.DocumentEditor.InsertParagraph();
            radRichTextEditor1.Commands.InsertTextCommand.Execute("病程记录");

            radRichTextEditor1.DocumentEditor.InsertTable(table);
            //radRichTextEditor1.DocumentEditor.InsertTable(1, 4);
            //radRichTextEditor1.Commands.InsertTableColumnCommand.Execute("aaa");
            //radRichTextEditor1.Commands.InsertTableColumnCommand.Execute("bbb");
            radRichTextEditor1.Commands.ExitHeaderFooterEditModeCommand.Execute();
            //MergeField field = new MergeField();
            //switch (count)
            //{
            //    case 0:
            //        field.PropertyPath = "time";
            //        break;
            //    case 1:
            //        field.PropertyPath = "fileName";
            //        break;
            //    case 2:
            //        field.PropertyPath = "info";
            //        break;
            //    case 3:
            //        field.PropertyPath = "doctor";
            //        break;
            //};
            //count++;

            //this.radRichTextEditor1.InsertField(field, FieldDisplayMode.DisplayName);
        }

        private List<RecordInfo> getFile(int type)
        {
            List<RecordInfo> infoList = new List<RecordInfo>();
            RecordInfo recordInfo = new RecordInfo();
            recordInfo.time = DateTime.Now.ToString("yyyy-MM-dd") + "-" + type;
            recordInfo.doctor = "张三";
            recordInfo.fileName = "南京康复每日病程";
            switch (type)
            {
                case 1:
                    recordInfo.info = "查房时患者诉左下胸部仍感不适，经输液后体温恢复正常，无畏冷。无胸闷、胸痛，无腹胀、腹泻。查体：神清，双肺呼吸音清，左下肺呼吸音仍较低。未闻及干湿性罗音。左下肺叩痛。心率100次/分，律齐，各瓣膜听诊区未闻及病理性杂音。腹平软，肝脾肋下未及，双下肢无浮肿。******主任查房后示患者主要为左下胸部不适，查体同前。要考虑是否有胸膜炎或肺部炎症，另有吸烟史，查体为桶状胸。故慢性支气管炎明确。嘱立即行胸片检查明确。遵嘱执行。";
                    break;
                case 2:
                    recordInfo.info = "查房时患者诉深呼吸时仍感左下胸部不适。查体：体温36.8℃，血压130/80mmHg。神志清楚。左下胸壁叩击痛，左下肺呼吸音较对侧低，双肺未闻及湿性罗音。心率偏快，律齐，各瓣膜听诊区未闻及病理性杂音。腹部查体阴性。胸片示：考虑慢性支气管炎并两下肺感染。查血流变正常。血尿淀粉酶未见异常，余各项检验及检查未见异常，可排除胰腺炎诊断，明确诊断为慢支病肺部感染，加强抗感染治疗，继续观察病情变化，改善心肌供氧。";
                    break;
                case 3:
                    recordInfo.info = "患者诉左下胸部不适明显缓解，无咳嗽咳痰，畏寒发热等表现。查体：神志清楚。左下胸壁无叩击痛，左下肺呼吸音较对侧低，双肺未闻及湿性罗音。心率偏快，律齐，各瓣膜听诊区未闻及病理性杂音。腹部查体阴性。今日下午查床边心电图提示有频发室性早搏，无明显冠心病证据。******主任查房后嘱：患者发现室性早搏，原因尚无法明确，可行心律平抗心律失常治疗，余治疗无调整，继续观察病情变化。";
                    break;
                case 4:
                    recordInfo.info = "查体：体温38.4℃，血压140/90mmHg、神清，桶状胸，双肺呼吸音清，未闻及干湿性罗音及哮鸣音，左下肺呼吸音较低，左下肺叩痛。心率102次/分，律齐，各瓣膜听诊区未闻及病理性杂音。腹平，肌紧张，上腹轻压痛。肝脾肋下未及，双下肢无浮肿。患者有吸烟史。";
                    break;
            }
            recordInfo.name = "王五";
            recordInfo.age = "15";
            recordInfo.sex = "男";
            recordInfo.bedName = "一号床";
            recordInfo.patientNo = "12341234";
            recordInfo.hospital = "南京康复";
            infoList.Add(recordInfo);
            return infoList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RadDocumentMerger radDocumentMerger = null;

            for (int i = 0; i < 15; i++)
            {
                DocxFormatProvider docxFormatProvider = new DocxFormatProvider();
                FileStream f = new FileStream(@"D:\MyProject\TelerikDemo\rec.docx", FileMode.Open);
                var document = docxFormatProvider.Import(f);
                f.Close();
                //RadDocumentEditor radDocumentEditor  = new RadDocumentEditor(document);
                document.MailMergeDataSource.ItemsSource = getFile(i % 4 + 1);
                document.MailMergeCurrentRecord();
                document.ChangeAllFieldsDisplayMode(FieldDisplayMode.Result);

                if (radDocumentMerger == null)
                {
                    radDocumentMerger = new RadDocumentMerger(document);
                }
                else
                {
                    AppendDocumentOptions options = new AppendDocumentOptions();
                    options.FirstSourceSectionPropertiesResolutionMode = SectionPropertiesResolutionMode.NoSectionBreak;
                    options.ConflictingStylesResolutionMode = ConflictingStylesResolutionMode.RenameSourceStyle;
                    radDocumentMerger.AppendDocument(document, options);
                }
            }
            this.radRichTextEditor1.Document = radDocumentMerger.Document;
        }

        private void ReplaceAllMatches(string toSearch, string toReplaceWith, RadDocument doc)
        {

            doc.Selection.Clear();

            DocumentTextSearch search = new DocumentTextSearch(doc);
            List<TextRange> rangesTrackingDocumentChanges = new List<TextRange>();

            foreach (var textRange in search.FindAll(toSearch))
            {
                TextRange newRange = new TextRange(new DocumentPosition(textRange.StartPosition, true), new DocumentPosition(textRange.EndPosition, true));
                rangesTrackingDocumentChanges.Add(newRange);
            }

            foreach (var textRange in rangesTrackingDocumentChanges)
            {
                doc.Selection.AddSelectionStart(textRange.StartPosition);

                doc.Selection.AddSelectionEnd(textRange.EndPosition);
                string textoSeleccionado = doc.Selection.GetSelectedText();

                DocumentPosition posInicial = textRange.StartPosition;
                DocumentPosition posFinal = textRange.EndPosition;

                DocumentPosition posTotal = new DocumentPosition(posInicial);
                //posTotal.MoveToCurrentLineStart();
                //posTotal.MoveToCurrentWordStart();


                //doc.Insert(toReplaceWith, new Telerik.Windows.Documents.Model.Styles.StyleDefinition());
                textRange.StartPosition.Dispose();
                textRange.EndPosition.Dispose();
            }
        }


    }


    public class myPrintDocument : RadPrintDocument
    {
        protected override void PrintHeader(PrintPageEventArgs args)
        {
            if (CurrentPage == 0)
            {
                args.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Blue), 0, 0, 1000, 800);
            }
            base.PrintHeader(args);
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);
        }
    }

    public class RecordInfo
    {
        public string time { get; set; }
        public string fileName { get; set; }
        public string info { get; set; }
        public string doctor { get; set; }

        public string name { get; set; }

        public string age { get; set; }
        public string age2 { get; set; }
        public string sex { get; set; }
        public string bedName { get; set; }
        public string patientNo { get; set; }
        public string hospital { get; set; }
    }
}
