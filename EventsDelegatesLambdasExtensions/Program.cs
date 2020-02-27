using EventsDelegatesLambdasExtensions._1_Lambdas;
using EventsDelegatesLambdasExtensions._2_Delegates;
using EventsDelegatesLambdasExtensions._3_Events;
using EventsDelegatesLambdasExtensions._4_Extensions;
using System;
using System.Diagnostics;

namespace EventsDelegatesLambdasExtensions {
    class Program {
        static void Main(string[] args) {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            new Functions().Start();

            //new FunctionAsVariable().Start();

            //new LambdaWithLinq().Start();

            //new Intro().Start();

            //new _3_Events.Intro.StartEventsWithoutHandlers().Start();
            //new _3_Events.Intro.StartEventsWithHandlers().Start();
            //new CustomEventsUsingDelegates.Market().Start();
            //new CustomEventArgs.Market().Start();


            //new ExtensionExamples().Start();

            Console.ReadLine();
        }
    }
}
