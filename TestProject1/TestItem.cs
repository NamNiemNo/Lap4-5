using Lap5_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ItemTests
    {
        private ItemManager itemManager;

        [SetUp]
        public void Setup()
        {
            itemManager = new ItemManager();
        }

        [Test]
        public void ThemSanPham_ValidItem_ShouldAddItem()
        {
            var item = new Item(1, "ValidItem");

            itemManager.AddItem(item);

            Assert.AreEqual(1, itemManager.items.Count);
            Assert.AreEqual(item, itemManager.items[0]);
        }

        [Test]
        public void ThemSanPham_TenSanPhamQuaDai_ShouldThrowException()
        {
            var item = new Item(1, new string('a', 51));

            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }

        [Test]
        public void ThemSanPham_TenSanPhamKhongPhaiChu_ShouldThrowException()
        {
            var item = new Item(1, "123");

            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }

        [Test]
        public void CapNhatSanPham_ValidItem_ShouldUpdateItem()
        {
            var item = new Item(1, "Name");
            itemManager.AddItem(item);
            var newName = "Name1";

            itemManager.UpdateItem(1, newName);

            Assert.AreEqual(newName, itemManager.items[0].Name);
        }

        [Test]
        public void CapNhatSanPham_SanPhamKhongTimThay_ShouldDoNothing()
        {
            var initialCount = itemManager.items.Count;

            var newName = "Updated Name";
            itemManager.UpdateItem(1, newName);
            Assert.AreEqual(initialCount, itemManager.items.Count); 
        }

        [Test]
        public void CapNhatSanPham_TenSanPhamQuaDai_ShouldThrowException()
        {
            var item = new Item(1, "Name");
            itemManager.AddItem(item);
            var newName = "NewNameToolong";
            Assert.Throws<ArgumentException>(() => itemManager.UpdateItem(1, newName));
        }

        [Test]
        public void CapNhatSanPham_TenSanPhamKhongPhaiChu_ShouldThrowException()
        {
            var item = new Item(1, "OriName");
            itemManager.AddItem(item);
            var newName = "123";
            Assert.Throws<ArgumentException>(() => itemManager.UpdateItem(1, newName));
        }

        [Test]
        public void XoaSanPham_SanPhamTonTai_ShouldDeleteItem()
        {
            var item = new Item(1, "ItemToDelete");
            itemManager.AddItem(item);
            itemManager.DeleteItem(1);
            Assert.AreEqual(0, itemManager.items.Count);
        }

        [Test]
        public void XoaSanPham_SanPhamKhongTimThay_ShouldDoNothing()
        {
            var initialCount = itemManager.items.Count;
            itemManager.DeleteItem(1);
            Assert.AreEqual(initialCount, itemManager.items.Count);
        }

        [Test]
        public void ThemSanPham_TenSanPhamRong_ShouldThrowException()
        {
            var item = new Item(1, "");
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
    }

}

