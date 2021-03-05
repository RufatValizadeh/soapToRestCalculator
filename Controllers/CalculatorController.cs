using System;
using Calculator_SOAP;
using Microsoft.AspNetCore.Mvc;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rufat_Soap_to_Rest.DTOs;
using Rufat_Soap_to_Rest.Models;
using Rufat_Soap_to_Rest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rufat_Soap_to_Rest.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private int callId;
        private DataContext _dataContext;

        public CalculatorController(
            ICallIdService callIdService,
            DataContext dataContext)
        {
            callId = callIdService.GetLastId();
            _dataContext = dataContext;
        }

        [HttpPost]
        public int Add([FromBody] RequestDTO request)
        {
            try
            {
                Console.WriteLine(DateTime.Now + " - Call {0}. Request to JSON", callId);
                var operation = new Operations();
                _dataContext.Operations.Add(operation);
                _dataContext.SaveChanges();

                const string url = "http://www.dneonline.com/calculator.asmx";

                var address = new EndpointAddress(url);
                Binding binding = new BasicHttpBinding();
                var client = new CalculatorSoapClient(binding, address);

                Console.WriteLine(DateTime.Now + " - Call {0}. Request to SOAP", callId);

                var requestLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(request)
                };

                _dataContext.Logs.Add(requestLog);

                var result = client.AddAsync(request.IntA, request.IntB).GetAwaiter().GetResult();
                Console.WriteLine(DateTime.Now + " - Call {0}. Response from SOAP", callId);
                var responseLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(result)
                };

                _dataContext.Logs.Add(requestLog);

                _dataContext.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [HttpPost]
        public int Subtract([FromBody] RequestDTO request)
        {
            try
            {
                Console.WriteLine(DateTime.Now + " - Call {0}. Request to JSON", callId);
                var operation = new Operations();
                _dataContext.Operations.Add(operation);
                _dataContext.SaveChanges();

                const string url = "http://www.dneonline.com/calculator.asmx";

                var address = new EndpointAddress(url);
                Binding binding = new BasicHttpBinding();
                var client = new CalculatorSoapClient(binding, address);

                Console.WriteLine(DateTime.Now + " - Call {0}. Request to SOAP", callId);

                var requestLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(request)
                };

                _dataContext.Logs.Add(requestLog);

                var result = client.SubtractAsync(request.IntA, request.IntB).GetAwaiter().GetResult();
                Console.WriteLine(DateTime.Now + " - Call {0}. Response from SOAP", callId);
                var responseLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(result)
                };

                _dataContext.Logs.Add(requestLog);

                _dataContext.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [HttpPost]
        public int Multiply([FromBody] RequestDTO request)
        {
            try
            {
                Console.WriteLine(DateTime.Now + " - Call {0}. Request to JSON", callId);
                var operation = new Operations();
                _dataContext.Operations.Add(operation);
                _dataContext.SaveChanges();

                const string url = "http://www.dneonline.com/calculator.asmx";

                var address = new EndpointAddress(url);
                Binding binding = new BasicHttpBinding();
                var client = new CalculatorSoapClient(binding, address);

                Console.WriteLine(DateTime.Now + " - Call {0}. Request to SOAP", callId);

                var requestLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(request)
                };

                _dataContext.Logs.Add(requestLog);

                var result = client.MultiplyAsync(request.IntA, request.IntB).GetAwaiter().GetResult();
                Console.WriteLine(DateTime.Now + " - Call {0}. Response from SOAP", callId);
                var responseLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(result)
                };

                _dataContext.Logs.Add(requestLog);

                _dataContext.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [HttpPost]
        public int Divide([FromBody] RequestDTO request)
        {
            try
            {
                Console.WriteLine(DateTime.Now + " - Call {0}. Request to JSON", callId);
                var operation = new Operations();
                _dataContext.Operations.Add(operation);
                _dataContext.SaveChanges();

                const string url = "http://www.dneonline.com/calculator.asmx";

                var address = new EndpointAddress(url);
                Binding binding = new BasicHttpBinding();
                var client = new CalculatorSoapClient(binding, address);

                Console.WriteLine(DateTime.Now + " - Call {0}. Request to SOAP", callId);

                var requestLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(request)
                };

                _dataContext.Logs.Add(requestLog);

                var result = client.DivideAsync(request.IntA, request.IntB).GetAwaiter().GetResult();
                Console.WriteLine(DateTime.Now + " - Call {0}. Response from SOAP", callId);
                var responseLog = new Logs()
                {
                    Parent_Id = operation.Id,
                    Value = JsonSerializer.Serialize(result)
                };

                _dataContext.Logs.Add(requestLog);

                _dataContext.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [HttpGet]
        public object Get()
        {
            return _dataContext.Operations.Include(s=>s.Logs);
        }
    }
}
