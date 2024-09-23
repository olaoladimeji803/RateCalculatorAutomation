using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using SpecflowTestAutomation.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SpecflowTestAutomation.Model;
using TechTalk.SpecFlow.Assist;
using SpecflowTestAutomation.EndPoints;
using Newtonsoft.Json;


namespace SpecflowTestAutomation.StepsDefinition
{
    [Binding]
    internal class CommonStepDefinitions
    {
        Context _context;
        static ExtentTest feature;
        static ExtentTest scenario;
        static ExtentReports report;
        ScenarioContext _scenarioContext;
        RateCalculatorEndpoints _rateCalculatorEndpoints;

       
        public CommonStepDefinitions(Context context, ScenarioContext scenarioContext, RateCalculatorEndpoints rateCalculatorEndpoints) 
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _rateCalculatorEndpoints = rateCalculatorEndpoints;
        }

        [Given(@"that exchange rate for rate calculator is set as shown below")]
        public void GivenThatExchangeRateForRateCalculatorIsSetAsShownBelow(Table table)
        {

            var rateCalculator = table.CreateInstance<RateCalculatorModel>();

            Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"rate", rateCalculator.rate },
                {"fromCurrency", rateCalculator.fromCurrency }, 
                {"toCurreny", rateCalculator.toCurrency } 
            };
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);

            _rateCalculatorEndpoints.PostMethod(jsonString);

            scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

      
        [Given(@"that a user load the rate calulation application")]
        public void GivenThatAUserLoadTheRateCalulationApplication()
        {
            _context.LoadRateCalculatorApplication();
        }


        [BeforeTestRun]
        public static void ReportGenerator()
        {
            var testResultReport = new ExtentV3HtmlReporter(AppDomain.CurrentDomain.BaseDirectory + @"\RateCalculatorTestResult.html");
            testResultReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            report = new ExtentReports();
            report.AttachReporter(testResultReport);
        }

        [AfterTestRun]
        public static void ReportCleaner()
        {
            report.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void StepsInTheReport()
        {
            var typeOfStep = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            //Cater for a step that passed
            if (_scenarioContext.TestError == null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            //Cater for a step that failed
            if (_scenarioContext.TestError != null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
            }
            //Cater for a step that has not been implemented
            if (_scenarioContext.ScenarioExecutionStatus.ToString().Equals("StepDefinitionPending"))
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
            }
        }

        [AfterScenario]
        public void CloseApplicationUnderTest()
        {
            try
            {
                if (_scenarioContext.TestError != null)  //this condition will always be true when a test failed
                {
                    string scenarioName = _scenarioContext.ScenarioInfo.Title;
                    string directory = AppDomain.CurrentDomain.BaseDirectory + @"\Screenshots\";
                    _context.TakeScreenshotAtThePointOfTestFailure(directory, scenarioName);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                _context.ShutDownRateCalculatorApplication();
            }
        }
    }
}
