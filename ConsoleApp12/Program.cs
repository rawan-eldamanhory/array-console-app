using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Array
    {
        private int[] _items;
        private int _size;
        private int _length;

        public int Size => _size;
        public int Length => _length;

        public Array(int size)
        {
            _size = size;
            _length = 0;
            _items = new int[size];
        }

        //fill the Array
        void Fill()
        {
            int no_of_items;
            Console.WriteLine("How many items you want to fill ? ");
            no_of_items = int.Parse(Console.ReadLine());
            if (no_of_items>_size)
            {
                Console.WriteLine("You cannot exceed the Array size");
                return;
            }
            else
            {
                for(int i=0; i<no_of_items; i++)
                {
                    Console.WriteLine("Enter item " + i);
                    _items[i] = int.Parse(Console.ReadLine());
                    _length++;
                }
            }
        }

        //Array size
        int GetSize()
        {
            return _size;
        }

        //Array length
        int GetLenght()
        {
            return _length;
        }

        //traverse
        void Display()
        {
            Console.WriteLine("Display Array content: ");
            for (int i = 0; i < _length; i++)
                Console.WriteLine(_items[i]);
        }

        //traverse
        //foreach (int x in a)
        //Console.WriteLine(x);

        //reverse
        void Reverse()
        {
            Console.WriteLine("Array Content after reverse : ");
            for (int i = _length - 1; i >= 0; i--)
                Console.WriteLine(_items[i]);
        }

        //min
        void Min()
        {
            int min = _items[0];
            for (int i = 0; i < _length; i++)
                if (_items[i] < min)
                    min = _items[i];
            Console.WriteLine("The minimum item = " + min);
        }

        //max
        void Max()
        {
            int max = _items[0];
            for (int i = 0; i < _length; i++)
                if (_items[i] > max)
                    max = _items[i];
            Console.WriteLine("The maximum item = " + max);
        }

        //insert at end
        void Add(int newitem)
        {
            if (_length < _size)
            {
                _items[_length] = newitem;
                _length++;
            }
            else
            {
                Console.WriteLine("You cannot add ! Array is full.");
            }
        }

        //insert at any place
        void Insert(int index, int newitem)
        {
            if(index >= 0 && index < _size)
            {
                for(int i=_length; i > index; i--)
                {
                    _items[i] = _items[i - 1];
                }
                _items[index] = newitem;
                _length++;
            }
            else
            {
                Console.WriteLine("Error!! Index is out of range.");
            }
        }

        //delete
        void Delete(int index)
        {
            if(index >= 0 && index < _size)
            {
                for (int i = index; i < _length - 1; i++)
                    _items[i] = _items[i + 1];
                _length--;
            }
            else
            {
                Console.WriteLine("Error!! Index is out of range.");
            }
        }

        //sequential search
         int sequentialSearch(int searchNumber)
        {
            for(int i=0; i<_length; i++)
            {
                if (_items[i] == searchNumber)
                {
                    return i;
                }
            }
            return -1; 
        }

        //binary search
        void Binarysearch(int searchNumber)
        {
            int low = 0;
            int high = _items.Length - 1;
            int mid = 0; 

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (searchNumber > _items[mid])
                {
                    low = mid + 1;
                }
                if (searchNumber < _items[mid])
                {
                    high = mid - 1;
                }
                if (searchNumber == _items[mid])
                {
                    Console.WriteLine("This item found at index : " + mid);
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            int Arraysize;
            Console.WriteLine("Enter the Array size : ");
            Arraysize = int.Parse(Console.ReadLine());
            Array myArray = new Array(Arraysize);
            myArray.Fill();
            Console.WriteLine("Array Size = " + myArray.GetSize());
            Console.WriteLine("Array Length = " + myArray.GetLenght());
            myArray.Display();

            myArray.Reverse();

            myArray.Min();

            myArray.Max();

            int newitem;
            Console.WriteLine("Enter the new item that you want to add to Array : ");
            newitem = int.Parse(Console.ReadLine());
            myArray.Add(newitem);
            Console.WriteLine("Array Size = " + myArray.GetSize());
            Console.WriteLine("Array Length = " + myArray.GetLenght());
            myArray.Display();

            int index;
            Console.WriteLine("Enter index of item that you want to add to Array : ");
            index = int.Parse(Console.ReadLine());
            int Newitem;
            Console.WriteLine("Enter value of item that you want to add to Array : ");
            Newitem = int.Parse(Console.ReadLine());
            myArray.Insert(index, Newitem);
            Console.WriteLine("Array Size = " + myArray.GetSize());
            Console.WriteLine("Array Length = " + myArray.GetLenght());
            myArray.Display();

            int Index;
            Console.WriteLine("Enter index of item that you want to delete from Array : ");
            Index = int.Parse(Console.ReadLine());
            myArray.Delete(Index);
            Console.WriteLine("Array Size = " + myArray.GetSize());
            Console.WriteLine("Array Length = " + myArray.GetLenght());
            myArray.Display();

            int Searchnumber;
            Console.WriteLine("Enter the value of the item that you want to search for : ");
            Searchnumber = int.Parse(Console.ReadLine());
            int INDEX = myArray.sequentialSearch(Searchnumber);
            if (INDEX == -1)
                Console.WriteLine("This item not found ! ");
            else
                Console.WriteLine("This Item found at index : " + INDEX);

            int SearchNumber;
            Console.WriteLine("Enter the value of the item that you want to search for : ");
            SearchNumber = int.Parse(Console.ReadLine());
            myArray.Binarysearch(SearchNumber);


            Console.ReadKey();
        }
    }
}
