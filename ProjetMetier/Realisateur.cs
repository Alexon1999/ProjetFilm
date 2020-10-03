using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Realisateur
    {

        private string nomRealisateur;
        private string prenomRealisateur;
        private string photoRealisateur;

        public Realisateur(string unNom , string unPrenom , string unePhoto)
        {
            NomRealisateur = unNom;
            PrenomRealisateur = unPrenom;
            PhotoRealisateur = unePhoto;
        }

        public string NomRealisateur { get => nomRealisateur; set => nomRealisateur = value; }
        public string PrenomRealisateur { get => prenomRealisateur; set => prenomRealisateur = value; }
        public string PhotoRealisateur { get => photoRealisateur; set => photoRealisateur = value; }
    }
}
