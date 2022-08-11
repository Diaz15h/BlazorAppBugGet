using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BlazorAppBugGet.Server.Controllers
{
    public class HomeControllerBase<TModel> :ODataController
    {
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {            
            return "here Delete";
        }
                     
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 10, MaxNodeCount = 1000)]
        public ActionResult<string> Get(ODataQueryOptions<TModel> oDataQueryOptions)        
        {
            var type = typeof(TModel);            
            return Ok($"Here Method Get(ODataQueryOptions o) TModel : {type.Name}");
        }
                
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var type = typeof(TModel);
            return Ok($"Here Method Get(int id) TModel : {type.Name}");
        }

        
        [HttpPost]
        public ActionResult<string> Post(TModel model)
        {
            return Ok("Here Post") ;
        }

        
        [HttpPut("{id}")]
        public ActionResult<TModel> Put(int id, TModel model)
        {            
            return Ok("Here Put");
        }
    }
}
