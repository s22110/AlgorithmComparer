using System;
using System.Linq;

namespace AlgorithmComparer
{
    public class AlgorithmEngine
    {
        #region MergeSort
        public void MergeSort(int[] numbers, int low, int high)
        {
            int mid;
            if (high > low)
            {
                mid = (high + low) / 2;
                MergeSort(numbers, low, mid);
                MergeSort(numbers, (mid + 1), high);
                MainMerge(numbers, low, (mid + 1), high);
            }
        }

        private void MainMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[numbers.Count()];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }
            while (left <= eol)
                temp[pos++] = numbers[left++];
            while (mid <= right)
                temp[pos++] = numbers[mid++];
            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        #endregion

        #region QuickSort
        public void QuickSort(int[] array, int low, int high)
        {
            int[] stack = new int[high - low + 1];

            int top = -1;

            stack[++top] = low;
            stack[++top] = high;

            while (top >= 0)
            {
                high = stack[top--];
                low = stack[top--];

                int p = Partition(array, low, high);

                if (p - 1 > low)
                {
                    stack[++top] = low;
                    stack[++top] = p - 1;
                }

                if (p + 1 < high)
                {
                    stack[++top] = p + 1;
                    stack[++top] = high;
                }
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int temp;
            int pivot = array[high];

            int i = (low - 1);
            for (int j = low; j <= high - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;

                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;

            return i + 1;
        }
        #endregion

        #region HeapSort
        public void HeapSort(int[] arr, int arrLength)
        {
            for (int i = arrLength / 2 - 1; i >= 0; i--)
                Heapify(arr, arrLength, i);
            for (int i = arrLength - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }

        private void Heapify(int[] arr, int arrLength, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < arrLength && arr[left] > arr[largest])
                largest = left;
            if (right < arrLength && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(arr, arrLength, largest);
            }
        }
        #endregion

        #region TimSort
        public void TimSort(int[] arr, int n)
        {
            int run = 32;

            // Sort individual subarrays of size RUN
            for (int i = 0; i < n; i += run)
                InsertionSort(arr, i, Math.Min((i + run - 1), (n - 1)));

            // Start merging from size RUN (or 32).
            // It will merge
            // to form size 64, then
            // 128, 256 and so on ....
            for (int size = run; size < n; size = 2 * size)
            {

                // Pick starting point of
                // left sub array. We
                // are going to merge
                // arr[left..left+size-1]
                // and arr[left+size, left+2*size-1]
                // After every merge, we increase
                // left by 2*size
                for (int left = 0; left < n; left += 2 * size)
                {

                    // Find ending point of left sub array
                    // mid+1 is starting point of
                    // right sub array
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    // Merge sub array arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                        Merge(arr, left, mid, right);
                }
            }
        }

        private void Merge(int[] arr, int l, int m, int r)
        {
            // original array is broken in two parts
            // left and right array
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];

            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];

            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

            // After comparing, we merge those two array
            // in larger sub array
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }

                k++;
            }

            // Copy remaining elements
            // of left, if any
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            // Copy remaining element
            // of right, if any
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        public void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }
        #endregion
    }
}
