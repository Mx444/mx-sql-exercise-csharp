using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework;

namespace Prenotazioni
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\DAVIDE\DOCUMENTS\VISUAL STUDIO 2015\PROJECTS\PRENOTAZIONI\PRENOTAZIONI\DATABASE1.MDF ;Integrated Security=True");
        DataTable DataTB = new DataTable();
       
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

           LoadDGV();
        }

        #region Datagrid Info
        void LoadDGV()
        {
            
            Connection.Open();
            SqlDataReader Reader = null;
            SqlCommand cmd = new SqlCommand("select * from Prenotazione order by Data", Connection);
            Reader = cmd.ExecuteReader();
            DataTB.Clear();
            DataTB.Load(Reader);
            DGV.DataSource = DataTB;
            Connection.Close();
            DGV.Columns["IdPrenotazione"].Visible = false;
        }
        
        #endregion

        #region Update
        void UpdateInfo()
        {
            Connection.Open();
            SqlCommand cmdDGV = new SqlCommand("", Connection);
            foreach (DataGridViewRow Riga in DGV.Rows)
            {

                if(Riga.Cells[0].Style.ForeColor==Color.Red)

                {
                    
                    if (Riga.Cells[0].Style.BackColor == Color.Bisque)
                        cmdDGV.CommandText = "insert into Prenotazione (Nome, Cognome, Data, Stato) values ('" 
                            + Riga.Cells["Nome"].Value
                            + "' , '"
                            + Riga.Cells["Cognome"].Value
                            + "' , '"
                            + Riga.Cells["Data"].Value
                            + "' , '"
                            + Riga.Cells["Stato"].Value
                            + "')";

                            
                    else
                        cmdDGV.CommandText = "update Prenotazione set Nome ='" 
                            + Riga.Cells["Nome"].Value 
                            +"' ,"
                            + "Cognome ='"
                            + Riga.Cells["Cognome"].Value 
                            + "' ,"
                            + "Data ='"
                            + Riga.Cells["Data"].Value
                            + "Stato ='"
                            + Riga.Cells["Stato"].Value
                            + "' where IdPrenotazione='" 
                            + Riga.Cells["IdPrenotazione"].Value 
                            +"'";
                    cmdDGV.ExecuteNonQuery();
                }
            }
            Connection.Close();
        }
        #endregion
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("", Connection);
            cmd.CommandText = "insert into Prenotazione (Nome, Cognome, Data, Stato) values ('"
                + Nometxt.Text
                + "' , '"
                + Cognometxt.Text
                + "' , '"
                + DataTP.Value.ToShortDateString()
                + "' , '"
                + Statocombo.Text
                + "')";
            cmd.ExecuteNonQuery();
            SqlDataReader Reader = null;
            SqlCommand command = new SqlCommand("select * from Prenotazione order by Data", Connection);
            Reader = command.ExecuteReader();
            DataTB.Clear();
            DataTB.Load(Reader);
            DGV.DataSource = DataTB;
            DGV.Columns["IdPrenotazione"].Visible = false;
            Connection.Close();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateInfo();
            Form1 FormMadre = new Form1();
            FormMadre.Show();
        }
        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewCell Cell in DGV.Rows[e.RowIndex].Cells)
              Cell.Style.ForeColor = Color.Red;
        }
        private void DGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    DGV.CurrentCell = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    DGV.Rows[e.RowIndex].Selected = true;
                    DGV.Focus();

                }
            }
            catch
            {

            }
        }
        private void DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // if (DGV.Rows[e.RowIndex].IsNewRow)
            //    foreach (DataGridViewCell Cell in DGV.Rows[e.RowIndex].Cells)
             //       Cell.Style.BackColor = Color.Bisque;
        }
             private void DGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Stai per eliminare "
                + (string)e.Row.Cells["Nome"].Value
                + " "
                + (string)e.Row.Cells["Cognome"].Value
                + " Confermi ?"
                , "Conferma eliminazione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (dialogResult == DialogResult.Yes)
            {
                Connection.Open();
                SqlCommand cmdSQL = new SqlCommand("", Connection);
                cmdSQL.CommandText = "delete from Prenotazione where IdPrenotazione='" + (int)e.Row.Cells["IdPrenotazione"].Value + "'";
                cmdSQL.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                timer1.Start();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                timer1.Start();
            }

            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateInfo();
            LoadDGV();
            //System.Threading.Thread.Sleep(100);
            timer1.Stop();  
        }
        private void Findtxt_TextChanged(object sender, EventArgs e)
        {
            UpdateInfo();
            LoadDGV();
            DataTB.DefaultView.RowFilter = "Nome LIKE '%" + Findtxt.Text + "%'";
        }
        private void Statocombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void metroTextBox1_Click(object sender, EventArgs e)
        {
          
        }
        private void thirteenForm1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void monoFlat_HeaderLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Nometxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void DGV_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void DGV_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
