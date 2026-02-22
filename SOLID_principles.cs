using System;

namespace SOLIDprinciples
{
    // ================= SRP =================
    public static class SRP
    {
        public interface IMovementS
        {
            void Move();
        }
        public interface IAttackS
        {
            void Attack();
        }
        public class PlayerMovementS : IMovementS
        {
            public void Move()
            {
                Console.WriteLine("Player is moving");
            }
        }
        public class PlayerAttackS : IAttackS
        {
            public void Attack()
            {
                Console.WriteLine("Player is attacking");
            }
        }
        public class PlayerS
        {
            private readonly IMovementS _movement;
            private readonly IAttackS _attack;

            public PlayerS(IMovementS movement, IAttackS attack)
            {
                _movement = movement;
                _attack = attack;
            }

            public void Move() => _movement.Move();
            public void Attack() => _attack.Attack();
        }

        // ⭐ ENTRY POINT FOR SRP DEMO
        // public static void Run()
        // {
        //     IMovementS movement = new PlayerMovementS();
        //     IAttackS attack = new PlayerAttackS();

        //     PlayerS player = new PlayerS(movement, attack);
        //     playerS.Move();
        //     playerS.Attack();

        //     Console.ReadLine();
        // }
    }

    // ================= OCP =================
    public static class OCP
    {
        public interface IAttackO
        {
            void Attack();
        }
        public class MeleeAttackO : IAttackO
        {
            public void Attack()
            {
                Console.WriteLine("Enemy attacks with sword");
            }
        }
        public class MagicAttackO : IAttackO
        {
            public void Attack()
            {
                Console.WriteLine("Enemy casts spell");
            }
        }
        public class RangedAttackO : IAttackO
        {
            public void Attack()
            {
                Console.WriteLine("Enemy shoots arrow");
            }
        }
        public class EnemyO
        {
            private IAttackO _attack;

            public EnemyO(IAttackO attack)
            {
                _attack = attack;
            }

            public void PerformAttack()
            {
                _attack.Attack();
            }
        }
        // ⭐ ENTRY POINT FOR OCP DEMO
        public static void Run()
        {
            EnemyO enemy1 = new EnemyO(new MeleeAttackO());
            EnemyO enemy2 = new EnemyO(new MagicAttackO());
            EnemyO enemy3 = new EnemyO(new RangedAttackO());

            enemy1.PerformAttack();
            enemy2.PerformAttack();
            enemy3.PerformAttack();

            Console.WriteLine();
        }

    }

    // ================= LSP =================
    public static class LSP
    {
        public abstract class EnemyL
        {
            public int Health { get; protected set; } = 100;
        
            public virtual void TakeDamage(int amount)
            {
                Health -= amount;
            }
        }
        public interface IAttackableL
        {
            void Attack();
        }
        public class SoldierEnemyL : EnemyL, IAttackableL //Attacking enemy
        {
            public void Attack()
            {
                Console.WriteLine("Soldier attacks!");
            }
        }
        public class GhostEnemyL : EnemyL //Non-attacking enemy
        {
            // Ghost does not attack — still valid Enemy
        }

        // ⭐ ENTRY POINT FOR LSP DEMO
        public static void Run()
        {
            EnemyL e1 = new SoldierEnemyL();
            EnemyL e2 = new GhostEnemyL();

            e1.TakeDamage(10);
            e2.TakeDamage(10);

            if (e1 is IAttackableL a)
            {
                a.Attack();
            }

        }
    }

    // ================= ISP =================
    public static class ISP
    {
        public interface IMovableI
        {
            void Move();
        }       
        public interface IAttackableI
        {
            void Attack();
        }
        public interface IHealableI
        {
            void Heal();
        }
        public class WarriorI : IMovableI, IAttackableI
        {
            public void Move()
            {
                Console.WriteLine("Warrior moves");
            }

            public void Attack()
            {
                Console.WriteLine("Warrior attacks");
            }
        }
        public class HealerI : IMovableI, IHealableI
        {
            public void Move()
            {
                Console.WriteLine("Healer moves");
            }

            public void Heal()
            {
                Console.WriteLine("Healer heals");
            }
        }

