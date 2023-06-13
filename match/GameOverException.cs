public class GameOverException : System.Exception {
    public Player? winner;
    public GameOverException() : base() {}
    public GameOverException(string message) : base(message) {}
    public GameOverException(string message, Player? winner) : base(message) {
        this.winner = winner;
    }
    public GameOverException(string message, System.Exception inner) : base(message, inner) {}
}