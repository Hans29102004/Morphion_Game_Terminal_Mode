using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        // Déclaration des variables statiques pour le tableau de jeu, le tour, et les scores des joueurs X et O
        static char[] tb = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int tour = 1; // 1 = joueur X, 2 = joueur O
        static int scoreJoueurX = 0;
        static int scoreJoueurO = 0;

        // Méthode principale du jeu
        static void Main(string[] args)
        {
            Console.Title = "Morpion XO";
            // Demande et récupération des noms des joueurs
            string nomJoueur1, nomJoueur2;
            Console.WriteLine("Entrez le nom du Joueur 1 -X : ");
            nomJoueur1 = Console.ReadLine();
            Console.WriteLine("Entrez le nom du Joueur 2 -O : ");
            nomJoueur2 = Console.ReadLine();

            // Boucle principale du jeu
            do
            {
                Console.Clear();
                Console.WriteLine($"Joueur 1 -X : {nomJoueur1} et Joueur 2 -O: {nomJoueur2}");
                Console.WriteLine("\n");
                Tb(); // Affichage du tableau de jeu

                Console.WriteLine("Choisissez une case");
                int choix = int.Parse(Console.ReadLine()) - 1;

                // Vérification et attribution du symbole X ou O à la case choisie
                if (tb[choix] != 'X' && tb[choix] != 'O')
                {
                    if (tour % 2 == 0)
                    {
                        tb[choix] = 'O';
                        tour++;
                    }
                    else
                    {
                        tb[choix] = 'X';
                        tour++;
                    }
                }
                else
                {
                    Console.WriteLine($"La case {choix + 1} est déjà occupée. Choisissez une autre case.");
                    Console.WriteLine("Appuyez sur une touche pour choisir à nouveau.");
                    Console.ReadLine();
                }

            } while (!Victoire() && !Egalité()); // Condition de fin de jeu

            Console.Clear();
            Tb(); // Affichage final du tableau

            // Affichage du résultat du jeu
            if (Victoire())
            {
                if (tour % 2 == 0)
                {
                    Console.WriteLine($"Puissance 3!!! Le joueur {nomJoueur2} a gagné !");
                    scoreJoueurO++;
                }
                else
                {
                    Console.WriteLine($"Puissance 3!!! Le joueur {nomJoueur1} a gagné !");
                    scoreJoueurX++;
                }
            }
            else
            {
                Console.WriteLine("Egalité");
            }

            // Affichage des scores des joueurs
            Console.WriteLine($"Score : {nomJoueur1}: {scoreJoueurX} || {nomJoueur2}: {scoreJoueurO}");

            // Demande de rejouer
            Console.WriteLine("Voulez-vous rejouer ? (Oui/Non)");
            string reponse = Console.ReadLine();
            if (reponse.ToLower() == "oui") //  ToLower pour ignorer la casse
            {
                ResetGame(); // Réinitialisation du jeu
                Main(args); // Relance le jeu en appelant la méthode Main
            }
            else
            {
                Console.WriteLine("Merci d'avoir joué !");
            }

            Console.ReadLine();
            
        }

        // Méthode d'affichage du tableau de jeu
        private static void Tb()
        {
            // Affichage des lignes et des cases du tableau
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tb[0]}  |  {tb[1]}  |  {tb[2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tb[3]}  |  {tb[4]}  |  {tb[5]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tb[6]}  |  {tb[7]}  |  {tb[8]}");
            Console.WriteLine("     |     |      ");
        }

        // Méthode pour vrifié si il y a  victoire
        private static bool Victoire()
        {
            // Vérification des différentes combinaisons gagnantes
            if ((tb[0] == tb[1] && tb[1] == tb[2]) ||
                (tb[3] == tb[4] && tb[4] == tb[5]) ||
                (tb[6] == tb[7] && tb[7] == tb[8]) ||
                (tb[0] == tb[3] && tb[3] == tb[6]) ||
                (tb[1] == tb[4] && tb[4] == tb[7]) ||
                (tb[2] == tb[5] && tb[5] == tb[8]) ||
                (tb[0] == tb[4] && tb[4] == tb[8]) ||
                (tb[2] == tb[4] && tb[4] == tb[6]))
            {
                return true;
            }
            else
                return false;
        }
        // Methode pour verifier si il y a egalité
        private static bool Egalité()
        {
            for (int i = 0; i < tb.Length; i++)
            {
                if (tb[i] != 'X' && tb[i] != 'O')
                {
                    return false;
                }
            }
            return true;
        }
        private static void ResetGame()
        {
            tb = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            tour = 1;
            
        }


    }
    
}
