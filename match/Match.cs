using Npgsql;

public class Match {
    
    string idMatch;
    string name;
    public DateTime date;
    Player[]? participates;
    double token;
    double prime;

    public string IdMatch {
        get {
            return idMatch;
        }
        set {
            if (value == null) throw new System.ArgumentException("IdMatch cannot be null");
            if (value.Contains("MAT") == false) throw new System.ArgumentException("IdMatch must start with MAT");
            if (value.Length != 8) throw new System.ArgumentException("IdMatch must be 8 characters");
            idMatch = value;
        }
    }

    public Player[] Participates {
        get {
            return participates;
        }
        set {
            if (value == null) throw new System.ArgumentException("Participates cannot be null");
            if (value.Length == 0) throw new System.ArgumentException("Participates must be more than 0");
            foreach (Player player in value) {
                if (player == null) throw new System.ArgumentException("Participates cannot be null");
            }
            if (value[0].IdPlayer == value[1].IdPlayer) throw new System.ArgumentException("Participates must be different");
            foreach (Player player in value) {
                player.Match = this;
            }
            participates = value;
        }
    }

    double Token {
        get {
            return token;
        }
        set {
            if (value < 0) {
                throw new System.ArgumentException("Token cannot be negative");
            }
            token = value;
        }
    }

    public double Prime {
        get {
            return prime;
        }
        set {
            if (value < 0) {
                throw new System.ArgumentException("Prime cannot be negative");
            }
            if (value < token) throw new System.ArgumentException("The sum of bets must be greater than the token " + token);
            prime = value - token;
        }
    }

    Match() {
        string sequence = Connection.GetSequence("match_id_seq");
        this.idMatch = "MAT" + Connection.fillZero(5, sequence);
        this.name = "M" + sequence;
        this.token = GetToken();
    }

    public Match(string[] bets, Player[] participates) : this() {
        this.Participates = participates;
        SetBets(bets);
    }

    public static int GetToken() {
        using (NpgsqlConnection connection = Connection.GetConnection()) {
            using (NpgsqlCommand command = new NpgsqlCommand("SELECT token FROM configuration", connection)) {
                using (NpgsqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetInt32(0);
                    }
                    throw new System.ArgumentException("No token found");
                }
            }
        }
    }

    public void SetBets(double[] bets) {
        if (bets.Length != participates.Length) throw new System.ArgumentException("The number of bets must be equal to the number of participates");
        double somme = 0;
        for (int i = 0; i < bets.Length; i++) {
            double value = bets[i];
            
            // Reset participations
            participates[i].Loss = value;
            participates[i].Profit = 0;
            participates[i].Point = 0;
            somme += value;
        }
        this.Prime = somme;
    }

    public void SetBets(string[] bets) {
        SetBets(ConvertBetsToDouble(bets));
    }

    public static double[] ConvertBetsToDouble(string[] bets) {
        double[] betsDouble = new double[bets.Length];
        for (int i = 0; i < bets.Length; i++) {
            if (bets[i].Length == 0) throw new System.ArgumentException("Bets cannot be empty");
            betsDouble[i] = Convert.ToDouble(bets[i]);
        }
        return betsDouble;
    }

    public void Insert() {
        using (NpgsqlConnection connection = Connection.GetConnection()) {
            // Create a new match
            using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO match (id_match, name) VALUES (@id_match, @name)", connection)) {
                command.Parameters.AddWithValue("id_match", this.idMatch);
                command.Parameters.AddWithValue("name", this.name);
                command.ExecuteNonQuery();
            }

            // Create a new match_player for each player
            foreach (Player player in participates) {
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO match_player (id_match, id_player, profit, loss) VALUES (@id_match, @id_player, @profit, @loss)", connection)) {
                    command.Parameters.AddWithValue("id_match", this.idMatch);
                    command.Parameters.AddWithValue("id_player", player.IdPlayer);
                    command.Parameters.AddWithValue("profit", player.Profit);
                    command.Parameters.AddWithValue("loss", player.Loss);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}