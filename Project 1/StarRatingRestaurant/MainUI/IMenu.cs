namespace MainUI
{
    internal interface IMenu
    {
        /// <summary>
        /// Will display the menu options
        /// </summary>
        void Display();
        /// <summary>
        /// Will Record Input
        /// </summary>
        /// <returns></returns>
        string UserChoice();
    }
}
