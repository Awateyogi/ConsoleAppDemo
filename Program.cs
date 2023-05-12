using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ConsoleAppDemo
{
    public class Branch
    {
        public string Name { get; set; }
        public List<Branch> Branches { get; set; }

        public Branch(string name)
        {
            Name = name;
            Branches = new List<Branch>();

        }

        public void Addbranch(Branch branch)
        {
            Branches.Add(branch);
        }


        public void Displaytbranches(int depth)
        {
            string a = new string('-', depth);
            Console.WriteLine($"{a}{Name}");
            foreach (var branch in Branches)
            {

                branch.Displaytbranches(depth + 1);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Find Clock Angle ");


            //at 12 hourse hourse hand conplete 360 degree.
            //at every 1 hour hourse hand comlete 360/12 =  30 degree.
            //in 1 hour their are 60 minuts so hourse hand complete 30 degree at 60 minuts
            //at every 1 minut hourse hand complete  30/60 = 0.5 degree
            //at 60  minutes minute hand complete 360 degree.
            //at every 1 minute minutes hand complete 360/60= 6 degree
            //total angle comleted from hourse hand is = Total minutes completed by houres hand * the angle completed from houre hand in one minutes 
            //total angle completed from minutes hand is = total minutes completed by minutes hand * the angle completed from minutes hand in one minute

            //The angle between houres and minutes hand =  total angle completed from minutes  or hourse hand - total angle comleted from hourse or nimutes hand
            //at programming  their we take  hh:mm so 
            //the angle completed by hourse hand(ph) = [(hh*60) + mm ] * 0.5 degree
            //the angle completed by minutes hand(mh) = mm * 6 degree
            //so Net angle Between hourse and minutes hand is = ph - mh

            Console.Write("Enter Hourse : ");
            int HOURSE = int.Parse(Console.ReadLine());

            Console.Write("Enter Minutes : ");
            int MINUTES = int.Parse(Console.ReadLine());

            Double HOURSEANGLE = ((HOURSE * 60) + MINUTES) * 0.5;
            Double MINUTESANGLE = MINUTES * 6;

            Double NETDIFFANGLE = Math.Abs(HOURSEANGLE - MINUTESANGLE);

            //TO CALCULATE MINIMUM ANGLE 
            if (NETDIFFANGLE < 360 - NETDIFFANGLE)
            {
                Console.WriteLine("Angle between " + HOURSE + " Houre and " + MINUTES + " minutes  is " + NETDIFFANGLE + " Degree");



                Console.ReadLine();
            }
            else
            {
                NETDIFFANGLE = 360 - NETDIFFANGLE;
                Console.WriteLine("Angle between " + HOURSE + " Houre and " + MINUTES + " minutes  is " + NETDIFFANGLE + " Degree");


                Console.ReadLine();
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------------------");

            Console.WriteLine(" 2) Branch Hierarchi ");



            Console.WriteLine("Enter the depth of Hierarchi  :   ");
            int hDepth = Convert.ToInt32(Console.ReadLine());

            var rtbranch = new Branch("RootClock");

            //vreate new branches
            var branch1 = new Branch(" " + HOURSE + "");
            var branch2 = new Branch(" " + MINUTES + "");
            var branch3 = new Branch(" " + NETDIFFANGLE + " ");

            //add branches to root branch
            rtbranch.Addbranch(branch1);
            rtbranch.Addbranch(branch2);

            //add subbranch to branch
            var subbranchH = new Branch("subbranchofHoureH1");
            branch1.Addbranch(subbranchH);
            var subbranchh1 = new Branch("subbranchofHoureH2");
            branch1.Addbranch(subbranchh1);

            //add sub sub branch to sub branch
            var subbranchM = new Branch("subbranchofMinuteM1");
            branch2.Addbranch(subbranchM);


            var subsubbranchH1 = new Branch("subsubbranchofBranchofHoure");
            subbranchH.Addbranch(subsubbranchH1);

            rtbranch.Addbranch(branch3);


            rtbranch.Displaytbranches(hDepth);

            Console.ReadLine();




        }
    }
}
