namespace ExchangeRateApp
{
    internal static class Program
    {
        //
        //  G��wny punkt wej�ciowy aplikacji
        //
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}