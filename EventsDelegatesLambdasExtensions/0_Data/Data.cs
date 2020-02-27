using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsDelegatesLambdasExtensions._1_Lambdas;

namespace EventsDelegatesLambdasExtensions._0_Data {
    public static class Data {
        public static IEnumerable<Functions.Movie> GetMovies() {
            return Enumerable.Range(1, 20).Select(x => new Functions.Movie($"Movie {x}"));
        }
    }
}
