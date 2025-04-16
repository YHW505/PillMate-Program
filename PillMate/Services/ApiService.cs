using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PillMate.Services
{
    public abstract class ApiService
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;

        protected ApiService(string endpoint)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var handler = new HttpClientHandler
            {
                // ❗ 개발환경 전용: 실서버 배포 시 반드시 수정할 것
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri("http://localhost:5000"); // 자신에 맞게 변경

            _baseUrl = $"/api/{endpoint}";
        }
    }
}
