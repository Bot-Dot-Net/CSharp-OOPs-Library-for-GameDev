using SOLIDprinciples;
using DesignPatterns;
using MiniGameARCHITECTURE;
public class Program
{

    public static void Main(string[] args)
    {   
        #region Questions
         
        // // Question 1
        // Car carObj = new Car();
        // carObj.color = "red";
        // carObj.speed = 100;
        // carObj.Drive();
        // Car carObj2 = new Car();
        // carObj2.color = "blue";
        // carObj2.speed = 200;
        // carObj2.Drive();
        // Person personObj = new Person();
        // personObj.name = "raaj";
        // personObj.age = 23;
        // personObj.Intro();
        // // Question 2
        // GameCharacter char1 = new GameCharacter();
        // char1.GameState = "active";
        // char1.AnimationType = "idle";
        // char1.Health = 100;
        // char1.IsAlive = true;
        // char1.CharacterName = "Warrior-1";
        // char1.CharacterSkill = 1;
        // char1.SkillLevel = 5;
        // char1.network = "online";
        // char1.PlayerStates();

        // GameCharacter char2 = new GameCharacter();
        // char2.GameState = "closed";
        // char2.AnimationType = "idle";
        // char2.Health = 0;
        // char2.IsAlive = false;
        // char2.CharacterName = "Mage-1";
        // char2.CharacterSkill = 2;
        // char2.SkillLevel = 10;
        // char2.network = "offline";
        // char2.PlayerStates();
        // // Question 3
        // Book book1 = new Book();
        // book1.Title = "Atomic Habits";
        // book1.Author = "James Clear";
        // Book book2 = book1;
        // book2.Author = "Robert Kiyosaki";
        // book2.Title = "Rich Dad Poor Dad";    
        // Console.WriteLine(book1.Author);
        // Console.WriteLine(book1.Title);
        // Console.WriteLine(book2.Author);
        // Console.WriteLine(book2.Title);
        // // Encapsulation Example
        // Animal animal = new Animal();
        // animal.Species = "Dog";
        // animal.SetAge(5);
        // animal.Color = "Brown";
        // animal.Sex = "Male";
        // animal.Speak();
        // Console.WriteLine("Animal Age: " + animal.GetAge());
        // Console.WriteLine("Animal Color: " + animal.Color);
        // Console.WriteLine("Animal Sex: " + animal.Sex);
        // BankAccount account = new BankAccount();
        // account.Deposit(500);
        // Console.WriteLine("Account Balance: " + account.Balance);
        // // Question 5
        // Student student = new Student();
        // student.Name = "Alice";
        // student.RollNumber = 101;
        // Console.WriteLine("Student Roll Number: " + student.RollNumber);
        // Console.WriteLine("Student Name: " + student.Name);
        // student.AddMarks(85);
        // Console.WriteLine("Student Marks: " + student.markes);
        // student.AddMarks(95);
        // Console.WriteLine("Student Marks: " + student.markes);
        // student.AddMarks(-5);
        // Console.WriteLine("Student Marks: " + student.markes);
        // student.AddMarks(12);
        // Console.WriteLine("Student Marks: " + student.markes);
        // student.AddMarks(75);
        // Console.WriteLine("Student Marks: " + student.markes);
        // // Question 6
        // Employee emp = new Employee("John Doe", 123, 50000);
        // Console.WriteLine("Employee Name: " + emp.name);
        // Console.WriteLine("Employee ID: " + emp.Id);
        // Console.WriteLine("Employee Salary: " + emp.Salary);
        // // Question 7
        // Resume resume = new Resume("raaj", 23)
        // {
        //   Email = "gally@gmail.com"  
        // };
        // resume.SetContactInfo("gally no. 420, india", "+919234567890", "gally@gmail.com");
        // resume.SetResumeDetails("B.Tech in Computer Science", 
        // @"5 years in software development,
        // 3 years in project management
        // 2 years in marketing,
        // 1 year in sales,
        // 1 year in customer service
        // ",
        // "C#, .NET, SQL, Problem Solving");
        // resume.DisplayInfo();
        // // Question 8
        // Account acc1 = new Account(1001);
        // Account acc2 = new Account(1002);
        // Console.WriteLine("Total Accounts: " + Account.GetTotalAccounts());
        // Console.ReadLine();
        // // Question 9
        // Counter counter1 = new Counter();
        // Counter counter2 = new Counter();
        // Counter counter3 = new Counter();
        // Console.WriteLine("Instance Count counter1: " + counter1.InstanceCount);
        // Console.WriteLine("Instance Count counter2: " + counter2.InstanceCount);
        // Console.WriteLine("Instance Count counter3: " + counter3.InstanceCount);
        // Console.WriteLine("Static Count: " + Counter.staticCount);
        // Console.ReadLine();
        // // Question 10
        // LibraryBook book = new LibraryBook();
        // book.IssueBook();
        // book.IssueBook();
        // book.ReturnBook();
        // book.ReturnBook();
        // Console.WriteLine("Is Book Issued: " + book.IsIssued);
        // Console.ReadLine();
        // // Question 11
        // IMovement walk = new WalkMovement();
        // IMovement dash = new Dash();
        // Enemy enemy1 = new Enemy(new MeleeAttack(), walk);
        // enemy1.Move();
        // enemy1.Attack();
        // Enemy enemy2 = new Enemy(new MagicAttack(), dash);
        // enemy2.Move();
        // enemy2.Attack();
        // Console.ReadLine();
        // // FOR PLAYER CLASS EXAMPLE METHOD 2 
        // // useing implementation and assignment
        // Player player = new Player();
        // player._movement = new WalkMovement();
        // player._attack = new MeleeAttack();
        // // run methods
        // player.Move();
        // player.Attack();
        // Console.ReadLine();
        // // FOR PLAYER2 CLASS EXAMPLE METHOD 2 
        // // useing implementation and assignment
        // Player2 player2 = new Player2();
        // player2.Movement = new Dash();
        // player2.Attack = new MagicAttack();
        // // run methods
        // player2.Update();
        // Console.ReadLine();
        // // Question 12
        // Character c = new Warrior("Thor");
        // c.PrintName();          // polymorphism (override)
        // c.TakeDamage(10);      // polymorphism (abstract)
        // if (c is IAttack2 a)    // interface casting
        // {
        //     a.Attack();
        // }
        // // Question 13
        // GameEntity playerEntity = new GameEntity(new PlayerMovement());
        // playerEntity.Move();
        // Console.WriteLine();
        // GameEntity enemyEntity = new GameEntity(new EnemyMovement());
        // enemyEntity.Move();
        // Console.ReadLine();
        // //method 2 for main (actually this explanes what happening in method 1)
        // // Create movement behaviors
        // IMovable playerMove = new PlayerMovement();
        // IMovable enemyMove = new EnemyMovement();
        // // Create entities with different behaviors
        // GameEntity player = new GameEntity(playerMove);
        // GameEntity enemy = new GameEntity(enemyMove);
        // // Use them
        // player.Move();   // Player moves!
        // enemy.Move();    // Enemy moves!
        // Console.ReadLine();
        // // Question 14
        // // Method 1 for main
        // Player3 p1 = new Player3(new Sword());
        // p1.WAttack();
        // Player3 p2 = new Player3(new Gun());
        // p2.WAttack();
        // // method 2 for main
        // IWeapon sword = new Sword();
        // IWeapon gun = new Gun();
        // Player3 p1 = new Player3(sword);
        // Player3 p2 = new Player3(gun);
        // p1.WAttack();
        // p2.WAttack();
    
        // // Question 15
        // Player4 player = new Player4();
        // player.Heal(20);
        // Console.WriteLine("Player Health: " + player.Health);
        // player.attack();
        // player.attack();
        // player.attack();
        // player.attack();
        // player.attack();
        // player.Heal(40);
        // Console.WriteLine("Player Health: " + player.Health);
        // Console.ReadLine();
        // // Question 16
        // // IAIBehavior aggressiveAI = new AggressiveAI();
        // // IAIBehavior passiveAI = new PassiveAI();
        // Enemy2 enemy = new Enemy2(new AggressiveAI());
        // enemy.Update();
        // enemy = new Enemy2(new PassiveAI());
        // enemy.Update();
        // // Player enters range → enemy becomes aggressive
        // enemy.SetAI(new AggressiveAI());
        // enemy.Update();   // Enemy attacks aggressively!
        // Console.ReadLine();
        #endregion 
        #region SOLID principles
        // // Single Responsibility Principle (SRP) Demo
        // // OPTION 1: Direct usage (also valid)
        // SRP.IMovementS movement = new SRP.PlayerMovementS();
        // SRP.IAttackS attack = new SRP.PlayerAttackS();
        // SRP.PlayerS player = new SRP.PlayerS(movement, attack);
        // player.Move();
        // player.Attack();
        // Console.WriteLine();
        // // // OPTION 2: Run via SRP demo
        // // SRP.Run();
        // // Open/Closed Principle (OCP) Demo
        // // Option 1
        // OCP.Run();
        // // Option 2: Direct usage (also valid)
        // OCP.EnemyO enemy1 = new OCP.EnemyO(new OCP.MeleeAttackO());
        // OCP.EnemyO enemy2 = new OCP.EnemyO(new OCP.MagicAttackO());
        // OCP.EnemyO enemy3 = new OCP.EnemyO(new OCP.RangedAttackO());
        // enemy1.PerformAttack();
        // enemy2.PerformAttack();
        // enemy3.PerformAttack();
        // Console.ReadLine();
        // // Liskov Substitution Principle (LSP) Demo
        // LSP.Run();
        // // Interface Segregation Principle (ISP) Demo
        // ISP.Run();
        // // Dependency Inversion Principle (DIP) Demo
        // DIP.PlayerD player1 = new DIP.PlayerD(new DIP.SwordD());
        // player1.Attack();
        // DIP.PlayerD player2 = new DIP.PlayerD(new DIP.GunD());
        // player2.Attack();
        
        // // Complete SOLID Principle Demo
        // COMPLETE_SOLID.Run();
        #endregion
        #region Design Patterns
        // StatePattern1.Run();
        // StatePattern2.Runn();
        // StatePattern3.Run();
        // StratagyPattern1.Run();
        // StratagyPattern2.Run();
        // StratagyPattern3.Run();
        // StratagyPattern4.Run();
        // ObserverPattern1.Run();
        // ObserverPattern2.Run();
        // CommandPattern1.Run();
        // CommandPattern2.Run();
        // CommandPattern3.Run();
        // CommandPattern4.Run();
        // CommandPattern5.Run();
        // FoctoryPattern1.Run();
        // FoctoryPattern2.Run();
        // FoctoryPattern3.Run();
        // GameArchitecture1.GamePlay();
        // GameArchitecture2.GamePlay();
        GameArchitecture3.GamePlay();
        // GameArchitecture4.GamePlay();
        #endregion
        
    }

#region Questions
// Question 1
// Create a class Person Add fields: Name, Age Add method Introduce() that prints name and age Create two objects of Person Assign different values Call Introduce() for both
    class Car
    {
        // properties
        public string color = ""; // not best practice to initialize like this
        public int speed = 0;

