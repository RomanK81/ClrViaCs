using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ClrViaDotNet
{

    public class Item
    {
        public Item Prev { get; set; } = null;
        public Item Next { get; set; } = null;

        public object DataObj => datObj.Value;

        public bool IsValueType<T>()
        {
            return typeof(T).IsValueType;
        }

        private Lazy<object> datObj => new Lazy<object>(GetType().GetProperty("Data").GetValue(this, null));

        public bool Equals<T>(T data)
        {
            //var t = itemData.GetType();
            //var t1 = data.GetType();
            if (DataObj.GetType() != typeof(T))
                return false;
            return (((T)DataObj).Equals(data));
        }

    }

    public static class ItemExtensions
    {
        public static Item SwapNextPrev(this Item curr)
        {
            var prev = curr.Prev;
            curr.Prev = curr.Next;
            curr.Next = prev;
            return curr;
        }
    }

    public class Item<T>: Item, IEquatable<T>
    {
        public Item(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public override bool Equals(object obj)
        {
            //if(obj.GetType(Item<T>))
            return Data.Equals(obj);
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }

        public bool Equals([AllowNull] T other)
        {
            return Equals(other);
        }

        //public static bool operator ==(Item<T> i1, Item<T> i2) { return i1.Data.Equals(i2.Data); }
        //public static bool operator != (Item<T> i1, Item<T> i2) { return !i1.Data.Equals(i2.Data); }
        public static bool operator ==(Item<T> i1, T d2) { return i1.Data != null && i1.Data.Equals(d2); }
        public static bool operator !=(Item<T> i1, T d2) { return !i1.Equals(d2); }
    }

}
