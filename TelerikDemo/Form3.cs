using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinForms.Documents.Model;

namespace TelerikDemo
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void radRichTextEditor1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            RadDocument document = new RadDocument();
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
                Text = "项目"
            };
            p1.Inlines.Add(s1);
            cell1.Blocks.Add(p1);
            row1.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            Paragraph p2 = new Paragraph();
            Span s2 = new Span
            {
                Text = "结果"
            };
            p2.Inlines.Add(s2);
            cell2.Blocks.Add(p2);
            row1.Cells.Add(cell2);


            TableCell cell3 = new TableCell();
            Paragraph p3 = new Paragraph();
            Span s3 = new Span
            {
                Text = "单位"
            };
            p3.Inlines.Add(s3);
            cell3.Blocks.Add(p3);
            row1.Cells.Add(cell3);

            table.Rows.Add(row1);

            TableRow row2 = new TableRow();

            TableCell cell4 = new TableCell();
            cell4.ColumnSpan = 3;
            Paragraph p4 = new Paragraph();
            Span s4 = new Span
            {
                Text = "Cell 3"
            };
            p4.Inlines.Add(s4);
            cell4.Blocks.Add(p4);
            row2.Cells.Add(cell4);
            table.Rows.Add(row2);

            Paragraph p = new Paragraph();
            Span s = new Span
            {
                Text = "身高、体重、血压"
            };
            Span ss = new Span
            {
                Text = "检查者：***"
            };

            p.Inlines.Add(s);
            p.Inlines.AddAfter(s, ss);

            section.Blocks.Add(p);
            section.Blocks.Add(table);
            section.Blocks.Add(new Paragraph());
            document.Sections.Add(section);

            this.radRichTextEditor1.Document = document;
        }
    }
}
