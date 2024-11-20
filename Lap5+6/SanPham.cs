using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5_6
{
    public class SanPham
    {
        public string Id { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public float Gia { get; set; }
        public string MauSac { get; set; }
        public string KichThuoc { get; set; }
        public int SoLuong { get; set; }

        public SanPham(string id, string maSanPham, string tenSanPham, float gia, string mauSac, string kichThuoc, int soLuong)
        {
            Id = id;
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            Gia = gia;
            MauSac = mauSac;
            KichThuoc = kichThuoc;
            SoLuong = soLuong;
        }

        public SanPham()
        {
        }
    }
}

