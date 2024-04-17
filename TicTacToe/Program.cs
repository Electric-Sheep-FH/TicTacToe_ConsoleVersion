namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool rejouer = true;
            while (rejouer)
            {
                string[,] grille = {
                    {"┌", "─", "┬", "─", "┬", "─", "┐"},
                    {"│", " ", "│", " ", "│", " ", "│"},
                    {"├", "─", "┼", "─", "┼", "─", "┤"},
                    {"│", " ", "│", " ", "│", " ", "│"},
                    {"├", "─", "┼", "─", "┼", "─", "┤"},
                    {"│", " ", "│", " ", "│", " ", "│"},
                    {"└", "─", "┴", "─", "┴", "─", "┘"}
                };

                bool jeu = true;

                while (jeu)
                {
                    for(int i = 1; i < 3; i++)
                    {
                        AfficherTableau(grille);

                        bool invalidMvt = true;
                        while (invalidMvt)
                        {
                            Console.WriteLine($"Choisissez où placer votre pion joueur {i} : ");
                            string choix = Console.ReadLine();

                            switch  ( choix )
                            {
                                case "1":
                                    invalidMvt = PlacementPion(grille,1,1,i);
                                    break;
                                case "2":
                                    invalidMvt = PlacementPion(grille, 1, 3, i);
                                    break;
                                case "3":
                                    invalidMvt = PlacementPion(grille, 1, 5, i);
                                    break;
                                case "4":
                                    invalidMvt = PlacementPion(grille, 3, 1, i);
                                    break;
                                case "5":
                                    invalidMvt = PlacementPion(grille, 3, 3, i);
                                    break;
                                case "6":
                                    invalidMvt = PlacementPion(grille, 3, 5, i);
                                    break;
                                case "7":
                                    invalidMvt = PlacementPion(grille, 5, 1, i);
                                    break;
                                case "8":
                                    invalidMvt = PlacementPion(grille, 5, 3, i);
                                    break;
                                case "9":
                                    invalidMvt = PlacementPion(grille, 5, 5, i);
                                    break;

                            }

                        }
                        Console.Clear();
                        AfficherTableau(grille);
                        if(TableauComplet(grille) && (!Victoire(grille,"O") || !Victoire(grille,"X")))
                        {
                            jeu = false;
                            Console.WriteLine("Aucun gagnant ! Voulez vous rejouez ? (y/n)");
                            string newGame = Console.ReadLine();
                            if (newGame == "n" || newGame == "N")
                            {
                                rejouer = false;
                            }
                            Console.Clear();
                            break;
                        }
                        if (Victoire(grille, "O") || Victoire(grille, "X"))
                        {
                            jeu = false;
                            Console.WriteLine($"Le joueur {i} remporte la partie ! Voulez vous rejouez ? (y/n)");
                            string newGame = Console.ReadLine();
                            if (newGame == "n" || newGame == "N")
                            {
                                rejouer = false;
                            }
                            Console.Clear();
                            break;
                        }
                        Console.Clear();

                    }
                }

            }
        }
        public static bool PlacementPion(string[,] grille, int gridX, int gridY, int compteurJoueur)
        {
            if (grille[gridX, gridY] == " " )
            {
                grille[gridX, gridY] = compteurJoueur == 1 ? "O" : "X";
                return false;
            } else
            {
                Console.WriteLine("Case déjà occupé ! Veuillez refaire votre choix.");
                return true;
            }
        }
        public static bool Victoire(string[,] grille, string signe)
        {
            //controle ligne
            for(int i = 1; i < grille.GetLength(0); i+=2)
            {
                if (grille [i,1] == signe && grille[i, 1] == grille[i, 3] && grille[i,1] == grille[i,5])
                {
                    return true;
                }
            }
            //controle colonne
            for (int i = 1; i < grille.GetLength(0); i += 2)
            {
                if (grille[1,i] == signe && grille[1,i] == grille[3,i] && grille[1,i] == grille[5,i])
                {
                    return true;
                }
            }
            //controle diagonale
            if (grille[1,1] == signe && grille[1,1] == grille[3,3] && grille[1,1] == grille[5,5])
            {
                return true;
            }
            if (grille[1, 5] == signe && grille[1, 5] == grille[3, 3] && grille[1, 5] == grille[5, 1])
            {
                return true;
            }
            return false;
        }
        public static bool TableauComplet(string[,] grille)
        {
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                for (int k = 0; k < grille.GetLength(1); k++)
                {
                    if (grille[j,k] == " ")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void AfficherTableau(string[,] grille)
        {
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                for (int k = 0; k < grille.GetLength(1); k++)
                {
                    Console.Write(grille[j, k]);
                }
                Console.WriteLine();
            }
        }
            
    }
}
