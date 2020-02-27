using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdasExtensions._2_Delegates {
    [TestClass]
    public class Intro {
        // Declaring delegate
        public delegate int PerformCalculation(int x, int y);

        public void Start() {
            Helpers.New();
            SetDelegate();

            Helpers.New();
            DelegateWithAnonymousFunction();

            Helpers.New();
            DelegateAndFunctionThatTakesDelegates();

            Helpers.New();
            MulticastDelegates();
        }

        [TestMethod]
        private void MulticastDelegates() {
            // Multicast delegates / combine delegates
            PerformCalculation pc1 = Add;
            PerformCalculation pc2 = Sub;
            PerformCalculation pc3 = pc1 + pc2;

            Helpers.Print(pc3(2, 5));

            pc3 += pc3;

            Helpers.Print(pc3(2, 5));
        }

        [TestMethod]
        private void DelegateAndFunctionThatTakesDelegates() {
            // using 'delegate' keyword
            PerformCalculation pc5 = delegate (int x, int y) {
                return x * 5 + x - y;
            };

            Helpers.Print(pc5(5, 1));

            // function that has delegate as input param
            SomeCalc(2, 5, Add);
            SomeCalc(2, 5, pc5);
        }

        [TestMethod]
        private static void DelegateWithAnonymousFunction() {
            // Anonymous functions
            PerformCalculation pc4 = (x, y) => x * y;

            Helpers.Print(pc4(2, 5));
        }


        [TestMethod]
        private void SetDelegate() {
            // Set delegate to function
            PerformCalculation pc = new PerformCalculation(Add);

            Helpers.Print(pc(2, 5));

            // Set same delegate to another function
            pc = Sub;

            Helpers.Print(pc(2, 5));
        }

        // Helper methods
        public int Add(int x, int y) {
            Helpers.Print($"Add was called on: {x} and {y}");
            return x + y;
        }

        public int Sub(int x, int y) {
            Helpers.Print($"Sub was called on: {x} and {y}");
            return x - y;
        }

        public void SomeCalc(int x, int y, PerformCalculation pc) {
            Helpers.Print($"SomeCalc using {pc.Method.Name}: {pc(x, y)}");
        }
    }
}
