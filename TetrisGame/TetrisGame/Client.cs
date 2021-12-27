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
        public Client(DatiCondivisi dati)
        {
            client = new UdpClient(12346);
            this.dati = dati;
        }

        public void Invia()
        {
            while(Pacchetto.connessione != 'c')
            {
                if(dati.getSizeDaInviare() > 0)
                {
                    string p = dati.getDaInviare(); //prendo il pacchetto da inviare
                    byte[] data = Encoding.ASCII.GetBytes(p); //trasformo in byte
                    client.Send(data, data.Length, "localhost", 12347); //invio
                }
            }
        }
    }
}
