namespace TournamentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Team team = new Team();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Console.Title = "! ! ! TOURNAMENT APP ! ! !");
            Console.WriteLine("___________________________" + 
                "\n" + "___________________________" + 
                "\n" + "___________________________" + "\n");

            char choice = ' ';
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- Create Player        [p]");
            Console.WriteLine("- Create Team          [t]");
            Console.WriteLine("- Add Plyer to Team    [a]");
            Console.WriteLine("\n- Exit                 [e]");

            List <Player> newPlayers = new List<Player>();

            bool RUNNING = true;
            while (RUNNING)
            {
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case 'p':
                        newPlayers.Add(Controller.CreatePlayer());
                        foreach(Player newPlayer in newPlayers)
                        {
                            Console.WriteLine("\n" + newPlayer.name + " " 
                                + newPlayer.surname + " " 
                                + newPlayer.position + " " + newPlayer.salary);
                        }
                        break;

                    case 'e':
                        RUNNING = false;
                        break;
                }


            }
            Console.WriteLine("\nBye bye");
        }
    }
}