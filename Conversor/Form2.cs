using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversor
{
    public partial class Form2 : Form
    {
        public CheckedListBox clbDivisas;
        private Button btnCancelar, btnAceptar;
        public Form2()
        {
            clbDivisas = new CheckedListBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.Size = new Size(300, 300);

            clbDivisas.Location = new Point(10, 10);
            clbDivisas.Size = new Size(260, 210);

            //validacionOpcion("MXN - Peso mexicano");
            btnAceptar.AutoSize = true;
            btnCancelar.AutoSize = true;
            btnAceptar.Text = "Aceptar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(10, 220);
            btnAceptar.Location = new Point(195, 220);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            btnAceptar.Click += new EventHandler(btnAceptar_Click);

            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);
            this.Controls.Add(clbDivisas);
        }
        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }
        private void btnAceptar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void validacionOpcion(string divisa)
        {
            if (divisa == "MXN - Peso mexicano")
            {
                clbDivisas.Items.Add("USD - Dólar estadounidense");
                clbDivisas.Items.Add("CAD - Dólar canadiense");
                clbDivisas.Items.Add("EUR - Euro");
                clbDivisas.Items.Add("JPY - Yen japonés");
            }
            if (divisa == "USD - Dólar estadounidense")
            {
                clbDivisas.Items.Add("MXN - Peso mexicano");
                clbDivisas.Items.Add("CAD - Dólar canadiense");
                clbDivisas.Items.Add("EUR - Euro");
                clbDivisas.Items.Add("JPY - Yen japonés");
            }
            if (divisa == "CAD - Dólar canadiense")
            {
                clbDivisas.Items.Add("MXN - Peso mexicano");
                clbDivisas.Items.Add("USD - Dólar estadounidense");
                clbDivisas.Items.Add("EUR - Euro");
                clbDivisas.Items.Add("JPY - Yen japonés");
            }
            if (divisa == "EUR - Euro")
            {
                clbDivisas.Items.Add("MXN - Peso mexicano");
                clbDivisas.Items.Add("USD - Dólar estadounidense");
                clbDivisas.Items.Add("CAD - Dólar canadiense");
                clbDivisas.Items.Add("JPY - Yen japonés");
            }
            if (divisa == "JPY - Yen japonés")
            {
                clbDivisas.Items.Add("MXN - Peso mexicano");
                clbDivisas.Items.Add("USD - Dólar estadounidense");
                clbDivisas.Items.Add("CAD - Dólar canadiense");
                clbDivisas.Items.Add("EUR - Euro");
            }
            
        }
        
    }
}
