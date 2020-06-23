using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_04_21_22
{
    class Context
    {
        private State state = null;

        public Context(State state)
        {
            this.TransitionTo(state);
        }
        
        public void TransitionTo(State state)
        {
            Console.WriteLine($"Контекст: переход к {state.GetType().Name}.");
            this.state = state;
            this.state.SetContext(this);
        }
        
        public void Give()
        {
            this.state.GiveWork();
        }

        public void Take()
        {
            this.state.TakeWork();
        }
    }

    abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract void GiveWork();

        public abstract void TakeWork();
    }
    
    class NotPassed : State
    {
        public override void GiveWork()
        {
            Console.WriteLine("Сдано на проверку.");
            this._context.TransitionTo(new Handed());
        }

        public override void TakeWork()
        {
            Console.WriteLine("Нельзя забрать несданную работу.");
        }
    }

    class Handed : State
    {
        public override void GiveWork()
        {
            Console.WriteLine("Вашу работу проверяют.");
            this._context.TransitionTo(new Checked());
        }

        public override void TakeWork()
        {
            Console.WriteLine("Вы забрали работу назад.");
            this._context.TransitionTo(new NotPassed());
        }
    }

    class Checked : State
    {
        public override void GiveWork()
        {
            Console.WriteLine("Работа проверена, нужно её забрать.");
        }

        public override void TakeWork()
        {
            Console.WriteLine("Вы забрали проверенную работу.");
            this._context.TransitionTo(new GiveOut());
        }
    }

    class GiveOut : State
    {
        public override void GiveWork()
        {
            Console.WriteLine("Вашу работу проверили, заберите её.");
        }

        public override void TakeWork()
        {
            Console.WriteLine("Вы забрали вашу работу.");
            this._context.TransitionTo(new NotPassed());
        }
    }
}