        // ⭐ ENTRY POINT FOR ISP DEMO
        public static void Run()
        {
            IMovableI m1 = new WarriorI();
            IMovableI m2 = new HealerI();

            m1.Move();
            m2.Move();

            IAttackableI attacker = new WarriorI();
            attacker.Attack();

            IHealableI healer = new HealerI();
            healer.Heal();

        }
    }

    // ================= DIP =================
    public static class DIP
    {
        public interface IWeaponD
        {
            void Use();
        }
            public class SwordD : IWeaponD
        {
            public void Use()
            {
                Console.WriteLine("Swinging sword");
            }
        }
        public class GunD : IWeaponD
        {
            public void Use()
            {
                Console.WriteLine("Firing gun");
            }
        }
        public class PlayerD
        {
            private IWeaponD _weapon;

            public PlayerD(IWeaponD weapon)
            {
                _weapon = weapon;
            }

            public void Attack()
            {
                _weapon.Use();
            }
        }

    
    }

    // ================= COMPLETE SOLID EXAMPLE =================
    public static class COMPLETE_SOLID
    {
    //🎮 One COMPLETE Game System using ALL 5 SOLID principles
    //🧱 GAME SYSTEM: Enemy with AI, Movement, Attack & Health
    //1️⃣ SRP — Single Responsibility Principle
    //Each class has ONE job.
    // Interfaces (capabilities)
    public interface IMovement
    {
        void Move();
    }

    public interface IAttack
    {
        void Attack();
    }

    public interface IHealable
    {
        void Heal(int amount);
    }

    public interface IAIBehavior
    {
        void Update();
    }
    //2️⃣ OCP — Open / Closed Principle
    //We can add new behavior without modifying Enemy.
    public class WalkMovement : IMovement
    {
        public void Move() => Console.WriteLine("Enemy walks");
    }

    public class FlyMovement : IMovement
    {
        public void Move() => Console.WriteLine("Enemy flies");
    }

    public class MeleeAttack : IAttack
    {
        public void Attack() => Console.WriteLine("Enemy attacks with melee");
    }

    public class FireAttack : IAttack
    {
        public void Attack() => Console.WriteLine("Enemy attacks with fire");
    }

    //3️⃣ LSP — Liskov Substitution Principle
    //Base class guarantees only universal behavior.
    public abstract class Character
    {
        public int Health { get; protected set; } = 100;

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }
    }

    /* 4️⃣ ISP — Interface Segregation Principle
        No giant interfaces.
        Enemy implements only what it needs. */

    //5️⃣ DIP — Dependency Inversion Principle
    //Enemy depends on abstractions, not implementations.🧠 FINAL ENEMY CLASS (ALL SOLID APPLIED)
    public class Enemy : Character
    {
        private IMovement _movement;
        private IAttack _attack;
        private IAIBehavior _ai;

        public Enemy(IMovement movement, IAttack attack, IAIBehavior ai)
        {
            _movement = movement;
            _attack = attack;
            _ai = ai;
        }

        public void Update()
        {
            _ai.Update();
            _movement.Move();
            _attack.Attack();
        }

        public void SetAttack(IAttack attack)
        {
            _attack = attack;
        }

        public void SetMovement(IMovement movement)
        {
            _movement = movement;
        }
    }
    // 🧠 AI Behaviors
    public class AggressiveAI : IAIBehavior
    {
        public void Update()
        {
            Console.WriteLine("AI: Aggressive mode");
        }
    }

    public class PassiveAI : IAIBehavior
    {
        public void Update()
        {
            Console.WriteLine("AI: Passive mode");
        }
    
    }
    // ⭐ ENTRY POINT FOR COMPLETE SOLID DEMO
    public static void Run()
    {
            Enemy enemy = new Enemy(
            new WalkMovement(),
            new MeleeAttack(),
            new PassiveAI()
        );

        enemy.Update();

        Console.WriteLine("\n-- Enemy enraged! --\n");

        enemy.SetAttack(new FireAttack());
        enemy.SetMovement(new FlyMovement());

        enemy.Update();

        Console.ReadLine();
    }
    }


    
}

