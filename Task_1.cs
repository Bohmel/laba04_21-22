using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_04_21_22
{
    enum Races { Squad, Orc, Elf, Minotaur, Kentaur, Cyclops, Dragon, Hydra, Knight }

    abstract class Component
    {
        protected Races Name { get; set; }

        public Component(Races Name)
        {
            this.Name = Name;
        }
        public abstract void Add(List<Component> warriors);
        public abstract void Remove(Component a);
        public abstract void Info();
    }

    class Warrior : Component
    {
        public Warrior(Races Name) : base(Name) 
        { }

        public override void Add(List<Component> warriors)
        {
            throw new ArgumentException("Воин не может быть группой");
        }

        public override void Remove(Component a)
        {
            throw new ArgumentException("Воин не может быть группой");
        }

        public override void Info()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    class Group : Component
    {
        public List<Component> GroupContent;

        public Group(Races Name) : base(Name)
        {
            this.Name = Races.Squad;
            GroupContent = new List<Component>() { };
        }

        public override void Add(List<Component> warriors)
        {
            foreach (var i in warriors)
            {
                this.GroupContent.Add(i);
            }
        }

        public override void Remove(Component a)
        {
            GroupContent.Remove(a);
        }

        public override void Info()
        {
            Group group;
            Warrior warrior;
            Console.WriteLine(this.ToString());
            foreach (var i in GroupContent)
            {
                group = i as Group;
                if (group != null)
                {
                    i.Info();
                    break;
                }

                warrior = i as Warrior;
                if (warrior != null)
                {
                    i.Info();
                }
            }
        }

        public override string ToString()
        {
            return $"\t{Name}";
        }
    }
}
