using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mono.Data.Sqlite;
using System.IO;
using Android.Database.Sqlite;
using Android.Util;

namespace conseilMoi.Resources.MaBase
{
    class MaBase
        { 
        //déclaration des variables de la classe
        String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); //chemin d'enregistrement de la base
        String maBase; //contient 'path' + le nom de la base - utilisé pour la connexion -
        SqliteConnection connexion; //variable de connexion à la base
                                    //Fin de déclarartion des variables

        //On vérifie si la base existe ( cette fonction est optionnelle car ne sert à rien d'autre)
        public string ExistBase() 
        {
            try //si pas d'erreur
            {
                maBase = path + "/maBase.sqlite";
                //on regarde si le fichier existe déjà
                if (File.Exists(maBase)) { return maBase + " Existe déjà"; }
                else { return maBase + " - à été créé"; }
            }
            catch
            { //si erreur
                return " ERREUR";
            }
        }//fin creerBase

        // Ouverture de la connexion (si la base n'existe pas elle est automatiquement créée)
        public void ConnexionOpen() 
        {
            this.connexion = new SqliteConnection("Data Source=" + maBase + ";Version=3;");
            this.connexion.Open();
        }//fin ConnexionOpen
        
        //fermeture de la connexion
        public void ConnexionClose() 
        {
            this.connexion.Close();
        }//fin ConnexionClose

        //création table UTILISATEUR
        public string CreerTableUtilisateur()
        {
            try
            {
                this.ConnexionOpen();
                SqliteCommand command = connexion.CreateCommand();
                command.CommandText = "create table UTILISATEUR		" +
                                        " ( " +
                                        " ID_utilisateur integer PRIMARY KEY ASC, " +
                                        " login          text, " +
                                        " password       text, " +
                                        " nom            text, " +
                                        " prenom         text, " +
                                        " Adresse1       text, " +
                                        " Adresse2       text, " +
                                        " Ville          text, " +
                                        " CP             text, " +
                                        " TEL            text " +
                                        " ); ";
                command.ExecuteNonQuery();
                connexion.Close();
                return "Ok creer table utilisateur";
            }
            catch { return "ERREUR creer table utilisateur"; }
        }// fin CreerTable
















    }
}