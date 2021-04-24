using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SachController : ControllerBase
    {
        private ISachBusiness _SachBusiness;
        private string _path;
        
        public SachController(ISachBusiness SachBusiness)
        {
            _SachBusiness = SachBusiness;
           
        }

        [Route("create-sach")]
        [HttpPost]
        public SachModel CreateSach([FromBody] SachModel model)
        {
            if (model.anhbia != null)
            {
                var arrData = model.anhbia.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.anhbia = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            
            _SachBusiness.Create(model);
            return model;
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("delete-sach")]
        [HttpPost]
        public IActionResult DeleteSach([FromBody] Dictionary<string, object> formData)
        {
            string masach = "";
            if (formData.Keys.Contains("masach") && !string.IsNullOrEmpty(Convert.ToString(formData["masach"])))
            { masach = Convert.ToString(formData["masach"]); }
            _SachBusiness.Delete(masach);
            return Ok();
        }

        [Route("update-sach")]
        [HttpPost]
        public SachModel UpdateSach([FromBody] SachModel model)
        {
            if (model.anhbia != null)
            {
                var arrData = model.anhbia.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.anhbia = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _SachBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SachModel GetDatabyID(int id)
        {
            return _SachBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SachModel> GetDatabAll()
        {
            return _SachBusiness.GetDataAll();
        }
        [Route("sp-get-by-chude/{id}")]
        [HttpGet]
        public List<SachModel> GetDataByChuDe(string id)
        {
            return _SachBusiness.GetDataByChuDe(id);
        }

        [Route("sp-get-by-nxb/{id}")]
        [HttpGet]
        public List<SachModel> GetDataByNXB(string id)
        {
            return _SachBusiness.GetDataByNXB(id);
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
                string tensach = "";
                if (formData.Keys.Contains("tensach") && !string.IsNullOrEmpty(Convert.ToString(formData["tensach"]))) { tensach = Convert.ToString(formData["tensach"]); }
               
                long total = 0;
                var data = _SachBusiness.phantrang(page, pageSize, out total, tensach);
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

        [Route("get-tuongtu/{id}")]
        [HttpGet]
        public IEnumerable<SachModel> Gettuongtu(int id)
        {
            return _SachBusiness.Gettuongtu(id);
        }

        [Route("get-new")]
        [HttpGet]
        public IEnumerable<SachModel> GetDataNew()
        {
            return _SachBusiness.GetDataNew();
        }
    }
}
