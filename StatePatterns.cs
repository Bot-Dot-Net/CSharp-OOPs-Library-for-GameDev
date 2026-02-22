using System;
namespace DesignPatterns
{
    public class StatePattern1
    {
        public interface IPlayerState
        {
            void Enter();
            void Update();
            void Exit();
        }

        public class IdleState : IPlayerState
        {
            public void Enter()
            {
                Console.WriteLine("Player enters Idle state");
            }

            public void Update()
            {
                Console.WriteLine("Player is idling...");
            }

            public void Exit()
            {
                Console.WriteLine("Player exits Idle state");
            }
        }

        public class AttackState : IPlayerState
        {
            public void Enter()
            {
                Console.WriteLine("Player enters Attack state");
            }

            public void Update()
            {
                Console.WriteLine("Player is attacking!");
            }

            public void Exit()
            {
                Console.WriteLine("Player exits Attack state");
            }
        }

        public class DeadState : IPlayerState
        {
            public void Enter()
            {
                Console.WriteLine("Player is DEAD");
            }

            public void Update()
            {
                Console.WriteLine("Player cannot act");
            }

            public void Exit()
            {
                // Usually nothing
            }
        }

        public class Player
        {
            private IPlayerState _currentState;

            public void SetState(IPlayerState newState)
            {
                _currentState?.Exit();
                _currentState = newState;
                _currentState.Enter();
            }

            public void Update()
            {
                _currentState?.Update();
            }
        }

        public static void Run()
        {
            Player player = new Player();
    
            player.SetState(new IdleState());
            player.Update();
    
            Console.WriteLine();
    
            player.SetState(new AttackState());
            player.Update();
    
            Console.WriteLine();
    
            player.SetState(new DeadState());
            player.Update();
    
            Console.ReadLine();

            // OUTPUT:
            // Player enters Idle state
            // Player is idling...
            // 
            // Player exits Idle state
            // Player enters Attack state
            // Player is attacking!
            // 
            // Player exits Attack state
            // Player is DEAD
            // Player cannot act
            // 
        }
    }
    public class StatePattern2
    {
        public interface IPlayerState
        {
            void Enter();
            void Update();
            void HandleInput(Player player);
        }
        public class GroundedState : IPlayerState
        {
            public void Enter()
            {
                Console.WriteLine("Player grounded");
            }

            public void HandleInput(Player player)
            {
                if (player.JumpPressed)
                {
                    player.SetState(new JumpState());
                }
            }

            public void Update()
            {
                Console.WriteLine("Standing on ground");
            }
        }
        public class JumpState : IPlayerState
        {
            public void Enter()
            {
                Console.WriteLine("Player jumps");
            }

            public void HandleInput(Player player)
            {
                // no jumping again
            }

            public void Update()
            {
                Console.WriteLine("Player in air");
            }
        }
        public class DeadState : IPlayerState
        {
            public void Enter()
            {
                Console.WriteLine("Player died");
            }

            public void HandleInput(Player player)
            {
                // No input allowed
            }

            public void Update()
            {
                Console.WriteLine("Dead...");
            }
        }
        public class Player
        {
            private IPlayerState _state;

            public bool JumpPressed { get; set; }

            public void SetState(IPlayerState state)
            {
                _state = state;
                _state.Enter();
            }

            public void Update()
            {
                _state.HandleInput(this);
                _state.Update();
            }
        }

        public static void Run()
        {
            Player player = new Player();

            // Initial state
            player.SetState(new GroundedState());

            // --- Frame 1 ---
            player.JumpPressed = false;
            player.Update();

            Console.WriteLine();

            // --- Frame 2 (player presses jump) ---
            player.JumpPressed = true;
            player.Update();

            Console.WriteLine();

            // --- Frame 3 ---
            player.JumpPressed = false;
            player.Update();

            Console.WriteLine();

            // Player dies
            player.SetState(new DeadState());
            player.Update();

            Console.ReadLine();
        }

    }
    public class StatePattern3
    {
        // =========================
        // 1. STATE INTERFACE
        // =========================
        public interface IVendingMachineState
        {
            void InsertCoin();
            void SelectProduct();
            void Dispense();
        }

