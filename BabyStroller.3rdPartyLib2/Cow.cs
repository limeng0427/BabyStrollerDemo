using System;
using BabyStroller.SDK;

namespace BabyStroller._3rdPartyLib2
{
    public class Cow : IAnimal
    {
        public void Voice(int times)
        {
            Console.WriteLine("Moo...");
        }
    }
}
