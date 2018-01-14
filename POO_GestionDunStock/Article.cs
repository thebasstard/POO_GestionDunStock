using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GestionDunStock
{
    class Article
    {
        private int numref;
        private string nom;
        private double prixvente;
        private int qt_en_stock;

        

        public int Numref
        {
            get { return numref; }
            set { numref = value; }
        }

        

        public  string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        
        public double Prixvente
        {
            get { return prixvente; }
            set { prixvente = value; }
        }

  

        public int QuantiteStock
        {
            get { return qt_en_stock; }
            set { qt_en_stock = value; }
        }

        public Article() { }

        public Article(int num, string name, double pr, int qt)
        {
            numref = num;
            nom = name;
            prixvente = pr;
            qt_en_stock = qt;
        }

        public override string ToString()
        {
            //return base.ToString();
            return "\r\nNuméro: " + numref + "\r\nNom: " + nom + "\r\nPrix: " + prixvente + "\r\nQuantité: " + qt_en_stock;
            
        }



    }
}
