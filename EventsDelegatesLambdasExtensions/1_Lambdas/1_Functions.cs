using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdasExtensions._1_Lambdas {
    [TestClass]
    public class Functions {
        public class Movie {
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

            public bool IsNameEqualTo(string name) {
                return Name == name;
            }
        }

        [TestMethod]
        public void Start() {
            var movie = new Movie("Some Movie");

            Helpers.Print("Ime:" + movie.GetName());
        }
    }
}
