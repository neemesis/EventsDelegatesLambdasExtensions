using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdasExtensions._4_Extensions {
    public static class ExtensionMethods {
        public static void GetNameAndGenre(this Movie movie, int year) {
            Helpers.Print($"GetNameAndGenre: {movie.Name}, {movie.Genre}, {year}");
        }

        public static string GetNameWithLowerLetters(this Movie movie) {
            Helpers.Print("GetNameWithLowerLetters was called!");
            return movie.Name.ToLower();
        }

        public static string GetDirector(this Movie movie) {
            Helpers.Print("GetDirector: Extension method called");
            return movie.Director;
        }

        public static void IsThisApples(this string o) {
            Console.WriteLine("Print");
        }

        //public static void GetRating(this Movie movie) {
        //    Helpers.Print($"GetRating: {movie.Rating}");
        //}
    }

    public class Movie {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        private int Rating { get; set; }

        public string GetDirector() {
            Helpers.Print("GetDirector: Class method called");
            return Director.ToUpper();
        }
    }

    [TestClass]
    public class ExtensionExamples {
        [TestMethod]
        public void Start() {
            var movie = new Movie {
                Year = 2019,
                Name = "Test Movie",
                Director = "Test Dir",
                Genre = "Some Genre"
            };

            Helpers.New(); // void function

            movie.GetNameAndGenre(2019);
            ExtensionMethods.GetNameAndGenre(movie, 2019);

            Helpers.New();

            // function that return string
            var name = movie.GetNameWithLowerLetters();
            Helpers.Print(name);

            Helpers.New();

            // class method vs extension method
            var director = movie.GetDirector();
            Helpers.Print(director);

            Helpers.New();

            // explicit call to extension method
            var director2 = ExtensionMethods.GetDirector(movie);
            Helpers.Print(director2);

            // extension method with private property
            //movie.GetRating();
        }
    }

}
