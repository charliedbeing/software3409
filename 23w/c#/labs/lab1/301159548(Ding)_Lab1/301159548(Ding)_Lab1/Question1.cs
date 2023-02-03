using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301159548_Ding__Lab1
{
    public class Question1<T>where T:class
    {
        private T[] _arr;
        private LinkedList<T> _list;
        private Stack<T> _stack;
        private Queue<T> _queue;

        public Question1()
        {
            this._arr = new T[5];
            this._list = new LinkedList<T>();
            this._stack = new Stack<T>();
            this._queue = new Queue<T>();
        }

        public T[] _Arr { get; set; }
        public LinkedList<T> _List { get; set; }
        public Stack<T> _Stack { get; set; }
        public Queue<T> _Queue { get; set; }

        public void print_seq<T>(ICollection<T> seq)
        {
            foreach(T item in seq)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void print_stack<T>(Stack<T> seq)
        {
            foreach (T item in seq)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void print_queue<T>(Queue<T> seq)
        {
            foreach (T item in seq)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

   public class TestQuestion1 {

       private  Question1<String> question1;

        public TestQuestion1()
        {
            this.question1 = new Question1<string>();
        }
        //1.1 Array vs linked list
        public void compareArrayAndList()
        {
            question1._Arr = new string[5];
            question1._List = new LinkedList<string>();

            //1 add

            for (int i = 0; i < 5; i++)
            {
                question1._Arr[i] = "item" + i;
                question1._List.AddLast("item" + i);
            }

            question1.print_seq(question1._Arr);
            Console.WriteLine("========");
            question1.print_seq(question1._List);

            // 2 get second item
            Console.WriteLine("=====get second item ===");
            Console.WriteLine(question1._Arr[1]);
            Console.WriteLine(question1._List.First.Next.Value);

            // 3 delete third item

            Console.WriteLine("=====3 delete third item ===");
            // 3.1 array
            string[] arr2 = new string[question1._Arr.Length - 1];
            int index = 0;
            for(int i = 0; i < question1._Arr.Length; i++)
            {
                if (i != 2)
                {
                    arr2[index] = question1._Arr[i];
                    index += 1;

                }
            }
            question1._Arr = arr2;
            Console.WriteLine("=====3.1 arr result ===");
            question1.print_seq(question1._Arr);

            //3.2 LinkedList

            question1._List.Remove(question1._List.First.Next.Next);
            Console.WriteLine("=====3.2 list result ===");
            question1.print_seq(question1._List);


            //4 update the last item to "Charlie"

            question1._Arr[question1._Arr.Length - 1] = "Charlie";

            Console.WriteLine("=====4.1 Arr result ===");
            question1.print_seq(question1._Arr);

            question1._List.RemoveLast();
            question1._List.AddLast("Charlie");

            Console.WriteLine("=====4.2 List result ===");
            question1.print_seq(question1._List);

        }

        //1.2 stack vs queue
        public void compareStackAndQueue()
        {
            question1._Stack = new Stack<string>();
            question1._Queue = new Queue<string>();

            // 1:add 

            for (int i = 0; i < 5; i++)
            {
                question1._Stack.Push("item" + i);
                question1._Queue.Enqueue("item" + i);
            }
            Console.WriteLine("=====1 add  ===");
            Console.WriteLine("=====1.1 stack add  ===");
            question1.print_stack(question1._Stack);
            Console.WriteLine("=====1.1 queue add  ===");
            question1.print_queue(question1._Queue);

            // 2:get   Stack try to get item2 , you have to remove item3,item4

            question1._Stack.Pop(); // remove 4
            question1._Stack.Pop();
      
            string get_itme2_stack = question1._Stack.Pop();

            Console.WriteLine("=====2.1 get item2  ===");
            Console.WriteLine(get_itme2_stack);

            Console.WriteLine("=====2.2 after get item2  ===");
            question1.print_stack(question1._Stack);

            //Queue try to get item2, you have to remove item0, item1


            question1._Queue.Dequeue();
            question1._Queue.Dequeue();

            string get_itme2_queue = question1._Queue.Dequeue();
            Console.WriteLine("=====2.1 queue get item2  ===");
            Console.WriteLine("=====2.1 get item2  ===");
            Console.WriteLine(get_itme2_queue);

            Console.WriteLine("=====2.2 after get item2  ===");
            question1.print_queue(question1._Queue);

         

        }


        //1.3 type constraint
        public void demo_type_constraint()
        {
            // Question1<int> demo = new Question1<int>(); // 
          //   Question1<long> demo = new Question1<long>();


        }
    }

}
