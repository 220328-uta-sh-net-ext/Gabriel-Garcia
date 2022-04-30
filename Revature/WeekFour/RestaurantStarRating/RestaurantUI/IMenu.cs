
namespace RestaurantUI
{
    internal interface IMenu
    {
        /// <summary>
        /// Will display the menu and user choices in th terminal
        /// </summary>
        void Display();
        //void DisplayUserMenu();
        //void DisplayAdminMenu();
        //.....
        /// <summary>
        /// Will record the user choice
        /// </summary>
        /// <returns>return string</returns>
        string UserChoice();
        //string UserChoiceLogingin();
        //string AdminUserLoggin();
    }
}
