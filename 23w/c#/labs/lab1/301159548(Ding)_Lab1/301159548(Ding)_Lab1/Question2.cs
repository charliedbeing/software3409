using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301159548_Ding__Lab1
{
    public class Question2
    {
        private StringBuilder sb;

        public Question2()
        {
            this.sb = new StringBuilder();  
        }
        public void append(string text)
        {
            this.sb.Append(text);
        }
        public Question2(string text)
        {
            this.sb = new StringBuilder();
            this.sb.Append(text);
        }

        public  int countOfString()
        {
            String s = this.sb.ToString();
            return  s.Split(' ').Length;
        }
    }
}
