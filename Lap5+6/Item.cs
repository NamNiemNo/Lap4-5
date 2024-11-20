using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5_6
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }



    public class ItemManager
    {
        public List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            if (string.IsNullOrEmpty(item.Name) || !IsValidName(item.Name))
            {
                throw new ArgumentException("ten item phải là chữ");
            }

            if (item.Name.Length > 10)
            {
                throw new ArgumentException("ten item không được quá 10 kí tự ");
            }

            items.Add(item);
        }

        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        public void UpdateItem(int id, string newName)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                if (string.IsNullOrEmpty(newName) || !IsValidName(newName))
                {
                    throw new ArgumentException("ten item phải là chữ");
                }

                if (newName.Length > 10)
                {
                    throw new ArgumentException("ten item không được quá 10 kí tự ");
                }
                item.Name = newName;
            }
        }

        public void DeleteItem(int id)
        {
            items.RemoveAll(i => i.Id == id);
        }
    }

}
