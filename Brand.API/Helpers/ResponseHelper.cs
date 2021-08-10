using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brand.API.Responses;
using Brand.Domain.Exception;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Brand.API.Helpers
{
    public class ResponseHelper
    {
        public async Task<IActionResult> CreateResponse(Func<Task<IActionResult>> func)
        {
            try
            {
                return await func();
            }
            catch (BrandException e)
            {
                var response = PrepareBadRequestResult(e);
                return response;
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
        
        private static IActionResult PrepareBadRequestResult(BrandException e)
        {
            var errors = JsonConvert.DeserializeObject<ICollection<string>>(e.Message);
            var errorResponse = new ErrorResponse();
            errorResponse.Errors.AddRange(errors.Select(error => new ErrorResponseItem {Message = error}));
            
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(errorResponse),
                ContentType = "application/json",
                StatusCode = 400
            };
        }
    }
}