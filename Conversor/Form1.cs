namespace Conversor
{
    public partial class Form1 : Form
    {
        private int num;
        private Label lblMoneda;
        private Label lblMonto;
        
        public GroupBox grpConversiones;
        //------
        private TextBox txtMonto;
        //------
        public ComboBox cmbDivisas;

        private Button btnCalcular;
        private Button btnLimpiar;


        public double valor;
        public Form1()
        {
            num = 1;   
            lblMoneda= new Label();
            lblMonto= new Label();
            txtMonto= new TextBox();
            cmbDivisas= new ComboBox();
            grpConversiones= new GroupBox();
            btnCalcular= new Button();
            btnLimpiar = new Button();
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.Size = new Size(300, 350);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            lblMoneda.AutoSize = true;
            lblMonto.AutoSize = true;
            lblMoneda.Text = "Moneda";
            lblMonto.Text = "Monto";
            lblMoneda.Location=new Point(10,10);
            lblMonto.Location = new Point(170, 10);

            cmbDivisas.Location = new Point(10,30);
            cmbDivisas.Size = new Size(150,30);
            cmbDivisas.Items.Add("USD - Dólar estadounidense");
            cmbDivisas.Items.Add("MXN - Peso mexicano");
            cmbDivisas.Items.Add("CAD - Dólar canadiense");
            cmbDivisas.Items.Add("EUR - Euro");
            cmbDivisas.Items.Add("JPY - Yen japonés");


            txtMonto.Size = new Size(100,20);
            txtMonto.Location = new Point(170,30);

            grpConversiones.Text ="Conversiones";
            grpConversiones.Size = new Size(265,200);
            grpConversiones.Location = new Point(10,100);

            btnCalcular.Size = new Size(100,20);
            btnCalcular.Text = "Calcular";
            btnCalcular.Location = new Point(170,60);
            btnCalcular.Click+= new EventHandler(btnCalcular_Click);

            btnLimpiar.Size = new Size(100, 20);
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Location = new Point(10, 60);
            btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
            //btnCalcular.Click += new EventHandler(btnCalcular_ClickReset);


            this.Controls.Add(lblMoneda);
            this.Controls.Add(lblMonto);
            this.Controls.Add(txtMonto);
            this.Controls.Add(cmbDivisas);
            this.Controls.Add(grpConversiones);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(btnCalcular);
        }
        private void btnCalcular_Click(object? sender, EventArgs e) {
            Form2 frmSeleccion = new Form2();
            if ((cmbDivisas.SelectedItem != null && cmbDivisas.SelectedItem.ToString() !="") && (txtMonto != null && txtMonto.Text != "" && validarNumero(txtMonto.Text) ==true))
            {
                this.valor = validarValorConversion(txtMonto.Text);
                if (cmbDivisas.SelectedItem.ToString()!=null)
                {
                    frmSeleccion.validacionOpcion(cmbDivisas.SelectedItem.ToString());
                }
                if (frmSeleccion.ShowDialog() == DialogResult.OK)
                {
                    foreach (var dato in frmSeleccion.clbDivisas.CheckedItems) {
                        
                        Label lblConversion = new Label();
                        TextBox txtConversion = new TextBox();
                        
                        lblConversion.Text = dato.ToString();
                        lblConversion.Location = new Point(10, 30*num);
                        txtConversion.Size = new Size(100, 10);
                        txtConversion.Location = new Point(160, 30*num);
                        txtConversion.Text = (realizarConversiones(dato.ToString(), cmbDivisas.SelectedItem.ToString(), valor));
                        num++;
                        grpConversiones.Controls.Add(txtConversion);
                        grpConversiones.Controls.Add(lblConversion);
                        
                    }
                    /*
                    Label lblConversion = new Label();
                    TextBox txtConversion = new TextBox();

                    lblConversion.Location = new Point(10,20);
                    txtConversion.Size = new Size(100, 20);
                    txtConversion.Location = new Point(160,20);

                    lblConversion.Text = frmSeleccion.clbDivisas.SelectedItem.ToString();
                    grpConversiones.Controls.Add(txtConversion);
                    grpConversiones.Controls.Add(lblConversion);
                    */
                }
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) {
            if (grpConversiones.Controls!=null)
            {
                num = 1;
                grpConversiones.Controls.Clear();
            }
        }
        private Double validarValorConversion(string valor)
        {
            double valorDouble = 0.0;
            bool resultado = double.TryParse(valor, out valorDouble);
            if (valor == "" || resultado == false || resultado==null )
            {
                return 0.0;
            }
            else
            {
                return Convert.ToDouble(valor);
            }

        }
        private bool validarNumero(string valor) {
            double valorDouble = 0.0;
            bool resultado = double.TryParse(valor, out valorDouble);
            if (valor == "" || resultado == false || resultado == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private string realizarConversiones(String divisaConversion, String divisaActual,double valor) {
            double resultado=0.0;
            string texto="";
            if (divisaActual == "MXN - Peso mexicano")
            {
                if (divisaConversion == "USD - Dólar estadounidense")
                {
                    resultado = valor * 0.05;
                    texto = resultado.ToString();
                }
                if (divisaConversion == "CAD - Dólar canadiense")
                {
                    resultado = valor * 0.06;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "EUR - Euro")
                {
                    resultado = valor * 0.04;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "JPY - Yen japonés")
                {
                    resultado = valor * 5.32;
                    texto = resultado.ToString();

                }
            }
            else if (divisaActual == "USD - Dólar estadounidense") {
                if (divisaConversion == "MXN - Peso mexicano") {
                    resultado = valor *21.23;
                    texto = resultado.ToString();
                }
                if (divisaConversion == "CAD - Dólar canadiense")
                {
                    resultado = valor *1.28;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "EUR - Euro")
                {
                    resultado = valor *0.89;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "JPY - Yen japonés")
                {
                    resultado = valor *113.05;
                    texto = resultado.ToString();

                }
            }
            else if (divisaActual == "CAD - Dólar canadiense") {
                if (divisaConversion == "MXN - Peso mexicano")
                {
                    resultado = valor *16.55;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "USD - Dólar estadounidense")
                {
                    resultado = valor *0.78;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "EUR - Euro")
                {
                    resultado = valor *0.69;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "JPY - Yen japonés")
                {
                    resultado = valor *88.12;
                    texto = resultado.ToString();

                }
            }
            else if (divisaActual == "EUR - Euro") {
                if (divisaConversion == "MXN - Peso mexicano")
                {
                    resultado = valor *23.96;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "USD - Dólar estadounidense")
                {
                    resultado = valor *1.13;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "CAD - Dólar canadiense")
                {
                    resultado = valor *1.45;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "JPY - Yen japonés")
                {
                    resultado = valor *127.56;
                    texto = resultado.ToString();
                }
            }
            else if (divisaActual == "JPY - Yen japonés") {
                if (divisaConversion == "MXN - Peso mexicano")
                {
                    resultado = valor *0.1878;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "USD - Dólar estadounidense")
                {
                    resultado = valor *0.0088;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "CAD - Dólar canadiense")
                {
                    resultado = valor *0.0113;
                    texto = resultado.ToString();

                }
                if (divisaConversion == "EUR - Euro")
                {
                    resultado = valor *0.0078;
                    texto = resultado.ToString();

                }
            }
            return texto; 
        }
    }
}