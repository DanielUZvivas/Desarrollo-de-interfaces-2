using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio44
{
    public partial class Form1 : Form
    {
        private string titulo = "Ejercicio 4";
        private int longitud;
        public Form1()
        {
            InitializeComponent();
            longitud = titulo.Length;
            labels();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String texto = txtFrase.Text;
            if (!lb1.Items.Contains(texto))
            {
                lb1.Items.Add(texto);
            }
            labels();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (rbLista1.Checked)
            {
                if (lb1.SelectedItems.Count > 0)
                {
                    for (int i = lb1.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lb1.Items.Remove(lb1.SelectedItems[i]);
                    }
                }
            }
            else if (rbLista2.Checked)
            {
                if(lb2.SelectedIndex != -1)
                {
                        lb2.Items.RemoveAt(lb2.SelectedIndex);
                } 
            }
            labels();

        }

        private void btnTraspasar_Click(object sender, EventArgs e)
        {
            if (rbTraspaso1.Checked)
            {
                if (lb1.SelectedItems.Count > 0)
                {
                    for (int i = lb1.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lb2.Items.Add(lb1.SelectedItems[i]);
                        lb1.Items.Remove(lb1.SelectedItems[i]);
                    }
                }
            }
            else if (rbTraspaso2.Checked)
            {
                if (lb2.SelectedIndex != -1)
                {
                    lb1.Items.Add(lb2.SelectedItem);
                    lb2.Items.Remove(lb2.SelectedItem);
                }
                 
            }
            labels();
        }

        private void labels()
        {
            lblNelements.Text = "" + lb1.Items.Count;
            lblIndicesSelected.Text = "";
            for (int i = 0; i < lb1.SelectedIndices.Count; i++)
            {
                lblIndicesSelected.Text += lb1.SelectedIndices[i] + " ";
            }
            toolTip1.SetToolTip(lb2,"Elementos: "+ lb2.Items.Count);
        }

        private void lb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labels();
        }
     

        private void timer1_Tick(object sender, EventArgs e)
        {
            string tituloFin = titulo.Substring(longitud);
            this.Text = tituloFin;
            longitud--;
            if(longitud < 0)
            {
                longitud = titulo.Length;
            }
            if(longitud %2  == 0)
            {
                this.Icon = Properties.Resources.bmw;
            }
            else
            {
                this.Icon = Properties.Resources.honda;
            }
        }

        private void rbLista1_CheckedChanged(object sender, EventArgs e)
        {
            if(sender is RadioButton rb)
            {
                if (rb == rbLista1 || rb == rbLista2)
                {
                    btnBorrar.Text = "Elimina de " + rb.Tag;
                }
               
                if(rb == rbTraspaso1 || rb == rbTraspaso2)
                {
                    btnTraspasar.Text = "Traspaso de " + rb.Tag;
                }
            }
        }

       
    }
}

