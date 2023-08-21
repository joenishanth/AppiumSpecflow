using AppiumSpecflow.Pages;

namespace AppiumSpecflow.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private CalculatorMainPage _mainPage;
        public CalculatorStepDefinitions(CalculatorMainPage mainPage)
        {
            _mainPage = mainPage;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _mainPage.MainDisplay.Displayed.Should().BeTrue();
            _mainPage.SelectNumber(number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _mainPage.SelectAdd();
            _mainPage.SelectNumber(number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _mainPage.Calculate();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            var actResult = _mainPage.GetResult();

            actResult.Should().Be(result.ToString());

        }
    }
}