using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TetrisGame
{
    /// <summary>
    /// Logica di interazione per Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        DatiCondivisi dati;
        //vettore contenent immagini dei blocchi
        private Image[,] controlloImmagini;
        //oggetto che controlla lo stato del gioco
        private Gioco statoGioco;

        //metodo che suddivide la grid in tanti blocchi vuoti, grazie a matrice di oggetti blocchi/immagini
        private Image[,] SetupCanvas(Grid grid)
        {
            Image[,] controlloImmagini = new Image[grid.righe, grid.colonne];   //il vettore controller-immagini contiente 22 righe e 10 colonne come
            int dimensioniCelle = 25;

            for(int r = 0; r < grid.righe; r++)
            {
                for (int c = 0; c < grid.colonne; c++)
                {
                    //per ogni riga e colonna della grid, creiamo un controller immagine di 25 pixel di larghezza per lunghezza
                    Image controllerImmagine = new Image
                    {
                        Width = dimensioniCelle,
                        Height = dimensioniCelle
                    };
                    //metodi per posizionare il controller immagine all interno della grid
                    //contiamo le righe dall alto verso il basso e le colonne da sinistra verso destra, impostiamo la distanza tra il canvas e dall'alto dell immagine,
                    //il -2 è per portare le 2 righe nascoste verso l alto , cosi non sono dentro il canvas
                    Canvas.SetTop(controllerImmagine, (r - 2) * dimensioniCelle);
                    Canvas.SetLeft(controllerImmagine, c * dimensioniCelle);

                    CanvasGioco.Children.Add(controllerImmagine);
                    controlloImmagini[r, c] = controllerImmagine;
                }
            }
            return controlloImmagini;
        }
        
        //creo vettore per i colori dei pezzi
        private ImageSource[] coloriBlocchi = new ImageSource[]
        {
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/TileRed.png", UriKind.Relative)),
        };

        //creo vettore con forme dei pezzi
        private ImageSource[] immaginiBlocchi = new ImageSource[]
        {
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-Q.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("GraficaTetris/GrafichePezzi/Block-Z.png", UriKind.Relative))

        };
        public Game(object dati)
        {
            InitializeComponent();
            statoGioco = new Gioco(dati);
            this.dati = dati as DatiCondivisi;
            controlloImmagini = SetupCanvas(statoGioco.CampoGioco);
            lblAvversario.Content = Pacchetto.nomeAvversario;
        }

        //metodo che disegna la grid del gioco
        private void DisegnaCampo(Grid grid)
        {
            for(int r = 0; r < grid.righe; r++)
            {
                for(int c = 0; c < grid.colonne; c++)
                {
                    int id = grid[r, c];    //sarà sempre 0 perchè i valori delle celle non sono settati
                    controlloImmagini[r, c].Source = coloriBlocchi[id];
                }
            }
        }

        //metodo che disegna i blocchi
        private void DisegnaBlocco(Blocco blocco)
        {
            foreach(Cella c in blocco.PosizionePezzi())
            {
                controlloImmagini[c.riga, c.colonna].Source = coloriBlocchi[blocco.Id];
            }
        }

        public static int stato = 0, righe = 0;
        //metodo che avvia il gioco con una grid e i blocchi di partenza
        private void DisegnaGioco(Gioco statoGioco)
        {
            DisegnaCampo(statoGioco.CampoGioco);
            DisegnaBlocco(statoGioco.BloccoCorrenteProp);
            PreviewProxBlocco(statoGioco.ListaBlocchi);
            lblPunteggio.Content = statoGioco.Score; //aggiorno il punteggio nella textbox
        }

        //visualizza il prossimo blocco
        private void PreviewProxBlocco(ListaBlocchi listaBlocchi)
        {
            Blocco proxBlocco = listaBlocchi.prossimoBlocco; //prendiamo il blocco successivo
            ImgProxBlocco.Source = immaginiBlocchi[proxBlocco.Id]; //applichiamo l'immagine dell'id corrispondente
        }

        private bool vinto = false;
        //metodo asincrono perchè vogliamo aspettare senza bloccare la UI
        private async Task GameLoop()
        {
            DisegnaGioco(statoGioco);
            while (!statoGioco.GameOver)
            {
                //l'operatore await ritorna il risultato del metodo in un secondo momento, dopo il completamento dell'operazione in corso
                await Task.Delay(500);
                statoGioco.MuoviInBasso();
                DisegnaGioco(statoGioco);

                lblPuntAvversario.Content = righe; //visualizzo le righe risolte dall'avversario
                if (stato == 1) //l'avversario ha perso
                {
                    //cambio la scritta allo stack panel
                    lblStato.Content = "Hai vinto!";
                    vinto = true;
                    statoGioco.GameOver = true; //imposto lo stato gioco a "fine"
                }
            }
            if(vinto == false) //se ho perso io
            {
                dati.AddDaInviare("g;1;0;-1"); //mando il pacchetto con stato a 1
                lblTotPunteggio.Content = "Punteggio: " + lblPunteggio.Content; //punteggio finale   
            }
            GameOverMenu.Visibility = Visibility.Visible; //visualizzo menu in tutti i casi con scritta iniziale diversa
        }

        //evento che rileva pressione tasti dell utente e muove il pezzo in tutte le direzioni
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (statoGioco.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    statoGioco.MuoviASinistra();
                    break;
                case Key.Right:
                    statoGioco.MuoviADestra();
                    break;
                case Key.Down:
                    statoGioco.MuoviInBasso();
                    break;
                case Key.Up:
                    statoGioco.RuotaBloccoOrario();
                    break;
                case Key.A:
                    statoGioco.RuotaBloccoAntiOrario();
                    break;
                case Key.Space:
                    statoGioco.CadutaBlocco();
                    break;
                default:
                    return;
            }
            DisegnaGioco(statoGioco);
        }

        //evento che in caricamento disegna la grid e i blocchi
        private async void CanvasGioco_LoadedAsync(object sender, RoutedEventArgs e)
        {
            //disegnaGioco(statoGioco);
            await GameLoop();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //chiudo questa finestra
        }
    }
}
