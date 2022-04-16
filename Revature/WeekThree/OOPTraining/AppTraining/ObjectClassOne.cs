using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//creating a new class 
namespace AppTraining
{
    internal class ObjectClassOne
    {
        public string sName = "name";//setting up some variables 
        public const string csName = "csName";//can't be changed

        //mwthods
        public void TestDoThings(string sString,string sName)
        {
            //this.sName is pointing to the one in ObjectClassOne while the sName is pointing to the variable located in TestDoThings
            this.sName = sName;
            Console.WriteLine($"{sString} and {sName}");
        }
    }
}
