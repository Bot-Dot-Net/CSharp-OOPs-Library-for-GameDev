using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class CommandPattern1
    { //❓ “If inputs increase, will InputHandler become very large?”
        // Command
        public interface ICommand
        {
            void Execute();
        }

        // Receiver
        public class Player
        {
            public void Jump() => Console.WriteLine("Player jumps");
            public void Shoot() => Console.WriteLine("Player shoots");
        }

        // Concrete Commands
        public class JumpCommand : ICommand
        {
            private Player _player;
            public JumpCommand(Player player) => _player = player;
            public void Execute() => _player.Jump();
        }

        public class ShootCommand : ICommand
        {
            private Player _player;
            public ShootCommand(Player player) => _player = player;
            public void Execute() => _player.Shoot();
        }

        // Invoker
        public class InputHandler
        {
            private ICommand _buttonA;
            private ICommand _buttonB;

            public void SetCommands(ICommand a, ICommand b)
            {
                _buttonA = a;
                _buttonB = b;
            }

            public void PressA() => _buttonA.Execute();
            public void PressB() => _buttonB.Execute();
        }
        public static void Run()
        {
            // // Client code
            // Player player = new Player();
            // ICommand jumpCommand = new JumpCommand(player);
            // ICommand shootCommand = new ShootCommand(player);

            // InputHandler inputHandler = new InputHandler();
            // inputHandler.SetCommands(jumpCommand, shootCommand);

            // inputHandler.PressA(); // Output: Player jumps
            // inputHandler.PressB(); // Output: Player shoots

            // Alternatively, we can directly set the commands without creating separate variables
            var player = new Player();
            var input = new InputHandler();

            input.SetCommands(
                new JumpCommand(player),
                new ShootCommand(player)
            );

            input.PressA(); // Jump
            input.PressB(); // Shoot

        }
    }

    public class CommandPattern2
    {
        // Command
        public interface ICommand
        {
            void Execute();
        }

        // Receiver
        public class Light
        {
            public void On() => Console.WriteLine("Light is ON");
            public void Off() => Console.WriteLine("Light is OFF");
        }

        // Concrete Commands
        public class LightOnCommand : ICommand
        {
            private Light _light;
            public LightOnCommand(Light light) => _light = light;
            public void Execute() => _light.On();
        }

        public class LightOffCommand : ICommand
        {
            private Light _light;
            public LightOffCommand(Light light) => _light = light;
            public void Execute() => _light.Off();
        }

        // Invoker
        public class RemoteControl
        {
            private ICommand _onCommand;
            private ICommand _offCommand;

            public void SetCommands(ICommand on, ICommand off)
            {
                _onCommand = on;
                _offCommand = off;
            }

            public void PressOn() => _onCommand.Execute();
            public void PressOff() => _offCommand.Execute();
        }
        public static void Run()
        {
            var light = new Light();
            var remote = new RemoteControl();

            remote.SetCommands(
                new LightOnCommand(light),
                new LightOffCommand(light)
            );

            remote.PressOn(); // Output: Light is ON
            remote.PressOff(); // Output: Light is OFF
        }
    }

    public class CommandPattern3
    {
        public interface ICommand //================== Command Interface ==================
        {
            void Execute();
        }

        public class Document
        {
            public void Save() => Console.WriteLine("Document saved");
            public void Open() => Console.WriteLine("Document opened");
        }
        public class SaveCommand : ICommand
        {
            private Document _document;
            public SaveCommand(Document document) => _document = document;
            public void Execute() => _document.Save();
        }
        public class OpenCommand : ICommand
        {
            private Document _document;
            public OpenCommand(Document document) => _document = document;
            public void Execute() => _document.Open();
        }  
        public class Menu
        {
            private ICommand _saveCommand;
            private ICommand _openCommand;

            public void SetCommands(ICommand save, ICommand open)
            {
                _saveCommand = save;
                _openCommand = open;
            }

            public void ClickSave() => _saveCommand.Execute();
            public void ClickOpen() => _openCommand.Execute();
        }
        public static void Run()
        {
            var document = new Document();
            var menu = new Menu();

            menu.SetCommands(
                new SaveCommand(document),
                new OpenCommand(document)
            );

            menu.ClickSave(); // Output: Document saved
            menu.ClickOpen(); // Output: Document opened
        }
    }

    public class CommandPattern4
    {
        //=================================================InputHandler (REUSABLE FOREVER)=================================================
        // using System;
        // using System.Collections.Generic;
        public enum Key //================== KEYBOARD + ARROW KEYS ==================
        {
            A, D, W, S,
            LeftArrow, RightArrow, UpArrow, DownArrow
        }

        public class InputHandler //================== REUSABLE FOREVER ==================
        {
            private Dictionary<Key, ICommand> _bindings =
                new Dictionary<Key, ICommand>();

            public void Bind(Key key, ICommand command)
            {
                _bindings[key] = command; // add or replace
            }

            public void Unbind(Key key)
            {
                _bindings.Remove(key);
            }

            public void HandleInput(Key key)
            {
                if (_bindings.TryGetValue(key, out ICommand command))
                    command.Execute();
                else
                    Console.WriteLine("No action bound to " + key);
            }
        }
        public interface ICommand   //================== Command Interface ==================
        {
            void Execute();
        }
        public class Player     //================== Receiver ==================
        {
            public void MoveLeft()  => Console.WriteLine("Player moves LEFT");
            public void MoveRight() => Console.WriteLine("Player moves RIGHT");
            public void MoveUp()    => Console.WriteLine("Player moves FORWARD");
            public void MoveDown()  => Console.WriteLine("Player moves BACK");
        }

        public class MoveLeftCommand : ICommand     //================== Concrete Command ==================
        {
            private Player _player;
            public MoveLeftCommand(Player player) => _player = player;
            public void Execute() => _player.MoveLeft();
        }

        public class MoveRightCommand : ICommand     //================== Concrete Command ==================
        {
            private Player _player;
            public MoveRightCommand(Player player) => _player = player;
            public void Execute() => _player.MoveRight();
        }

        public class MoveUpCommand : ICommand   //================== Concrete Command ==================
        {
            private Player _player;
            public MoveUpCommand(Player player) => _player = player;
            public void Execute() => _player.MoveUp();
        }

        public class MoveDownCommand : ICommand     //================== Concrete Command ==================
        {
            private Player _player;
            public MoveDownCommand(Player player) => _player = player;
            public void Execute() => _player.MoveDown();
        }

        public static void Run()    //================== Client Code ==================
        {
            Player player = new Player();
            InputHandler input = new InputHandler();

            // Create commands
            ICommand left  = new MoveLeftCommand(player);
            ICommand right = new MoveRightCommand(player);
            ICommand up    = new MoveUpCommand(player);
            ICommand down  = new MoveDownCommand(player);

            // Initial key bindings (keyboard)
            input.Bind(Key.A, left);
            input.Bind(Key.D, right);
            input.Bind(Key.W, up);
            input.Bind(Key.S, down);

            Console.WriteLine("=== Initial Controls ===");
            input.HandleInput(Key.A);
            input.HandleInput(Key.W);

            // Rebinding keys (player changes controls)
            Console.WriteLine("\n=== Rebinding Controls ===");

            input.Unbind(Key.A);
            input.Bind(Key.LeftArrow, left);

            input.Unbind(Key.W);
            input.Bind(Key.UpArrow, up);

            input.HandleInput(Key.LeftArrow);
            input.HandleInput(Key.UpArrow);

            Console.ReadLine();
        }
    }
    
    public class CommandPattern5
    {
        public interface ICommand
        {
            void Execute();
        }
        public class Player
        {
            public void Attack() => Console.WriteLine("Player attacks!");
            public void Defend() => Console.WriteLine("Player defends!");
        }
        public class AttackCommand : ICommand
        {
            private Player _player;
            public AttackCommand(Player player) => _player = player;
            public void Execute()
            {
                _player.Attack();
            }
        }
        public class DefendCommand : ICommand
        {
            private Player _player;
            public DefendCommand(Player player) => _player = player;
            public void Execute()
            {
                _player.Defend();
            }
        }
        public class InputHandler
        {
            private ICommand _attackCommand;
            private ICommand _defendCommand;
            public void SetCommands(ICommand attack, ICommand defend)
            {
                _attackCommand = attack;
                _defendCommand = defend;
            }
            public void PressAttack() => _attackCommand.Execute();
            public void PressDefend() => _defendCommand.Execute();
        }
        
        public static void Run()
        {   var player = new Player();
            var input = new InputHandler();

            input.SetCommands(
                new AttackCommand(player),
                new DefendCommand(player)
            );

            input.PressAttack(); // Output: Player attacks!
            input.PressDefend(); // Output: Player defends!
        }
    }
}