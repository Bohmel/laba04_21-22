using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_04_21_22
{
    public enum EBody { fastback, hardtop, universal }
    public enum EEngine { petrol, diesel, gas }
    public enum EWheels { WarmSeasons, ColdSeasons, AllSeasons }

    public interface IBuilder
    {
        void BuildBody(EBody body);
        void BuildEngine(EEngine engine);
        void BuildWheels(EWheels wheels);
    }

    class Car : IBuilder
    {
        private AbstractCar product = new AbstractCar();

        public Car()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.product = new AbstractCar();
        }

        public void BuildBody(EBody body)
        {
            this.product.AddBody(body);
        }

        public void BuildEngine(EEngine engine)
        {
            this.product.AddEngine(engine);
        }

        public void BuildWheels(EWheels wheels)
        {
            this.product.AddWheels(wheels);
        }

        public AbstractCar GetProduct()
        {
            AbstractCar result = this.product;

            this.Reset();

            return result;
        }
    }

    class AbstractCar
    {
        private List<object> parts = new List<object>();

        public void AddBody(EBody body)
        {
            this.parts.Add(body);
        }

        public void AddEngine(EEngine engine)
        {
            this.parts.Add(engine);
        }

        public void AddWheels(EWheels wheels)
        {
            this.parts.Add(wheels);
        }
        
        public string Info()
        {
            string info = "";
            foreach (var i in parts)
            {
                info += $"{i.ToString()}\n";
            }
            info += "\n";

            return info;
        }
    }

    class CarProduction
    {
        private IBuilder builder;

        public IBuilder Builder
        {
            set { builder = value; }
        }

        public void buildSummerCar()
        {
            this.builder.BuildBody(EBody.hardtop);
            this.builder.BuildEngine(EEngine.gas);
            this.builder.BuildWheels(EWheels.WarmSeasons);
        }

        public void buildWinterCar()
        {
            this.builder.BuildBody(EBody.fastback);
            this.builder.BuildEngine(EEngine.petrol);
            this.builder.BuildWheels(EWheels.ColdSeasons);
        }
    }
}
