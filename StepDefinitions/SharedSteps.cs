using System;
using AppiumSpecflow.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AppiumSpecflow.StepDefinitions
{
    [Binding, Scope(Tag = "SharedSteps")]
    public class SharedSteps
    {
        private readonly GTMainPage _mainPage;
        private readonly VenuePriceCalculatorStepsContext _context;

        public SharedSteps(GTMainPage mainPage, VenuePriceCalculatorStepsContext context)
        {
            _mainPage = mainPage;
            _context = context;
        }
        
        [Given(@"Jim has opened the Globotickets application")]
        public void GivenJimHasOpenedTheGloboticketsApplication()
        {
            _mainPage.Title.Displayed.Should().BeTrue();
        }

        [Given(@"Jim has chosen a random number of guests")]
        public void GivenJimHasChosenARandomNumberOfGuests()
        {
            _context.NumberOfGuests = new Random().Next(1, 201);
        }
    }
}