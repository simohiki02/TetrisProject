using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class Server
    {
        private DatiCondivisi dati;
        private IPEndPoint riceveEP;
        private byte[] dataReceived; //byte per salvare i dati ricevuti
        private string risposta;
        private UdpClient client;
        private bool m;

        public Server(DatiCondivisi dati)
        {
            this.dati = dati;
            riceveEP = new IPEndPoint(IPAddress.Any, 12345);
            dataReceived = new byte[1500];
            risposta = "";
            client = new UdpClient(12345);

            client.Client.ReceiveTimeout = 1000;

            m = true;
        }

        public void Ricevi()
        {
            while (Pacchetto.Connessione != 'c') //ricevi fino a quando non si chiude la connessione
            {
                try
                {
                    dataReceived = client.Receive(ref riceveEP);
                    m = true;
                }
                catch (Exception ex) { m = false; }
                if (m == true)
                {
                    Client.address = riceveEP.Address.ToString(); //salvo l'indirizzo IP del destinatario
                    risposta = Encoding.ASCII.GetString(dataReceived);
                    Pacchetto p = new Pacchetto(risposta); //creo il pacchetto
                    if (p.tipo == "g")
                    {
                        Game.righe = p.righe; //salvo già le righe risolte
                        Game.stato = p.stato; //lo stato gioco dell'avversario (sta continuando, ha perso)
                        Game.malus = p.malus; //e il malus
                    }
                    else
                        dati.AddDaElaborare(p); //lo aggiungo alla lista da elaborare 
                } 
            }
            Console.WriteLine("Thread Server terminato");
        }
    }
}
