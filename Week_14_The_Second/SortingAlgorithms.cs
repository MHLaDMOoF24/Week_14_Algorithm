using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_14_The_Second
{
    public class SortingAlgorithms
    {
        public void SelectionSort(Student[] students)
        {
            int n = students.Length;
            Student temp = new Student("", 0);

            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                    if (students[j].GroupNumber < students[min].GroupNumber)
                        min = j;
                temp = students[min];
                students[min] = students[i];
                students[i] = temp;
            }
        }

        //================
        public void BubbleSort(Student[] students)
        {
            int n = students.Length;
            int i, j;
            Student temp = new Student("", 0);
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(students[j].FullName, students[j + 1].FullName) > 0)
                    {

                        // Swap arr[j] and arr[j+1]
                        temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped by inner loop, then break
                if (swapped == false)
                    break;
            }
        }

        //=================
        public void QuickSort(Student[] students,int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p] is now at right place
                int partIndex = Partition(students, low, high);

                // Separately sort elements before and after partition index
                QuickSort(students, low, partIndex - 1);
                QuickSort(students, partIndex + 1, high);
            }
        }
        static int Partition(Student[] students, int low, int high)
        {
            // Choosing the pivot
            Student pivot = students[high];

            // Index of smaller element and indicates the right position of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller than the pivot
                if (string.Compare(students[j].FullName, pivot.FullName) > 0)
                {

                    // Increment index of smaller element
                    i++;
                    Swap(students, i, j);
                }
            }
            Swap(students, i + 1, high);
            return (i + 1);
        }
        static void Swap(Student[] arr, int i, int j)
        {
            Student temp = new Student("", 0);
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

    }
}
