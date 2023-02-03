using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _301159548_Ding__Lab1
{
    public class Question3
    {
        private List<Athlete> Athletes;
        private SearchTool<Athlete> searchTool;
        public Question3() {
            this.Athletes = new List<Athlete>();
            this.searchTool = new SearchTool<Athlete>();
        }

        public int loadDataToList()
        {

            //new StreamReader(@"C:\Users\charl\source\repos\23W\c#\301159548(Ding)_Lab1\medalist.csv")
            using (var reader = new StreamReader("medalist.csv"))
            {
                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (index > 0)
                    {
                        Athlete athlete = new Athlete(values[0],Int16.Parse(values[1])
                            , Int16.Parse(values[2]), Int16.Parse(values[3]), Int16.Parse(values[4]));
                        this.Athletes.Add(athlete);
                    }
                    index++;
                }
            }
            return this.Athletes.Count;

        }
        // 1 add new medalist 
        public void addAthlete(Athlete athlete)
        {
            this.Athletes.Add(athlete);
        }

        //2 delete a specific athlete with name and year
        public bool deleteAthlete(string name, int year)
        {
            bool result = false;
            int index = -1;

            for(int i=0;i<this.Athletes.Count;++i) {
                Athlete current = this.Athletes[i];
                if(current.Name.Equals(name) && current.Year == year)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                this.Athletes.RemoveAt(index);
                result= true;
            }

            return result;
         
        }
        // 3: search method 
        public List<Athlete> searchByGoldNumber(int gold)
        {
            List < Athlete > result = new List < Athlete >();
            result = (List<Athlete>)this.searchTool.searchByGold(this.Athletes, gold);

            Console.WriteLine(result.Count);
            
            return result;
        }
        public List<Athlete> searchByHasGold()
        {
            List<Athlete> result = new List<Athlete>();
            result = (List<Athlete>)this.searchTool.searchByHasGold(this.Athletes);

            Console.WriteLine(result.Count);

            return result;
        }


    }
    public class SearchTool<T> where T : Athlete


    {

        public SearchTool() { }

        public  IEnumerable<T> searchByGold(List<T> list,int goldMedals)
        {
            List<T> result = new List<T>();
            AthleteByGold athleteByGold = new AthleteByGold(goldMedals);

            foreach (T item in list)
            {
                if(athleteByGold.CompareTo(item)==0)
                {
                    result.Add(item);
                }
            }

            return result;
        }
        public IEnumerable<T> searchByHasGold(List<T> list)
        {
            List<T> result = new List<T>();
            AthleteByGold athleteByGold = new AthleteByGold();

            foreach (T item in list)
            {
                if (athleteByGold.CompareTo(item) > 0)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }

    public class Athlete
    {
        private string name;
        private int year;
        private int gold_medals;
        private int silver_medals;
        private int bronze_medals;


        public string Name{ get { return name; } }
        public int Year { get { return year;}}
        public int Gold_madals { get { return gold_medals; } }
        public int Silver_madals { get { return silver_medals; } }
        public int Bronze_madals { get { return bronze_medals; } }

        public Athlete() { }

        public Athlete(string n, int y, int gold,int silver,int bronze) {
            this.name = n;
            this.year = y;
            this.gold_medals = gold;
            this.silver_medals = silver;
            this.bronze_medals= bronze;
        }

       
    }

    public class AthleteByGold : Athlete
    {
        public AthleteByGold(int gold):base("",0,gold,0,0)
        {
            
        }

        public AthleteByGold() { }

       public int CompareTo(Athlete obj)
        {
           int result = -1;
          
            if(this.Gold_madals == obj.Gold_madals)
            {
                result = 0;
            }else if (obj.Gold_madals > 0)
            {
                result = 1;
            }

            return result;
        }
    }


}
