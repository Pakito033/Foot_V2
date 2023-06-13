namespace baby_foot;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        try {
            ApplicationConfiguration.Initialize();
            Application.Run(new Bet());
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
        // MessageBox.Show((Math.Cos(60 * Math.PI / 180.0).ToString()));
    }    
}