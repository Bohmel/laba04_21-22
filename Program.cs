using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_04_21_22
{
    class Program
    {
        static void CompositeMethod()
        {
            Component MainSquad = new Group(Races.Squad);

            Component war1 = new Warrior(Races.Elf);
            Component squad1 = new Group(Races.Squad);
            MainSquad.Add(new List<Component> { war1, squad1 });

            Component war2 = new Warrior(Races.Knight);
            Component war3 = new Warrior(Races.Dragon);
            Component squad2 = new Group(Races.Squad);
            squad1.Add(new List<Component> { war2, war3, squad2 });

            Component war4 = new Warrior(Races.Orc);
            Component war5 = new Warrior(Races.Orc);
            squad2.Add(new List<Component> { war4, war5 });

            MainSquad.Info();
        }

        static void Task1()
        {
            CompositeMethod();
        }

        static void BuilderMethod()
        {
            CarProduction director = new CarProduction();
            Car builder = new Car();
            director.Builder = builder;

            director.buildSummerCar();
            Console.WriteLine(builder.GetProduct().Info());

            director.buildWinterCar();
            Console.WriteLine(builder.GetProduct().Info());

            builder.BuildBody(EBody.fastback);
            builder.BuildEngine(EEngine.diesel);
            builder.BuildWheels(EWheels.WarmSeasons);
            Console.WriteLine(builder.GetProduct().Info());
        }

        static void FactoryMethod()
        {
            FigureCreation creator = new FigureCreator_B();
            Figure A = creator.Create();

            creator = new FigureCreator_A();
            Figure B = creator.Create();

            creator = new FigureCreator_C();
            Figure C = creator.Create();

            creator.Add(new List<Figure>() { A, B, C});
            Console.WriteLine(creator.RandomFigure());
        }

        static void Task2()
        {
            BuilderMethod();
            FactoryMethod();
        }

        static void StrategyMethod()
        {
            Person Orc = new Person(new Orc(false));
            Orc.PersonInfo();

            Person Harpy = new Person(new Harpy());
            Harpy.PersonInfo();

            Person Vampyre = new Person(new Vampyre());
            Vampyre.PersonInfo();
        }

        static void ObserverMethod()
        {
            Newspaper foo = new Newspaper();

            Task_3_2 bar1 = new Task_3_2();
            foo.Follow(bar1);

            Task_3_2 bar2 = new Task_3_2();
            foo.Follow(bar2);

            foo.Notify();

            foo.Unfollow(bar2);

            foo.Notify();
        }

        static void StateMethod()
        {
            Context context = new Context(new NotPassed());
            context.Give();
            context.Give();
            context.Take();
            context.Take();
        }

        static void Task3()
        {
            StrategyMethod();
            ObserverMethod();
            StateMethod();
        }

        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
        }
    }
}
