namespace juego;
public abstract class Player
{
    public  string id;
    public Player(string id)
    {
       this.id=id;
    }
    public abstract jugada GiveMeRecords(GameInformation gm, Referee rf)
    {
       
    }
}
    //Hay que revisar el metodo de la clase para que no se repita
    public class ManualPlayer:Player
    {
        public ManualPlayer(string id):base(Player){}
        public override jugada GiveMeRecords(GameInformation gm, Referee rf)
        {
        System.Console.WriteLine(" jugador  "+ this.id);
        Console.ForegroundColor=ConsoleColor.Cyan;
        foreach (var item in gm.OptionsToPlay)
        {
            System.Console.WriteLine(item.option + " option# "+ cont++);
        }
        Console.ForegroundColor=ConsoleColor.Gray;

        cont=0;
        System.Console.WriteLine("select a record to play");
        foreach (var item in rf.AsignedRecords[this])
        {
            System.Console.WriteLine(cont + " " + item.element1 + "-" + item.element2);
            cont++;
        }

        int answer = int.Parse(Console.ReadLine());
        System.Console.WriteLine( "where do you want to play?"  );
        int selectedOption = int.Parse(Console.ReadLine());
        int cont = 0;
        cont=0;
        foreach (var item in rf.AsignedRecords[this])
        {
           if(cont==answer)return new jugada( selectedOption, item);
           cont++;    
        }
        //devolver  por default ya q no debe llegar aqui, ver como arreglar esto
        return new jugada (0, rf.AsignedRecords[this][0]);

        }
    }
    public class RandomPlayer:Player
    {
        public RandomPlayer(string id):base(Player){}
        public override jugada GiveMeRecords(GameInformation gm, Referee rf)
        {
            random r1=new random(gm.numberOfOptions);
            random r2=new random(1);
            answer=r1.nextRandom();
            selectedOption=r2.nextRandom();
            int cont = 0;
        cont=0;
        foreach (var item in rf.AsignedRecords[this])
        {
           if(cont==answer)return new jugada( selectedOption, item);
           cont++;    
        }
        //devolver  por default ya q no debe llegar aqui, ver como arreglar esto
        return new jugada (0, rf.AsignedRecords[this][0]);
        }
    }
    public class MyPlayer:Player
    {
        public MyPlayer(string id){base(Player);}
        public override jugada GiveMeRecords(GameInformation gm, Referee rf)
        {
            
        }
    }
