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

        public Server(DatiCondivisi dati) 
        {
            this.dati = dati;
            riceveEP = new IPEndPoint(IPAddress.Any, 12345);
            dataReceived = new byte[1500];
            risposta = "";
            client = new UdpClient(12345);
        }

        public void Ricevi()
        {
            while(Pacchetto.connessione != 'c') //ricevi fino a quando non si chiude la connessione
            {
                dataReceived = client.Receive(ref riceveEP);
                risposta = Encoding.ASCII.GetString(dataReceived);
                Pacchetto p = new Pacchetto(risposta); //creo il pacchetto
                dati.addDaElaborare(p); //lo aggiungo alla lista da elaborare 
            }  
        }
    }
}
