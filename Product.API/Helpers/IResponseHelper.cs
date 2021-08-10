using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Product.API.Helpers
{
    public interface IResponseHelper
    {
        Task<IActionResult> CreateResponse(Func<Task<IActionResult>> func);
    }
}