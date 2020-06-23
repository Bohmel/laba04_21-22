using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_04_21_22
{
    //Заранее предупреждаю, что это является лишь примером реализации паттерна и не полным, т.к. долго и времени не особо много
    abstract class FigureCreation
    {
        List<Figure> figureList = new List<Figure>() { };

        abstract public Figure Create();

        public void Add(List<Figure> list)
        {
            foreach (var i in list)
            {
                figureList.Add(i);
            }
        }

        public Figure RandomFigure()
        {
            Random rnd = new Random();
            int randIndex = rnd.Next(0, figureList.Count);
            return figureList[randIndex];
        }
    }

    class FigureCreator_A : FigureCreation
    {
        public override Figure Create() { return new Figure_A(); }
    }

    class FigureCreator_B : FigureCreation
    {
        public override Figure Create() { return new Figure_B(); }
    }

    class FigureCreator_C : FigureCreation
    {
        public override Figure Create() { return new Figure_C(); }
    }

    abstract class Figure
    { }

    class Figure_A : Figure
    {
        public Figure_A() { Console.WriteLine("A"); }
    }

    class Figure_B : Figure
    {
        public Figure_B() { Console.WriteLine("B"); }
    }

    class Figure_C : Figure
    {
        public Figure_C() { Console.WriteLine("C"); }
    }
}
