using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniGameARCHITECTURE;

namespace MiniGameARCHITECTURE
{
    public class GameArchitecture2
    {
        public interface IEnemyState
        {
            void Enter(Enemy enemy);
            void Update(Enemy enemy);
            void Exit(Enemy enemy);
        }
        public class PetrolState : IEnemyState
        {
            public void Enter(Enemy enemy)
            {
                Console.WriteLine("Petrol Stater Entering!");
            }
            public void Update(Enemy enemy)
            {
                Console.WriteLine("Petrol Stater Updating!");
                enemy.ChangeState(new ChaseState());
            }
            public void Exit(Enemy enemy)
            {
                Console.WriteLine(" Petrol Stater Exiting!");
            }
        }
        public class ChaseState : IEnemyState
        {
            public void Enter(Enemy enemy)
            {
                Console.WriteLine("Chase State Entering!");
            }
            public void Update(Enemy enemy)
            {
                Console.WriteLine("Chase State Updating!");
                enemy.ChangeState(new AttackState());
            }
            public void Exit(Enemy enemy)
            {
                Console.WriteLine("Chase State Exiting!");
            }
        }
        public class AttackState : IEnemyState
        {
            public void Enter(Enemy enemy)
            {
                Console.WriteLine("Attack State Entering!");
            }
            public void Update(Enemy enemy)
            {
                // Console.WriteLine("Attack State Updating!");
                enemy.Attack();
            }
            public void Exit(Enemy enemy)
            {
                Console.WriteLine("Attack State Exiting!");
            }
        }

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

        public class Health
        {
            public int Value { get; private set; }

            public Health(int initialHealth)
            {
                Value = initialHealth;
            }

            public void TakeDamage(int amount)
            {
                Value -= amount;
                if (Value < 0) Value = 0;
            }
        }

        public class Enemy
        {
            public Health Health { get; }
            private IWeapon _weapon;
            private IEnemyState _state;
            private bool _isAlive = true;

            public event Action<int> OnEnemyKilled;

            public Enemy(IWeapon weapon)
            {
                Health = new Health(100);
                _weapon = weapon;
                ChangeState(new PetrolState());
            }

            public void ChangeState(IEnemyState newState)
            {
                _state?.Exit(this);
                _state = newState;
                _state.Enter(this);
            }

            public void Update()
            {
                if (_isAlive)
                    _state.Update(this);
            }

            public void Attack()
            {
                if (_isAlive)
                    _weapon.Attack();
            }

            public void TakeDamage(int amount)
            {
                if (!_isAlive) return;

                Health.TakeDamage(amount);

                if (Health.Value <= 0)
                    Die();
            }

            private void Die()
            {
                _isAlive = false;
                Console.WriteLine("Enemy died");
                OnEnemyKilled?.Invoke(10);
            }
        }

        public class ScoreSystem
        {
            public int Score { get; private set; }

            public void OnEnemyKilled(int points)
            {
                Score += points;
                Console.WriteLine($"Score: {Score}");
            }
        }

        public static void GamePlay()
        {
            Enemy enemy = new Enemy(new Sword());
            ScoreSystem score = new ScoreSystem();

            enemy.OnEnemyKilled += score.OnEnemyKilled;

            enemy.Update();
            enemy.TakeDamage(50);
            enemy.Update();
            enemy.TakeDamage(40);
            enemy.Update();
            enemy.TakeDamage(30);
            enemy.Update();
            enemy.TakeDamage(20);
            enemy.Update();
        }
    }
}