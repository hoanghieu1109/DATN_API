using System;
using System.Collections.Generic;

namespace Model
{
    public class SachModel
    {
        public int masach { get; set; }
        public string tensach { get; set; }
        public int giaban { get; set; }
        public string mota { get; set; }
        public string anhbia { get; set; }
        public int soluongton { get; set; }
        public int manxb { get; set; }
        public int machude { get; set; }

        public NhaXuatBanModel NXB { get; set; }
        public ChuDeModel CD { get; set; }


    }
}
