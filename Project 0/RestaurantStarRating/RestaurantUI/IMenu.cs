
namespace RestaurantUI
{
    internal interface IMenu
    {
        /// <summary>
        /// Will display the menu and user choices in th terminal
        /// </summary>
        void DisplayStartMenu();
        void DisplayUserMenu();
        void DisplayAdminMenu();
        //.....
        /// <summary>
        /// Will record the user choice
        /// </summary>
        /// <returns>return string</returns>
        string UserChoiceLogedin();
        string UserChoiceLogingin();
        string AdminUserLoggin();
    }
}
