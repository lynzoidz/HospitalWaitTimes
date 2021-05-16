using HospitalWaitTimes;
using HospitalWaitTimes.Model.Responses.Hospital;
using Moq;
using Moq.Protected;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HospitalWaitTimesTests
{
    public class HospitalServiceTests
    {
        private IHospitalService _hospitalService;

        public HospitalServiceTests()
        {
            var factory = new Mock<IHttpClientFactory>();
            var handler = new Mock<HttpMessageHandler>();

            handler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(GetHospitalAPIExampleJSON())
                });

            var client = new HttpClient(handler.Object);
            client.BaseAddress = new System.Uri("http://test.com/");
            factory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            _hospitalService = new HospitalService(factory.Object);
        }

        [Fact]
        public async Task DeserializeHospitals_From_Response()
        {
            List<HospitalSingle> test = await _hospitalService.GetHospitals(null);
            Assert.True(test.Count > 0);
        }

        [Fact]
        public async Task SydneyHospital_FromLevelPain3_InResponse()
        {
            List<HospitalSingle> test = await _hospitalService.GetHospitals(3);
            Assert.True(test[0].Name == "Sydney Childrens Hospital");
        }

        public string GetHospitalAPIExampleJSON()
        {
            return @"{
                        '_embedded':{
                            'hospitals':[
                                {
                                'id':1,
                                'name':'St Vincents Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':10,
                                        'levelOfPain':0,
                                        'averageProcessTime':20
                                    },
                                    {
                                        'patientCount':5,
                                        'levelOfPain':1,
                                        'averageProcessTime':33
                                    },
                                    {
                                        'patientCount':1,
                                        'levelOfPain':2,
                                        'averageProcessTime':15
                                    },
                                    {
                                        'patientCount':10,
                                        'levelOfPain':3,
                                        'averageProcessTime':39
                                    },
                                    {
                                        'patientCount':2,
                                        'levelOfPain':4,
                                        'averageProcessTime':33
                                    }
                                ],
                                'location':{
                                    'lat':-33.88040900,
                                    'lng':151.22095800
                                    }
                                },
                                {
                                'id':2,
                                'name':'Royal Prince Alfred Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':0,
                                        'levelOfPain':0,
                                        'averageProcessTime':60
                                    },
                                    {
                                        'patientCount':1,
                                        'levelOfPain':1,
                                        'averageProcessTime':15
                                    },
                                    {
                                        'patientCount':2,
                                        'levelOfPain':2,
                                        'averageProcessTime':16
                                    },
                                    {
                                        'patientCount':0,
                                        'levelOfPain':3,
                                        'averageProcessTime':87
                                    },
                                    {
                                        'patientCount':1,
                                        'levelOfPain':4,
                                        'averageProcessTime':71
                                    }
                                ],
                                'location':{
                                    'lat':-33.88940600,
                                    'lng':151.18348800
                                    }
                                },
                                {
                                'id':3,
                                'name':'Royal North Shore Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':4,
                                        'levelOfPain':0,
                                        'averageProcessTime':75
                                    },
                                    {
                                        'patientCount':4,
                                        'levelOfPain':1,
                                        'averageProcessTime':25
                                    },
                                    {
                                        'patientCount':4,
                                        'levelOfPain':2,
                                        'averageProcessTime':5
                                    },
                                    {
                                        'patientCount':4,
                                        'levelOfPain':3,
                                        'averageProcessTime':60
                                    },
                                    {
                                        'patientCount':14,
                                        'levelOfPain':4,
                                        'averageProcessTime':87
                                    }
                                ],
                                'location':{
                                    'lat':-33.82099200,
                                    'lng':151.19141500
                                    }
                                },
                                {
                                'id':4,
                                'name':'Sydney Childrens Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':2,
                                        'levelOfPain':0,
                                        'averageProcessTime':30
                                    },
                                    {
                                        'patientCount':11,
                                        'levelOfPain':1,
                                        'averageProcessTime':29
                                    },
                                    {
                                        'patientCount':10,
                                        'levelOfPain':2,
                                        'averageProcessTime':44
                                    },
                                    {
                                        'patientCount':2,
                                        'levelOfPain':3,
                                        'averageProcessTime':16
                                    },
                                    {
                                        'patientCount':11,
                                        'levelOfPain':4,
                                        'averageProcessTime':75
                                    }
                                ],
                                'location':{
                                    'lat':-33.91728600,
                                    'lng':151.23767000
                                    }
                                },
                                {
                                'id':5,
                                'name':'Prince of Wales Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':0,
                                        'levelOfPain':0,
                                        'averageProcessTime':23
                                    },
                                    {
                                        'patientCount':2,
                                        'levelOfPain':1,
                                        'averageProcessTime':20
                                    },
                                    {
                                        'patientCount':2,
                                        'levelOfPain':2,
                                        'averageProcessTime':28
                                    },
                                    {
                                        'patientCount':3,
                                        'levelOfPain':3,
                                        'averageProcessTime':25
                                    },
                                    {
                                        'patientCount':21,
                                        'levelOfPain':4,
                                        'averageProcessTime':65
                                    }
                                ],
                                'location':{
                                    'lat':-33.91851000,
                                    'lng':151.23897000
                                    }
                                },
                                {
                                'id':6,
                                'name':'Ryde Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':1,
                                        'levelOfPain':0,
                                        'averageProcessTime':40
                                    },
                                    {
                                        'patientCount':1,
                                        'levelOfPain':1,
                                        'averageProcessTime':38
                                    },
                                    {
                                        'patientCount':1,
                                        'levelOfPain':2,
                                        'averageProcessTime':50
                                    },
                                    {
                                        'patientCount':4,
                                        'levelOfPain':3,
                                        'averageProcessTime':30
                                    },
                                    {
                                        'patientCount':4,
                                        'levelOfPain':4,
                                        'averageProcessTime':29
                                    }
                                ],
                                'location':{
                                    'lat':-33.79627100,
                                    'lng':151.08970900
                                    }
                                },
                                {
                                'id':7,
                                'name':'Concord Repatriation General Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':5,
                                        'levelOfPain':0,
                                        'averageProcessTime':42
                                    },
                                    {
                                        'patientCount':1,
                                        'levelOfPain':1,
                                        'averageProcessTime':16
                                    },
                                    {
                                        'patientCount':2,
                                        'levelOfPain':2,
                                        'averageProcessTime':80
                                    },
                                    {
                                        'patientCount':5,
                                        'levelOfPain':3,
                                        'averageProcessTime':44
                                    },
                                    {
                                        'patientCount':4,
                                        'levelOfPain':4,
                                        'averageProcessTime':23
                                    }
                                ],
                                'location':{
                                    'lat':-33.83513200,
                                    'lng':151.09665500
                                    }
                                },
                                {
                                'id':8,
                                'name':'St George Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':5,
                                        'levelOfPain':0,
                                        'averageProcessTime':11
                                    },
                                    {
                                        'patientCount':5,
                                        'levelOfPain':1,
                                        'averageProcessTime':42
                                    },
                                    {
                                        'patientCount':5,
                                        'levelOfPain':2,
                                        'averageProcessTime':37
                                    },
                                    {
                                        'patientCount':15,
                                        'levelOfPain':3,
                                        'averageProcessTime':39
                                    },
                                    {
                                        'patientCount':5,
                                        'levelOfPain':4,
                                        'averageProcessTime':68
                                    }
                                ],
                                'location':{
                                    'lat':-33.96549300,
                                    'lng':151.13403200
                                    }
                                },
                                {
                                'id':9,
                                'name':'Northern Beaches Hospital',
                                'waitingList':[
                                    {
                                        'patientCount':10,
                                        'levelOfPain':0,
                                        'averageProcessTime':21
                                    },
                                    {
                                        'patientCount':10,
                                        'levelOfPain':1,
                                        'averageProcessTime':41
                                    },
                                    {
                                        'patientCount':21,
                                        'levelOfPain':2,
                                        'averageProcessTime':39
                                    },
                                    {
                                        'patientCount':10,
                                        'levelOfPain':3,
                                        'averageProcessTime':40
                                    },
                                    {
                                        'patientCount':10,
                                        'levelOfPain':4,
                                        'averageProcessTime':38
                                    }
                                ],
                                'location':{
                                    'lat':-33.75040000,
                                    'lng':151.23260000
                                    }
                                },
                                {
                                'id':10,
                                'name':'Auburn Hospital & Community Health Services',
                                'waitingList':[
                                    {
                                        'patientCount':1,
                                        'levelOfPain':0,
                                        'averageProcessTime':36
                                    },
                                    {
                                        'patientCount':6,
                                        'levelOfPain':1,
                                        'averageProcessTime':20
                                    },
                                    {
                                        'patientCount':3,
                                        'levelOfPain':2,
                                        'averageProcessTime':18
                                    },
                                    {
                                        'patientCount':4,
                                        'levelOfPain':3,
                                        'averageProcessTime':50
                                    },
                                    {
                                        'patientCount':6,
                                        'levelOfPain':4,
                                        'averageProcessTime':4
                                    }
                                ],
                                'location':{
                                    'lat':-33.86040200,
                                    'lng':151.03362000
                                    }
                                }
                            ]
                        },
                        '_links':{
                            'self':{
                                'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/hospitals'
                            },
                            'next':{
                                'href':'http://dmmw-api.australiaeast.cloudapp.azure.com:8080/hospitals?limit=10&page=1'
                            }
                        },
                        'page':{
                            'size':10,
                            'totalElements':23,
                            'totalPages':2,
                            'number':0
                        }
                    }";
        }
    }
}
