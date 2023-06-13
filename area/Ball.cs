using baby_foot;

public class Ball {

    double x;
    double y;
    public double dx = 0;
    public double dy = 1;
    static int rayon = 20;
    BabyFoot babyFoot;

    public double X {
        get {
            return x;
        }
        set {
            if (0 > value || value + this.GetDiametre() > babyFoot.GetWidthArea()) {
                throw new LocationNotInAreaException("La balle est sortie de l'aire de jeu", 0);
            }
            x = value;
        }
    }

    public double Y {
        get {
            return y;
        }
        set {
            if (0 > value || value + this.GetDiametre() > babyFoot.GetHeightArea()) {
                throw new LocationNotInAreaException("La balle est sortie de l'aire de jeu", 1);
            }
            y = value;
        }
    }

    public Ball(BabyFoot babyFoot) {
        this.babyFoot = babyFoot;
        Reset();
    }

    public void Move() {
        try {
            this.X += dx;
            this.Y += dy;
        } catch (LocationNotInAreaException e) {
            if (e.point == 0) {
                dx = -dx;
            } else {
                dy = -dy;
            }
            this.Move();
        }
    }

    public int GetDiametre() {
        return rayon * 2;
    }

    public void Reset() {
        this.X = babyFoot.GetWidthArea() / 2 - rayon;
        this.Y = babyFoot.GetHeightArea() / 2 - rayon;
        this.dx = 0;
        this.dy = 1;
    }

    public double GetAngle(BabyFootPlayer player) {
        return Math.Atan2(player.Y - this.Y, player.X - this.X);
    }

    public double GetAngle(Goal goal) {
        return Math.Atan2(goal.Y - this.Y, goal.X - this.X);
    }

    public void MoveTo(BabyFootPlayer player) {
        double angle = this.GetAngle(player);
        this.dx = Math.Cos(angle);
        this.dy = Math.Sin(angle);
    }

    public void MoveTo(Goal goal) {
        double angle = this.GetAngle(goal);
        this.dx = Math.Cos(angle);
        this.dy = Math.Sin(angle);
    }

}