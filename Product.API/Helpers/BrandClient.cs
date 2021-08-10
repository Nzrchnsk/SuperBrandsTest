using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Product.API.DTO;
using Product.Domain.Exception;
using Product.Domain.Interfaces;

namespace Product.API.Helpers
{
    public class BrandClient : IBrandClient
    {

        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public BrandClient(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient("brand");
            _mapper = mapper;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> GetBrand(int id)
        {
            var brandDTO = await RequestBrandAsync<BrandDTO>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    QueryHelpers.AddQueryString(
                        $"brand/{id}",
                        new Dictionary<string, string>()
                    )
                )
            );
            var brand = _mapper.Map<BrandDTO, Domain.Entities.BrandAggregate.Brand>(brandDTO);
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> GetBrand(string name)
        {
            var brandDTO = await RequestBrandAsync<BrandDTO>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    QueryHelpers.AddQueryString(
                        "brand",
                        new Dictionary<string, string>
                        {
                            ["name"] = name
                        }
                    )
                )
            );
            var brand = _mapper.Map<BrandDTO, Domain.Entities.BrandAggregate.Brand>(brandDTO);
            return brand;
        }
        
        private async Task<TResponseType> RequestBrandAsync<TResponseType>(HttpRequestMessage request)
        {
            var response = await GetBrandResponse(request);

            var responseData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponseType>(responseData);
        }
        
        private async Task<HttpResponseMessage> GetBrandResponse(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ProductException(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }
}