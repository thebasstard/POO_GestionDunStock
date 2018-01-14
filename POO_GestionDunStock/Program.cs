using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GestionDunStock
{
    class Program
    {
        //fonction qui permet de vérifier l'existence d'un article
        static int Rechercher(List<Article> L, int r)            
        {
            int p = -1;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].Numref == r)
                {
                    p = i;
                    break;
                }
            }
            return p;
        }
        static void Main(string[] args)
        {
                int choix, num, quantite, p;
                double prix;
                string nom;
                List<Article> Stock = new List<Article>();
                do
                {
                    Console.Out.WriteLine("*******************************Menu*****************************");
                    Console.Out.WriteLine("1-Rechercher un article par numéro");
                    Console.Out.WriteLine("2-Ajouter un article");
                    Console.Out.WriteLine("3-Supprimer un article par numéro");
                    Console.Out.WriteLine("4-Modifier un article par numéro");
                    Console.Out.WriteLine("5-Rechercher un article par nom");
                    Console.Out.WriteLine("6-Rechercher un article par intervalle de prix de vente");
                    Console.Out.WriteLine("7-Afficher tous les articles");
                    Console.Out.WriteLine("8-Quitter");
                    Console.Out.Write("Donner votre choix: ");
                    choix = int.Parse(Console.In.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            Console.Out.Write("Donner le numéro de l'article à rechercher: ");
                            num = int.Parse(Console.In.ReadLine());
                            p = Rechercher(Stock, num);
                            if (p == -1)
                            {
                                Console.Out.WriteLine("article est introuvable");
                            }
                            else
                            {
                                Console.Out.WriteLine(Stock[p]);
                            }
                            break;

                        case 2:
                            Console.Out.Write("Donner le numéro de l'article à ajouter: ");
                            num = int.Parse(Console.In.ReadLine());
                            p = Rechercher(Stock, num);
                            if (p != -1)
                            {
                                Console.Out.WriteLine("Article existe dèjà");
                            }
                            else
                            {
                                Console.Out.Write("Donner le nom : ");
                                nom = Console.In.ReadLine();
                                Console.Out.Write("Donner le prix: ");
                                prix = double.Parse(Console.In.ReadLine());
                                Console.Out.Write("Donner la quantité: ");
                                quantite = int.Parse(Console.In.ReadLine());
                                Stock.Add(new Article(num, nom, prix, quantite));
                                Console.Out.WriteLine("Article Ajouté avec succès");
                            }
                            break;

                        case 3:
                            Console.Out.Write("Donner le numéro de l'article à supprimer:");
                            num = int.Parse(Console.In.ReadLine());
                            p = Rechercher(Stock, num);
                            if (p == -1)
                            {
                                Console.Out.WriteLine("Article introuvable");
                            }
                            else
                            {
                                //Stock.Remove(Stock[p]);
                                Stock.RemoveAt(p);
                                Console.Out.WriteLine("Article supprimé avec succès");
                            }
                            break;

                        case 4:
                            Console.Out.Write("Entrer le numéro de l'article à modifier: ");
                            num = int.Parse(Console.In.ReadLine());
                            p = Rechercher(Stock, num);
                            if (p == -1)
                            {
                                Console.Out.WriteLine("Article introuvable");
                            }
                            else
                            {   //Proposer un sous menu pour choisir l'attribut à modifier
                                int c;
                                do
                                {
                                    Console.Out.WriteLine("*****Options*****");
                                    Console.Out.WriteLine("1-Modifier le nom");
                                    Console.Out.WriteLine("2-Modifier le prix");
                                    Console.Out.WriteLine("3-Modifier la quantité");
                                    Console.Out.WriteLine("4-Terminer");
                                    Console.Out.Write("Donner votre choix: ");
                                    c = int.Parse(Console.In.ReadLine());
                                    switch (c)
                                    {
                                        case 1:
                                            Console.Out.Write("Donner le nouveau nom: ");
                                            Stock[p].Nom = Console.In.ReadLine();
                                            Console.Out.WriteLine("Nom modifié avec succès");
                                            break;
                                        case 2:
                                            Console.Out.Write("Donner le prix: ");
                                            Stock[p].Prixvente = double.Parse(Console.In.ReadLine());
                                            Console.Out.WriteLine("Prix modifié avec succès");
                                            break;
                                        case 3:
                                            Console.Out.Write("Donner la quantité: ");
                                            Stock[p].QuantiteStock = int.Parse(Console.In.ReadLine());
                                            Console.Out.WriteLine("Quantité modifiée avec succès");
                                            break;
                                        case 4:
                                            Console.Out.WriteLine("Modifications terminées");
                                            break;
                                        default:
                                            Console.Out.WriteLine("Choix invalide");
                                            break;
                                    }

                                }
                                while (c != 4);
                            }
                            break;

                        case 5:
                            Console.Out.Write("Donner le nom de l'article à rechercher: ");
                            nom = Console.In.ReadLine();
                            int comp = 0;
                            for (int i = 0; i < Stock.Count; i++)
                            {
                                if (Stock[i].Nom.ToLower() == nom.ToLower())
                                {
                                    Console.Out.Write(Stock[i].ToString());
                                    comp++;
                                }
                            }
                            if (comp == 0)
                            {
                                Console.Out.WriteLine("Aucun résultat");
                            }
                            break;
                        case 6:
                            double min, max; int cpt = 0;
                            Console.Out.Write("Donner le prix min :");
                            min = double.Parse(Console.In.ReadLine());
                            Console.Out.Write("Donner le prix max: ");
                            max = double.Parse(Console.In.ReadLine());
                            if (min < 0 || max < 0 || min > max)
                            {
                                Console.Out.WriteLine("Intervalle invalide");
                            }
                            else
                            {
                                for (int i = 0; i < Stock.Count; i++)
                                {
                                    if (Stock[i].Prixvente >= min && Stock[i].Prixvente <= max)
                                    {
                                        cpt++;
                                        Console.Out.WriteLine(Stock[i]);
                                    }
                                }
                                if (cpt == 0)
                                {
                                    Console.Out.WriteLine("Aucun résultat");
                                }
                            }
                            break;
                        case 7:
                            foreach (Article a in Stock)
                            {
                                Console.Out.WriteLine(a);
                            }
                            if (Stock.Count == 0)
                            {
                                Console.Out.WriteLine("Aucun résultat");
                            }
                            break;
                        case 8:
                            Console.Out.WriteLine("Fin du programme");
                            break;
                        default:
                            Console.Out.WriteLine("Choix invalide");
                            break;

                    }
                } while (choix != 8);
                Console.ReadKey();
                
            }
        }
}
