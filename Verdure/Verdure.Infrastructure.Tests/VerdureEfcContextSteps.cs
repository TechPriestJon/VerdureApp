using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Infrastructure.Tests.Config;

namespace Verdure.Infrastructure.Tests
{
    [Binding]
    public class VerdureEfcContextSteps
    {
        string contextProvider;

        [Given(@"I have an inmemory database context")]
        public void GivenIHaveAnInmemoryDatabaseContext()
        {

        }
        
        [When(@"load it into memory")]
        public void WhenLoadItIntoMemory()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                contextProvider = context.Database.ProviderName;
            }
        }
        
        [Then(@"the context generates the model correctly")]
        public void ThenTheContextGeneratesTheModelCorrectly()
        {
            Assert.IsNotNull(contextProvider);
            Assert.AreEqual(contextProvider, "Microsoft.EntityFrameworkCore.InMemory");
        }
    }
}
