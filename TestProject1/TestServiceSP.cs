using Lap5_6;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

public class SanPhamServiceTests
{
    private SanPhamService sanPhamService;

    public void SetUp()
    {
        sanPhamService = new SanPhamService();
    }

    [Test]
    [TestCase("1","SP01","Iphone",22,"Black","xxl",0)]
    [TestCase("1", "SP01", "Iphone", 22, "Black", "xxl", 100)]
    [TestCase("1", "SP01", "Iphone", 22, "Black", "xxl", -1)]

    public void LoiThem(string id, string maSanPham, string tenSanPham, float gia, string mauSac, string kichThuoc, int soLuong)
    {
        var SanPham = new SanPham()
        {
            Id = id,
            MaSanPham = maSanPham,
            TenSanPham = tenSanPham,
            Gia = gia,
            MauSac = mauSac,
            KichThuoc = kichThuoc,
            SoLuong = soLuong
        };
        Assert.Throws<ArithmeticException>(()=>sanPhamService.Them(SanPham));
    }
    public void ThemThanhCong()
    {
        var sanPham = new SanPham("1", "SP001", "Product 1", 100.0f, "Red", "M", 50);
        var sanPham2 = new SanPham("1", "SP001", "Product 1", 100.0f, "Red", "M", 51);
        sanPhamService.Them(sanPham);
        sanPhamService.Them(sanPham2);
        var danhsach = sanPhamService.GetAllSP();
        Assert.AreEqual(2, danhsach.Count);
    }
    [Test]
    public void EditSanPham_ValidInput_EditsSanPham()
    {
        var sanPham = new SanPham("1", "SP001", "Product 1", 400.0f, "Purple", "M", 20);
        sanPhamService.Them(sanPham);
        var sanPhamnew = new SanPham("1", "SP001", "Product abc", 400.0f, "Purple", "M", 20);

        sanPhamService.Sua("SP001",sanPhamnew);
        var danhsach = sanPhamService.GetAllSP();
        Assert.AreEqual(sanPhamnew.TenSanPham, danhsach[0].TenSanPham);
    }
    [Test]
    public void EditSanPham_ThrowsArgumentException()
    {
        var sanPham = new SanPham("1", "SP001", "Product 1", 400.0f, "Purple", "M", 20);
        sanPhamService.Them(sanPham);
        var sanPhamnew = new SanPham("1", "SP001", "Product abc", 450.0f, "Green", "L", 30);
        Assert.Throws<ArgumentException>(() => sanPhamService.Sua("SP999", sanPhamnew));
    }
    [Test]
    public void EditSanPham_ValidMaSanPham_UpdatesSoLuong()
    {
        var sanPham = new SanPham("10", "SP000", "Product 10", 600.0f, "Gray", "M", 15);
        sanPhamService.Them(sanPham);
        var sanPhamnew = new SanPham("10", "SP000", "Product 10", 600.0f, "Gray", "M", 25);
        sanPhamService.Sua("SP000",sanPham);
        var danhsach = sanPhamService.GetAllSP();
        Assert.AreEqual(sanPhamnew.SoLuong, danhsach[0].SoLuong);
    }
    [Test]
    public void EditSanPham_ValidMaSanPham_UpdatesSixevssize()
    {
        var sanPham = new SanPham("10", "SP000", "Product 10", 600.0f, "Gray", "M", 15);
        sanPhamService.Them(sanPham);
        var sanPhamnew = new SanPham("10", "SP000", "Product 10", 600.0f, "Gray", "l", 25);
        sanPhamService.Sua("SP000", sanPham);
        var danhsach = sanPhamService.GetAllSP();
        Assert.AreEqual(sanPhamnew.SoLuong, danhsach[0].SoLuong);
        Assert.AreEqual(sanPhamnew.KichThuoc, danhsach[0].KichThuoc);

    }
}
