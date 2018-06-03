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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var db = new Note1Entities();
            for (int i = 0; i < this.listView.SelectedRows.Count; i++)
            {
                var row = this.listView.SelectedRows[i];
                var item = (Note)row.DataBoundItem;
                try
                {
                    DialogResult = MessageBox.Show("Bạn có muốn xoa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult == DialogResult.OK)
                    {
                        var @note = db.Note.Find(item.id);
                        db.Note.Remove(@note);
                        db.SaveChanges(); // Do-It
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.ShowNoteList();
        }
    }
}
