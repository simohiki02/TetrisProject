using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.GraficaTetris;

namespace TetrisGame
{
    public class ListaBlocchi
    {
        //classe necessaria a scegliere random il blocco successivo
        private Blocco[] blocchi = new Blocco[]
        {
            new I(),
            new J(),
            new L(),
            new Q(),
            new S(),
            new T(),
            new Z(),
        };

        //oggetto random per prendere il prossimo blocco
        private Random random = new Random();

        public Blocco prossimoBlocco = new Blocco();

        public ListaBlocchi()
        {
           
            //costruttore va in posizione random nell array e sceglie un blocco
            prossimoBlocco = bloccoRandom();
        }

        private Blocco bloccoRandom()
        {
            return blocchi[random.Next(blocchi.Length)];
        }


        //metodo che aggiorna il prossimo blocco scelto
        public Blocco aggiornaBlocco()
        {
            Blocco b = prossimoBlocco;

            do
            {
                prossimoBlocco = bloccoRandom();
            }
            while (b.id == prossimoBlocco.id);

            return b;
        }

    }
}
