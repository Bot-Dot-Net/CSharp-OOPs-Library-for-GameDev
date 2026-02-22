using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class ObjectPooling1
    {
        public class Bullet
        {
            public bool IsActive { get; private set; }

            public void Shoot()
            {
                IsActive = true;
                Console.WriteLine("Bullet shot!");
            }

            public void Reset()
            {
                IsActive = false;
                Console.WriteLine("Bullet reset.");
            }
        }

        public class BulletPool
        {
            private readonly Stack<Bullet> _pool = new Stack<Bullet>();

            public Bullet GetBullet()
            {
                if (_pool.Count > 0)
                    return _pool.Pop();

                return new Bullet();
            }

            public void ReturnBullet(Bullet bullet)
            {
                bullet.Reset();
                _pool.Push(bullet);
            }
        }
        public static void Run()
        {
            var pool = new BulletPool();

            var bullet1 = pool.GetBullet();
            bullet1.Shoot();

            var bullet2 = pool.GetBullet();
            bullet2.Shoot();

            pool.ReturnBullet(bullet1);
            pool.ReturnBullet(bullet2);

            var bullet3 = pool.GetBullet(); // Reuses bullet1
            bullet3.Shoot();
        }
    }

    public class ObjectPooling2
    {
        public class Enemy
        {
            public bool IsActive { get; private set; }

            public void Spawn()
            {
                IsActive = true;
                Console.WriteLine("Enemy spawned!");
            }

            public void Despawn()
            {
                IsActive = false;
                Console.WriteLine("Enemy despawned.");
            }
        }

        public class EnemyPool
        {
            private readonly Stack<Enemy> _pool = new Stack<Enemy>();

            public Enemy GetEnemy()
            {
                if (_pool.Count > 0)
                    return _pool.Pop();

                return new Enemy();
            }

            public void ReturnEnemy(Enemy enemy)
            {
                enemy.Despawn();
                _pool.Push(enemy);
            }
        }
        public static void Run()
        {
            var pool = new EnemyPool();

            var enemy1 = pool.GetEnemy();
            enemy1.Spawn();

            var enemy2 = pool.GetEnemy();
            enemy2.Spawn();

            pool.ReturnEnemy(enemy1);
            pool.ReturnEnemy(enemy2);

            var enemy3 = pool.GetEnemy(); // Reuses enemy1
            enemy3.Spawn();
        }
    }

    public class ObjectPooling
    {
        public class Bullet
        {
            public bool IsActive { get; private set; }

            public void Activate()
            {
                IsActive = true;
                Console.WriteLine("Bullet fired");
            }

            public void Deactivate()
            {
                IsActive = false;
                Console.WriteLine("Bullet returned to pool");
            }
        }
        public class BulletPool
        {
            private List<Bullet> _pool = new();

            public BulletPool(int size)
            {
                for (int i = 0; i < size; i++)
                    _pool.Add(new Bullet());
            }

            public Bullet GetBullet()
            {
                foreach (var bullet in _pool)
                {
                    if (!bullet.IsActive)
                        return bullet;
                }

                return null; // pool exhausted
            }
        }
        public static void Run()
        {
            BulletPool pool = new BulletPool(10);

            Bullet bullet = pool.GetBullet();
            if (bullet != null)
            {
                bullet.Activate();
            }
            bullet.Deactivate();
        }

    }
}