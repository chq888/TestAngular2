using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAngular2.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAngular2.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
    public class TestAPIController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<TestModel> Get()
        {
            return GetTestList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TestModel Get(int id)
        {
            return GetTestList()[0];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TestModel value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TestModel value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    public List<TestModel> GetTestList()
    {
      List<TestModel> list = new List<TestModel>();
      list.Add(new TestModel(1, "Shanu"));
      list.Add(new TestModel(1, "Afraz"));
      list.Add(new TestModel(1, "Afreen"));
      list.Add(new TestModel(1, "Asha"));
      list.Add(new TestModel(1, "Kather"));
      return list;
    }

  }
}
