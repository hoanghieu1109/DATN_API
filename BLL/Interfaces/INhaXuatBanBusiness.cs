using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface INhaXuatBanBusiness
    {
        List<NhaXuatBanModel> GetDataAll();
        bool Create(NhaXuatBanModel model);
        bool Update(NhaXuatBanModel model);
        bool Delete(string id);
        NhaXuatBanModel GetDatabyID(int id);
        List<NhaXuatBanModel> phantrang(int pageIndex, int pageSize, out long total, string tennxb);
    }
}
