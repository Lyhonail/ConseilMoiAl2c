﻿using System;
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


        public string ExistBase() //On vérifie si la base existe ( cette fonction est optionnelle car ne sert à rien d'autre)
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

        public void ConnexionOpen() // Ouverture de la connexion (si la base n'existe pas elle est automatiquement créée)
        {
            this.connexion = new SqliteConnection("Data Source=" + maBase + ";Version=3;");
            this.connexion.Open();
        }//fin ConnexionOpen

        public void ConnexionClose() //fermeture de la connexion
        {
            this.connexion.Close();
        }//fin ConnexionClose


        public string CreerTableUtilisateur()//création d'une table
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
            //Retourne le message d'erreur SQL
            catch (SqliteException ex)
            {
                return ex.Message;
            }
            //Fermeture de la connexion
            finally
            {
                this.ConnexionClose();
            }
        }// fin CreerTable

        //création de la table PRofil
        public string CreerTableProfil()
        {
            try
            {
                this.ConnexionOpen();
                SqliteCommand command = connexion.CreateCommand();
                command.CommandText = "create table PROFIL		" +
                                        " ( " +
                                        " ID_profil PRIMARY KEY ASC, " +
                                        " Lib_profil          text, " +
                                        " ); ";
                command.ExecuteNonQuery();
                connexion.Close();
                return "Ok creer table profil";
            }
            //Retourne le message d'erreur SQL
            catch (SqliteException ex)
            {
                return ex.Message;
            }
            //Fermeture de la connexion
            finally
            {
                this.ConnexionClose();
            }
        }// fin CreerTableProfil

















    }
}