using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duration
{
    class Durée
    {
        private int heure;
        private int minute;
        private int seconde;

        /* initialisation */
        public Durée(int heure, int minute, int seconde)
        {
            if (heure < 0 || heure > 23)
                this.heure = 0;
            else
                this.heure = heure;

            if (minute < 0 || minute > 59)
                this.minute = 0;
            else
                this.minute = minute;

            if (seconde < 0 || seconde > 59)
                this.seconde = 0;
            else
                this.seconde = seconde;
        }

        /* affichage */
        public void Afficher()
        {
            Console.WriteLine(
                $"{this.heure.ToString().PadLeft(2, '0')}:" +
                $"{this.minute.ToString().PadLeft(2, '0')}:" +
                $"{this.seconde.ToString().PadLeft(2, '0')}"
            );
        }

        /* addition */
        static public Durée operator +(Durée duree1, Durée duree2)
        {
            int totalSecondes = (duree1.heure + duree2.heure) * 3600;
            totalSecondes += (duree1.minute + duree2.minute) * 60;
            totalSecondes += duree1.seconde + duree2.seconde;

            int heure = (totalSecondes / 3600) % 24;
            int minute = (totalSecondes % 3600) / 60;
            int seconde = (totalSecondes % 3600) % 60;

            return new Durée(heure, minute, seconde);
        }

        /* soustraction */
        static public Durée operator -(Durée duree1, Durée duree2)
        {
            int totalSecondes = (duree1.heure - duree2.heure) * 3600;
            totalSecondes += (duree1.minute - duree2.minute) * 60;
            totalSecondes += duree1.seconde - duree2.seconde;

            if (totalSecondes < 0)
                totalSecondes = (24 * 3600) + totalSecondes;

            int heure = (totalSecondes / 3600) % 24;
            int minute = (totalSecondes % 3600) / 60;
            int seconde = (totalSecondes % 3600) % 60;

            return new Durée(heure, minute, seconde);
        }

        /* égalité */
        static public bool operator ==(Durée duree1, Durée duree2)
        {
            if ((duree1.heure == duree2.heure) && (duree1.minute == duree2.minute) && (duree1.seconde == duree2.seconde))
                return true;
            else
                return false;
        }

        /* inégalité */
        static public bool operator !=(Durée duree1, Durée duree2)
        {
            return !(duree1 == duree2);
        }

        /* supériorité */
        static public bool operator >(Durée duree1, Durée duree2)
        {
            if (duree1.heure > duree2.heure)
                return true;
            else if (duree1.heure == duree2.heure)
            {
                if (duree1.minute > duree2.minute)
                    return true;
                else if (duree1.minute == duree2.minute)
                {
                    if (duree1.seconde > duree2.seconde)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /* infériorité */
        static public bool operator <(Durée duree1, Durée duree2)
        {
            if (!(duree1 > duree2) && (duree1 != duree2))
                return true;
            else
                return false;
        }

        /* supérieur ou égal */
        static public bool operator >=(Durée duree1, Durée duree2)
        {
            if ((duree1 > duree2) || (duree1 == duree2))
                return true;
            else
                return false;
        }

        /* inférieur ou égal */
        static public bool operator <=(Durée duree1, Durée duree2)
        {
            if (!(duree1 > duree2) || (duree1 == duree2))
                return true;
            else
                return false;
        }

        /* convertir en secondes */
        static public explicit operator int(Durée duree1)
        {
            return (duree1.heure * 3600) + (duree1.minute * 60) + duree1.seconde;
        }
    }
}
