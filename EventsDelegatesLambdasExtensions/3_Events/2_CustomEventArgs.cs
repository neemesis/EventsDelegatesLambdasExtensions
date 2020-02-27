using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsDelegatesLambdasExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventsDelegatesLambdasExtensions._3_Events {
    class CustomEventArgs {
        public class MyEventArgs : EventArgs {
            public int OldValue { get; set; }
            public int NewValue { get; set; }
        }

        public class Product {
            public event EventHandler<MyEventArgs> OnPriceChanged; // can pass custom class and/or custom number of input parameters
            public event EventHandler<MyEventArgs> OnPriceGet; // requires 'object' to be passed
            public string Name { get; set; }
            private int _price;

            public int Price {
                get {
                    OnPriceGet?.Invoke(this, new MyEventArgs { OldValue = _price });
                    return _price;
                }
                set {
                    var oldPrice = _price;
                    _price = value;
                    OnPriceChanged?.Invoke(this, new MyEventArgs { OldValue = oldPrice, NewValue = _price });
                }
            }
        }

        [TestClass]
        public class Market {
            [TestMethod]
            public void Start() {
                var product = new Product { Name = "Apples", Price = 100 };

                product.OnPriceChanged += OnPriceChanged;

                Helpers.ReadLine();
                product.Price = 150;
                Helpers.ReadLine();
                product.Price = 200;
                Helpers.ReadLine();
                product.Price = 300;
            }

            public void OnPriceChanged(object o, MyEventArgs eventArgs) {
                var product = o as Product;
                Helpers.Print($"Price was changed from {eventArgs.OldValue} to {eventArgs.NewValue}!");
                
                // How to get into infinite loop
                //product.Price += 10;
            }
        }
    }
}
