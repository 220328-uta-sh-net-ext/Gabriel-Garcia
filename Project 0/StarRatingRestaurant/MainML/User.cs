namespace MainML
{
    public class User
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        ~User(){}
        public User()
        {
            FName = "";
            LName = "";
            UserName = "";
            Password = "";
        }
        public override string ToString()
        {
            return $"Name: {FName} {LName}\nUser Name: {UserName}\n";
        }
    }
}
