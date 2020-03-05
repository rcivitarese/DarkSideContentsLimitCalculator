using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DSCLC.DataLayer;
using DSCLC.Web.ViewModels;

namespace DSCLC.Web.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class ContentsListController : ControllerBase
    {

        public ContentsListController (IRenterContentService service)
        {
            _service = service;
        }

        // GET: api/ContentsList
        [HttpGet]
        public DisplayContentLimitViewModel Manage()
        {
            DisplayContentLimitMapper mapper = new DisplayContentLimitMapper();

            var contentList = _service.GetAllContentItems();
            var categoryList = _service.GetCategoryList();

            DisplayContentLimitViewModel model = mapper.MapToModel(contentList, categoryList);

            return model;
        }

        [HttpPost("addnew")]
        public IActionResult Add([FromBody]AddNewItemViewModel newItem)
        {
            ViewModelToDomainModelMapper mapper = new ViewModelToDomainModelMapper();

            _service.AddItem(mapper.MapToModel(newItem));

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteItem(id);
        }

        private readonly IRenterContentService _service;

    }
}
