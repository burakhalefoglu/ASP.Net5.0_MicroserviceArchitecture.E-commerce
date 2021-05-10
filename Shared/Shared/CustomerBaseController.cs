using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
namespace Shared
{
    public class CustomerBaseController : ControllerBase
    {
        public IActionResult CreateActionResult<T>(ResponseModel<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatuseCode
            };
        }

    }
}
