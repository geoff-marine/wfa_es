using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nest;

namespace wfa_es
{
    public partial class Form1 : Form
    {
        private Vessel vessel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                vessel = new Vessel();
                FillList(vessel.GetAll(), listView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FillList(List<Vessel> list, ListView component)
        {
            BuildListView(component);

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem.Text = list[i].cfr.ToString();
                
            }
        }

        private void BuildListView(ListView component)
        {
            component.Columns.Clear();
            component.Items.Clear();

            component.View = System.Windows.Forms.View.Details;
            component.FullRowSelect = true;
            component.GridLines = true;

            component.Columns.Add("cfr", 50);
        }
    }
}
