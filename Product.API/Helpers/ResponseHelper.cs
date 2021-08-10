using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product.API.Responses;
using Product.Domain.Exception;

namespace Product.API.Helpers
{
    public class ResponseHelper : IResponseHelper
    {
        public async Task<IActionResult> CreateResponse(Func<Task<IActionResult>> func)
        {
            try
            {
                return await func();
            }
            catch (ProductException e)
            {
                var response = PrepareBadRequestResult(e);
                return response;
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
        
        private static IActionResult PrepareBadRequestResult(ProductException e)
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