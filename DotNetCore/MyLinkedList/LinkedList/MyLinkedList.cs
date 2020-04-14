using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ClrViaDotNet
{
    public sealed class MyLinkedList: IEnumerable
    {
        public Item Head { get; private set; }
        public Item Tail { get; private set; }

        public int Size { get; private set; } = 0;

        public void Add<T>(T data)
        {
            if (typeof(T).IsEnum)
                return;
            
            var current = new Item<T>(data);

            if(Head != null)
            {
                current.Prev = Tail;
                Tail.Next = current;
                Tail = current;
            }
            else
            {
                Head = current;
                Tail = current;
            }

            Size++;
        }

        public void Reverse()
        {
            var tail = Tail;

            var curr = Tail;
            while (curr.Prev != null)
            {
                curr.SwapNextPrev();
                curr = curr.Next;
            }
            Tail = curr.SwapNextPrev();

            Head = tail;
        }


        public object HeadData => Head.DataObj;

        public object TailData => Tail.DataObj;
  
        public bool Remove<T>(T data)
        {
            if (Head == null)
                return false;

            if (Head.Equals<T>(data))
            {
                RemoveHead();
                return true;
            }

            var curr = Head;
            while(curr.Next != null)
            {
                if (curr.Next.Equals<T>(data))
                {
                    curr.Next = curr.Next.Next;
                    curr.Next.Prev = curr;
                    Size--;
                    return true;
                }

                curr = curr.Next;
            }

            return false;
        }

        //public T GetData<T>()
        //{
        //    if (readData is T)
        //    {
        //        return (T)readData;
        //    }
        //    try
        //    {
        //        return (T)Convert.ChangeType(readData, typeof(T));
        //    }
        //    catch (InvalidCastException)
        //    {
        //        return default(T);
        //    }
        //}

        public object this[int i]
        {
            get
            {
                if (i < 0 || i >= Size)
                    throw new IndexOutOfRangeException($"i={i}, Size={Size}");

                var current = Head;
                var index = 0;
                while (index++ < i && current != null)
                {
                    current = current.Next;
                }
                return current.DataObj;
            }
        }

        public void RemoveAll<T>(T data)
        {
            if (data == null)
                return;

            if (Head.Equals<T>(data))
            {
                RemoveHead();
            }

            if (Head == null)
                return;

            var curr = Head;
            while (curr.Next != null)
            {
                //var next = curr.Next;
                if (curr.Next.Equals<T>(data))
                {
                    curr.Next = curr.Next.Next;
                    curr.Next.Prev = curr;
                    Size--;
                }
                curr = curr.Next;
            }

            if (Head.Equals<T>(data))
                RemoveHead(); 
        }

        public Item RemoveHead()
        {
            if (Head == null)
                return null;

            var curr = Head;
            Head = Head.Next;
            Head.Prev = null;
            Size--;
            if (Head == null)
            {
                Tail = null;
            }
            return curr;
        }

        public override string ToString()
        {
            var current = Head;
            var str = new StringBuilder();
            while (current != null)
            {
                str.Append($"{current}, ");
                current = current.Next;
            }

            return str.ToString();
        }


        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
    }
}
