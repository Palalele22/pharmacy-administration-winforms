using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarmacieNoua;
using LibrarieModele;
using NivelAccesDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {

        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;
        List<Panel> listPanel = new List<Panel>();
        int index;
        IStocareRetete stocareRetete = (IStocareRetete)new StocareFactory().GetTipStocare(typeof(Reteta));
        IStocareIngrediente stocareIngrediente = (IStocareIngrediente)new StocareFactory().GetTipStocare(typeof(Ingredient));
        IStocareMedicamente stocareMedicamente = (IStocareMedicamente)new StocareFactory().GetTipStocare(typeof(Medicament));

        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            index = 1;
            listPanel[index].BringToFront();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            index = 2;
            AfiseazaMedicamente();
            listPanel[index].BringToFront();
        }

        private void btnAfiseaza_Click(object sender, EventArgs e)
        {

            index = 2;
            AfiseazaMedicamente();
            listPanel[index].BringToFront();

        }

        private void btnCautare_Click(object sender, EventArgs e)
        {

            index = 3;
            listPanel[index].BringToFront();

        }

        private void lblTitlu_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panelAdaugare);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            listPanel.Add(panel4);
            listPanel.Add(panel5);
            listPanel.Add(panel6);
            listPanel.Add(panel7);
            listPanel[0].BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeMed_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdaugaMed_Click(object sender, EventArgs e)
        {
                try
                {
                    var rezultat = stocareMedicamente.AddMedicament(new Medicament( txtNumeMed.Text, Convert.ToDateTime(dateTimePicker1.Value), txtProspect.Text, txtTip.Text, Convert.ToInt32(txtIdReteta.Text)));
                    if (rezultat == SUCCES)
                    {
                        MessageBox.Show("Medicament adaugat");
                        AfiseazaMedicamente();
                        
                    }
                    else
                    {
                        MessageBox.Show("Eroare la adaugare medicamentului");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exceptie" + ex.Message);
                }
            
        }

        private void ResetareControale()
        {
            txtNumeMed.Text = string.Empty;
            txtCod.Text = string.Empty;
           
            txtProspect.Text = string.Empty;

           
            

        }
        private bool DateIntrareValide()
        {
            int result,ok=1;
            bool rezultatConversie;
            if (txtNumeMed.Text == "") { lblNume.ForeColor = Color.Red; ok = 0; }
            else
                lblNume.ForeColor = Color.Black;
           

            return true;
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
        }

        private void btnCautareMed_Click(object sender, EventArgs e)
        {
            String name = txtNumeCautare.Text;
            try
            {
                Medicament medicament = stocareMedicamente.GetMedicament(name);

                if (medicament != null )
                {
                    dataGridMedicamente.RowCount = 1;
                    dataGridMedicamente.ColumnCount = 6;
                    
                    dataGridMedicamente.Rows[0].Cells[0].Value = medicament.IdMedicament;
                    dataGridMedicamente.Rows[0].Cells[1].Value = medicament.NumeMedicament;
                    dataGridMedicamente.Rows[0].Cells[2].Value = medicament.DataExp;
                    dataGridMedicamente.Rows[0].Cells[3].Value = medicament.Prospect;
                    dataGridMedicamente.Rows[0].Cells[4].Value = medicament.TipMedicament;
                    dataGridMedicamente.Rows[0].Cells[5].Value = medicament.IdReteta;

                    

                }
                //incarcarea datelor in controalele de pe forma

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void btnModificaLista_Click(object sender, EventArgs e)
        {
            index = 1;
            listPanel[index].BringToFront();
           
        }

        private void btnModificaFinal_Click(object sender, EventArgs e)
        {
            try
            {
                var rezultat = stocareMedicamente.UpdateMedicament(new Medicament(txtNumeMed.Text, Convert.ToDateTime(dateTimePicker1.Value), txtProspect.Text, txtTip.Text, Convert.ToInt32(txtIdReteta.Text), Convert.ToInt32(txtCod.Text)));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Medicament modificat");
                    AfiseazaMedicamente();

                }
                else
                {
                    MessageBox.Show("Eroare la modificarea medicamentului");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPret_Click(object sender, EventArgs e)
        {

        }

        private void btnAddIng_Click(object sender, EventArgs e)
        {
            index = 4;
            listPanel[index].BringToFront();
        }

        private void btnBackIngr_Click(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
        }

        private void btnModificaIngr_Click(object sender, EventArgs e)
        {
            try
            {
                var rezultat = stocareIngrediente.UpdateIngredient(new Ingredient(txtNumeIngr.Text, Convert.ToDateTime(dateTimePickerIngr.Value), Convert.ToInt32(txtStoc.Text), Convert.ToInt32(txtIngr.Text)));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Ingredient actualizat");
                    AfiseazaIngrediente();
                    ReseteazaCampurile2();
                }
                else
                {
                    MessageBox.Show("Eroare la aactualizarea ingredientului");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void btnBackListIngr_Click(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
        }

        private void btnModifIngrList_Click(object sender, EventArgs e)
        {
            index = 4;
            listPanel[index].BringToFront();
        }

        private void btnModIng_Click(object sender, EventArgs e)
        {
            index = 5;
            AfiseazaIngrediente();
            listPanel[index].BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var rezultat = stocareRetete.UpdateReteta(new Reteta(txtListaIngr.Text, Convert.ToInt32(txtIdRet.Text)));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Reteta actualizata");
                    AfiseazaRetete();
                    ReseteazaCampurile();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizarea retetei");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var rezultat = stocareRetete.AddReteta(new Reteta(txtListaIngr.Text));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Reteta adaugata");
                    AfiseazaRetete();
                    ReseteazaCampurile();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare reteta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void ReseteazaCampurile()
        {
            txtListaIngr.Text = "";
            txtIdRet.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index = 6;
            ReseteazaCampurile();
            listPanel[index].BringToFront();
        }

        private void btnModifReteta_Click(object sender, EventArgs e)
        {
            index = 7;
            listPanel[index].BringToFront();
            AfiseazaRetete();
        }

        private void btnBackListRetete_Click(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
        }

        private void btnModifListRet_Click(object sender, EventArgs e)
        {
            index = 6;
            listPanel[index].BringToFront();
        }

        private void dataGridReteteL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AfiseazaRetete()
        {
            try
            {
                var retete = stocareRetete.GetRetete();
                if (retete != null && retete.Any())
                {
                    dataGridReteteL.DataSource = retete.Select(r => new { r.IdReteta,  r.IdsIngrediente }).ToList();

                    dataGridReteteL.Columns["IdReteta"].HeaderText = "Id Reteta";
                    dataGridReteteL.Columns["IdsIngrediente"].HeaderText = "Lista Ingrediente";
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridIngrediente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AfiseazaIngrediente()
        {
            try
            {
                var ingrediente = stocareIngrediente.GetIngrediente();
                if (ingrediente != null && ingrediente.Any())
                {

                    dataGridIngrediente.DataSource = ingrediente.Select(i => new { i.IdIngredient, i.NumeIngredient, i.DataExp, i.Stoc }).ToList();

                    dataGridIngrediente.Columns["IdIngredient"].HeaderText = "Id Ingredient";
                    dataGridIngrediente.Columns["NumeIngredient"].HeaderText = "Nume Ingredient";
                    dataGridIngrediente.Columns["DataExp"].HeaderText = "Data Expirarii";
                    dataGridIngrediente.Columns["Stoc"].HeaderText = "Stoc";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAdaugaIng_Click(object sender, EventArgs e)
        {
            try
            {
                var rezultat = stocareIngrediente.AddIngredient(new Ingredient(txtNumeIngr.Text,Convert.ToDateTime(dateTimePickerIngr.Value), Convert.ToInt32(txtStoc.Text)));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Ingredient adaugat");
                    AfiseazaIngrediente();
                    ReseteazaCampurile2();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare ingredientului");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void ReseteazaCampurile2()
        {
            txtIngr.Text = "";
            txtNumeIngr.Text = "";
            txtStoc.Text = "";
        }

        private void dataGridIngrediente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridIngrediente.CurrentCell.RowIndex;
            string idIngredient = dataGridIngrediente[PRIMA_COLOANA, currentRowIndex].Value.ToString();
            
            try
            {
                Ingredient i = stocareIngrediente.GetIngredient(Int32.Parse(idIngredient));

                //incarcarea datelor in controalele de pe forma
                if (i != null)
                {
                    txtIngr.Text = i.IdIngredient.ToString();
                    txtNumeIngr.Text = i.NumeIngredient;
                    txtStoc.Text = i.Stoc.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridReteteL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridReteteL.CurrentCell.RowIndex;
            string idReteta = dataGridReteteL[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Reteta r = stocareRetete.GetReteta(Int32.Parse(idReteta));

                //incarcarea datelor in controalele de pe forma
                if (r != null)
                {
                    txtIdRet.Text = r.IdReteta.ToString();
                    txtListaIngr.Text = r.IdsIngrediente.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridViewMeds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridViewMeds.CurrentCell.RowIndex;
            string idMedicament = dataGridViewMeds[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Medicament m = stocareMedicamente.GetMedicament(Int32.Parse(idMedicament));

                //incarcarea datelor in controalele de pe forma
                if (m != null)
                {
                    txtCod.Text = m.IdMedicament.ToString();
                    txtNumeMed.Text = m.NumeMedicament.ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(m.DataExp);
                    txtProspect.Text = m.Prospect.ToString();
                    txtIdReteta.Text = m.IdReteta.ToString();
                    txtTip.Text = m.TipMedicament.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AfiseazaMedicamente()
        {
            try
            {
                var medicamente = stocareMedicamente.GetMedicamente();
                if (medicamente != null && medicamente.Any())
                {

                    dataGridViewMeds.DataSource = medicamente.Select(m => new { m.IdMedicament, m.NumeMedicament, m.DataExp, m.Prospect, m.TipMedicament, m.IdReteta }).ToList();

                    dataGridViewMeds.Columns["IdMedicament"].HeaderText = "Id Medicament";
                    dataGridViewMeds.Columns["NumeMedicament"].HeaderText = "Nume Medicament";
                    dataGridViewMeds.Columns["DataExp"].HeaderText = "Data Expirarii";
                    dataGridViewMeds.Columns["Prospect"].HeaderText = "Prospect";
                    dataGridViewMeds.Columns["TipMedicament"].HeaderText = "Tip Medicament";
                    dataGridViewMeds.Columns["IdReteta"].HeaderText = "Id Reteta";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridViewMeds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
