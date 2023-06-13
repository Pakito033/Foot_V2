namespace baby_foot;

public partial class FormPlayer : Form {
    
    public FormPlayer() {
        InitializeComponent();
    }

    private void AddPlayer(object sender, EventArgs e) {
        try {
            // Get value in textBox name and insert a new player
            string value = name.Text; // Text in textBox name
            if(String.IsNullOrEmpty(value) == false){
                Player player = new Player(value);
                player.Insert();
                name.Text = "";
                MessageBox.Show("Joueur " + value + " ajouté");   
            }
            else throw new System.ArgumentException("Please enter player's name");
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
    }

     private void Play(object sender, EventArgs e){
        try {
            Bet betForm = new Bet();
            Thread newBetFormThread = new Thread(delegate() {
                Application.Run(betForm);
            });
            newBetFormThread.SetApartmentState(ApartmentState.STA);
            newBetFormThread.Start();
            Thread.Sleep(300);
            this.Close();
        } catch (Exception ex) {
            MessageBox.Show(ex.ToString());
        }
    }
    
}
