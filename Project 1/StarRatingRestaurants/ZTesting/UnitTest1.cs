using Xunit;
using System.Collections.Generic;
using System.Linq;
using BL;
using DL;
using Models;
namespace ZTesting
{
    public class UnitTest1
    {
        IRestaurantLogic _rest;
        static readonly Restaurant rest = new();

        [Fact]
        public void ModelTestUser()
        {
            User user = new()
            {
                FirstName = "Admin",
                LastName = "",
                Email = "",
                UserName = "",
                Password = "",
                ReviewerId = ""
            };
            Assert.Equal("Admin", user.FirstName);
            Assert.Equal("", user.LastName);
            Assert.Equal("", user.Email);
            Assert.Equal("", user.UserName);
            Assert.Equal("", user.Password);
            Assert.Equal("", user.ReviewerId);
        }
        [Fact]

        public void ModelTestRestaurant()
        {
            Restaurant restaurant = new()
            {
                Name = "name",
                Id = "id"
            };
            Assert.Equal("name", restaurant.Name);
            Assert.Equal("id", restaurant.Id);
        }
        [Fact]

        public void ModelTestLocaiton()
        {
            Location location = new()
            {
                Country = "country",
                State = "state",
                City = "city",
                Id = "id",
                Zipcode = "zip"
            };
            Assert.Equal("country", location.Country);
            Assert.Equal("state", location.State);
            Assert.Equal("city", location.City);
            Assert.Equal("id", location.Id);
            Assert.Equal("zip", location.Zipcode);
        }
        [Fact]

        public void ModelTestReview()
        {
            Reviews reviews = new()
            {
                Id = "id",
                Review = "good",
                Rate = 0,
                ReviewerId = "user id"
            };
            Assert.Equal("id", reviews.Id);
            Assert.Equal("good", reviews.Review);
            Assert.Equal(0, reviews.Rate);
            Assert.Equal("user id", reviews.ReviewerId);
        }
        //[Theory]
        //[InlineData("Name", "Cheetah Chow and Grill")]
        //public void Test(string where, string equal)
        //{
        //    _rest.DisplayAllRestaurants();
        //    //foreach(var i in )
        //    //Assert.Equal()
        //    _rest.SearchRestaurant(where,equal);
        //
        //}
    }
}