using Xunit;
using UserBL;

namespace UserTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrage
            SampleTest obj = new SampleTest();
            int a = 10, b = 20, expected = 30;

            //Act
            var actual = obj.Add(a, b);
            //Assert
            Assert.Equal(expected, actual);

        }//dotnet a
    }
}