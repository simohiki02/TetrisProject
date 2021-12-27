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
        static List<string> listaDati = new List<string>(); //lista dei dati da inviare
        static DatiCondivisi dati = new DatiCondivisi(); //inizializzo i dati condivisi
        public MainWindow()
        {
            InitializeComponent();
            Peer p = new Peer(dati); //costruttore dei Thread
            p.StartThread(); //start dei thread
        }

        public static void MessConnessione(string nome)
        {
            string mess = "Accettare la connessione da " + nome + "?";
            MessageBoxResult risposta = MessageBox.Show(mess, "Connessione", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(risposta == MessageBoxResult.Yes) //accetto la richiesta
            {
                string name = Interaction.InputBox("Inserisci il tuo nome");
                string pacchetto = "y;" + name; 
                dati.addDaInviare(pacchetto); //lo aggiungo alla lista dei pacchetti da inviare
            }
            else
            {
                
            }
        }
    }
}
