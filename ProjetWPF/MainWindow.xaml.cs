using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetMetier;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> lesGenresFilms;
        Dictionary<string , List<Film>> dicoFilms;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Acteur> lesActeurs = new List<Acteur>();

            Acteur acteur1 = new Acteur("De Niro", "Robert", "Images/De Niro.png");
            Acteur acteur2 = new Acteur("Di Caprio", "Leonardo", "Images/Di Caprio.png");
            Acteur acteur3 = new Acteur("Nicholson", "Jack", "Images/Nicholson.png");
            Acteur acteur4 = new Acteur("Depp", "Johnny", "Images/Depp.png");
            Acteur acteur5 = new Acteur("Pitt", "Brad", "Images/Pitt.png");
            Acteur acteur6 = new Acteur("Portman", "Natalie", "Images/Portman.png");
            Acteur acteur7 = new Acteur("Lawrence", "Jennifer", "Images/Lawrence.png");
            Acteur acteur8 = new Acteur("Jolie", "Angelina", "Images/Jolie.png");
            Acteur acteur9 = new Acteur("Kidman", "Nicole", "Images/Kidman.png");
            Acteur acteur10 = new Acteur("Stone", "Emma", "Images/Stone.png");

            lesActeurs.Add(acteur1);lesActeurs.Add(acteur2); lesActeurs.Add(acteur3); lesActeurs.Add(acteur4); lesActeurs.Add(acteur5); lesActeurs.Add(acteur6);
            lesActeurs.Add(acteur7); lesActeurs.Add(acteur8); lesActeurs.Add(acteur9); lesActeurs.Add(acteur10);

            Realisateur real1 = new Realisateur("Tarantino", "Quentin", "Images/Tarantino.png");
            Realisateur real2 = new Realisateur("Spielberg", "Steven", "Images/Spielberg.png");
            Realisateur real3 = new Realisateur("Scorsese", "Martin", "Images/Scorsese.png");

            Film film1 = new Film("Film n°1", 23000, "Images/Film n°1.png", real1);
            Film film2 = new Film("Film n°2", 56000, "Images/Film n°2.png", real2);
            Film film3 = new Film("Film n°3", 21000, "Images/Film n°3.png", real3);

            film1.AjouterActeur(acteur1);
            film1.AjouterActeur(acteur3);
            film1.AjouterActeur(acteur9);

            film2.AjouterActeur(acteur2);
            film2.AjouterActeur(acteur5);
            film1.AjouterActeur(acteur10);

            film3.AjouterActeur(acteur4);
            film3.AjouterActeur(acteur6);
            film3.AjouterActeur(acteur8);



            List<Film> lesFilmsHorreurs = new List<Film>();
            List<Film> lesFilmsComedies = new List<Film>();
            List<Film> lesFilmsActions = new List<Film>();
            List<Film> lesFilmsSciences = new List<Film>();


            lesFilmsHorreurs.Add(film1);
            lesFilmsComedies.Add(film2);
            lesFilmsActions.Add(film3);

            lesGenresFilms = new List<string>();
            lesGenresFilms.Add("Horreur");
            lesGenresFilms.Add("Comédie");
            lesGenresFilms.Add("Action");
            lesGenresFilms.Add("Science-Fiction");

            cboGenreFilm.ItemsSource = lesGenresFilms;

            dicoFilms = new Dictionary<string, List<Film>>();
            dicoFilms.Add(lesGenresFilms[0], lesFilmsHorreurs );
            dicoFilms.Add(lesGenresFilms[1], lesFilmsComedies);
            dicoFilms.Add(lesGenresFilms[2], lesFilmsActions);
            dicoFilms.Add(lesGenresFilms[3], lesFilmsSciences);

            lstImagesActeurs.ItemsSource = lesActeurs;

        }

        private void cboGenreFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboGenreFilm.SelectedItem != null)
            {
                lstFilms.ItemsSource = dicoFilms[cboGenreFilm.SelectedItem as string];
            }
            else
            {
                cboGenreFilm.Items.Refresh();
            }
        }

        private void lstFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstFilms.SelectedItem != null)
            {
                // List<Acteur> lesActeurs = new List<Acteur>();
                lstActeurs.ItemsSource = dicoFilms[cboGenreFilm.SelectedItem as string].Find(film => film.TitreFilm == (lstFilms.SelectedItem as Film).TitreFilm).LesActeurs;
            }
            else
            {
                lstActeurs.ItemsSource = null;
            }
        }

        private void btnAjoutFilm_Click(object sender, RoutedEventArgs e)
        {
            if(txtFilm.Text == "")
            {
                MessageBox.Show("Saisir un titre du film", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(txtNbEntrees.Text == "")
                {
                    MessageBox.Show("Saisir un nombre d'entrées", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(txtNomRealisateur.Text == "")
                    {
                        MessageBox.Show("Saisir un nom de réalisateur", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if(txtPrenomRealisateur.Text == "")
                        {
                            MessageBox.Show("Saisir un prenom de réalisateur", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            List<Film> lstNouveauxFilms = new List<Film>();
                            List<Acteur> lesActeurs = new List<Acteur>();
                            Realisateur newRealisateur = new Realisateur(txtNomRealisateur.Text, txtPrenomRealisateur.Text, "Images/NewRealisateur.png");
                            Film newFilm = new Film(txtFilm.Text, Convert.ToInt32(txtNbEntrees.Text), "Images/NewFilm.png" , newRealisateur);

                            //(lstImagesActeurs.SelectedItems as List<Acteur>).ForEach(acteur =>
                            //{
                            //    lesActeurs.Add(acteur);
                            //    newFilm.AjouterActeur(acteur);
                            //});

                            newFilm.LesActeurs = lstImagesActeurs.SelectedItems as List<Acteur>;


                            if (txtNomGenre.Text != "")
                            {
                                lstNouveauxFilms.Add(newFilm);
                                dicoFilms.Add(txtNomGenre.Text, lstNouveauxFilms);
                                lesGenresFilms.Add(txtNomGenre.Text);
                                cboGenreFilm.ItemsSource = lesGenresFilms;
                            }
                            else
                            {
                                dicoFilms[cboGenreFilm.SelectedItem as string].Add(newFilm);
                            }
                        }
                    }
                }
            }
        }
    }
}
