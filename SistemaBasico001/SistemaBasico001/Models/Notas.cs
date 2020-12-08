using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBasico001.Models
{
    public class Notas
    {
        public Notas() { }
        public string Materia;
        public string Nota1;
        public string Nota2;
        public string Nota3;
        public string Nota4;
        public string Recu;
        public string Media;
        public Notas(string Materia, string Nota1, string Nota2, string Nota3, string Nota4, string Recu, string Media)
        {
            this.Materia = Materia;
            this.Nota1 = Nota1;
            this.Nota2 = Nota2;
            this.Nota3 = Nota3;
            this.Nota4 = Nota4;
            this.Recu = Recu;
            string[] notas2 = new string[5] { Nota1, Nota2, Nota3, Nota4, Recu };
            double[] notas = new double[5];
            int cont = 0;
            foreach (var nota in notas2)
            {
                if (nota != null)
                {
                    notas[cont] = Convert.ToDouble(nota);
                }
                else
                {
                    notas[cont] = 0;
                }
                cont++;
            }
            if (notas[4] > 0)
            {
                this.Media = Convert.ToString((notas[0] + notas[1] + notas[2] + notas[3] + notas[4]) / 5);
            }
            else
            {
                this.Media = Convert.ToString((notas[0] + notas[1] + notas[2] + notas[3]) / 4);
            }

        }
        public Notas(string Materia, string Nota1, string Nota2, string Nota3, string Nota4, string Recu, string Media, string IDMateria)
        {
            this.Materia = Materia;
            this.Nota1 = Nota1;
            this.Nota2 = Nota2;
            this.Nota3 = Nota3;
            this.Nota4 = Nota4;
            this.Recu = Recu;
            string[] notas2 = new string[5] { Nota1, Nota2, Nota3, Nota4, Recu };
            double[] notas = new double[5];
            int cont = 0;
            foreach (var nota in notas2)
            {
                if (nota != null)
                {
                    notas[cont] = Convert.ToDouble(nota);
                }
                else
                {
                    notas[cont] = 0;
                }
                cont++;
            }
            if (notas[4] > 0)
            {
                this.Media = Convert.ToString((notas[0] + notas[1] + notas[2] + notas[3] + notas[4]) / 5);
            }
            else
            {
                this.Media = Convert.ToString((notas[0] + notas[1] + notas[2] + notas[3]) / 4);
            }

        }
    }
}