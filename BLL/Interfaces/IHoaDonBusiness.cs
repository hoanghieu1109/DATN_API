using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IHoaDonBusiness
    {
        bool Create(HoaDonModel model);

        List<HoaDonModel> GetDataAll();

        HoaDonModel GetDatabyID(string id);
        HoaDonModel GetChiTietByHoaDon(string id);
        List<HoaDonModel> Search(int pageIndex, int pageSize, out long total, string ho_ten);
    }
}
