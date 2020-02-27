using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdasExtensions._1_Lambdas {
    public class FunctionAsVariable {
        class Movie {
            public Movie(string name) {
                Name = name;
            }

            private string Name { get; set; }

            public string GetName() {
                return Name;
            }

            public void SetName(string name) {
                Name = name;
            }
        }

        public void Start() {
            // Existing function
            Helpers.New();
            var movie = new Movie("Some Movie");

            Func<string> function = movie.GetName;

            Helpers.Print(function());

            // Custom function
            Helpers.New();
            Func<Movie, string> functionThatReceivesMovieAndReturnsString = (movieParam) => {
                return movieParam.GetName();
            };

            Helpers.Print(functionThatReceivesMovieAndReturnsString(movie));

            // Functions that are void with input params
            Helpers.New();
            Action<string> voidFunction = x => Helpers.Print(x);

            voidFunction("PrintThis");

            // Difference between Func and Action


            // Action
            Action action = () => Console.WriteLine("Action");
            action();

            Action<string> action2 = (x) => Console.WriteLine(x);
            action2("tos");

            // Predicate
            Predicate<int> predicate = (x) => x == 5;
            Helpers.Print(predicate(5));
            Helpers.Print(predicate(6));

        }
    }
}
