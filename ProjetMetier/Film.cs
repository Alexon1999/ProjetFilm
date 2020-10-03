using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Film
    {
        private string titreFilm;
        private string photoFilm;
        private int nbEntrees;
        private List<Acteur> lesActeurs;
        private Realisateur leRealisateur;



        public Film(string unTitre , int entrees , string unePhoto , Realisateur unRealisateur)
        {
            TitreFilm = unTitre;
            PhotoFilm = unePhoto;
            NbEntrees = entrees;
            LeRealisateur = unRealisateur;
            LesActeurs = new List<Acteur>();
        }

        public string TitreFilm { get => titreFilm; set => titreFilm = value; }
        public string PhotoFilm { get => photoFilm; set => photoFilm = value; }
        public int NbEntrees { get => nbEntrees; set => nbEntrees = value; }
        public List<Acteur> LesActeurs { get => lesActeurs; set => lesActeurs = value; }
        public Realisateur LeRealisateur { get => leRealisateur; set => leRealisateur = value; }

        public void AjouterActeur(Acteur unActeur)
        {
            LesActeurs.Add(unActeur);
        }

    }
}
