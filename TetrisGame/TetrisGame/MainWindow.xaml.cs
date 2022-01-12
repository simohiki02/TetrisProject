using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace TetrisGame
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatiCondivisi dati; //inizializzo i dati condivisi
        Peer p;
        public MainWindow()
        {
            InitializeComponent();
            dati = new DatiCondivisi();
            dati.mw = this;
            p = new Peer(dati); //costruttore dei Thread
            p.StartThread(); //start dei thread
        }

        public void MessConnessione(string nome)
        {
            string mess = "Accettare la connessione da " + nome + "?";
            MessageBoxResult risposta = MessageBox.Show(mess, "Connessione", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(risposta == MessageBoxResult.Yes) //accetto la richiesta
            {
                string name = Interaction.InputBox("Inserisci il tuo nome");
                Pacchetto.nome = name; //salvo il mio nome
                string pacchetto = "y;" + name; 
                dati.AddDaInviare(pacchetto); //lo aggiungo alla lista dei pacchetti da inviare
                StartGame();
            }
            else
            {
                string pacchetto = "n;" + "null";
                dati.AddDaInviare(pacchetto); //lo aggiungo alla lista dei pacchetti da inviare
            }
        }
        public void MessNoConnessione() //ho mandato una richiesta ma non è stata accettata
        {
            string mess = "connessione non accettata";
            MessageBox.Show(mess, "Richiesta rifiutata", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void StartGame()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                Game game = new Game(dati);
                game.ShowDialog(); //apro la finestra di gioco

                /*quando la finestra Game si chiude*/
                Pacchetto.Connessione = 'c'; //fermo i thread
                Close(); //chiudo la finestra
            }); 
        }

        private void BtnConnetti_Click(object sender, RoutedEventArgs e)
        {
            string nome = TxtNome.Text; //prendo il nome dell'utente
            string ip = TxtIpDest.Text; //ip del destinatario
            Client.address = ip; //salvo l'indirizzo del destinatario
            dati.AddDaInviare("a;" + nome); //salvo nella lista il pacchetto da inviare
        }

        //in caso chiudesse la finestra dalla x
        private void CloseFromX(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Pacchetto.Connessione = 'c'; //fermo i thread
        }
    }
}
