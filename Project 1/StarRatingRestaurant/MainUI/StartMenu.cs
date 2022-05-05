using MainUI;
internal class StartMenu : IMenu
{

    public void Display()
    {
        Console.WriteLine("-- Welcome to Restaurant Review --\n");
        Console.WriteLine("   <2> Create User");
        Console.WriteLine("   <1> Login User");
        Console.WriteLine("   <0> Exit");
        Console.WriteLine("\n----------------------------------\n");
    }

    public string UserChoice()
    {
        Console.Write("   > ");
        string sInput = Console.ReadLine();
        Console.Write("\n");
        switch (sInput)
        {
            case "0":
                Console.Clear();
                return "Exit";
            case "1":
                Console.Clear();
                return "LoginUser";
            case "2":
                Console.Clear();
                return "AddUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "StartMenu";
        }
    }
}