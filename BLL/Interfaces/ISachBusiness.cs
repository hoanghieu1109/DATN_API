using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ISachBusiness
    {
        bool Create(SachModel model);
        SachModel GetDatabyID(int id);
        List<SachModel> GetDataAll();
        List<SachModel> GetDataByChuDe(string id);
        List<SachModel> GetDataByNXB(string id);
        bool Update(SachModel model);
        bool Delete(string id);
        List<SachModel> phantrang(int pageIndex, int pageSize, out long total, string tensach);
        List<SachModel> Gettuongtu(int masach);
        List<SachModel> GetDataNew();
    }
}
