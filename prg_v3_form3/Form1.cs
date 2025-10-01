using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prg_v3_form3
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            // Marcas
            cmbMarca.Items.Add("Ford");
            cmbMarca.Items.Add("Chevrolet");
            cmbMarca.Items.Add("Fiat");


            // Colores
            cmbColor.Items.Add("Blanco");
            cmbColor.Items.Add("Negro");
            cmbColor.Items.Add("Rojo");
            cmbColor.Items.Add("Gris");

            // Columnas creadas
            dgvAutos.Columns.Add("Marca", "Marca");
            dgvAutos.Columns.Add("Modelo", "Modelo");
            dgvAutos.Columns.Add("Color", "Color");

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool repetir = true;

            do
            {
                // Valida la seleccion de auto
                if (cmbMarca.SelectedItem == null || cmbModelo.SelectedItem == null || cmbColor.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar Marca, Modelo y Color");
                    repetir = false; 
                }
                else
                {
                    // Agregar auto a la lista
                    dgvAutos.Rows.Add(cmbMarca.SelectedItem, cmbModelo.SelectedItem, cmbColor.SelectedItem);
                    MessageBox.Show("Auto agregado correctamente");

                    // vacia ComboBox para nuevo ingreso
                    cmbMarca.SelectedIndex = -1;
                    cmbModelo.Items.Clear();
                    cmbColor.SelectedIndex = -1;

                    repetir = false; 
                }

            } while (repetir);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAutos.CurrentRow != null && !dgvAutos.CurrentRow.IsNewRow)
            {
                dgvAutos.Rows.Remove(dgvAutos.CurrentRow);
            }
            else
            {
                MessageBox.Show("Seleccione un auto de la lista para eliminar.");
            }

        }

        // cambia la marca seleccionada
        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModelo.Items.Clear(); // limpiar modelos anteriores

            
            if (cmbMarca.SelectedItem == null) 
            { 
                return;
            }


            switch (cmbMarca.SelectedItem.ToString())
            {
                case "Ford":
                    cmbModelo.Items.Add("Fiesta");
                    cmbModelo.Items.Add("Ecosport");
                    break;

                case "Chevrolet":
                    cmbModelo.Items.Add("Prisma");
                    cmbModelo.Items.Add("Cruze");
                    break;

                case "Fiat":
                    cmbModelo.Items.Add("Palio");
                    cmbModelo.Items.Add("Cronos");
                    break;
            }

        }
    }
}