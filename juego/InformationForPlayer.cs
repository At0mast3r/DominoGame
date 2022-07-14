namespace juego
{
    public class InformationForPlayer
    {
        //almacenador de los pases de cada jugador, importante garantizar que sea un clonado del original para que el 
        //jugador no pueda copiarlo
        public Dictionary<Player, List<int>> turnPass;
        //almacenador de las jugadas de cada jugador.
        public Dictionary<Player, List<jugada>> turnPlayed;
        //listas de fichas que tiene el jugador con sus valores correspondientes
        public List<(Records rcd, int weight)> records;
        //indices de indices de las fichas que matchean con las opciones para jugar dada la lista anterior
        public List<Records> matchedRec;
        //lista de opciones en las que jugar
        public List<(Records,int)> Options;
        public InformationForPlayer(Dictionary<Player, List<int>> turnPass, Dictionary<Player, List<jugada>> turnPlayed, List<(Records rcd, int weight)> records, List<Records> matchedRec,List<(Records,int)> Options)
        {
            this.turnPass = turnPass;
            this.turnPlayed = turnPlayed;
            this.records = records;
            this.matchedRec = matchedRec;
            this.Options=Options;
        }

        public void Sort()
        {
            for (int i = 0; i <this.records.Count - 1; i++)
                for (int j = i + 1; j < this.records.Count; j++)
                {
                    if (this.records[i].weight > this.records[j].weight)
                    {
                        Swap(this.records[i], this.records[j]);
                    }
                }
        }

        static void Swap((Records rcd, int wgt) left, (Records rcd, int wgt) right)
        {
            Records rd = new Records(0,0);
            int temp = 0;
            rd = left.rcd;
            temp = left.wgt;
            left.rcd = right.rcd;
            left.wgt = right.wgt;
            right.rcd = rd;
            right.wgt = temp;
        }
    }


}