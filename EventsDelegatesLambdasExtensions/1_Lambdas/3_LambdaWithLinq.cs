using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsDelegatesLambdasExtensions._1_Lambdas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventsDelegatesLambdasExtensions._1_Lambdas {
    [TestClass]
    public class LambdaWithLinq {
        [TestMethod]
        public void Start() {
            var movies = _0_Data.Data.GetMovies();

            // Filter movies using predefined function
            Helpers.New();
            var movie1 = movies.First(FilterMovie1);

            Helpers.Print(movie1.GetName());

            // Filter movies using anonymous function
            Helpers.New();
            var movie3 = movies.First(movie => {
                Console.WriteLine("tos");
                return movie.GetName() == "Movie 3";
                }
            );

            Helpers.Print(movie3.GetName());

            // Using Func to filter
            Helpers.New();
            Func<Functions.Movie, bool> usingFuncFilterMoviesEndingOn5 = (movie) => {
                Helpers.Print("This is printed for every movie in movies!");
                return movie.GetName().EndsWith("5");
            };

            var moviesEndingOn5 = movies.Where(usingFuncFilterMoviesEndingOn5);
            // calling the function directly
            var directCall = usingFuncFilterMoviesEndingOn5(movies.First());
            Helpers.Print(directCall);

            Helpers.Print(moviesEndingOn5.Count());
        }

        public static bool FilterMovie1(Functions.Movie movie) {
            return movie.GetName() == "Movie 1";
        }
    }
}
