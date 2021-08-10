using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.API.DTO;
using Product.API.Helpers;
using Product.Domain.Interfaces;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IResponseHelper _responseHelper;

        public ProductController(ILogger<ProductController> logger, IProductService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
            _responseHelper = new ResponseHelper();
        }

        [HttpGet]
        [Route("range")]
        public async Task<IActionResult> Get()
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var products = await _productService.GetRangeAsync();
                var ret = new List<ProductDTO>(); 
                foreach (var product in products)
                {
                    ret.Add(_mapper.Map<Domain.Entities.Product, ProductDTO>(product));
                }
                return Ok(ret);
            });
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var product = await _productService.GetAsync(id);
                var ret = _mapper.Map<Domain.Entities.Product, ProductDTO>(product);
                return Ok(ret);
            });
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var product = await _productService.FindAsync(name);
                var ret = _mapper.Map<Domain.Entities.Product, ProductDTO>(product);
                return Ok(ret);
            });
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CreateProductDTO productDTO)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var product = await _productService.CreateAsync(new Domain.Entities.Product(0, productDTO.Name, productDTO.BrandId,
                    productDTO.BrandName, productDTO.RusSize));
                
                var ret = _mapper.Map<Domain.Entities.Product, ProductDTO>(product);
                return Ok(ret);
            });
        }
    }
}