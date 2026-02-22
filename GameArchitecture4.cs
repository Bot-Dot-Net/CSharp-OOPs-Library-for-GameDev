using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniGameARCHITECTURE
{
    public class GameArchitecture4
    {
        // ===================== WEAPON =====================
        public interface IWeapon
        {
            void Attack();
        }
        public class Sword : IWeapon
        {
            public void Attack()
            {
                Console.WriteLine("Enemy swings sword!");
            }
        }
        public class Bow : IWeapon
        {
            public void Attack()
            {
                Console.WriteLine("Enemy fires arrow!");
            }
        }
        // ===================== ENEMY COMBAT =====================
        public class EnemyCombate
        {
            private IWeapon weapon;
            public EnemyCombate(IWeapon weapon)
            {
                this.weapon = weapon;
            }
            public void Attack()
            {
                weapon.Attack();
            }
            public void ChangeWeapon(IWeapon newWeapon)
            {
                weapon = newWeapon;
            }
        }
        // ===================== ENEMY HEALTH =====================
        public class Health
        {
            private int value;
            
            public Health(int initialValue)
            {
                value = initialValue;
            }
            public void TakeDamage(int amount)
            {
                value -= amount;
                if (value < 0) value = 0;
            }
            public int GetHealth() => value;
            public void Reset(int value)
            {
                this.value = value;
            }
            
        }
        // ===================== ENEMY STATE =====================
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
                Console.WriteLine("Enemy starts patrolling.");
            }
            public void Update(Enemy enemy)
            {
                Console.WriteLine("Enemy patrolling.");
                enemy.ChangeState(new AttackState());
            }
            public void Exit(Enemy enemy)
            {
                Console.WriteLine("Enemy stops patrolling.");
            }
        }
        public class AttackState : IEnemyState
        {
            public void Enter(Enemy enemy)
            {
                Console.WriteLine("Enemy starts attacking.");
            }
            public void Update(Enemy enemy)
            {
                Console.WriteLine("Enemy attacking.");
                enemy.Combat.Attack();
            }
            public void Exit(Enemy enemy)
            {
                Console.WriteLine("Enemy stops attacking.");
            }
        }
        // ===================== ENEMY =====================
        public class Enemy
        {
            public Health Health { get; }
            public EnemyCombate Combat { get; }
            private IEnemyState _state;
            public event Action<int> OnEnemyKilled;

            private bool _isAlive = true;
            public bool IsAlive => _isAlive;
            public void Reset()
            {
                _isAlive = true;
                Health.Reset(100);
                ChangeState(new PetrolState());
            }

            public Enemy(IWeapon weapon)
            {
                Health = new Health(100);
                Combat = new EnemyCombate(weapon);
                // ChangeState(new PetrolState());
                _isAlive = false; // IMPORTANT for pool
            }

            public void Spawn()
            {
                _isAlive = true;
                Console.WriteLine("Enemy spawned");
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

            public void TakeDamage(int amount)
            {
                if (!_isAlive) return;

                Health.TakeDamage(amount);
                if (Health.GetHealth() <= 0)
                    Die();
            }

            private void Die()
            {
                _isAlive = false;
                Console.WriteLine("Enemy died");
                OnEnemyKilled?.Invoke(10);
            }
        }
        // ===================== FACTORY =====================
        public static class EnemyFactory
        {
            public static Enemy CreateMeleeEnemy()
            {
                return new Enemy(new Sword());
            }
            public static Enemy CreateRangedEnemy()
            {
                return new Enemy(new Bow());
            }
        }
        // ===================== OBJECT POOL =====================
        public class EnemyPool
        {
            private readonly List<Enemy> _pool = new();

            public EnemyPool(int size)
            {
                for (int i = 0; i < size; i++)
                {
                    _pool.Add(EnemyFactory.CreateMeleeEnemy());
                }
            }
            public Enemy GetEnemy()
            {
                foreach (var enemy in _pool)
                {
                    if (!enemy.IsAlive)
                    {
                        enemy.Reset();
                        return enemy;
                    }
                }
                return null;
            }
        }
        // ===================== SCORE SYSTEM =====================
        public class ScoreSystem
        {
            private int score = 0;
            public void AddScore(int points)
            {
                score += points;
                Console.WriteLine($"Score: {score}");
            }
        }
        // ===================== GAMEANAGER =====================
        public class GameManager
        {
            private readonly EnemyPool _enemyPool;
            private readonly ScoreSystem _score;

            public GameManager()
            {
                _enemyPool = new EnemyPool(5);
                _score = new ScoreSystem();

            }

            public void SpawnWave(int count)
            {
                Console.WriteLine($"Spawning wave of {count} enemies");

                for (int i = 0; i < count; i++)
                {
                    Enemy enemy = _enemyPool.GetEnemy();
                    if (enemy == null) return;

                    enemy.OnEnemyKilled += _score.AddScore;
                }
            }
        }

        // ===================== GAMEPLAY =====================
        public static void GamePlay()
        {            
            var pool = new GameArchitecture4.EnemyPool(2);
            var score = new GameArchitecture4.ScoreSystem();

            var enemy = pool.GetEnemy();
            enemy.OnEnemyKilled += score.AddScore;

            // enemy AI tick
            enemy.Update();          // Patrol → Attack
            enemy.Update();          // Attack uses weapon

            enemy.TakeDamage(100);  // Enemy dies → score +10

            enemy.Combat.ChangeWeapon(new GameArchitecture4.Bow()); // change weapon
            enemy.Update(); // now attacks with bow
            // reuse from pool
            var enemy2 = pool.GetEnemy();
            enemy2.OnEnemyKilled += score.AddScore;
            enemy2.Update();
            enemy2.TakeDamage(100);

            var enemy3 = pool.GetEnemy();
            if (enemy3 != null)
            {
                enemy3.OnEnemyKilled += score.AddScore;
                enemy3.Update();
                enemy3.TakeDamage(100);
            }

            // ScoreSystem score = new ScoreSystem(); // Create score system
            // EnemyPool pool = new EnemyPool(3); // Create a pool of 3 enemies

            // Enemy enemy1 = pool.GetEnemy(); // gets a new enemy from the pool
            // Enemy enemy2 = pool.GetEnemy(); // gets a new enemy from the pool

            // enemy1.OnEnemyKilled += score.AddScore; // Subscribe to score updates
            // enemy2.OnEnemyKilled += score.AddScore; // Subscribe to score updates

            // enemy1.Combat.Attack(); // Enemy swings sword!
            // enemy1.TakeDamage(100); // Enemy dies, Score: 10

            // enemy2.Combat.Attack(); // Enemy swings sword!
            // enemy2.TakeDamage(100); // Enemy dies, Score: 20
            // // reuse pooled enemy
            // Enemy enemy3 = pool.GetEnemy(); // gets a new enemy from the pool (reused)
            // enemy3.OnEnemyKilled += score.AddScore; // Subscribe to score updates
            // enemy3.Combat.Attack(); // Enemy swings sword!
            // enemy3.TakeDamage(100); // Enemy dies, Score: 30
        }

    }
}