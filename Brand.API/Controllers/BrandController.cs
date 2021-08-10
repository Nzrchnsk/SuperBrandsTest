using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Brand.API.DTO;
using Brand.API.Helpers;
using Brand.API.Responses;
using Brand.Domain.Entities.BrandAggregate;
using Brand.Domain.Exception;
using Brand.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Brand.API.Controllers
{
    [ApiController]
    [Route("brand")]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly IResponseHelper _responseHelper;
        
        public BrandController(ILogger<BrandController> logger, IBrandService brandService, IMapper mapper)
        {
            _logger = logger;
            _brandService = brandService;
            _mapper = mapper;
            _responseHelper = new ResponseHelper();
        }

        [HttpGet]
        [Route("range")]
        public async Task<IActionResult> Get()
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var brands = await _brandService.GetRangeAsync();
                var ret = new List<BrandDTO>(); 
                foreach (var brand in brands)
                {
                    ret.Add(_mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand));
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
                var brand = await _brandService.GetWithSizesAsync(id);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                return Ok(ret);
            });
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var brand = await _brandService.FindWithSizesAsync(name);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                return Ok(ret);
            });
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CreateBrandDTO brandDTO)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var brand = await _brandService.CreateAsync(new Domain.Entities.BrandAggregate.Brand(0, brandDTO.Name));
                
                var sizes = new List<Size>();
                foreach (var sizeDTO in brandDTO.Sizes)
                {
                    sizes.Add(new Size(rusSize:sizeDTO.RusSize, brandSize:sizeDTO.BrandSize, brandId: brand.Id));
                }
                brand = await _brandService.AddSizeRangeAsync(sizes, brand.Id);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                return Ok(ret);
            });
        }
        

        [HttpPost]
        [Route("{id}/size")]
        public async Task<IActionResult> Post([FromBody]SizeDTO sizeDTO, [FromRoute]int id = 0)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var brand = await _brandService.AddSizeAsync(new Size(rusSize:sizeDTO.RusSize, brandSize:sizeDTO.BrandSize, brandId: id), 
                    id);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                return Ok(ret);
            });
        }  
        
        [HttpPost]
        [Route("{id}/size/range")]
        public async Task<IActionResult> Post([FromBody]IEnumerable<SizeDTO> sizeDTOList, [FromRoute]int id = 0)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var sizes = new List<Size>();
                foreach (var sizeDTO in sizeDTOList)
                {
                    sizes.Add(new Size(rusSize:sizeDTO.RusSize, brandSize:sizeDTO.BrandSize, brandId: id));
                }
                var brand = await _brandService.AddSizeRangeAsync(sizes, id);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                return Ok(ret);
            });
        }
    }
}