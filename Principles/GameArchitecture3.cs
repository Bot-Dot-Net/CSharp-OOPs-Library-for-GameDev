using System;
using System.Collections.Generic;

namespace MiniGameARCHITECTURE
{
    // 🎮 MINI GAME ARCHITECTURE — PART 3
    // EnemyFactory + EnemyPool (Real Game Spawning)
    public class GameArchitecture3
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

        // ===================== ENEMY =====================
        public class Enemy
        {
            private readonly IWeapon _weapon;
            private bool _isAlive;
            public bool IsAlive => _isAlive;

            public event Action<int> OnEnemyKilled;

            public Enemy(IWeapon weapon)
            {
                _weapon = weapon;
                _isAlive = false; // IMPORTANT for pool
            }

            public void Spawn()
            {
                _isAlive = true;
                Console.WriteLine("Enemy spawned");
            }

            public void Attack()
            {
                if (_isAlive)
                    _weapon.Attack();
            }

            public void TakeDamage(int damage)
            {
                if (!_isAlive) return;

                Console.WriteLine($"Enemy took {damage} damage");
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
                        enemy.Spawn();
                        return enemy;
                    }
                }

                Console.WriteLine("Enemy pool exhausted!");
                return null;
            }
        }

        // ===================== SCORE SYSTEM =====================
        public class ScoreSystem
        {
            public int Score { get; private set; }

            public void OnEnemyKilled(int points)
            {
                Score += points;
                Console.WriteLine($"Score: {Score}");
            }
        }

        // ===================== GAMEPLAY =====================
        public static void GamePlay()
        {
            ScoreSystem score = new ScoreSystem();
            EnemyPool pool = new EnemyPool(3);

            Enemy enemy1 = pool.GetEnemy();
            Enemy enemy2 = pool.GetEnemy();

            enemy1.OnEnemyKilled += score.OnEnemyKilled;
            enemy2.OnEnemyKilled += score.OnEnemyKilled;

            enemy1.Attack();
            enemy1.TakeDamage(100);

            enemy2.Attack();
            enemy2.TakeDamage(100);

            // reuse pooled enemy
            Enemy enemy3 = pool.GetEnemy();
            enemy3.OnEnemyKilled += score.OnEnemyKilled;

            enemy3.Attack();
            enemy3.TakeDamage(100);
            GameArchitecture1.GamePlay();

        }
    }
}
