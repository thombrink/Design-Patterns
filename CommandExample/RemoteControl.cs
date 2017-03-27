using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample {
    public class RemoteControl {
        private ICommand[] _onCommands;
        private ICommand[] _offCommands;

        private ICommand _undoCommand;

        public RemoteControl() {
            var remoteSize = 10;

            _onCommands = new ICommand[remoteSize];
            _offCommands = new ICommand[remoteSize];

            for(var i = 0; i < remoteSize; i++) {
                _onCommands[i] = new NoCommand();
                _offCommands[i] = new NoCommand();
            }
        }

        public void SetCommand(uint slot, ICommand onCommand, ICommand offCommand) {
            if (slot >= _onCommands.Length) return;

            _onCommands[slot] = onCommand;
            _offCommands[slot] = offCommand;
        }

        public void OnButtonPressed(uint slot) {
            _onCommands[slot]?.Execute();
            _undoCommand = _onCommands[slot];
        }

        public void OffButtonPressed(uint slot) {
            _offCommands[slot]?.Execute();
            _undoCommand = _offCommands[slot];
        }

        public void UndoButtonPressed() {
            _undoCommand?.Undo();
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("\n------ Remote Control -------\n");
            for (int i = 0; (i < _onCommands.Length); i++) {
                sb.Append(("[slot "
                                + (i + ("] "
                                + (_onCommands[i].GetType().Name + ("    "
                                + (_offCommands[i].GetType().Name + "\n")))))));
            }

            return sb.ToString();
        }
    }
}
