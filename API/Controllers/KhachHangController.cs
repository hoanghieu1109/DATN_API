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
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBusiness _khachhangBusiness;
        public KhachHangController(IKhachHangBusiness khachhangBusiness)
        {
            _khachhangBusiness = khachhangBusiness;
        }
         
        [Route("create-item")]
        [HttpPost]
        public KhachHangModel CreateItem([FromBody] KhachHangModel model)
        {
            _khachhangBusiness.Create(model);
            return model;
        } 
    }
}
