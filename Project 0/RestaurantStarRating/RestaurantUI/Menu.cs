using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public interface Menu
    {
        /// <summary>
        /// Will display the menu and user choices in th terminal
        /// </summary>
        void Display();
        /// <summary>
        /// Will record the user choice
        /// </summary>
        /// <returns>return string</returns>
        string UserChoice();
    }
}
