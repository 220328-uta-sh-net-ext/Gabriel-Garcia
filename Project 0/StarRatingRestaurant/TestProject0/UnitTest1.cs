using Xunit;
using MainBL;
using MainDL;
using MainML;

namespace TestProject0
{
    public class UnitTest1
    {
        static readonly Restaurant rest = new();
        static readonly User user = new();
        readonly IRestaurantLogic rLogic;
        readonly IUserLogic uLogic;

        public UnitTest1(IRestaurantLogic logic)
        { rLogic = logic; }
        public UnitTest1(IUserLogic logic)
        { uLogic = logic;}

        [Fact]
        public void Test1()
        {
            //Arrange

            //Act
            //Assert
        }
        
    }
}