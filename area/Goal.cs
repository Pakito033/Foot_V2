using baby_foot;

public class Goal {

    int x;
    int y;
    int width;
    int height;
    Team team;
    BabyFoot babyFoot;

    public int X {
        get {
            return x;
        }
        set {
            x = value;
        }
    }

    public int Y {
        get {
            return y;
        }
        set {
            y = value;
        }
    }

    public int Width {
        get {
            return width;
        }
        set {
            width = value;
        }
    }

    public int Height {
        get {
            return height;
        }
        set {
            height = value;
        }
    }

    public Team Team {
        get {
            return team;
        }
        set {
            team = value;
        }
    }

    public BabyFoot BabyFoot {
        get {
            return babyFoot;
        }
        set {
            babyFoot = value;
        }
    }

    public Goal(BabyFoot babyFoot, Team team, int x, int y, int width, int height) {
        this.BabyFoot = babyFoot;
        this.Team = team;
        this.Team.goal = this;
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public bool IsInGoal(Ball ball) {
        return ball.X + ball.GetDiametre() > this.X && ball.X < this.X + this.Width 
        && ball.Y + ball.GetDiametre() > this.Y && ball.Y < this.Y + this.Height;
    }

}