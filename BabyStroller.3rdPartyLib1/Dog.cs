using System;
using BabyStroller.SDK;

namespace BabyStroller._3rdPartyLib1
{
    public class Dog : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Woof...");
            }
            
        }
    }
}
