using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {

        private readonly ILogger<BrandController> _logger;
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly ResponseHelper _responseHelper;
        
        public BrandController(ILogger<BrandController> logger, IBrandService brandService, IMapper mapper)
        {
            _logger = logger;
            _brandService = brandService;
            _mapper = mapper;
            _responseHelper = new ResponseHelper();
        }

        [HttpGet]
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
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var brand = await _brandService.GetWithSizesAsync(id);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                foreach (var size in brand.Sizes)
                {
                    ret.Sizes.Add(_mapper.Map<Size, SizeDTO>(size));
                }
                return Ok(ret);
            });
        }


        [HttpPost]
        public async Task<IActionResult> AddSize([FromBody]SizeDTO sizeDTO, [FromQuery]int brandId = 0)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var brand = await _brandService.AddSizeAsync(new Size(rusSize:sizeDTO.RusSize, brandSize:sizeDTO.BrandSize, brandId: brandId), 
                    brandId);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                foreach (var size in brand.Sizes)
                {
                    ret.Sizes.Add(_mapper.Map<Size, SizeDTO>(size));
                }
                return Ok(ret);
            });
        }  
        
        [HttpPost]
        public async Task<IActionResult> AddSize([FromBody]IEnumerable<SizeDTO> sizeDTOList, [FromQuery]int brandId = 0)
        {
            return await _responseHelper.CreateResponse(async () =>
            {
                var sizes = new List<Size>();
                foreach (var sizeDTO in sizeDTOList)
                {
                    sizes.Add(new Size(rusSize:sizeDTO.RusSize, brandSize:sizeDTO.BrandSize, brandId: brandId));
                }
                var brand = await _brandService.AddSizeAsync(sizes, brandId);
                var ret = _mapper.Map<Domain.Entities.BrandAggregate.Brand, BrandDTO>(brand);
                foreach (var size in brand.Sizes)
                {
                    ret.Sizes.Add(_mapper.Map<Size, SizeDTO>(size));
                }
                return Ok(ret);
            });
        }


       
    }
}