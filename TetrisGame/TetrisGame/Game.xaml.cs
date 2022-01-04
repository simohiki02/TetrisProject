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
using System.Windows.Shapes;

namespace TetrisGame
{
    /// <summary>
    /// Logica di interazione per Game.xaml
    /// </summary>
    public partial class Game : Window
    {

        private Image[,] controlloImmagini;
        private Gioco statoGioco = new Gioco();

        private Image[,] setupCanvas(Gioco grid)
        {
            Image[,] controlloImmagini = new Image[grid.righe, grid.colonne];
            int dimensioniCelle = 25;


            for(int r = 0; r < grid.righe; r++)
            {
                for (int c = 0; c < grid.colonne; c++)
                {
                    Image controllerImmagine = new Image
                    {
                        Width = dimensioniCelle,
                        Height = dimensioniCelle
                    };

                    Canvas.SetTop(controllerImmagine, (r - 2) * dimensioniCelle);
                    Canvas.SetLeft(controllerImmagine, c * dimensioniCelle);
                    GameCanvas.Children.Add(controllerImmagine);
                    controlloImmagini[r, c] = controllerImmagine;
                }
            }
            return controlloImmagini;
        }

        private ImageSource[] coloriBlocchi = new ImageSource[]
        {
            new BitmapImage(new Uri("GrafichePezzi/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/TileRed.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/TileYellow.png", UriKind.Relative))

        };

        private ImageSource[] immaginiBlocchi = new ImageSource[]
        {
            new BitmapImage(new Uri("GrafichePezzi/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/Block-Q.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("GrafichePezzi/Block-Z.png", UriKind.Relative))

        };
        public Game()
        {
            InitializeComponent();
            //controlloImmagini = setupCanvas(statoGioco.campoTetris)
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
