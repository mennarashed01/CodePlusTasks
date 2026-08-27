namespace StudentGradeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name , Grade;
            double examScore = 0 , AttendanceRate= 0;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("    Student Eligibility & Grade System");
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("\nPLease Enter Student Data");
            Console.WriteLine("-----------------------------");
            
            Console.Write("Name: ");
            name = Console.ReadLine();

            while (true)
            {
                Console.Write("Exam Score (0 to 100): ");
                if (!double.TryParse(Console.ReadLine(), out examScore))
                {
                    Console.WriteLine("Invalid Input: Values must be between 0 and 100.");
                    continue;
                }

                if (examScore < 0 || examScore > 100)
                {
                    Console.WriteLine("Invalid Input: Values must be between 0 and 100.");
                    continue;
                }

                break;

            }

            while (true)
            {
                Console.Write("Attendace Rate (0 to 100): ");
                if (!double.TryParse(Console.ReadLine(), out AttendanceRate))
                {
                    Console.WriteLine("Invalid Input: Values must be between 0 and 100.");
                    continue;
                }

                if (AttendanceRate < 0 || AttendanceRate > 100)
                {
                    Console.WriteLine("Invalid Input: Values must be between 0 and 100.");
                    continue;
                }

                break;

            }



            Console.WriteLine("--------------------------------\n\n");
            if(AttendanceRate < 75)
            {
                Console.WriteLine("Status: Failed \nReason: Low Attendance Rate ");
            }
            else
            {
                if (examScore >= 90)
                    Grade = "A (Excellent)";
                else if (examScore >= 80)
                    Grade = "B (Very Good)";
                else if (examScore >= 70)
                    Grade = "C (Good)";
                else if (examScore >= 50)
                    Grade = "D (Pass)";
                else
                    Grade = "F (Fail)";

                Console.WriteLine($"Your Grade is : {Grade}");

            }

            

        }
    }
}
