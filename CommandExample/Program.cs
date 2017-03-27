using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample {
    class Program {
        static void Main(string[] args) {
            var remoteControl = new RemoteControl();

            var livingRoomLight = new Light();

            var livingRoomLightOn = new LightOnCommand(livingRoomLight);
            var livingRoomLightOff = new LightOffCommand(livingRoomLight);

            remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);

            remoteControl.OnButtonPressed(0);
            remoteControl.OffButtonPressed(0);
            Console.WriteLine(remoteControl);
            remoteControl.UndoButtonPressed();
            remoteControl.OffButtonPressed(0);
            remoteControl.OnButtonPressed(0);
            Console.WriteLine(remoteControl);
            remoteControl.UndoButtonPressed();
            Console.ReadKey();
        }
    }
}
