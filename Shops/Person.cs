using System;
using System.Collections.Generic;
using System.Text;

namespace Shops
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public decimal Balance { get; set; }
    }
}
