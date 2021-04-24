using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuDeController : ControllerBase
    {
        private IChuDeBusiness _ChuDeBusiness;
        public ChuDeController(IChuDeBusiness ChuDeBusiness)
        {
            _ChuDeBusiness = ChuDeBusiness;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ChuDeModel> GetDatabAll()
        {
            return _ChuDeBusiness.GetDataAll();
        }

        [Route("create-chude")]
        [HttpPost]
        public ChuDeModel CreateChuDe([FromBody] ChuDeModel model)
        {
            
            
            _ChuDeBusiness.Create(model);
            return model;
        }
        [Route("delete-chude")]
        [HttpPost]
        public IActionResult DeleteChuDe([FromBody] Dictionary<string, object> formData)
        {
            string machude = "";
            if (formData.Keys.Contains("machude") && !string.IsNullOrEmpty(Convert.ToString(formData["machude"])))
            { machude = Convert.ToString(formData["machude"]); }
            _ChuDeBusiness.Delete(machude);
            return Ok();
        }

        [Route("update-chude")]
        [HttpPost]
        public ChuDeModel UpdateChuDe([FromBody] ChuDeModel model)
        {
            _ChuDeBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ChuDeModel GetDatabyID(int id)
        {
            return _ChuDeBusiness.GetDatabyID(id);
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel phantrang([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenchude = "";
                if (formData.Keys.Contains("tenchude") && !string.IsNullOrEmpty(Convert.ToString(formData["tenchude"]))) { tenchude = Convert.ToString(formData["tenchude"]); }

                long total = 0;
                var data = _ChuDeBusiness.phantrang(page, pageSize, out total, tenchude);
                response.TotalSachs = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
