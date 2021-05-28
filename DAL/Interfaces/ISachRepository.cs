using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISachRepository
    {
        bool Create(SachModel model);
        bool Update(SachModel model);
        bool Delete(string id);
        SachModel GetDatabyID(int id);
        NhaXuatBanModel GetNXBBYSACH(int id);
        ChuDeModel GetCDBYSACH(int id);
        List<SachModel> GetDataAll();
        List<SachModel> GetDataByChuDe(string machude);
        List<SachModel> GetDataByNXB(string machude);
        List<SachModel> phantrang(int pageIndex, int pageSize, out long total, string tensach);
        List<SachModel> Gettuongtu(int masach);
        List<SachModel> GetDataNew();
        List<SachModel> TimKiemTongQuat(string keyWord, int? minPrice, int? maxPrice, int? pageIndex, int? pageSize, int? chude, int? nhaxuatban, bool? lowToHighPrice, bool? newestFirst, out long total);
    }
}
