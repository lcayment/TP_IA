using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_RecoFormesMatrice
{
    class Program
    {
        /*
         * Le but de ce programme est d'identifier différents chiffres extraits depuis une matrice d'adjacence
         * Auteur : Lucie Cayment
         */
        static void Main(string[] args)
        {
            int nbnodes;
            string nomFichier = "";
            string fichierDemande = "";
            char[,] matrix = new char[100, 100];

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
                    matrix[x, y] += ligne[0];      // C’est « d » ou « b » normalement 
                    ligne = monStreamReader.ReadLine();
                }

                // Fermeture du StreamReader (obligatoire) 
                monStreamReader.Close();

                for (int i = 0; i < nbnodes; i++)
                {
                    for (int j = 0; j < nbnodes; j++)
                    {
                        if (matrix[i, j] != '0')
                        {
                            Console.Write(matrix[i, j]);
                        }
                    }
                    Console.WriteLine("");
                }

            }
        }
    }
}

