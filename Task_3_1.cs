using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_04_21_22
{
    interface Movement
    {
        void Walk();
        void Fly();
    }

    class Person
    {
        protected Movement Hero;

        public Person(Movement hero)
        {
            Hero = hero;
        }

        public void PersonInfo()
        {
            Hero.Fly();
            Hero.Walk();
            Console.WriteLine(new string('*', 25));
        }
    }

    class Orc : Movement
    {
        public bool isMagician { get; set; }

        public Orc(bool isMagician)
        {
            this.isMagician = isMagician;
        }

        public void Fly()
        {
            if (isMagician)
                Console.WriteLine($"{this.GetType().Name} может использовать магию для полёта");
            else
                Console.WriteLine($"{this.GetType().Name} не может летать");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} может передвигаться пешком");
        }
    }

    class Troll : Movement
    {
        public bool isMagician { get; set; }

        public Troll(bool isMagician)
        {
            this.isMagician = isMagician;
        }

        public void Fly()
        {
            if (isMagician)
                Console.WriteLine($"{this.GetType().Name} может использовать магию для полёта");
            else
                Console.WriteLine($"{this.GetType().Name} не может летать");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} может передвигаться пешком");
        }
    }

    class Pegasus : Movement
    {
        public Pegasus() { }

        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} может летать");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} может передвигаться пешком");
        }
    }

    class Elf : Movement
    {
        public bool isMagician { get; set; }

        public Elf(bool isMagician)
        {
            this.isMagician = isMagician;
        }

        public void Fly()
        {
            if (isMagician)
                Console.WriteLine($"{this.GetType().Name} может использовать магию для полёта");
            else
                Console.WriteLine($"{this.GetType().Name} не может летать");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} может передвигаться пешком");
        }
    }

    class Vampyre : Movement
    {
        public Vampyre() { }

        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} может летать");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} может передвигаться пешком");
        }
    }

    class Harpy : Movement
    {
        public Harpy() { }

        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} может летать");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} может передвигаться пешком");
        }
    }
}
