using RestSharp;

namespace SpecflowTestAutomation.EndPoints
{
    public class RateCalculatorEndpoints
    {
        string setRateBaseUrl = EnvironmentData.setRateBaseUrl;
        public string content = string.Empty;
        public string statusCode = string.Empty;

        public void GetMethod()
        {
            var client = new RestClient(setRateBaseUrl);
            var request = new RestRequest(setRateBaseUrl, Method.GET);
            var result = client.Execute(request);
            content = result.Content;
            statusCode = result.StatusCode.ToString();
        }

        public void PostMethod(object body)
        {
            var client = new RestClient(setRateBaseUrl);
            var request = new RestRequest(setRateBaseUrl, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
        }

        public void PutMethod(object body)
        {
            var client = new RestClient(setRateBaseUrl);
            var request = new RestRequest(setRateBaseUrl, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
        }

        public void DeleteMethod()
        {
            var client = new RestClient(setRateBaseUrl);
            var request = new RestRequest(setRateBaseUrl, Method.DELETE);
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
        }
    }
}
