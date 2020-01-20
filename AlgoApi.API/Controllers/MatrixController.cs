using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.MatrixHandling;
using Microsoft.AspNetCore.Mvc;

namespace AlgoApi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<string[]>> RandomMatrix([FromQuery(Name = "repetition")] int repetition, [FromQuery(Name = "values")] string[] values)
        {
            return MatrixUtils.GetRandomMatrixOfEquitableRepeatedValues(repetition, values).ToList();
        }
    }
}