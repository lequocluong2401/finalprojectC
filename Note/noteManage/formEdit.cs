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
    public partial class formEdit : Form
    {
        private Note note;

        public formEdit(Note note)
        {
            InitializeComponent();
            this.note = note;
            
        }

       
        private void Edit_Load(object sender, EventArgs e)
        {
            this.txtTitle.Text = note.title;
            this.txtContext.Text = note.content;
           
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            var db = new Note1Entities();
            Note newNote = db.Note.Find(this.note.id);
            try
            {
                newNote.title = this.txtTitle.Text;
                newNote.content = this.txtContext.Text;
                db.Entry(newNote).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges(); // Do-It
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
