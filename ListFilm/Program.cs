using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//SOURCES: https://github.com/Sigma3Wolf/ListFilm
namespace ListFilm {
    public enum JoursSemaine {
        Dimanche = 0,
        Lundi = 1,
        Mardi = 2,
        Mercredi = 3,
        Jeudi = 4,
        Vendredi = 5,
        Samedi = 6,
    }

    public class Films {
        public string NomFilm;
        public JoursSemaine Jours;

        public Films(string pstrNomFilm, JoursSemaine penmJours) {
            this.NomFilm = pstrNomFilm;
            this.Jours = penmJours;
        }
    }

    internal class Program {
        static void Main(string[] args) {
            List<Films> ListFilms = new List<Films>();
            Films objFilm;

            ListFilms.Add(new Films("Rapide et Dangereux", JoursSemaine.Mardi));
            ListFilms.Add(new Films("Pas sans moi!", JoursSemaine.Lundi));
            ListFilms.Add(new Films("Mon chien Sammy", JoursSemaine.Lundi));
            ListFilms.Add(new Films("Pas sans moi!", JoursSemaine.Mercredi));
            ListFilms.Add(new Films("Pas sans moi!", JoursSemaine.Vendredi));
            ListFilms.Add(new Films("Wonderworld!", JoursSemaine.Vendredi));
            ListFilms.Add(new Films("Loin de toi", JoursSemaine.Samedi));

            bool blnExit = false;
            while (blnExit == false) {
                Console.Clear(); //Efface l'écran
                Console.WriteLine("Menu CINEMA");
                Console.WriteLine("===========");
                Console.WriteLine();
                Console.WriteLine("1. Liste des films par jour");
                Console.WriteLine("2. Liste des films pour une journée");
                Console.WriteLine("3. Journée d'un film spécifique");
                Console.WriteLine("4. Sortir");
                Console.WriteLine();
                Console.WriteLine("Faite votre choix: {1, 2, 3, 4}");

                string strChoix = "";
                while (strChoix == "") { 
                    ConsoleKeyInfo KeyInput = Console.ReadKey(true);

                    //Assume qu'on a fait un choix valide
                    strChoix = KeyInput.Key.ToString().ToUpper();

                    switch (strChoix) {
                        case "D1":
                        case "D2":
                        case "D3":
                        case "D4":
                            //Comme je n'ai pas mis de break apres 1,2 et 3, il vont tous au choix 4
                            break;

                        default:
                            //Choix invalide, on recommence
                            strChoix = "";
                            break;
                    }
                }

                //Ici c'est notre boucle d'action décisionnel
                switch (strChoix) {
                    case "D1":
                        ShowAllDays(ListFilms);
                        break;

                    case "D2":
                        FilmForDayX(ListFilms);
                        break;

                    case "D3":
                        FilmDay(ListFilms);
                        break;

                    case "D4":
                        //on sort du programme
                        blnExit = true;
                        break;
                }

                if (strChoix != "D4") {
                    //Attendre l'entré d'une clé avant d'effacer l'ecran
                    Console.WriteLine();
                    Console.WriteLine("Appuyez sur une touche pour retourner au menu");
                    Console.ReadKey(true);
                }
            }


            //int lngIndex = 0;
            //foreach (string word in List1) {
            //    Console.WriteLine(word);
            //    Console.WriteLine(List2[lngIndex]);
            //    lngIndex++;
            //}

        }

        //Console.WriteLine("1. Liste des films par jour");
        public static void ShowAllDays(List<Films> plstFilms) {
            Console.Clear(); //Efface l'écran    
            foreach (var objThisDay in Enum.GetValues(typeof(JoursSemaine))) {
                // on vérifie si le jour de la semaine contient un film
                int lngCount = 0;
                foreach (Films objFilm in plstFilms) {
                    if (objFilm.Jours.ToString() == objThisDay.ToString()) {
                        lngCount++;
                    }
                }

                if (lngCount > 0) {
                    Console.WriteLine(objThisDay.ToString() + " il y a " + lngCount.ToString() + " film(s):");
                    foreach (Films objFilm in plstFilms) {
                        if (objFilm.Jours.ToString() == objThisDay.ToString()) {
                            Console.WriteLine("\t" + objFilm.NomFilm);
                        }
                    }
                    Console.WriteLine();
                } else {
                    Console.WriteLine(objThisDay.ToString() + " il n'y a pas de film\r\n");
                }
            }
        }

