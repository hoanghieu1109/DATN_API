using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ChuDeBusiness : IChuDeBusiness
    {
        private IChuDeRepository _res;
        public ChuDeBusiness(IChuDeRepository ChuDeGroupRes)
        {
            _res = ChuDeGroupRes;
        }
        public List<ChuDeModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public ChuDeModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(ChuDeModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ChuDeModel model)
        {
            return _res.Update(model);
        }
        public List<ChuDeModel> phantrang(int pageIndex, int pageSize, out long total, string tenchude)
        {
            return _res.phantrang(pageIndex, pageSize, out total, tenchude);
        }
    }

}
