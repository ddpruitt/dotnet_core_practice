using System;

namespace POC.IoCItch.Con01
{
    public interface IFantasySeries { }

    [Test(TestName = "Test1")]
    public class WheelOfTime : IFantasySeries { }

    [Test(TestName = "Test2")]
    public class GameOfThrones : IFantasySeries { }

    [Test(TestName = "Test3")]
    public class BlackCompany : IFantasySeries { }

    public class TestAttribute : Attribute
    {
        public string TestName { get; set; }

    }
}