using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class FactoryPattern1
    {
        public interface IShoeExport
        {
            void Export();
        }
        public class NikeFactory : IShoeExport
        {
            public void Export()
            {
                Console.WriteLine("Nike Shoe Exported");
            }
        }
        public class AdidasFactory : IShoeExport
        {
            public void Export()
            {
                Console.WriteLine("Adidas Shoe Exported");
            }
        }
        public class PumaFactory : IShoeExport
        {
            public void Export()
            {
                Console.WriteLine("Puma Shoe Exported");
            }
        }
        public class ShoeFactory
        {
            public static IShoeExport GetShoeByFactory(string byBrand)
            {
                return byBrand switch
                {
                    "NIKE" => new NikeFactory(),
                    "ADIDAS" => new AdidasFactory(),
                    "PUMA" => new PumaFactory(),
                    _ => throw new ArgumentException("Invalid Shoe Brand")
                };
            }
        }
        public static void Run()
        {
            IShoeExport nike = ShoeFactory.GetShoeByFactory("NIKE");
            IShoeExport adidas = ShoeFactory.GetShoeByFactory("ADIDAS");
            IShoeExport puma = ShoeFactory.GetShoeByFactory("PUMA");

            nike.Export();
            adidas.Export();
            puma.Export();
        }
    }

    public class FactoryPattern2
    {
        public interface IShape
        {
            void Draw();
        }
        public class Circle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Circle Drawn");
            }
        }
        public class Square : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Square Drawn");
            }
        }
        public class Rectangle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Rectangle Drawn");
            }
        }
        public static class ShapeFactory
        {
            public static IShape GetShape(string type)
            {
                return type switch
                {
                    "circle" => new Circle(),
                    "square" => new Square(),
                    "rectangle" => new Rectangle(),
                    _ => throw new ArgumentException("Invalid shape type")
                };
            }
            
            // // Alternative implementation using enum with return switch expressions
            // public enum ShapeType
            // {
            //     Circle,
            //     Square,
            //     Rectangle
            // }
            // public static IShape GetShape(ShapeType shapeType)
            // {
            //     return shapeType switch
            //     {
            //         ShapeType.Circle => new Circle(),
            //         ShapeType.Square => new Square(),
            //         ShapeType.Rectangle => new Rectangle(),
            //         _ => throw new ArgumentException("Invalid shape type")
            //     };
            // }

            // //Alternative implementation using case switch statements
            // public IShape GetShape(string shapeType)
            // {
            //     switch (shapeType.ToLower())
            //     {
            //         case "circle":
            //             return new Circle();
            //         case "square":
            //             return new Square();
            //         case "rectangle":
            //             return new Rectangle();
            //         default:
            //             throw new ArgumentException("Invalid shape type");
            //     }
            // }
        }
        public static void Run()
        {
            IShape circle = ShapeFactory.GetShape("circle");
            IShape square = ShapeFactory.GetShape("square");
            IShape rectangle = ShapeFactory.GetShape("rectangle");

            circle.Draw();
            square.Draw();
            rectangle.Draw();
        }
    }

    public class FactoryPattern3
    {
        public interface IAmmo
        {
            void Consume();
        }
        public class Bullet : IAmmo
        {
            public void Consume() => Console.WriteLine("Bullet consumed");
        }

        public class Shell : IAmmo
        {
            public void Consume() => Console.WriteLine("Shell consumed");
        }

        public interface IWeapon
        {
            void Fire();
        }
        public class Gun : IWeapon
        {
            private IAmmo _ammo;
            public Gun(IAmmo ammo) => _ammo = ammo;

            public void Fire()
            {
                Console.WriteLine("Gun fires");
                _ammo.Consume();
            }
        }

        public class Shotgun : IWeapon
        {
            private IAmmo _ammo;
            public Shotgun(IAmmo ammo) => _ammo = ammo;

            public void Fire()
            {
                Console.WriteLine("Shotgun fires");
                _ammo.Consume();
            }
        }

        public class Laser : IWeapon
        {
            public void Fire() => Console.WriteLine("Laser fires (no ammo)");
        }
        public enum WeaponType
        {
            Gun,
            Shotgun,
            Laser
        }

        public static class WeaponFactory
        {
            public static IWeapon Create(WeaponType type)
            {
                return type switch
                {
                    WeaponType.Gun     => new Gun(new Bullet()),
                    WeaponType.Shotgun => new Shotgun(new Shell()),
                    WeaponType.Laser   => new Laser(),
                    _ => throw new Exception("Unknown Weapon")
                };
            }
        }
        public static void Run()
        {
            IWeapon gun = WeaponFactory.Create(WeaponType.Gun);
            IWeapon shotgun = WeaponFactory.Create(WeaponType.Shotgun);
            IWeapon laser = WeaponFactory.Create(WeaponType.Laser);
            
            gun.Fire();
            shotgun.Fire();
            laser.Fire();
        }
    }

    
}