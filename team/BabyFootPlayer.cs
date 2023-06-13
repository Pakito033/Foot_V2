using baby_foot;

public class BabyFootPlayer {
    
    int x; // Coordinate of the player in (0, 0) of the square of graphics
    int y; // Coordinate of the player in (0, 0) of the square of graphics
    Player owner;
    static int rayon = 20;
    BabyFoot babyFoot;
    Team team;
    public Brush color;
    public bool IsGoal;
    public bool isDef;
    public bool isMid;
    public bool isAtk;
    public bool IsPossession;
    public int line;

    public static int Rayon {
        get {
            return rayon;
        }
        set {
            if (value < 0) throw new System.ArgumentException("Rayon cannot be negative");
            rayon = value;
        }
    }

    public int X {
        get {
            return x;
        }
        set {
            
            if (0 > value || value + this.GetDiametre() > babyFoot.GetWidthArea()) throw new LocationNotInAreaException("Le joueur est sorti de l'aire de jeu", 0);
            x = value;
        }
    }

    public int Y {
        get {
            return y;
        }
        set {
            if (0 > value || value + this.GetDiametre() > babyFoot.GetHeightArea()) throw new LocationNotInAreaException("Le joueur est sorti de l'aire de jeu", 1);
            y = value;
        }
    }

    public Player Owner {
        get {
            return owner;
        }
        set {
            if (value == null) throw new System.ArgumentException("Owner cannot be null");
            owner = value;
        }
    }

    public BabyFoot BabyFoot {
        get {
            return babyFoot;
        }
        set {
            if (value == null) throw new System.ArgumentException("BabyFoot cannot be null");
            babyFoot = value;
        }
    }

    public Team Team {
        get {
            return team;
        }
        set {
            if (value == null) throw new System.ArgumentException("Team cannot be null");
            team = value;
        }
    }

    public int GetDiametre() {
        return rayon * 2;
    }

    public BabyFootPlayer(int x, int y, BabyFoot babyFoot, Player owner, Brush color, Team team, int line) {
        this.BabyFoot = babyFoot;
        this.Owner = owner;
        this.X = x;
        this.Y = y;
        this.color = color;
        this.Team = team;
        this.line = line;
    }

    public bool IsTouchBall() {
        return (this.X + this.GetDiametre() >= BabyFoot.ball.X && this.X <= BabyFoot.ball.X + BabyFoot.ball.GetDiametre() 
        && this.Y + this.GetDiametre() >= BabyFoot.ball.Y && this.Y <= BabyFoot.ball.Y + BabyFoot.ball.GetDiametre());
    }

    public bool IsLeftBabyPlayer() {
        return this.X < BabyFoot.GetWidthArea() / 2;
    }

    public PointF[] GetCurser() {
        PointF[] curser = new PointF[4];
        curser[0] = new PointF(this.X + this.GetDiametre() / 2, this.Y - 50);
        curser[1] = new PointF(this.X + this.GetDiametre(), this.Y + this.GetDiametre() / 2 - 50);
        curser[2] = new PointF(this.X + this.GetDiametre() / 2, this.Y + this.GetDiametre() - 50);
        curser[3] = new PointF(this.X, this.Y + this.GetDiametre() / 2 - 50);
        return curser;
    }

    public void MoveVertical(int direction) {
        // if direction is 1, this is up
        // if direction is -1, this is down
        try {
            int value = this.Y + (direction * 10);
            if (line < 2) {
                if (team.Hight == 0) {
                    if (value < babyFoot.GetHeightArea() / 2) {
                        Y = value;
                    }
                } else {
                    if (value > babyFoot.GetHeightArea() / 2) {
                        Y = value;
                    }
                }
            } else {
                if (team.Hight == 0) {
                    if (value > (babyFoot.GetHeightArea() / 4)) {
                        Y = value;
                    }
                } else {
                    if (value < 3 * (babyFoot.GetHeightArea() / 4)) {
                        Y = value;
                    }
                }
            }
        } catch (LocationNotInAreaException) {

        }
    }

    public void MoveHorizontal(int direction) {
        // if direction is 1, this is right
        // if direction is -1, this is left
        try {
            this.X += direction * 10;
        } catch (LocationNotInAreaException) {

        }
    }

    public double GetDistanceWithBall() {
        return Math.Sqrt(Math.Pow(this.X - BabyFoot.ball.X, 2) + Math.Pow(this.Y - BabyFoot.ball.Y, 2));
    }

    public double GetDistance(BabyFootPlayer player) {
        return Math.Sqrt(Math.Pow(this.X - player.X, 2) + Math.Pow(this.Y - player.Y, 2));
    }
    
}