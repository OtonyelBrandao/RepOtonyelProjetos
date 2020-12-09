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
        public string IDMateria;
        public string IDNota1;
        public string IDNota2;
        public string IDNota3;
        public string IDNota4;
        public string IDRecu;
        public Notas(string Materia,string IDMateria, string Nota1,string IDNota1, string Nota2,string IDNota2, string Nota3,string IDNota3, string Nota4,string IDNota4, string Recu, string IDRecu, string Media)
        {
            if (Recu == null)
            {
                Recu = Convert.ToString(0);
            }
            if (Nota4 == null)
            {
                Nota4 = Convert.ToString(0);
            }
            if (Nota3 == null)
            {
                Nota3 = Convert.ToString(0);
            }
            if (Nota2 == null)
            {
                Nota2 = Convert.ToString(0);
            }
            if (Nota1 == null)
            {
                Nota1 = Convert.ToString(0);
            }

            this.Materia = Materia;
            this.Nota1 = Nota1;
            this.Nota2 = Nota2;
            this.Nota3 = Nota3;
            this.Nota4 = Nota4;
            this.Recu = Recu;
            this.IDMateria = IDMateria;
            this.IDNota1 = IDNota1;
            this.IDNota2 = IDNota2;
            this.IDNota3 = IDNota3;
            this.IDNota4 = IDNota4;
            this.IDRecu = IDRecu;
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