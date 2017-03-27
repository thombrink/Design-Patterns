using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainExample {
    class Program {
        static void Main(string[] args) {

            var h1 = new BabyHandler();
            var h2 = new ChildHandler();
            var h3 = new GrownUpHandler();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            var ageArray = new uint[] { 0, 3, 5, 2, 9, 20, 44, 12 };
            foreach(var age in ageArray) {
                h1.HandleRequest(age);
            }

            Console.ReadKey();
        }
    }

    abstract class HumanHandler {
        protected HumanHandler Successor;

        public void SetSuccessor(HumanHandler successor) {
            Successor = successor;
        }

        public abstract void HandleRequest(uint age);
    }

    class BabyHandler : HumanHandler {
        public override void HandleRequest(uint age) {
            if(age < 1) {
                Console.WriteLine($"I'm a baby because I'm {age} years old");
            } else if (Successor != null) {
                Successor.HandleRequest(age); 
            }
        }
    }

    class ChildHandler : HumanHandler {
        public override void HandleRequest(uint age) {
            if (age >= 1 && age < 18) {
                Console.WriteLine($"I'm a child because I'm {age} years old");
            }
            else if (Successor != null) {
                Successor.HandleRequest(age);
            }
        }
    }

    class GrownUpHandler : HumanHandler {
        public override void HandleRequest(uint age) {
            if (age >= 18 && age < 99) {
                Console.WriteLine($"I'm a gruwn up because I'm {age} years old");
            }
            else if (Successor != null) {
                Successor.HandleRequest(age);
            }
        }
    }
}