        // method
        public void Drive()
        {
            Console.WriteLine("The car is driving at "+ speed);
            Console.WriteLine("The car color is " + color);
        }
    }
    class Person
    {
        public string name = ""; // better to initialize in constructor
        public int age = 0;
        public void Intro()
        {
            Console.WriteLine("hi my name is " + name + " my age is " + age);
        }
    }

// Question 2
// Write one real-world thing you want to model using OOP (example: Phone, BankAccount, GameCharacter)
    public class GameCharacter
    {
        public string GameState = "";
        public string AnimationType = "";
        public int Health;
        public bool IsAlive ;

        public string CharacterName = "";
        public int CharacterSkill;
        public int SkillLevel;
        public string network = "";
        public void PlayerStates()
        {
            Console.WriteLine("GameState " + GameState);
            Console.WriteLine("Character Name is " + CharacterName);
            Console.WriteLine(" playe is alive = " + IsAlive);
            if (IsAlive)
            {
                Console.WriteLine("player Animation Type " + AnimationType);
                Console.WriteLine("player Health then  " + Health);
            }
            else
            {
                Health = 0;
                Console.WriteLine("player is dead no animation");
                Console.WriteLine("player Health then  " + Health );
            }
            Console.WriteLine("Character Skill is " + CharacterSkill);
            Console.WriteLine("Skill Level is " + SkillLevel);
            Console.WriteLine("Network is" + network);
        }
    }


// Question 3
    public class Book
    {
        public string Title = "";
        public string Author = "";
            
    }

// Question 4
//Why does changing one reference affect the other?
/* answer: 
    Because both book1 and book2 reference the same object in memory. 
    When you assign book2 = book1, you're not creating a new object; 
    instead, you're making book2 point to the same memory location as book1. 
    Therefore, any changes made to the object through either reference will be reflected when accessed through the other reference.
*/


// Encapsulation Example
    public class Animal
    {
        public string Species = "";
        private int Age;
        public string Color = "";
        public string Sex = ""; //{get; set;} // get in public and set in public
         public int age { get; private set; } // alternative way to encapsulate Age
        /* this can also be used, this means Get in public but Set is private to the class only */


