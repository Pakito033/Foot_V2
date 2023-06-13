using Npgsql;

public class Player {

    string idPlayer;
    string? name;
    double profit;
    double loss;
    double balance;
    int point = 0;
    Match match;

    public string? Name {
        get {
            return name;
        }
        set {
            if (value == null) throw new System.ArgumentException("Name cannot be null");
            if (value.Length == 0) throw new System.ArgumentException("Name cannot be empty");
            name = value;
        }
    }

    public string IdPlayer {
        get {
            return idPlayer;
        }
        set {
            if (value == null) throw new System.ArgumentException("IdPlayer cannot be null");
            if (value.Contains("PLA") == false) throw new System.ArgumentException("IdPlayer must start with PLA");
            if (value.Length != 8) throw new System.ArgumentException("IdPlayer must be 8 characters");
            idPlayer = value;
        }
    }

    public int Point {
        get {
            return point;
        }
        set {
            if (value < 0) throw new System.ArgumentException("Point cannot be negative");
            int score = GetScoreForWin();
            if (value >= score) throw new GameOverException(this.name + " has already " + score + " points", this);
            point = value;
        }
    }

    public double Profit {
        get {
            return profit;
        }
        set {
            if (value < 0) throw new System.ArgumentException("Profit cannot be negative");
            profit = value;
        }
    }

    public double Loss {
        get {
            return loss;
        }
        set {
            if (value < 0) throw new System.ArgumentException("Loss cannot be negative");
            loss = value;
        }
    }

    public Match Match {
        get {
            return match;
        }
        set {
            if (value == null) throw new System.ArgumentException("Match cannot be null");
            match = value;
        }
    }

    Player() {
        // TODO: check if this sequence already exists
        this.idPlayer = "PLA" + Connection.fillZero(5, Connection.GetSequence("player_id_seq"));
    }

    public Player(string? name) : this() {
        this.name = name;
    }

    Player(string idPlayer, string? name, double profit, double loss, double balance) {
        this.IdPlayer = idPlayer;
        this.name = name;
        this.Profit = profit;
        this.Loss = loss;
        this.balance = balance;
    }

    public void Insert() {
        using (NpgsqlConnection connection = Connection.GetConnection()) {
            using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO player (id_player, name) VALUES (@idPlayer, @name)", connection)) {
                command.Parameters.AddWithValue("idPlayer", this.IdPlayer);
                Console.WriteLine(this.IdPlayer);
                command.Parameters.AddWithValue("name", this.Name);
                command.ExecuteNonQuery();
            }
        }
    }

    public static Player[] GetAll() {
        using (NpgsqlConnection connection = Connection.GetConnection()) {
            using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM v_liste_joueur_argent", connection)) {
                using (NpgsqlDataReader reader = command.ExecuteReader()) {
                    List<Player> players = new List<Player>();
                    while (reader.Read()) {
                        Player player = new Player(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetDouble(2),
                            reader.GetDouble(3),
                            reader.GetDouble(4)
                        );
                        players.Add(player);
                    }
                    return players.ToArray();
                }
            }
        }
    }

    public void Win() {
        if (this.Match == null) throw new System.ArgumentException("Player must be in a match to win");
        this.Profit += match.Prime;
    }

    public void AddPoint() {
        this.Point++;
    }

    public static int GetScoreForWin() {
        using (NpgsqlConnection connection = Connection.GetConnection()) {
            using (NpgsqlCommand command = new NpgsqlCommand("SELECT score FROM configuration", connection)) {
                using (NpgsqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        return (int) reader["score"];
                    }
                }
                throw new System.ArgumentException("No token found");
            }
        }
    }

}