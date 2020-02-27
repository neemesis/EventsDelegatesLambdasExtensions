using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsDelegatesLambdasExtensions._1_Lambdas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventsDelegatesLambdasExtensions._3_Events {
    public class Intro {
        public class Cinema {
            public EventHandler BeforeMovie;
            public EventHandler AfterMovie;

            public void AirMovie(Functions.Movie movie) {
                Helpers.ReadLine("to AirMovie");

                BeforeMovie?.Invoke(this, EventArgs.Empty);
                Helpers.Print($"Airing: {movie.GetName()}");
                AfterMovie?.Invoke(this, EventArgs.Empty);
            }
        }

        public class StartEventsWithoutHandlers {
            public void Start() {
                var cinema = new Cinema();
                var movie = new Functions.Movie("Some movie");

                cinema.AirMovie(movie);
            }
        }

        [TestClass]
        public class StartEventsWithHandlers {
            [TestMethod]
            public void Start() {
                var cinema = new Cinema();
                var movie = new Functions.Movie("Some movie");

                cinema.BeforeMovie += OnBeforeMovie;
                cinema.AfterMovie += OnAfterMovie;

                cinema.AirMovie(movie);

                // Unsubscribe handlers
                Helpers.New();
                cinema.BeforeMovie -= OnBeforeMovie;
                cinema.AirMovie(movie);

                // Add multiple handlers
                Helpers.New();
                cinema.AfterMovie += (o, args) => Helpers.Print("Another handler on after movie!");
                cinema.AirMovie(movie);
            }

            public void OnBeforeMovie(object o, EventArgs args) {
                Helpers.Print("OnBeforeMovie handler!");
            }

            public void OnAfterMovie(object o, EventArgs args) {
                Helpers.Print("OnAfterMovie handler!");
            }
        }

        public class StartEventsWithAnonymousHandlers {
            [TestMethod]
            public void Start() {
                var movie = new Functions.Movie("Some movie");
                var cinema = new Cinema();

                cinema.BeforeMovie += (o, args) => Helpers.Print("Before movie!");
                cinema.AfterMovie += (o, args) => Helpers.Print("After movie!");

                Helpers.ReadLine();
                cinema.AirMovie(movie);
            }
        }
    }
}
