using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;        // lib to use I/O

namespace TP_RecoFormes
{
    class Program
    {
        /*
         * Le but de ce programme est d'identifier des caractèristiques pour identifer différents chiffres extraits de fichiers texte
         * Auteur : Lucie Cayment
         */
        static void Main(string[] args)
        {
            int nbnodes;
            string nomFichier = "";
            string fichierDemande = "";
            char[,] matrix = new char[100, 100];
            int B = 0;
            int D = 0;
            int B_gauche = 0;
            int B_droite = 0;
            int B_droite_haut = 0;
            int B_gauche_haut = 0;
            int chiffreReconnu = -1;


            Console.WriteLine("Merci d'inscrire le nom du fichier souhaité :");
            fichierDemande = Console.ReadLine();
            nomFichier = "..\\..\\fichier_txt\\" + fichierDemande + ".txt";
            if (File.Exists(nomFichier) == false)
            {
                Console.WriteLine("Le fichier {0} demandé n'existe pas :(", nomFichier);
            }
            else    // le fichier existe
            {
                Console.WriteLine("Le fichier {0} demandé existe", nomFichier);
                // on initialise un stream reader avec le nom du fichier
                StreamReader monStreamReader = new StreamReader(nomFichier);
                string ligne = monStreamReader.ReadLine();
                nbnodes = Convert.ToInt32(ligne);   // Nombre de nœuds du graphe
                Console.WriteLine("Voici le nombre de noeuds : {0}", nbnodes);

                // on va lire toutes les lignes du fichier
                ligne = monStreamReader.ReadLine();
                while (ligne != null)    // Tant qu’il reste une ligne dans le fichier 
                {
                    int x = Convert.ToInt32(ligne);
                    ligne = monStreamReader.ReadLine();
                    int y = Convert.ToInt32(ligne);
                    ligne = monStreamReader.ReadLine();
                    matrix[x, y] = ligne[0];      // C’est « d » ou « b » normalement 
                    if (ligne[0] == 'b')
                    {
                        if (y == 0)     // la liaison est à gauche du chiffre
                        {
                            B_gauche++;
                        }
                        else
                        {
                            if (x == 0)     // la liaison est en haut à gauche du chiffre
                            {
                                B_gauche_haut++;
                            }
                            else            // la liaison est en haut à droite du chiffre
                            {
                                B_droite_haut++;
                            }
                            B_droite++;
                        }
                        B++;
                    }
                    else if (ligne[0] == 'd')
                    {
                        D++;
                    }
                    ligne = monStreamReader.ReadLine();
                }

                // Fermeture du StreamReader (obligatoire) 
                monStreamReader.Close();

                Console.WriteLine("Il y a {0} de liaisons B, dont {1} sur le côté gauche et {2} sur le côté droit", B, B_gauche, B_droite);
                Console.WriteLine("Il y a {0} de liaisons D", D);

                chiffreReconnu = SortieNombreNoeud(nbnodes);
                if (chiffreReconnu == -1)
                {
                    chiffreReconnu = SortieNombre(B, D, B_gauche, B_droite, B_droite_haut, B_gauche_haut);
                }

                Console.WriteLine("Le chiffre décrit dans le fichier texte est le chiffre {0}", chiffreReconnu);
            }

            
        }

        static int SortieNombreNoeud(int nbnodes)
        {
            int chiffre = -1;
            // ---------------- On differencie 1 du 5 du 7 ----------------
            if (nbnodes == 3)
            {
                chiffre = 1;
            }
            else if (nbnodes == 4)
            {
                chiffre = 7;
            }
            else if (nbnodes == 5)
            {
                chiffre = 4;
            }
            else;

            return chiffre;
            // ---------------- ---------------- ----------------
        }
        static int SortieNombre(int B, int D, int B_gauche, int B_droite, int B_droite_haut, int B_gauche_haut)
        {
            int chiffre = -1;

            // ---------------- On differencie 8 du 0 ----------------
            if (chiffre == -1)
            {
                if ((B == 4) && (D == 2))
                {
                    chiffre = 0;
                }
                else if ((B == 4) && (D == 3))
                {
                    chiffre = 8;
                }
            }
            // ---------------- ---------------- ----------------

            // ---------------- On differencie 3 du 6 du 9 ----------------
            if (chiffre == -1)
            {
                if ((B_gauche == 2) && (B_droite == 1))
                {
                    chiffre = 6;
                }
                else if ((B_droite == 2) && (B_gauche == 1))
                {
                    chiffre = 9;
                }
                else if (B_gauche == 0)
                {
                    chiffre = 3;
                }
            }
            // ---------------- ---------------- ----------------

            // ---------------- On differencie 2 du 5 ----------------
            if (chiffre == -1)
            {
                if (B_droite_haut == 1)
                {
                    chiffre = 5;
                }
                else if (B_gauche_haut == 1)
                {
                    chiffre = 2;
                }
            }
            // ---------------- ---------------- ----------------

            return chiffre;
        }
    }
}
