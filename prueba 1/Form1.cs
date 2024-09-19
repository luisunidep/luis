
namespace prueba_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnVerResultados_Click(object sender, EventArgs e)
        {
            {
                var num1 = 7;
                var num2 = 5;

                // Clase de operaciones aritméticas
                Operaciones op = new Operaciones();
                int resultadoSuma = op.suma(num1, num2);
                int resultadoResta = op.resta(num1, num2);
                int resultadoMultiplicacion = op.multiplicación(num1, num2);
                double resultadoDivision = op.divicion(num1, num2);

                // Clase de operaciones relacionales y lógicas
                OperadoresRelacionales rel = new OperadoresRelacionales();
                bool mayorQue = rel.mayorQue(num1, num2);
                bool menorQue = rel.menorQue(num1, num2);
                bool igual = rel.igual(num1, num2);


                // Mostrar los resultados
                MessageBox.Show($"Suma: {resultadoSuma}\nResta: {resultadoResta}\nMultiplicación: {resultadoMultiplicacion}\nDivisión: {resultadoDivision}\n" +
                                $"Mayor que: {mayorQue}\nMenor que: {menorQue}\nIgual: {igual}\n");
            }
        }

        class Operaciones
        {
            public int suma(int a, int b)
            {
                return a + b;
            }

            public int resta(int a, int b)
            {
                return a - b;
            }

            public int multiplicación(int a, int b)
            {
                return a * b;
            }

            public double divicion(int a, int b)
            {
                if (b != 0)
                    return (double)a / b;
                else
                    throw new DivideByZeroException("No se puede dividir entre cero.");
            }
        }

        class OperadoresRelacionales
        {
            public bool mayorQue(int a, int b)
            {
                return a > b;
            }

            public bool menorQue(int a, int b)
            {
                return a < b;
            }

            public bool igual(int a, int b)
            {
                return a == b;
            }
        }
    }
}
        
    

        



