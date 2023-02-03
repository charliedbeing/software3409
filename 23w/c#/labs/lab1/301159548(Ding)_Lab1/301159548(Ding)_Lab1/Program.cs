namespace _301159548_Ding__Lab1

{
    public class Program
    {
       
        static void Main(string[] args)
        {
            // Test for question 1
            TestQuestion1 testQuestion1 = new TestQuestion1();

            testQuestion1.compareArrayAndList();

           testQuestion1.compareStackAndQueue();

            testQuestion1.demo_type_constraint();

            // Test for question 2
            Question2 question2 = new Question2("This is to test whether the extension \r\nmethod count can return a right answer or not");

      
            // Test for question 3
           Question3 question3 = new Question3();

            int size = question3.loadDataToList();

            Console.WriteLine(size);

            question3.searchByGoldNumber(4);

            question3.searchByHasGold();



        }

       

       
    }
}
