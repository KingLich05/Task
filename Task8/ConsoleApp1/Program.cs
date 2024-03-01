using System.Linq;



List<Player> players = new List<Player>
{
    new Player("sultana", 150),
    new Player("Sultan", 200),
    new Player("Natlus", 164),
    new Player("Sula", 175),
    new Player("Sul", 284),
    new Player("tan", 134)
};

List<Player> newPlayers = new List<Player>
{
    new Player("abc", 155),
    new Player("cba", 185),
    new Player("dfa", 173),
    new Player("fds", 157)
};

var filtredPlayers = players.Where(player => player.Level >= 150).OrderByDescending(player => player.Level);

foreach (var player in filtredPlayers)
{
    Console.WriteLine(player.Login);
}

var groupPlayers = players.Union(newPlayers);
groupPlayers = groupPlayers.OrderBy(player => player.Level);

Console.WriteLine("_____________________");

foreach (var gPlayer in groupPlayers)
{
    Console.WriteLine(gPlayer.Login);
}




class Player
{
    public string Login { get; private set; }
    public int Level { get; private set; }

    public Player(string login, int level)
    {
        Login = login;
        Level = level;
    }
}