        public void Speak()
        {
            Console.WriteLine("The " + Species + " says hello!");
        }
        public int GetAge()
        {
            return Age;
        }
        public void SetAge(int age)
        {
            if (age >= 0)
            {
                Age = age;
            }
            else
            {
                Console.WriteLine("Age cannot be negative.");
            }
        }
        }
    public class BankAccount
    {
        private decimal _balance;
    
        public decimal Balance
        {
            get { return _balance; }
            private set { _balance = value; }
        }
    
        public void Deposit(decimal amount)
        {
            if (amount > 0)
                Balance += amount;
        }
    }

// Question 5
/*
    1. Create class Student

    2. Private field _marks

    3. Public property Marks

    4. Prevent marks < 0 or > 100 
    5. Add method AddMarks(int value)

    6. Marks should increase only if value > 0
*/
    public class Student
    {
        public string Name = "";
        public int RollNumber {get; set;}
        private int _marks;
        public int markes
        {
            get { return _marks;}
        }
        public void AddMarks(int value)
        {
            if (value >0 )
                {
                     _marks += value;
                }
            else
                {
                    Console.WriteLine("Marks should be between 0 and 100");
                }
        }
    }

// Question 6
// create class employee, properties name, id, salary, initialize via constructor, method display details
// selary can no be negatve, throw if invalid
// 📌 Rules
// No default invalid objects
// Use constructor validation
// No console printing inside class
    public class Employee
    {
        public string name {get; private set;}
        public int Id {get; private set;}
        private decimal _salary;
        public decimal Salary
        {
            get { return _salary;}

        }
        public Employee(string name, int id, decimal salary)
        {
            this.name = name;
            this.Id = id;
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }
            this._salary = salary;
        }
    }