        //Console.WriteLine("2. Liste des films pour une journée");
        public static void FilmForDayX(List<Films> plstFilms) {
            Console.Clear(); //Efface l'écran
            Console.WriteLine("Films par jour");
            Console.WriteLine("==============");
            Console.WriteLine();
            Console.WriteLine("1. Dimanche");
            Console.WriteLine("2. Lundi");
            Console.WriteLine("3. Mardi");
            Console.WriteLine("4. Mercredi");
            Console.WriteLine("5. Jeudi");
            Console.WriteLine("6. Vendredi");
            Console.WriteLine("7. Samedi");
            Console.WriteLine();
            Console.WriteLine("Faite votre choix: (1-7)");

            JoursSemaine JourDuFilm = JoursSemaine.Dimanche;
            string strChoix = "";
            while (strChoix == "") {
                ConsoleKeyInfo KeyInput = Console.ReadKey(true);

                //Assume qu'on a fait un choix valide
                strChoix = KeyInput.Key.ToString().ToUpper();

                switch (strChoix) {
                    case "D1":
                        JourDuFilm = JoursSemaine.Dimanche;
                        break;
                    case "D2":
                        JourDuFilm = JoursSemaine.Lundi;
                        break;
                    case "D3":
                        JourDuFilm = JoursSemaine.Mardi;
                        break;
                    case "D4":
                        JourDuFilm = JoursSemaine.Mercredi;
                        break;
                    case "D5":
                        JourDuFilm = JoursSemaine.Jeudi;
                        break;
                    case "D6":
                        JourDuFilm = JoursSemaine.Vendredi;
                        break;
                    case "D7":
                        JourDuFilm = JoursSemaine.Samedi;
                        break;
                    
                    default:
                        //Choix invalide, on recommence
                        strChoix = "";
                        break;
                }
            }

            Console.Clear(); //Efface l'écran

            // On vérifie si le jour de la semaine contient un film
            int lngCount = 0;
            foreach (Films objFilm in plstFilms) {
                if (objFilm.Jours.ToString() == JourDuFilm.ToString()) {
                    lngCount++;
                }
            }

            if (lngCount > 0) {
                Console.WriteLine(JourDuFilm.ToString() + " il y a " + lngCount.ToString() + " film(s):");
                foreach (Films objFilm in plstFilms) {
                    if (objFilm.Jours.ToString() == JourDuFilm.ToString()) {
                        Console.WriteLine("\t" + objFilm.NomFilm);
                    }
                }
                Console.WriteLine();
            } else {
                Console.WriteLine("Il n'y a pas de film " + JourDuFilm.ToString());
            }
        }

        //Console.WriteLine("3. Journée d'un film spécifique");
        public static void FilmDay(List<Films> plstFilms) {
            Console.Clear(); //Efface l'écran
            Console.WriteLine("Choisissez votre film");
            Console.WriteLine("=====================");
            Console.WriteLine();

            //Lister les films disponible
            //Cette liste nous permettra de savoir si nous avons deja le film
            //pour eviter de le lister 2 fois
            List<string> DansList = new List<string>();

            int lngLetter = 64;  //65 en ASCII est A, on prend la valeur AVANT
            string strLetter = "";
            foreach (Films objFilm in plstFilms) {
                //On verifie si on a deja lister ce film
                if (!DansList.Contains(objFilm.NomFilm)) {
                    //Ok, on a jamais lister ce film
                    DansList.Add(objFilm.NomFilm);
                    lngLetter++;  //On incrémente la lettre
                    strLetter = ((char)lngLetter).ToString();
                    Console.WriteLine(strLetter + ". " + objFilm.NomFilm);
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Faite votre choix: (A-" + strLetter + ")");
            byte bytMaxChoice = (byte)Convert.ToChar(strLetter);

            int bytChoix = 0;
            string strChoix = "";
            while (strChoix == "") {
                ConsoleKeyInfo KeyInput = Console.ReadKey(true);

                //Assume qu'on a fait un choix valide
                strChoix = KeyInput.Key.ToString().ToUpper();

                //Evalue si le choix est valide, sinon, efface le choix
                bytChoix = (byte)Convert.ToChar(strChoix);
                if (bytChoix < 65 || bytChoix > bytMaxChoice) {
                    strChoix = "";
                }
            }

            //Recupère le nom de notre film basée sur le choix utilisateur
            bytChoix = bytChoix - 65;  //On enleve 65 (A) à la lettre choisie pour obtenir l'index
            string FilmName = DansList[bytChoix];

            Console.Clear();
            Console.WriteLine("Le film [" + FilmName + "] joue le:");
            foreach (Films objFilm in plstFilms) {
                if (objFilm.NomFilm == FilmName) {
                    Console.WriteLine("\t" + objFilm.Jours.ToString());
                }
            }
        }
    }
}
