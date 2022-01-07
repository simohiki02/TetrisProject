using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class Client
    {
        private UdpClient client;
        private DatiCondivisi dati;
        public static string address; //indirizzo del destinatario
        public Client(DatiCondivisi dati)
        {
            client = new UdpClient();
            this.dati = dati;
        }

        public void Invia()
        {
            while(Pacchetto.connessione != 'c')
            {
                if(dati.GetSizeDaInviare() > 0)
                {
                    string p = dati.GetDaInviare(); //prendo il pacchetto da inviare
                    byte[] data = Encoding.ASCII.GetBytes(p); //trasformo in byte
                    client.Send(data, data.Length, address, 12347); //invio
                }
            }
        }
    }
}
