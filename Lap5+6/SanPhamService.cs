using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5_6
{
    public class SanPhamService
    {
        private List<SanPham> sanPhamList = new List<SanPham>();

        public void Them(SanPham sanPham)
        {  if(sanPham.SoLuong<=0 || sanPham.SoLuong >= 100)
            {
                throw new ArithmeticException("loi");
            }
            sanPhamList.Add(sanPham);
           
        }

        public void Sua(string maSanPham, SanPham sanPhamMoi)
        {
            var sp = sanPhamList.Find(s => s.MaSanPham == maSanPham);
            if (sp != null)
            {
                sp.TenSanPham = sanPhamMoi.TenSanPham;
                sp.Gia = sanPhamMoi.Gia;
                sp.MauSac = sanPhamMoi.MauSac;
                sp.KichThuoc = sanPhamMoi.KichThuoc;
                sp.SoLuong = sanPhamMoi.SoLuong;
            }
            else
            {
                throw new ArgumentException("loi");
            }
        }

        public void Xoa(string maSanPham)
        {
            var sp = sanPhamList.Find(s => s.MaSanPham == maSanPham);
            if (sp != null)
            {
                sanPhamList.Remove(sp);
            }
            throw new Exception("loi");
        }
        public List<SanPham> GetAllSP() { return sanPhamList; }
    }
}
