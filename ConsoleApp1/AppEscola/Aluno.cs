using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscola.RegrasDeNegocio
{

    internal class Aluno
    {
        public int Id { get; set; }
        public int NumeroDeMatricula { get; set; }
        public string Nome { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }

        //metodos 
        public double CalcularMedia()
        {
            return (Nota1 + Nota2) / 2;

        }
        public string MostrarSituacao()
        {
            string situacao = "REPROVADO";
            if (CalcularMedia() >= 60)
            {
                situacao = "APROVADO";
            }
            return situacao;
        }

    }
}