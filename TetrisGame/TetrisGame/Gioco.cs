﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class Gioco
    {
        private Blocco bloccoCorrente;
        public Grid campoGioco { get; }
        public ListaBlocchi listaBlocchi;
        public bool gameOver; //sarà true in caso l'utente perda

        public Blocco GetBlocco()
        {
            return bloccoCorrente;
        }

        public void SetBlocco()
        {
            bloccoCorrente.Reset();
        }

        public Grid GetCampoGioco()
        {
            return campoGioco;
        }

        public ListaBlocchi GetListaBlocchi()
        {
            return listaBlocchi;
        }

        public Gioco()
        {
            this.campoGioco = new Grid(22, 10); //inizializza la grid con 22 righe e 10 colonne
            this.listaBlocchi = new ListaBlocchi(); //inizializza la lista dei blocchi
            this.bloccoCorrente = listaBlocchi.AggiornaBlocco(); //prendo il primo blocco
        }

        //metodo per posizionare il blocco all'interno della grid
        public void PosizionaBlocco()
        {
            //ad ogni pezzo del blocco corrente assegno l'id del pezzo corrispondente
            foreach(Cella c in bloccoCorrente.PosizionePezzi())
            {
                campoGioco[c.riga, c.colonna] = bloccoCorrente.Id; 
            }
            //controlliamo se ci sono righe completate
            campoGioco.CheckRigheCompletate();

            //controlliamo se l'utente ha perso
            if(IsGameOver() == true)
            {
                gameOver = true; //sentinella
            }
            else //altrimenti passo al prossimo blocco
            {
                bloccoCorrente = listaBlocchi.AggiornaBlocco();
            }
        }

        //metodo per controllare se l'utente ha perso
        public bool IsGameOver()
        {
            //se le prime due righe della grid non sono vuote l'utente ha perso
            return !(campoGioco.RigaVuota(0) && campoGioco.RigaVuota(1));
        }

        //metodo che verifica se il blocco è in una posizione valida
        //il blocco deve essere completamente all'interno della grid
        private bool BloccoValido()
        {
            //per ogni pezzo del blocco corrente 
            foreach (Cella c in bloccoCorrente.PosizionePezzi())
            {
                //se uno dei pezzi del blocco è fuori dalla grid o si sovrappone a un altro non è valido 
                if (campoGioco.IsEmpty(c.riga, c.colonna) == false)
                {
                    return false;
                }
            }
            return true;
        }

        //metodo per ruotare il blocco in senso orario
        public void RuotaBloccoOrario()
        {
            bloccoCorrente.RuotaPezzoSensoOrario();
            //se il blocco non può essere ruotato perchè altrimenti andrebbe fuori dalla grid
            if (BloccoValido() == false) 
            {
                //lo ruotiamo nell'altro senso
                bloccoCorrente.RuotaPezzoSensoAntiOrario();
            }
        }

        //metodo per ruotare il blocco in senso orario
        //operazioni inverse di quello orario
        public void RuotaBloccoAntiOrario()
        {
            bloccoCorrente.RuotaPezzoSensoAntiOrario();
            if (BloccoValido() == false)
            {
                bloccoCorrente.RuotaPezzoSensoOrario();
            }
        }

        //metodo per muovere il pezzo in basso
        public void MuoviInBasso()
        {
            //sommo semplicemente 1 alle righe del pezzo
            bloccoCorrente.MuoviPezzo(1, 0);
            if (BloccoValido() == false) //se il pezzo esce dalla grid
            {
                //lo risposto in alto quindi sposto la riga indietro di 1
                bloccoCorrente.MuoviPezzo(-1, 0);

                //e chiamo il blocco successivo dato che sono arrivato in fondo o ho colliso con un altro pezzo
                PosizionaBlocco();
            }
        }

        //metodo per muovere il pezzo a destra
        public void MuoviADestra()
        {
            //sommo semplicemente 1 alle colonne del pezzo
            bloccoCorrente.MuoviPezzo(0, 1); 
            if (BloccoValido() == false) //se il pezzo esce dalla grid
            {
                //lo risposto indietro quindi sposto la colonna indietro di 1
                bloccoCorrente.MuoviPezzo(0, -1);
            }
        }

        //metodo per muovere il pezzo a sinistra
        public void MuoviASinistra()
        {
            //sottraggo semplicemente 1 alle colonne del pezzo
            bloccoCorrente.MuoviPezzo(0, -1);
            if (BloccoValido() == false) //se il pezzo esce dalla grid
            {
                //lo risposto avanti quindi sposto la colonna avanti di 1
                bloccoCorrente.MuoviPezzo(0, 1);
            }
        }
    }
}
