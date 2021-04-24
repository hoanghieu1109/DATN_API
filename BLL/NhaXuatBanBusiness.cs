using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class NhaXuatBanBusiness : INhaXuatBanBusiness
    {
        private INhaXuatBanRepository _res;
        public NhaXuatBanBusiness(INhaXuatBanRepository NhaXuatBanGroupRes)
        {
            _res = NhaXuatBanGroupRes;
        }
        public List<NhaXuatBanModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public NhaXuatBanModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NhaXuatBanModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(NhaXuatBanModel model)
        {
            return _res.Update(model);
        }
        public List<NhaXuatBanModel> phantrang(int pageIndex, int pageSize, out long total, string tennxb)
        {
            return _res.phantrang(pageIndex, pageSize, out total, tennxb);
        }
    }

}
