using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        private ISachBusiness _rsp;
        public HoaDonBusiness(IHoaDonRepository res, ISachBusiness rsp)
        {
            _res = res;
            _rsp = rsp;
        }
        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }
        public List<HoaDonModel> GetDataAll()
        {
            var kq = _res.GetDataAll();
            foreach(var item in kq)
            {
                item.listjson_chitiet = _res.GetChitietbyhoadon(item.ma_hoa_don);
                foreach (var ct in item.listjson_chitiet)
                {

                    ct.tensach = _rsp.GetDatabyID(ct.masach).tensach;
                    ct.giaban = _rsp.GetDatabyID(ct.masach).giaban;
                }

            }
            return kq;

        }

        public HoaDonModel GetDatabyID(string id)
        {
            var kq= _res.GetDatabyID(id);
            kq.listjson_chitiet = _res.GetChitietbyhoadon(kq.ma_hoa_don);
            foreach (var item in kq.listjson_chitiet)
            {

                item.tensach = _rsp.GetDatabyID(item.masach).tensach;
                item.giaban = _rsp.GetDatabyID(item.masach).giaban;
            }

            return kq;
        }

        public HoaDonModel GetChiTietByHoaDon(string id)
        {
            var kq = _res.GetDatabyID(id);

            kq.listjson_chitiet = _res.GetChitietbyhoadon(kq.ma_hoa_don);
            foreach (var item in kq.listjson_chitiet)
            {
             
                item.tensach = _rsp.GetDatabyID(item.masach).tensach;
                item.giaban = _rsp.GetDatabyID(item.masach).giaban;
            }
            

            return kq;
        }

        public List<HoaDonModel> Search(int pageIndex, int pageSize, out long total, string ho_ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ho_ten);

        }
    }

}
