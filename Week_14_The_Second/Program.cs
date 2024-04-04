namespace Week_14_The_Second
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            DataHandler dataHandler = new DataHandler("students.txt");
            SortingAlgorithms sortingAlgorithms = new SortingAlgorithms();


            Student[] loadedStudents = dataHandler.LoadStudents();
            while (true)
            {
                Console.WriteLine("\n  -- Sorting menu: ");
                Console.WriteLine("1) Sort by Group Number (Selection Sort)");
                Console.WriteLine("2) Sort by Full Name (Bubble Sort)");
                Console.WriteLine("3) Sort by Full Name (Quick Sort)");
                Console.Write("\n -- Please select a sorting type: ");
                string selector = Console.ReadLine();
                Console.Clear();
                switch (selector)
                {
                    case "1":
                        Console.WriteLine("Selection Sorting by GroupNumber: ");
                        sortingAlgorithms.SelectionSort(loadedStudents);
                        PrintStudents(loadedStudents);
                        break;
                    case "2":
                        Console.WriteLine("Bubble Sorting by FullName: ");
                        sortingAlgorithms.BubbleSort(loadedStudents);
                        PrintStudents(loadedStudents);
                        break;
                    case "3":
                        Console.WriteLine("Quick Sorting by FullName: ");
                        // -1 for array length adjustment
                        sortingAlgorithms.QuickSort(loadedStudents, 0, loadedStudents.Length - 1);
                        PrintStudents(loadedStudents);
                        break;
                    default:
                        break;
                }
            }
            

            

            




        }

        public static void PrintStudents(Student[] loadedStudents)
        {
            int i = 1;
            foreach (Student student in loadedStudents)
            {
                if ((student.GroupNumber % 2) == 0)
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine($"{i}) {student.FullName} fra gruppe {student.GroupNumber}");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
