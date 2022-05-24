using System;
using System.Linq;

namespace AlgorithmComparer
{
    class Program
    {
        static void Main()
        {
            new Program().Run();
        }

        private void Run()
        {
            var numberManager = new NumberManager();
            var printer = new Printer();

            int[] array = numberManager.GenerateRandomArray(500000);
            printer.PrintArray(array, "Generated array");

            var testEngine = new TestEngine();
            var algEng = new AlgorithmEngine();

            var heapSortArray = numberManager.CopyArray(array);
            var mergeSortArray = numberManager.CopyArray(array);
            var quickSortArray = numberManager.CopyArray(array);
            var timSortArray = numberManager.CopyArray(array);

            testEngine.ExecuteTestScenario(
                heapSortArray,
                () => algEng.HeapSort(heapSortArray, heapSortArray.Length - 1),
                "HeapSort");

            testEngine.ExecuteTestScenario(
                mergeSortArray,
                () => algEng.MergeSort(mergeSortArray, 0, mergeSortArray.Length - 1),
                "MergeSort");

            testEngine.ExecuteTestScenario(
                timSortArray,
                () => algEng.TimSort(timSortArray, timSortArray.Length),
                "TimSort");

            testEngine.ExecuteTestScenario(
                quickSortArray,
                () => algEng.QuickSort(quickSortArray, 0, quickSortArray.Length - 1),
                "QuickSort");
        }
    }
}
