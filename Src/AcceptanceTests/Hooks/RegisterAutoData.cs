﻿namespace Thoughtology.GameOfLife.AcceptanceTests.Hooks
{
    using BoDi;
    using Ploeh.AutoFixture;
    using TechTalk.SpecFlow;

    [Binding]
    public class RegisterAutoData
    {
        private readonly IObjectContainer container;

        public RegisterAutoData(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void RegisterFixtureInstance()
        {
            var fixture = new Fixture();
            container.RegisterInstanceAs<IFixture>(fixture);
        }
    }
}
