using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace TetrisGame
{
    class Tempo
    {
        private double secondi, minuti;
        private bool stop;
        public Tempo()
        {
            secondi = 0;
            minuti = 0;
            stop = false;
        }
        public void Calcola()
        {
            while (stop == false)
            {
                Thread.Sleep(1000); //ogni secondo
                secondi++; //incremento
                if (secondi > 59) //minuto
                {
                    minuti++;
                    secondi = 00;
                }
                //devo inserire l'invoke perchè accedo ad un oggetto di proprietà già di un altro thread
                Crono = minuti.ToString("00") + ":" + secondi.ToString("00");
            }
        }

        public void SetStop()
        {
            stop = true;
        }
    }
}
