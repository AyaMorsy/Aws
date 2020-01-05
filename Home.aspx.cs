using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Apriori;
using BAL;
using Label = System.Web.UI.WebControls.Label;

namespace AprioriWebApp2
{
    public partial class Home : System.Web.UI.Page

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.HorizontalAlign = HorizontalAlign.Left;
        }
        string FileName = string.Empty;
        List<Thread> threads = new List<Thread>();
        protected void LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var file = openFileDialog.FileName;
            var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "Text|*.txt";
            //if (dialog.ShowDialog() != DialogResult.OK) return;
            //FileName = dialog.FileName;
            FileName = @"C:\Users\hp\Desktop\paper\data set\New Text Document (2).txt";
            //trackBar1.Enabled = true;
            DoThingThread();
            RefreshButton.Enabled = true;
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            AbortThread();
            DoThingThread();
        }
        private void AbortThread()
        {
            foreach (var thread in threads)
            {
                thread.Abort();
            }
            threads.Clear();
        }
        private void DoThings()
        {
            int Support = 2;
            //if (trackBar1.InvokeRequired)
            //    trackBar1.Invoke(new MethodInvoker(delegate
            //    {
            //        Support = trackBar1.Value + 1;
            //        trackBar1.Enabled = false;
            //    }
            //    ));
            // flowLayoutPanel1.Controls.Clear();
            // flowLayoutPanel1.Controls.Add(new (File.ReadAllLines(FileName).ToList()));
           // flowLayoutPanel1.Controls.Add(((System.Web.UI.Control) new TableUserControl(File.ReadAllLines(FileName).ToList())));

            GridView DataGridview = new GridView();
            DataGridview.Height = 500;
            DataGridview.DataSource = TableUserControl(File.ReadAllLines(FileName).ToList());
            DataGridview.DataBind();
            
            
            flowLayoutPanel1.Controls.Add(DataGridview);

            BAL.Apriori apriori = new BAL.Apriori(FileName);
            int k = 1;
            List<BAL.ItemSet> ItemSets = new List<BAL.ItemSet>();
            bool next;
            do
            {
                next = false;
                var L = apriori.GetItemSet(k, Support, IsFirstItemList: k == 1);
                if (L.Count > 0)
                {
                    List<AssociationRule> rules = new List<AssociationRule>();
                    if (k != 1)
                        rules = apriori.GetRules(L);
                  //  TableUserControl tableL = new TableUserControl(L, rules);
                   TableUserControl(L, rules);

                    next = true;
                    k++;
                    ItemSets.Add(L);
                    //if (flowLayoutPanel1.InvokeRequired)
                    //    flowLayoutPanel1.Invoke(new MethodInvoker(delegate
                    //    {
                    //  flowLayoutPanel1.Controls.Add( (System.Web.UI.Control)tableL);
                    //flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
                    //}
                    //));
                }
            } while (next);

            //if (trackBar1.InvokeRequired)
            //    trackBar1.Invoke(new MethodInvoker(delegate
            //    {
            //        trackBar1.Enabled = true;
            //    }
            //    ));
        }
        private void DoThingThread()
        {
            DoThings();
            Thread t = new Thread(delegate ()
            {
                //pictureBox1.Invoke(new MethodInvoker(delegate
                //{
                //    pictureBox1.Show();
                //}));
                DoThings();
                //pictureBox1.Invoke(new MethodInvoker(delegate
                //{
                //    pictureBox1.Hide();
                //}));
            })
            { Name = "DoThings" };
            threads.Add(t);
            t.Start();
        }
        public void TableUserControl(ItemSet itemSet, List<AssociationRule> rules)
        {
            GridView ItemSetsDataGrid = new GridView();
            GridView RulesDataGrid = new GridView();
            Label ItemSet = new Label();
            Label RuleSet = new Label();
            ItemSet.Text = itemSet.Label;
           
            
            //ItemSetLabel.Text = itemSet.Label;
            DataTable dt = new DataTable();
            if (dt.Columns.Count == 0)
            {

                dt.Columns.Add("itemSet", typeof(string));
                dt.Columns.Add("Items", typeof(string));
            }
            DataTable dt2 = new DataTable();
            if (dt2.Columns.Count == 0)
            {

                dt2.Columns.Add("item", typeof(string));
                dt2.Columns.Add("Confidance", typeof(string));
                dt2.Columns.Add("Support", typeof(string));
            }
            
            foreach (var item in itemSet)
            {
                dt.Rows.Add(item.Key.ToDisplay(), item.Value);
            }
            if (rules.Count == 0)
            {
                ItemSetsDataGrid.Height = 342;
                //RulesDataGrid.Visible = false;
            }
            else
            {
                RuleSet.Text = "Rules"; 
                foreach (var item in rules)
                {

                    dt2.Rows.Add(item.Label, item.Confidance.ToPercentString(), item.Support.ToPercentString());

                }
            }
            ItemSetsDataGrid.Height = 500;
            RulesDataGrid.Height = 500;
            ItemSetsDataGrid.DataSource = dt;
            ItemSetsDataGrid.DataBind();
            RulesDataGrid.DataSource = dt2;
            RulesDataGrid.DataBind();

            flowLayoutPanel2.Controls.Add(ItemSet);
            flowLayoutPanel2.Controls.Add(ItemSetsDataGrid);
            flowLayoutPanel2.Controls.Add(RuleSet);
            flowLayoutPanel2.Controls.Add(RulesDataGrid);
            foreach (var item in itemSet)
            {
                if (item.Value < itemSet.Support)
                    ItemSetsDataGrid.Rows[ItemSetsDataGrid.Rows.Count - 1].BackColor = System.Drawing.Color.LightGray;
            }

        }

        public DataTable TableUserControl(List<string> Values)
        {
            DataTable dt = new DataTable();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Itemset", typeof(string));
                dt.Columns.Add("Count", typeof(string));

            }
            ItemSetLabel.Text = "Transactions";
            //ItemSetsDataGridView.Columns[0].HeaderText = "TransactionID";
            //ItemSetsDataGridView.Columns[1].HeaderText = "Items";
            for (int i = 0; i < Values.Count; i++)
            {

                dt.Rows.Add(i, Values[i]);

                // ItemSetsDataGridView.Rows.Add(i, Values[i]);
            }
            
            return dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //ItemSetsDataGridView.ClearSelection();
        }

    }
}