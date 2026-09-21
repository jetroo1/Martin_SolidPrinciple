namespace OrderDesk;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // The form is built by the composition root, not by `new Form1()`.
        Application.Run(CompositionRoot.CreateMainForm());
    }
}
