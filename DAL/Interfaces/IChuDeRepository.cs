using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IChuDeRepository
    {
        bool Create(ChuDeModel model);
        bool Update(ChuDeModel model);
        bool Delete(string id);
        ChuDeModel GetDatabyID(int id);
        List<ChuDeModel> GetDataAll();
        List<ChuDeModel> phantrang(int pageIndex, int pageSize, out long total, string tenchude);
    }
}
