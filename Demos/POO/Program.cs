using System;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!".CarlosGuilherme());

        }
    }
    
    
    abstract class ClassA
    {
        public virtual void Valida() {
            Console.WriteLine("DOWork");
        }
    }

    class ClassB : ClassA
    {
        public sealed override void Valida()
        {
            Console.WriteLine("DoWorkClassB");
        }
    }

    class ClassC : ClassA
    {
    //    public override void Valida()
    //    {
    //        base.Valida();
    //    }
    }


}
