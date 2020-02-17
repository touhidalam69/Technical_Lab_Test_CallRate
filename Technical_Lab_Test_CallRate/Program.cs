using System;

namespace Technical_Lab_Test_CallRate
{
    class Program
    {
        static void Main(string[] args)
        {
            string pickHourStart = "9:00:00 AM";
            string pickHourEnd = "10:59:59 PM";
            DateTime startTime = System.DateTime.Now;
            DateTime endTime = System.DateTime.Now;
            double differenceInSecond = 0;
            int pulseInSec = 20;
            double callRate = 0;
            double PhoneBillAmountPaisa = 0;

            Console.WriteLine("Please Input Start Time" + Environment.NewLine + "('yyyy-MM-dd hh:mm:ss AM')");
            startTime = Convert.ToDateTime(Console.ReadLine().Trim());
            Console.WriteLine(Environment.NewLine + "################################");
            Console.WriteLine("Please Input End Time" + Environment.NewLine + "('yyyy-MM-dd hh:mm:ss PM')");
            endTime = Convert.ToDateTime(Console.ReadLine().Trim());

            differenceInSecond = (double)(endTime - startTime).TotalSeconds;


            DateTime pickHourStartTempForCallStart = Convert.ToDateTime(startTime.ToShortDateString() + " " + pickHourStart);
            DateTime pickHourEndTempForCallStart = Convert.ToDateTime(startTime.ToShortDateString() + " " + pickHourEnd);

            DateTime pickHourStartTempForCallEnd = Convert.ToDateTime(endTime.ToShortDateString() + " " + pickHourStart);
            DateTime pickHourEndTempForCallEnd = Convert.ToDateTime(endTime.ToShortDateString() + " " + pickHourEnd);

            Console.WriteLine(Environment.NewLine + Environment.NewLine + "################ Breakdown ################");
            for (int i = 0; i <= differenceInSecond; i = (i + pulseInSec))
            {
                DateTime tempEndTime = startTime.AddSeconds(pulseInSec);
                if ((startTime >= pickHourStartTempForCallStart && startTime <= pickHourEndTempForCallStart) || (tempEndTime >= pickHourStartTempForCallEnd && tempEndTime <= pickHourEndTempForCallEnd))
                {
                    callRate = 30;
                }
                else
                {
                    callRate = 20;
                }

                PhoneBillAmountPaisa += GetPhoneBill(pulseInSec, callRate, pulseInSec);

                Console.WriteLine("{0} + 20 second({1})={2} paisa", startTime, tempEndTime, callRate);
                startTime = startTime.AddSeconds(pulseInSec);
            }

            Console.WriteLine(Environment.NewLine + Environment.NewLine + "################ Call Summery ################");
            Console.WriteLine("Total Call Duration {0} Second/ {1} Minutes", differenceInSecond, Math.Round((differenceInSecond / 60), 2));
            Console.WriteLine("Total bill in Paisa: {0}", PhoneBillAmountPaisa);
            double billInTaka = PhoneBillAmountPaisa / 100;
            Console.WriteLine("Total bill in Taka: {0}", billInTaka);

            Console.Read();
        }

        private static double GetPhoneBill(double durationInSecond, double callRate, int pulseInSec)
        {
            double PhoneBillAmount = 0;
            int pulseCount = Convert.ToInt32(durationInSecond) / pulseInSec;
            int extraSecond = Convert.ToInt32(durationInSecond) % pulseInSec;
            if (extraSecond != 0)
            {
                pulseCount++;
            }

            PhoneBillAmount = pulseCount * callRate;
            return PhoneBillAmount;
        }
    }
}
