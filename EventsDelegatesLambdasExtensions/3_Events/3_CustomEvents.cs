using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdasExtensions._3_Events {
    public class CustomEventsUsingDelegates {
        public delegate void ValueChanged(int oldValue, int newValue);

        class Product {
            public event ValueChanged OnValueChanged;
            public string Name { get; set; }
            private int _price;

            public int Price {
                get {
                    return _price;
                }
                set {
                    var oldPrice = _price;
                    _price = value;
                    OnValueChanged?.Invoke(oldPrice, _price);
                }
            }
        }

        [TestClass]
        public class Market {
            [TestMethod]
            public void Start() {
                var product = new Product { Name = "Apples", Price = 100 };

                product.OnValueChanged += OnPriceChanged;

                Helpers.ReadLine();
                product.Price = 150;
                Helpers.ReadLine();
                product.Price = 200;
                Helpers.ReadLine();
                product.Price = 300;
            }

            public void OnPriceChanged(int oldValue, int newValue) {
                Helpers.Print($"Price was changed from {oldValue} to {newValue}!");
            }
        }
    }
}
