namespace juego;
public abstract class Player
{
    public  string id;
    public Player(string id)
    {
       this.id=id;
    }
    public abstract jugada GiveMeRecords(InformationForPlayer info, Referee rf);
}
    //Hay que revisar el metodo de la clase para que no se repita
    public class ManualPlayer:Player
    {
        public ManualPlayer(string id):base(id){}
        public override jugada GiveMeRecords(InformationForPlayer info, Referee rf)
        {
         int cont = 0;   
        System.Console.WriteLine(" jugador  "+ this.id);
        Console.ForegroundColor=ConsoleColor.Cyan;
        foreach (var item in info.Options)
        {
            System.Console.WriteLine(item.Item2 + " option# "+ cont++);
        }
        Console.ForegroundColor=ConsoleColor.Gray;

        cont=0;
        System.Console.WriteLine("This is your hand");
        foreach (var item in rf.AsignedRecords[this])
        {
            System.Console.WriteLine(cont + " " + item.element1 + "-" + item.element2);
            cont++;
        }
        cont=0;
        System.Console.WriteLine("select a record to play");
        foreach (var item in info.matchedRec)
        {
            System.Console.WriteLine(cont + " " + item.element1 + "-" + item.element2);
            cont++;
        }

        int answer = int.Parse(Console.ReadLine());
        System.Console.WriteLine( "where do you want to play?"  );
        int selectedOption = int.Parse(Console.ReadLine());
        return new jugada (selectedOption,info.matchedRec[answer]);

        }
    }
    public class RandomPlayer:Player
    {
        public RandomPlayer(string id):base(id){}
        public override jugada GiveMeRecords(InformationForPlayer info, Referee rf)
        {
            System.Console.WriteLine( this.id  );
            Random r1=new Random();
           // Random r2=new Random();
            int answer=r1.Next(0,info.matchedRec.Count);
            System.Console.WriteLine( "answer:"+  answer);
            int selectedOption=r1.Next(0,2);
            System.Console.WriteLine( "select:"+  selectedOption);
        
        return new jugada (selectedOption,info.matchedRec[answer]);
        }
    }
    /*public class MyPlayer:Player
    {
        public MyPlayer(string id){base(id);}
        public override jugada GiveMeRecords(GameInformation info, Referee rf) 
        {
        
        }
    }*/
