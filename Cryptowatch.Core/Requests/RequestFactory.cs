using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Core.Requests
{
    public class RequestFactory
    {
        public static IDataRequest CreateRequest(DataRequest request)
        { 
           switch(request.Type)
            {
                case RequestType.Ticker:
                    return new PoloniexTickerRequest();
                case RequestType.Chart:
                    return new PoloniexChartRequest();
                default:
                    throw new Exception($"Unsupported data request type '{request.Type}'.");
            }
        }
    }
}
