using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IChuDeBusiness
    {
        
        List<ChuDeModel> GetDataAll();
        bool Create(ChuDeModel model);
        bool Update(ChuDeModel model);
        bool Delete(string id);
        ChuDeModel GetDatabyID(int id);
        List<ChuDeModel> phantrang(int pageIndex, int pageSize, out long total, string tenchude);
    }
}
