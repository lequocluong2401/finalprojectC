using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note.noteManage
{
    public partial class formList : Form
    {
        public formList()
        {
            InitializeComponent();
        }
        private void listLoad(object sender, EventArgs e)
        {
            this.ShowNoteList();
        }

        private void ShowNoteList()
        {
            var db = new Note1Entities();
            this.listView.DataSource = db.Note.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAdd();
            form.ShowDialog();
            this.ShowNoteList();
        }
    }
}
