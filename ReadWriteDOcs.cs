using Novacode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP
{
    class ReadWriteDOcs
    {
        System.Windows.Forms.IDataObject data;

        public string ReadMsword(string filePath)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            try
            {

                object miss = System.Reflection.Missing.Value;
                object path = filePath;
                //lbWordDocs.Items.Add(filePath);
                //rtbox.Text()
                object readOnly = false;
                Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                docs.ActiveWindow.Selection.WholeStory();
                docs.ActiveWindow.Selection.Copy();
                data = Clipboard.GetDataObject();
                //rtbox.Text = (string)(data.GetData(DataFormats.Text));
                docs.Close(ref miss, ref miss, ref miss);
                word.Quit(ref miss, ref miss, ref miss);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(word);
            }

            //return (data.GetData(DataFormats.Text).ToString());
            return (data.GetData(DataFormats.Text).ToString());


        }

        public void WriteMsword(string filePath, string text)
        {
            var doc = DocX.Create(filePath);
            doc.InsertParagraph(text);
            doc.Save();





            //        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            //        try{
            //        var doc = app.Documents.Add();
            //        var paragraph = doc.Paragraphs.Add();
            //        paragraph.Range.Text = text;

            //        app.ActiveDocument.SaveAs(filePath, WdSaveFormat.wdFormatDocument);
            //        }
            //            finally
            //{
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(app); 
            //}

        }


    }
}
