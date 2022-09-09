using FluentAssertions;
using PatisserieAPI.Model;
using System;
using Xunit;

namespace PatisserieTest.Products
{
    public class MiniTartTests
    {
        private Guid Id = Guid.NewGuid();
        private const string Name = "Name";
        private const string Description = "Description";
        private const double Price = 1.11;
        private const string Type = "Type";

        [Fact]
        public void AllValidInputs()
        {
            var miniTart = new MiniTart(Id, Name, Description, Price, Type);
            miniTart.Id.Should().Be(Id);
            miniTart.Name.Should().Be(Name);
            miniTart.Description.Should().Be(Description);
            miniTart.Price.Should().Be(Price);
            miniTart.Type.Should().Be(Type);
        }

        [Fact]
        public void EmptyId()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Guid.Empty, Name, Description, Price, Type); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void EmptyName()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, "", Description, Price, Type); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void NullName()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, null, Description, Price, Type); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void EmptyDescription()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, Name, "", Price, Type); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void NullDescription()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, Name, null, Price, Type); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void NeativePrice()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, Name, Description, -5, Type); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void ZeroPrice()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, Name, Description, 0, Type); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void EmptyType()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, Name, Description, Price, ""); };
            createMiniTart.Should().Throw<Exception>();
        }

        [Fact]
        public void NullType()
        {
            Action createMiniTart = () => { var miniTart = new MiniTart(Id, Name, Description, Price, null); };
            createMiniTart.Should().Throw<Exception>();
        }
    }
}