// Question 7
// Create class Car
// Fields: Brand, Speed
// Constructor parameters same names
// Use this correctly
// Add another constructor that takes only Brand
// Chain constructors using this(...)
    public class Resume
    {
        // personal info
        public string Name {get; private set;}
        public int Age {get; private set;}
        // contact info
        public string Address {get; private set;} = ""; // initialize to empty string to avoid null warning, option 1
        public string? PhoneNumber {get; private set;}  // this can be null, '?' this handles null warning, option 2
        public required string Email {get; init;} // required keyword to ensure its initialized before use, option 3
        // resume details
        public string Education = "";
        public string Experience = "";
        public string Skills = "";

        public Resume(string name, int age)
        {
            this.Age = age;
            if (Age < 19)
            {
                throw new ArgumentException("you are not eligible for this job");
            }
            this.Name = name;
        }
        public void SetContactInfo(string address, string phoneNumber/*, string email*/)
        {
            
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            // this.Email = email;
        }
       public void SetResumeDetails(string education,string experience,string skills)
        {
            this.Education = education;
            this.Experience = experience;
            this.Skills = skills;
        } 
        public void DisplayInfo()
        {
            
            Console.WriteLine("Name: " + Name + "\n");
            Console.WriteLine("Age: " + Age + "\n");
            Console.WriteLine("Address: " + Address + "\n");
            Console.WriteLine("Phone Number: " + PhoneNumber + "\n");
            Console.WriteLine("Email: " + Email + "\n");
            Console.WriteLine("Education: " + Education + "\n");
            Console.WriteLine("Experience: " + Experience + "\n");
            Console.WriteLine("Skills: " + Skills + "\n");
        }

    }

// Question 8
// Create class Account
// Static field TotalAccounts
// Instance field AccountNumber
// Increment total in constructor
// Add static method GetTotalAccounts()
    public class Account
    {
        private static int TotalAccounts = 0;
        public int AccountNumber {get; private set;}
        public Account(int accountNumber)
        {
            this.AccountNumber = accountNumber;
            TotalAccounts++;
        }

        public static int GetTotalAccounts()
        {
            return TotalAccounts;
        }
        // 2️⃣ Make it read-only via property (cleaner API)
        // public static int TotalAccounts => TotalAccounts;
        // Then you don’t even need a method.
        // Console.WriteLine(Account.TotalAccounts);
    }
    

