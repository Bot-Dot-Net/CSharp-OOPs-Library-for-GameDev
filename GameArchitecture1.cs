using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniGameARCHITECTURE
{
    public class GameArchitecture1
    {
        public interface IWeapon
        {
            void Attack();
        }
        public class Sword : IWeapon
        {
            public void Attack()
            {
                Console.WriteLine("Swinging a sword!");
            }
        }
        public class Bow : IWeapon
        {
            public void Attack()
            {
                Console.WriteLine("Firing a bow!");
            }
        }
        public interface IMovement
        {
            void Move();
        }
        public class WalkMovement : IMovement
        {
            public void Move()
            {
                Console.WriteLine("Walking forward.");
            }
        }
        public class JumpMovement : IMovement
        {
            public void Move()
            {
                Console.WriteLine("Jumping up!");
            }
        }

        public class Health
        {
            public int _health { get; private set; }
            // public int Value => _health;

            public Health(int initialHealth)
            {
                _health = initialHealth;
            }
            public void TakeDamage(int amount)
            {
                _health -= amount;
                if (_health < 0) _health = 0;
            }
            public void Heal(int amount)
            {
                _health += amount;
                if (_health > 100) _health = 100;
            }
        }

        public class Player
        {
            public Health Health { get;}
            private IWeapon _weapon;
            private IMovement _movement;

            public Player(IWeapon weapon, IMovement movement)
            {
                Health = new Health(100);
                _weapon = weapon;
                _movement = movement;
            }

            public void Attack()
            {
                _weapon.Attack();
            }
            public void Move()
            {
                _movement.Move();
            }

            public void ChangeWeapon(IWeapon newWeapon)
            {
                _weapon = newWeapon;
            }
            public void ChangeMovement(IMovement newMovement)
            {
                _movement = newMovement;
            }
        }

        public static void GamePlay()
        {
            Player player = new Player(new Sword(), new WalkMovement());

            player.Move();
            player.Attack();
            player.Health.TakeDamage(30);
            Console.WriteLine("Player Health: " + player.Health._health);

            player.ChangeMovement(new JumpMovement());
            player.Move();
            player.ChangeWeapon(new Bow());
            player.Attack();
            player.Health.TakeDamage(10);
            Console.WriteLine("Player Health: " + player.Health._health);
            player.Health.TakeDamage(10);
            Console.WriteLine("Player Health: " + player.Health._health);
            player.Health.TakeDamage(10);
            Console.WriteLine("Player Health: " + player.Health._health);
            player.Health.TakeDamage(10);
            Console.WriteLine("Player Health: " + player.Health._health);
            player.Health.Heal(50);
            Console.WriteLine("Player Health: " + player.Health._health);
        }
    }
}