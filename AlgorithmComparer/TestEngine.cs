using System;

namespace AlgorithmComparer
{
    public class TestEngine
    {
        NumberManager _numberManager;
        public TestEngine()
        {
            _numberManager = new NumberManager();
        }

        public void ExecuteTestScenario(int[] array, Action action, string algorithmName)
        {
            //Run algorithm on not sorted array
            ExecuteTest(action, algorithmName, "Not sorted array");

            //Run algorithm on sorted array
            ExecuteTest(action, algorithmName, "Sorted array");

            //Reverse array
            _numberManager.ReverseArray(array);

            //Run algorithm on reversed array
            ExecuteTest(action, algorithmName, "Reversed sorted array");
        }

        private void ExecuteTest(Action action, string algorithmName, string testDescription)
        {
            var stopWatch = new ExecStopWatch();
            var execTime = stopWatch.CountExecTime(action);

            Console.WriteLine($"{algorithmName} -> {testDescription}:");
            Console.WriteLine($"Execution time: {execTime}");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
