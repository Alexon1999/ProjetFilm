using System;

namespace ProjetMetier
{
    public class Acteur
    {
        private string nomActeur;
        private string photoActeur;
        private string prenomActeur;

        public Acteur(string unNom , string unPrenom , string unePhoto)
        {
            NomActeur = unNom;
            PrenomActeur = unPrenom;
            PhotoActeur = unePhoto;

        }

        public string NomActeur { get => nomActeur; set => nomActeur = value; }
        public string PhotoActeur { get => photoActeur; set => photoActeur = value; }
        public string PrenomActeur { get => prenomActeur; set => prenomActeur = value; }
    }
}