// Question 9 – Static vs Instance Behavior
// Create a class Counter that:
//  Has a static variable TotalCount
//  Has a non-static variable InstanceCount
// In the constructor:
//  Increment both counters
//  Create 3 objects in Main
// Print:
//      InstanceCount from each object
//      TotalCount using the class name
    public class Counter
    {
        private static int _staticCount = 0;
        public int InstanceCount {get; private set;}

        public Counter()
        {
            _staticCount++;
            InstanceCount++;
        }

        public static int staticCount => _staticCount;
    }


// Question 10
// Create class LibraryBook
// Fields: _isIssued, Read-only property IsIssued
// Methods:
//      IssueBook()
//      ReturnBook()
//      Prevent double issue / double return
//📌Rules:
//      All state private
//      No public fields
//      Methods enforce rules

    public class LibraryBook
    {
        private bool _isIssued = false;
        public bool IsIssued
        {
            get { return _isIssued;}
        }
        public void IssueBook()
        {
            if (_isIssued)
            {
                Console.WriteLine("Book is already issued.");
            }
            else
            {
                _isIssued = true;
                Console.WriteLine("Book issued successfully.");
            }
        }
        public void ReturnBook()
        {
            if (!_isIssued)
            {
                Console.WriteLine("Book is already returned.");
            }
            else
            {
                _isIssued = false;
                Console.WriteLine("Book returned successfully.");
            }
        }
        
        }

// Question 11
// Create interface IAttack
// Method Execute()
// Implement: MeleeAttack, MagicAttack
// Create Enemy class
// Assign attack behavior via constructor
// Call attack polymorphically
    public interface IMovement // interface for movement behaviors   /ASSIGNMENT/
    {
        void Move(); // assign movement behavior FUNCTION
    }
    public class WalkMovement : IMovement // inherits movement behavior for walking   /IMPLEMENTATION/
    {
        public void  Move() // implementation of Move method for walking
        {
            Console.WriteLine("Walking");
        }
    }
    public class Dash : IMovement // inherits movement behavior for dashing   /IMPLEMENTATION/
    {
        public void Move() // implementation of Move method for dashing
        {
            Console.WriteLine("Dashing");
        }
    }
    public interface IAttack // interface for attack behaviors   /ASSIGNMENT/
    {
        void Execute(); // assign attack behavior FUNCTION
    }
    public class MeleeAttack : IAttack // inherits attack behavior for melee   /IMPLEMENTATION/
    {
        public void Execute() // implementation of Execute method for melee attack
        {
            Console.WriteLine("Performing melee attack!");
        }
    }
    public class MagicAttack : IAttack // inherits attack behavior for magic   /IMPLEMENTATION/
    {
        public void Execute()
        {
            Console.WriteLine("Performing magic attack!");
        }
    }
    public class Enemy // Enemy class that uses IAttack behavior  /USE/
    {
        private IMovement _movement; // composition: Enemy HAS-A IMovement behavior 
        private IAttack _attack; // composition: Enemy HAS-A IAttack behavior 
        public Enemy(IAttack attack, IMovement movement) // constructor injection of attack behavior /DEPENDENCY INJECTION/
        {
            this._attack = attack; 
            this._movement = movement;
        }

        public void Move() // method to perform movement using assigned behavior 
        {
            _movement.Move();
        }
        public void Attack() // method to perform attack using assigned behavior  
        {
            _attack.Execute();
        }

    }

// FOR PLAYER CLASS EXAMPLE METHOD 2 
    public class Player
    {
        public IMovement _movement; // composition: Player HAS-A IMovement behavior 
        public IAttack _attack; // composition: Player HAS-A IAttack behavior 

        public void Move() // method to perform movement using assigned behavior 
        {
            _movement.Move();
        }
        public void Attack() // method to perform attack using assigned behavior  
        {
            _attack.Execute();
        }
    }

// FOR PLAYER2 CLASS EXAMPLE METHOD 2 
        public class Player2
    {
        public IMovement Movement;
        public IAttack Attack;

        public void Update()
        {
            Movement.Move();
            Attack.Execute();
        }
    }

// Qeuestion 12
// Design a game character system using both abstract and interface.
// Requirements:
//      Create an abstract class Character
//          It must have:
//              Name
//              an abstract method TakeDamage(int amount)
//              a non-abstract method PrintName()
// Create an interface IAttack
//      Method: Attack()
// Create two classes:
//      Warrior
//      Mage
// Rules:
//      Both Warrior and Mage must:
//      inherit from Character
//       implement IAttack
//      They must have different implementations of:
//      TakeDamage
//      Attack
// In Main:
//      Create one Character reference for a Warrior
//      Create one Character reference for a Mage
//  Call:
//      PrintName()
//      Attack()
//      TakeDamage(20)
// ⚠️ Rules (important)
// ❌ No inheritance chains deeper than 1 level
// ❌ No explanation text
// ✅ Only code
// ✅ Use abstract, override, and interface properly
public abstract class Character
{
    public string? Name { get; protected set; }

