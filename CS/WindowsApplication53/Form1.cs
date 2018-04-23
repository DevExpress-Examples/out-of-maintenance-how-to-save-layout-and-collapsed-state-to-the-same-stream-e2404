using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication53
{
    public partial class Form1 : Form
    {
        PivotLayoutHelper pivotLayoutHelper;
        public Form1()
        {
            InitializeComponent();
        }
        void Form1_Load(object sender, EventArgs e)
        {
            PopulateTable();
            pivotGridControl1.RefreshData();
            pivotGridControl1.BestFit();
        }
        void PopulateTable()
        {
            DataTable myTable = dataSet1.Tables["Data"];
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today, 7 });
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddDays(1), 4 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today, 12 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1), 14 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today, 11 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1), 10 });

            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1), 4 });
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1).AddDays(1), 2 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddYears(1), 3 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1).AddYears(1), 1 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddYears(1), 8 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1).AddYears(1), 22 });
        }
        MemoryStream stream = new MemoryStream();
        void simpleButton1_Click(object sender, EventArgs e) {
            stream.Position = 0;
            PivotLayoutHelper.SavePivot(pivotGridControl1, stream);
        }
        void simpleButton2_Click(object sender, EventArgs e)
        {
            stream.Position = 0;
            PivotLayoutHelper.LoadPivot(pivotGridControl1, stream);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            pivotGridControl1.Fields.Clear();
        }
    }    
}