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
    public class NhaXuatBanController : ControllerBase
    {
        private INhaXuatBanBusiness _NhaXuatBanBusiness;
        public NhaXuatBanController(INhaXuatBanBusiness NhaXuatBanBusiness)
        {
            _NhaXuatBanBusiness = NhaXuatBanBusiness;
        }

        
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NhaXuatBanModel> GetDatabAll()
        {
            return _NhaXuatBanBusiness.GetDataAll();
        }

        [Route("create-nxb")]
        [HttpPost]
        public NhaXuatBanModel CreateNXB([FromBody] NhaXuatBanModel model)
        {


            _NhaXuatBanBusiness.Create(model);
            return model;
        }
        [Route("delete-nxb")]
        [HttpPost]
        public IActionResult DeleteNXB([FromBody] Dictionary<string, object> formData)
        {
            string manxb = "";
            if (formData.Keys.Contains("manxb") && !string.IsNullOrEmpty(Convert.ToString(formData["manxb"])))
            { manxb = Convert.ToString(formData["manxb"]); }
            _NhaXuatBanBusiness.Delete(manxb);
            return Ok();
        }

        [Route("update-nxb")]
        [HttpPost]
        public NhaXuatBanModel UpdateNXB([FromBody] NhaXuatBanModel model)
        {
            _NhaXuatBanBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public NhaXuatBanModel GetDatabyID(int id)
        {
            return _NhaXuatBanBusiness.GetDatabyID(id);
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
                string tennxb = "";
                if (formData.Keys.Contains("tennxb") && !string.IsNullOrEmpty(Convert.ToString(formData["tennxb"]))) { tennxb = Convert.ToString(formData["tennxb"]); }

                long total = 0;
                var data = _NhaXuatBanBusiness.phantrang(page, pageSize, out total, tennxb);
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
