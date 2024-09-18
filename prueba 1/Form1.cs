
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
            Operaciones op = new Operaciones();
            int resultado1 = op.suma(num1, num2);
            int resultado2 = op.resta(num1, num2);
            int resultado3 = op.multiplicación(num1, num2);
            int resultado4 = op.divicion(num1, num2);
        }


        class Operaciones
        {
            public int suma(int a, int b)
            {
                int toalsuma = a + b;
                return toalsuma;
            }
            public int resta(int a, int b)
            {
                int toalresta = a + b;
                return toalresta;
            }
            public int multiplicación(int a, int b)
            {
                int toalmultiplicación = a + b;
                return toalmultiplicación;
            }
            public int divicion(int a, int b)
            {
                int toaldivicion = a + b;
                return toaldivicion;
            }
        }
    }
}
        