        // =========================
        // 2. CONTEXT (VENDING MACHINE)
        // =========================
        public class VendingMachine
        {
            // State instances (created once)
            public IVendingMachineState NoCoinState { get; }
            public IVendingMachineState HasCoinState { get; }
            public IVendingMachineState DispenseState { get; }
            public IVendingMachineState SoldOutState { get; }

            public IVendingMachineState CurrentState { get; private set; }
            public int ProductCount { get; private set; }

            public VendingMachine(int productCount)
            {
                ProductCount = productCount;

                NoCoinState = new NoCoinState(this);
                HasCoinState = new HasCoinState(this);
                DispenseState = new DispenseState(this);
                SoldOutState = new SoldOutState(this);

                CurrentState = productCount > 0 ? NoCoinState : SoldOutState;
            }

            public void SetState(IVendingMachineState state)
            {
                CurrentState = state;
            }

            public void ReleaseProduct()
            {
                if (ProductCount > 0)
                {
                    ProductCount--;
                    Console.WriteLine("Product dispensed.");
                }
            }

            // User actions
            public void InsertCoin() => CurrentState.InsertCoin();
            public void SelectProduct() => CurrentState.SelectProduct();
            public void Dispense() => CurrentState.Dispense();
        }

        // =========================
        // 3. STATES
        // =========================

        // ---- NO COIN ----
        public class NoCoinState : IVendingMachineState
        {
            private VendingMachine machine;

            public NoCoinState(VendingMachine machine)
            {
                this.machine = machine;
            }

            public void InsertCoin()
            {
                Console.WriteLine("Coin inserted.");
                machine.SetState(machine.HasCoinState);
            }

            public void SelectProduct()
            {
                Console.WriteLine("Insert coin first.");
            }

            public void Dispense()
            {
                Console.WriteLine("No coin inserted.");
            }
        }

        // ---- HAS COIN ----
        public class HasCoinState : IVendingMachineState
        {
            private VendingMachine machine;

            public HasCoinState(VendingMachine machine)
            {
                this.machine = machine;
            }

            public void InsertCoin()
            {
                Console.WriteLine("Coin already inserted.");
            }

            public void SelectProduct()
            {
                Console.WriteLine("Product selected.");
                machine.SetState(machine.DispenseState);
            }

            public void Dispense()
            {
                Console.WriteLine("Select product first.");
            }
        }

        // ---- DISPENSE ----
        public class DispenseState : IVendingMachineState
        {
            private VendingMachine machine;

            public DispenseState(VendingMachine machine)
            {
                this.machine = machine;
            }

            public void InsertCoin()
            {
                Console.WriteLine("Please wait, dispensing.");
            }

            public void SelectProduct()
            {
                Console.WriteLine("Already selected.");
            }

            public void Dispense()
            {
                machine.ReleaseProduct();

                if (machine.ProductCount > 0)
                {
                    machine.SetState(machine.NoCoinState);
                }
                else
                {
                    Console.WriteLine("Machine is sold out.");
                    machine.SetState(machine.SoldOutState);
                }
            }
        }

        // ---- SOLD OUT ----
        public class SoldOutState : IVendingMachineState
        {
            private VendingMachine machine;

            public SoldOutState(VendingMachine machine)
            {
                this.machine = machine;
            }

            public void InsertCoin()
            {
                Console.WriteLine("Machine is sold out.");
            }

            public void SelectProduct()
            {
                Console.WriteLine("Machine is sold out.");
            }

            public void Dispense()
            {
                Console.WriteLine("Machine is sold out.");
            }
        }

        // =========================
        // 4. RUN DEMO
        // =========================
        public static void Run()
        {
            VendingMachine machine = new VendingMachine(2);

            machine.InsertCoin();
            Console.ReadLine();

            machine.SelectProduct();
            Console.ReadLine();

            machine.Dispense();

            Console.WriteLine();

            machine.InsertCoin();
            Console.ReadLine();

            machine.SelectProduct();
            Console.ReadLine();

            machine.Dispense();

            Console.WriteLine();

            machine.InsertCoin(); // sold out now
            Console.ReadLine();
        }
    }
}   
