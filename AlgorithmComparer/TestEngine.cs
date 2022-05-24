using System;

namespace AlgorithmComparer
{
    public class TestEngine
    {
        private NumberManager _numberManager;
        private Printer _printer;
        public TestEngine()
        {
            _numberManager = new NumberManager();
            _printer = new Printer();
        }

        public void ExecuteTestScenario(int[] array, Action action, string algorithmName)
        {
            //Run algorithm on not sorted array
            ExecuteTest(action, algorithmName, "Not sorted array");
            _printer.PrintArray(array, "Array after sorting");

            //Run algorithm on sorted array
            ExecuteTest(action, algorithmName, "Sorted array");
            _printer.PrintArray(array, "Array after sorting");

            //Reverse array
            _numberManager.ReverseArray(array);
            _printer.PrintArray(array, "Reversed array");

            //Run algorithm on reversed array
            ExecuteTest(action, algorithmName, "Reversed sorted array");
            _printer.PrintArray(array, "Array after sorting");
        }

        private void ExecuteTest(Action action, string algorithmName, string testDescription)
        {
            var stopWatch = new ExecStopWatch();
            var execTime = stopWatch.CountExecTime(action);

            Console.WriteLine($"{algorithmName} -> {testDescription}:");
            Console.WriteLine($"Execution time: {execTime}");
            Console.WriteLine();
        }

    }
}
