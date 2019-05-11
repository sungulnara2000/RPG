using RPG.Factories;
using System;
using Xunit;
using RPG.Units;

namespace RPG.Test
{
    public class FactoryTest
    {
        [Fact]
        public void TestArcher()
        {
            var factory = new ArcherFactory();
            Assert.IsType(typeof(ArcherFactory), factory);

            Unit archer = factory.CreateUnit();
            Assert.IsType(typeof(Archer), archer);
        }

        [Fact]
        public void TestFire()
        {
            var factory = new FireFactory();
            Assert.IsType(typeof(FireFactory), factory);

            Unit fireMan = factory.CreateUnit();
            Assert.IsType(typeof(FireMan), fireMan);
        }

        [Fact]
        public void TestIce()
        {
            var factory = new IceFactory();
            Assert.IsType(typeof(IceFactory), factory);

            Unit iceMan = factory.CreateUnit();
            Assert.IsType(typeof(IceMan), iceMan);
        }
    }
}
