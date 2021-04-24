using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class SachBusiness : ISachBusiness
    {
        private ISachRepository _res;
        public SachBusiness(ISachRepository SachGroupRes)
        {
            _res = SachGroupRes;
        }
        public bool Create(SachModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SachModel model)
        {
            return _res.Update(model);
        }
        public SachModel GetDatabyID(int id)
        {
            var kq= _res.GetDatabyID(id);
            if (kq != null) { 
            kq.NXB = _res.GetNXBBYSACH(id);
            kq.CD = _res.GetCDBYSACH(id);}
            return kq;
        }

       
        public List<SachModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<SachModel> phantrang(int pageIndex, int pageSize, out long total, string tensach)
        {

            var kq= _res.phantrang(pageIndex, pageSize, out total, tensach);
            foreach (var item in kq)
            {
                item.NXB = _res.GetNXBBYSACH(item.masach);
                item.CD = _res.GetCDBYSACH(item.masach);
            }
            return kq;
        }
        public List<SachModel> GetDataByChuDe(string id)
        {
            return _res.GetDataByChuDe(id);
        }
        public List<SachModel> GetDataByNXB(string id)
        {
            return _res.GetDataByNXB(id);
        }

        public List<SachModel> Gettuongtu(int masach)
        {
            return _res.Gettuongtu(masach);
        }

        public List<SachModel> GetDataNew()
        {
            return _res.GetDataNew();
        }
    }

}
