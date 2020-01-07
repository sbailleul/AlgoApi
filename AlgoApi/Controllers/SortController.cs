using System.Collections.Generic;
using AlgoApi.Models;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Services.Reordering;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<List<string>>> NaiveSearch(SortRequest<string> sortRequest)
        {
            var naiveSearch = new NaiveSearch<string>();

            return naiveSearch.SortMatrix(sortRequest.Matrix);
        }
    }
}