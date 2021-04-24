using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHoaDonRepository
    {
        bool Create(HoaDonModel model);
        List<HoaDonModel> GetDataAll();
        HoaDonModel GetDatabyID(string id);
        List<HoaDonModel> Search(int pageIndex, int pageSize, out long total, string ho_ten);
        List<ChiTietHoaDonModel> GetChitietbyhoadon(string id);
    }
}