    public Character(string name)
    {
        Name = name;
    }

    public abstract void TakeDamage(int amount);

    public virtual void PrintName()
    {
        Console.WriteLine("Character Name: " + Name);
    }
}

public interface IAttack2
{
    void Attack();
}

public class Warrior : Character, IAttack2
{
    public Warrior(string name) : base(name)
    {
    }

    public override void TakeDamage(int dmg)
    {
        Console.WriteLine("Warrior takes " + dmg + " damage!");
    }

    public override void PrintName()
    {
        Console.WriteLine("Warrior Name: " + Name);
    }

    public void Attack()
    {
        Console.WriteLine("Warrior attacks with sword!");
    }
}


// Question 13 (Game Dev)
// Create interface IMovable
//      Method Move()
//  Implement:
//      PlayerMovement
//      EnemyMovement
//  Create GameEntity
//      Assign movement via interface
//      Call movement polymorphically
//  In comments:
//      Why abstraction reduces coupling?
// 📌 Rules
// Depend on interfaces
// Hide implementation
// Expose only intent
    public interface IMovable
    {
        void Move();
    }
    public class PlayerMovement : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Player moves!");
        }
    }
    public class EnemyMovement : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Enemy moves!");
        }
    }
    public class GameEntity
    {
        private IMovable _movable;
        public GameEntity(IMovable movable)
        {
            _movable = movable;
        }
        public void Move()
        {
            _movable.Move();
        }
    }

// Question 14 (Game Dev - Weapons System)
// Create interface IWeapon
// Method Use()
// Implement:
// Sword
// Bow
// Create Player class
// Give it a field IWeapon Weapon
// Method Attack() → calls Weapon.Use()
// Change weapon at runtime
    public interface IWeapon
    {
        void USE();
    }
    public class Sword : IWeapon
    {
        public void USE()
        {
            Console.WriteLine("Swinging the sword!");
        }
    }
    public class Gun : IWeapon
    {
        public void USE()
        {
            Console.WriteLine("Firing the gun!");
        }
    }
    public class Player3
    {
        public IWeapon Weapon {get; set;}
        public Player3(IWeapon weapon)
        {
            Weapon = weapon;
        }
        public void WAttack()
        {
            Weapon.USE();
        }
    }

// Question 15 (Game Dev - Healable Characters)
// Create interface IHealable
// Method Heal(int amount)
// Create abstract class Character
// Health property
// Abstract Attack() method
// Create Player class
// Inherit from Character
// Implement IHealable
    public interface Ihealthable
    {
        void Heal(int amount);
    }
    public abstract class CharacterBase
    {
        public int Health {get; protected set;}
        public abstract void attack();
    }
    public class Player4 : CharacterBase, Ihealthable
    {
        public Player4()
        {
            Health = 100;
        }
        public override void attack()
        {
            Health -= 10;
            Console.WriteLine("Player attacks!");
        }
        public void Heal(int amount)
        {
            if (Health + amount > 100)
            {
                Health = 100;
            }
            else
            Health += amount;
            Console.WriteLine("Player healed by " + amount);
        }
    }

// Question 16 (Game Dev - Inventory System)
// Create interface IAIBehavior
// Method Update()
// Implement:
// AggressiveAI
// PassiveAI
// Create Enemy class
// Inject IAIBehavior via constructor
// Call AI update from Enemy
// Swap AI at runtime
// 📌 Rules
// Depend on abstractions
// Inject, don’t create
// Prefer constructor injection
    public interface IAIBehavior
    {
        void Update();
    }
    public class AggressiveAI : IAIBehavior
    {
        public void Update()
        {
            Console.WriteLine("Enemy attacks aggressively!");
        }
    }
    public class PassiveAI : IAIBehavior
    {
        public void Update()
        {
            Console.WriteLine("Enemy wanders passively.");
        }
    }
    public class Enemy2
    {
        private IAIBehavior _ai;
        public Enemy2(IAIBehavior ai)
        {
            _ai = ai;
        }
        public void SetAI(IAIBehavior ai)
        {
            _ai = ai;
        }
        public void Update()
        {
            _ai.Update();
        }
    }

#endregion

}