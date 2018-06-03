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
        private Note note;
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

        private void Listview(object sender, EventArgs e)
        {
            if (this.listView.SelectedRows.Count == 1)
            {
                var row = this.listView.SelectedRows[0];
                var item = (Note)row.DataBoundItem;

                var form = new formEdit(item);
                form.ShowDialog();
                this.ShowNoteList();
            }
        }

    }
}
