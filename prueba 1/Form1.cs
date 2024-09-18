namespace prueba_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var num1 = 7;
            var num2 = 5;
            operaciones op= new operaciones();
            int resultado = op.suma(num1, num2);
        }

        
        class operaciones   
        }



            public int suma(int a, int b)
            {
                int toalsuma = a + b;
                return toalsuma;
            }
        }
    

