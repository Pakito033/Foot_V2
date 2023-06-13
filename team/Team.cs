using baby_foot;

public class Team {

    public BabyFootPlayer[] players;
    public Player owner;
    Brush color;
    BabyFoot babyFoot;
    int position = 0;
    int hight;
    public Goal goal;

    public int Position {
        get {
            return position;
        }
        set {
            if (value < 0) throw new Exception("Position must be positif");
            position = value;
        }
    }

    public int Hight {
        get {
            return hight;
        }
        set {
            if (value != 0 || value != 1) throw new Exception("Hight must be 0 or 1");
                hight = value;
        }
    }

    public Team(BabyFoot babyFoot, Player owner, Brush color, int hight) {
        this.owner = owner;
        this.color = color;
        this.babyFoot = babyFoot;
        InitFormation(hight);
    }

    public void InitFormation(int position) { 
        this.hight = position;
        int[] formations = {1, 3, 5, 3}; // Formations of the team
        int[] gaps = {40, 30, 20, 0}; // Gaps of the players
        int[] k = {1, 2, 4, 6}; // Line of the players
        this.players = new BabyFootPlayer[formations.Sum()];
        int indexPlayer = 0;
        for (int i = 0; i < 4; i++) {    
            int y = ((k[i]) * ((babyFoot.GetHeightArea() / 9)) - gaps[i]);
            for (int j = 0; j < formations[i]; j++) {
                this.players[indexPlayer] = new BabyFootPlayer(((j + 1) * (babyFoot.GetWidthArea() / (formations[i] + 1))) - 20, (position == 0) ? y : (babyFoot.GetHeightArea() - 45) - y, babyFoot, owner, color, this, i);
                if(indexPlayer < 4){
                    this.players[indexPlayer].isDef = true;
                }
                else if(indexPlayer > 3 && indexPlayer < 9){
                    this.players[indexPlayer].isMid = true;
                }
                else if(indexPlayer > 8){
                    this.players[indexPlayer].isAtk = true;
                }
                indexPlayer++;
            }
        }
        this.players[0].IsPossession = true;
        this.players[0].IsGoal = true;
    }

    public BabyFootPlayer GetPlayersWithCurser() {
        return players[Position]; // Get the tige compared with position
    }

    public int GetPlayerLowDistanceWithBall() {
        int index = (this.Position == 0) ? 1 : 0;
        double min = players[index].GetDistanceWithBall();
        for (int i = 0; i < players.Length; i++) {
            if (this.Position != i && min > players[i].GetDistanceWithBall()) {
                min = players[i].GetDistanceWithBall();
                index = i;
            }
        }
        return index;
    }

    public int GetPlayerLowDistanceWithCurser() {
        BabyFootPlayer player = GetPlayersWithCurser();
        int index = (this.Position == 0) ? 1 : 0;
        double min = players[index].GetDistance(player);
        for (int i = 0; i < players.Length; i++) {
            if (this.Position != i && min > players[i].GetDistance(player)) {
                min = players[i].GetDistance(player);
                index = i;
            }
        }
        return index;
    }

    public void ChangeCurser() {
        this.Position = GetPlayerLowDistanceWithBall();
        // if(this.Position < 12){
        //     this.Position++;
        // }
        // else{
        //     this.Position = 0;
        // }
    }

    public void Move(int rotation) {
        // rotation = 0 => Move to goal
        // rotation = 1 => Move to player
        BabyFootPlayer player = GetPlayersWithCurser();
        if (player.IsTouchBall()) {
            if (rotation == 0) babyFoot.ball.MoveTo(this.goal);
            else babyFoot.ball.MoveTo(players[GetPlayerLowDistanceWithCurser()]);
        }
    }

    public void reverseGoal() {
        BabyFootPlayer goalkeeper = players[0];
        if (goalkeeper.IsTouchBall() && goalkeeper.IsGoal) babyFoot.ball.MoveTo(this.goal);
    }

}