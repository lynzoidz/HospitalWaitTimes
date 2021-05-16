using HospitalWaitTimes;
using HospitalWaitTimes.Model.Responses.Illness;
using Moq;
using Moq.Protected;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HospitalWaitTimesTests
{
    public class IllnessServiceTests
    {
        private IIllnessService _illnessService;

        public IllnessServiceTests()
        {
            var factory = new Mock<IHttpClientFactory>();
            var handler = new Mock<HttpMessageHandler>();

            handler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(GetIllnessesAPIExampleJSON())
                });

            var client = new HttpClient(handler.Object);
            client.BaseAddress = new System.Uri("http://test.com/");
            factory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            _illnessService = new IllnessService(factory.Object);
        }

        [Fact]
        public async Task DeserializeIllnesses_From_Response()
        {
            List<IllnessGroup> test = await _illnessService.GetIllnesses();
            Assert.True(test.Count > 0);
        }

        public string GetIllnessesAPIExampleJSON()
        {
            return @"{'_embedded':{'illnesses':[{'illness':{'name':'Mortal Cold','id':1},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/1'}}},{'illness':{'name':'Happy Euphoria','id':2},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/2'}}},{'illness':{'name':'Withering Parasite','id':3},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/3'}}},{'illness':{'name':'Death\'s Delusions','id':4},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/4'}}},{'illness':{'name':'Intense Intolerance','id':5},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/5'}}},{'illness':{'name':'Whispering Hepatitis','id':6},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/6'}}},{'illness':{'name':'Spirit Parasite','id':7},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/7'}}},{'illness':{'name':'Crippling Paranoia','id':8},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/8'}}},{'illness':{'name':'Sheep Sneeze','id':9},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/9'}}},{'illness':{'name':'Impossible Ebola','id':10},'_links':{'illnesses':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses/10'}}}]},'_links':{'self':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses'},'next':{'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses?limit=10&page=1'}},'page':{'size':10,'totalElements':15,'totalPages':1,'number':0}}";
        }
    }
}
