using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class StratagyPattern1
    {
        public interface IstratagyAttack
        {
            void Attack();
        }
        public class SwordAttack : IstratagyAttack
        {
            public void Attack()
            {
                Console.WriteLine("Player attacks with a sword!");
            }
        }
        public class BowAttack : IstratagyAttack
        {
            public void Attack()
            {
                Console.WriteLine("Player attacks with a bow!");
            }
        }
        public class Player
        {
            private IstratagyAttack _stratagy;
            public Player (IstratagyAttack stratagy)
            {
                _stratagy = stratagy;
            }
            public void SetAttackStratagy(IstratagyAttack stratagy)
            {
                _stratagy = stratagy;
            }
            public void PerformAttack()
            {
                _stratagy.Attack();
            }
        }
        public static void Run()
        {
            Player player = new Player(new SwordAttack());
            player.PerformAttack();
            Console.WriteLine();
            Console.WriteLine("Player switches to bow attack.");
            player.SetAttackStratagy(new BowAttack());
            player.PerformAttack();
            Console.WriteLine();
            Console.WriteLine("Player switches to Sword attack.");
            player.SetAttackStratagy(new SwordAttack());
            player.PerformAttack();
            Console.ReadLine();
        
        }
    }

    public class StratagyPattern2
    {
        public interface IstratagyMovement
        {
            void Move();
        }
        public class Walk : IstratagyMovement
        {
            public void Move()
            {
                Console.WriteLine("Player walks!");
            }
        }
        public class Run : IstratagyMovement
        {
            public void Move()
            {
                Console.WriteLine("Player runs!");
            }
        }

        public class Player
        {
            private IstratagyMovement _stratagy;
            public Player (IstratagyMovement stratagy)
            {
                _stratagy = stratagy;
            }
            public void SetMovementStratagy(IstratagyMovement stratagy)
            {
                _stratagy = stratagy;
            }
            public void PerformMove()
            {
                _stratagy.Move();
            }
        }
        public static void Runn()
        {
            Player player = new Player(new Walk());
            player.PerformMove();
            Console.WriteLine();
            Console.WriteLine("Player switches to run.");
            player.SetMovementStratagy(new Run());
            player.PerformMove();
            Console.WriteLine();
            Console.WriteLine("Player switches to walk.");
            player.SetMovementStratagy(new Walk());
            player.PerformMove();
            Console.ReadLine();
        }
    }

    public class StratagyPattern3
    {
        public interface IDamageStrategy
        {
            int Calculate(int baseDamage);
        }
        public class NormalDamage : IDamageStrategy
        {
            public int Calculate(int baseDamage)
            {
                return baseDamage;
            }
        }
        public class CriticalDamage : IDamageStrategy
        {
            public int Calculate(int baseDamage)
            {
                return baseDamage * 2;
            }
        }
        public class BossDamage : IDamageStrategy
        {
            public int Calculate(int baseDamage)
            {
                return baseDamage / 2;
            }
        }

        public class Weapon
        {
            private IDamageStrategy _damageStrategy;

            public Weapon(IDamageStrategy strategy)
            {
                _damageStrategy = strategy;
            }

            public void SetDamageStrategy(IDamageStrategy strategy)
            {
                _damageStrategy = strategy;
            }

            public int DealDamage(int baseDamage)
            {
                return _damageStrategy.Calculate(baseDamage);
            }
        }
        public static void Run()
        {
            // Create a weapon with normal damage strategy
            Weapon sword = new Weapon(new NormalDamage());

            Console.WriteLine(sword.DealDamage(10)); // 10
            // Player gets crit buff
            sword.SetDamageStrategy(new CriticalDamage());
            Console.WriteLine(sword.DealDamage(10)); // 20            
            // Enemy becomes boss
            sword.SetDamageStrategy(new BossDamage());
            Console.WriteLine(sword.DealDamage(10)); // 5

            // Alternatively, we can create a new weapon with a different strategy
            Weapon weapon = new Weapon(new NormalDamage());
            int baseDamage = 10;
            Console.WriteLine($"Base Damage: {baseDamage}");
            Console.WriteLine($"Normal Damage: {weapon.DealDamage(baseDamage)}");
            Console.WriteLine();
            Console.WriteLine("Weapon switches to critical damage.");
            weapon.SetDamageStrategy(new CriticalDamage());
            Console.WriteLine($"Critical Damage: {weapon.DealDamage(baseDamage)}");
            Console.WriteLine();
            Console.WriteLine("Weapon switches to boss damage.");
            weapon.SetDamageStrategy(new BossDamage());
            Console.WriteLine($"Boss Damage: {weapon.DealDamage(baseDamage)}");
            Console.ReadLine();
        }
    }

    public class StratagyPattern4
    {
        public interface IWalkability  //==============WALKABLE ROBOT====================
        {
            void Walk();
        }
        public class WalkableRobot : IWalkability
        {
            public void Walk()
            {
                Console.WriteLine("Robot is walking");
            }
        }
        public class NonWalkableRobot : IWalkability
        {
            public void Walk()
            {
                Console.WriteLine("This robot cannot walk");
            }
        }

        public interface ITalkability  //=================TALKABLE ROBOT=================
        {
            void Talk();
        }
        public class TalkableRobot : ITalkability
        {
            public void Talk()
            {
                Console.WriteLine("Robot is talking");
            }
        }
        public class NonTalkableRobot : ITalkability
        {
            public void Talk()
            {
                Console.WriteLine("This robot cannot talk");
            }
        }
        public interface IFlyability  //=================FLYABLE ROBOT=================
        {
            void Fly();
        }
        public class FlyableRobot : IFlyability
        {
            public void Fly()
            {
                Console.WriteLine("Robot is flying");
            }
        }
        public class NonFlyableRobot : IFlyability
        {
            public void Fly()
            {
                Console.WriteLine("This robot cannot fly");
            }
        }

        public class Robot  //=================ROBOT BASE CLASS=================
        {
            private IWalkability _walkability;
            private ITalkability _talkability;
            private IFlyability _flyability;
            public virtual void Display()
            {
                Console.WriteLine("I am a robot");
            }

            public Robot(IWalkability walkability, ITalkability talkability, IFlyability flyability)
            {
                _walkability = walkability;
                _talkability = talkability;
                _flyability = flyability;
            }

            public void SetWalkable(IWalkability walkability)
            {
                _walkability = walkability;
            }

            public void SetTalkable(ITalkability talkability)
            {
                _talkability = talkability;
            }

            public void SetFlyable(IFlyability flyability)
            {
                _flyability = flyability;
            }

            public void Walk()
            {
                _walkability.Walk();
            }

            public void Talk()
            {
                _talkability.Talk();
            }

            public void Fly()
            {
                _flyability.Fly();
            }
        }
        public class RoomRobot : Robot
        {
            public RoomRobot(IWalkability walkability, ITalkability talkability, IFlyability flyability) : base(walkability, talkability, flyability)
            {
            }
            public override void Display()
            {
                Console.WriteLine("I am a room robot");
            }
        }
        public class DroneRobot : Robot
        {
            public DroneRobot(IWalkability walkability, ITalkability talkability, IFlyability flyability) : base(walkability, talkability, flyability)
            {
            }
            public override void Display()
            {
                Console.WriteLine("I am a drone robot");
            }
        }
        public static void Run()
        {
            Robot roomRobot = new RoomRobot(new WalkableRobot(), new TalkableRobot(), new NonFlyableRobot());
            roomRobot.Display();
            roomRobot.Walk();
            roomRobot.Talk();
            roomRobot.Fly();
            Console.WriteLine();
            roomRobot.SetWalkable(new NonWalkableRobot());
            roomRobot.Walk();
            Console.WriteLine();
            Robot droneRobot = new DroneRobot(new NonWalkableRobot(), new NonTalkableRobot(), new FlyableRobot());
            droneRobot.Display();
            droneRobot.Walk();
            droneRobot.Talk();
            droneRobot.Fly();
            Console.WriteLine();
            droneRobot.SetTalkable(new TalkableRobot());
            droneRobot.Talk();
            Console.ReadLine();
        }
    }
}