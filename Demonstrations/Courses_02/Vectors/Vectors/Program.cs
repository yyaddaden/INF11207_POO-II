using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Vecteur
    {
        public int x;
        public int y;

        public void Afficher()
        {
            Console.WriteLine($"x = {this.x} | y = {this.y}");
        }

        static public bool operator ==(Vecteur vect1, Vecteur vect2)
        {
            if (vect1.x == vect2.x && vect1.y == vect2.y)
                return true;
            else
                return false;
        }

        static public bool operator !=(Vecteur vect1, Vecteur vect2)
        {
            return !(vect1 == vect2);
        }

        /* Implicite */
        static public implicit operator int(Vecteur vect1)
        {
            return (int)Math.Sqrt(Math.Pow(vect1.x, 2) + Math.Pow(vect1.y, 2));
        }

        /* Explicite */
        //static public explicit operator int(Vecteur vect1)
        //{
        //    return (int)Math.Sqrt(Math.Pow(vect1.x, 2) + Math.Pow(vect1.y, 2));
        //}

        static public Vecteur operator +(Vecteur vect1, Vecteur vect2)
        {
            Vecteur vect3 = new Vecteur();
            vect3.x = vect1.x + vect2.x;
            vect3.y = vect1.y + vect2.y;

            return vect3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vecteur vect1 = new Vecteur();
            vect1.x = 5; vect1.y = 3;

            Vecteur vect2 = new Vecteur();
            vect2.x = 5; vect2.y = 3;

            /* somme */
            Console.Write("Somme des vecteurs vect1 + vect2 donne le vecteur : ");
            (vect1 + vect2).Afficher();

            /* égalité */
            Console.WriteLine($"Egalité des vecteurs vect1 = vect2 donne : {vect1 == vect2}");

            /* conversion explicite */
            //int val = (int)vect1;

            /* conversion implicite */
            int val = vect1;

            Console.Write("La norme du vecteur vect1 donne : ");
            Console.WriteLine($"{val}");

            Console.ReadKey();
        }
    }
}
