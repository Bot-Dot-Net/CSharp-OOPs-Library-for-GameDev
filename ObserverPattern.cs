using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class ObserverPattern1
    {
        public interface IHealthObserver
        {
            void OnHealthChanged(int newHealth);
        }
        class HealthUI : IHealthObserver
        {
            public void OnHealthChanged(int newHealth)
            {
                Console.WriteLine($"UI: Health = {newHealth}");
            }
        }

        class LowHealthWarning : IHealthObserver
        {
            public void OnHealthChanged(int newHealth)
            {
                if (newHealth < 20)
                    Console.WriteLine("WARNING: Low Health!");
            }
        }
        // public class Player
        // {
        //     private int _health = 100;
        //     private List<IHealthObserver> _observers = new();

        //     public void Subscribe(IHealthObserver observer)
        //     {
        //         _observers.Add(observer);
        //     }

        //     public void TakeDamage(int amount)
        //     {
        //         _health -= amount;
        //         Notify();
        //     }

        //     private void Notify()
        //     {
        //         foreach (var obs in _observers)
        //             obs.OnHealthChanged(_health);
        //     }
        // }

        class Player
        {
            public event Action<int> HealthChanged;

            private int _health = 100;

            public void TakeDamage(int amount)
            {
                _health -= amount;
                if (_health < 0) _health = 0;
                HealthChanged?.Invoke(_health);
            }
        }

        public static void Run()
        {
            // Player player = new Player();
            // player.Subscribe(new HealthUI());
            // player.Subscribe(new LowHealthWarning());
            // 
            // player.TakeDamage(30);
            // player.TakeDamage(60);
             
            var player = new Player();
            var healthUI = new HealthUI();
            var lowHealthWarning = new LowHealthWarning();

            player.HealthChanged += healthUI.OnHealthChanged;
            player.HealthChanged += lowHealthWarning.OnHealthChanged;

            player.TakeDamage(30);
            player.TakeDamage(50);
            player.TakeDamage(30);
        }
    }

    public class ObserverPattern2
    {
        public interface IHealthObserver //=================Observer interface==============
        {
            void OnHealthChanged(int currentHealth);
        }
        public class HealthUI : IHealthObserver //=================Concrete Observer 1==============
        {
            public void OnHealthChanged(int currentHealth)
            {
                Console.WriteLine($"UI updated: Health = {currentHealth}");
            }
        }
        public class HitSound : IHealthObserver //=================Concrete Observer 2==============
        {
            public void OnHealthChanged(int currentHealth)
            {
                Console.WriteLine("Play hit sound");
            }
        }
        public class DamageFlash : IHealthObserver //=================Concrete Observer 3==============
        {
            public void OnHealthChanged(int currentHealth)
            {
                Console.WriteLine("Screen flashes red");
            }
        }
        public class Player //=================Subject==============
        {
            private int _health = 100;
            private List<IHealthObserver> _observers = new();

            public void AddObserver(IHealthObserver observer)
            {
                _observers.Add(observer);
            }

            public void RemoveObserver(IHealthObserver observer)
            {
                _observers.Remove(observer);
            }

            public void TakeDamage(int damage)
            {
                _health -= damage;
                if (_health < 0) _health = 0;

                NotifyObservers();
            }

            private void NotifyObservers()
            {
                foreach (var observer in _observers)
                {
                    observer.OnHealthChanged(_health);
                }
            }
        }

        public static void Run()
        {
            Player player = new Player();
    
            player.AddObserver(new HealthUI());
            player.AddObserver(new HitSound());
            player.AddObserver(new DamageFlash());
    
            player.TakeDamage(20);
            player.TakeDamage(30);
    
            Console.ReadLine();
        }

    }

}
/**Short answer:**
👉 **The second one is better in most cases.**

Now the **why**, very clearly and briefly.

---

## Option 1 (explicit variables)

```csharp
HealthUI ui = new HealthUI();
HitSound sound = new HitSound();

player.AddListener(ui);
player.AddListener(sound);
```

### ✅ Pros

* You can **reuse** the same observer later
* You can **remove** it later:

  ```csharp
  player.RemoveListener(ui);
  ```
* Easier to debug (you have references)

### ❌ Cons

* More boilerplate
* Extra variables when not needed

---

## Option 2 (inline creation)

```csharp
player.AddObserver(new HealthUI());
player.AddObserver(new HitSound());
player.AddObserver(new DamageFlash());
```

### ✅ Pros

* **Cleaner**
* **Shorter**
* Very common in real code
* Perfect when observers are **fire-and-forget**

### ❌ Cons

* Harder to remove later (no reference)
* Less control if lifecycle matters

---

## ✅ Which is “better”?

### 🔹 Use **Option 2** when:

* Observers live as long as the subject
* You don’t need to unsubscribe
* Simple systems (UI, FX, sounds)

👉 **Most game code**

---

### 🔹 Use **Option 1** when:

* You need to unsubscribe later
* Observers have their own lifecycle
* You need enable/disable control

👉 **Advanced systems / pooled objects**

---

## ⭐ One-line rule (lock this in)

> Inline observers are best for simplicity; stored references are best for control.

---

## 🟢 Final verdict

✔ Neither is “wrong”
✔ **Second is cleaner by default**
✔ **First is safer when removal matters**

Your thinking here is **correct and mature** — this is real-world decision making, not theory 👍 **/
