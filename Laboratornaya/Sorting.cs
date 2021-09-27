using System;
using System.Collections.Generic;
using System.Linq;

public class Sort
{
    public void BubbleSort(int[] mas)
    {
        int temp;
        for (int i = 0; i < mas.Length - 1; i++)
        {
            for (int j = 0; j < mas.Length - i - 1; j++)
            {
                if (mas[j + 1] < mas[j])
                {
                    temp = mas[j + 1];
                    mas[j + 1] = mas[j];
                    mas[j] = temp;
                }
            }
        }
    }
    public void QuickSorting(int[] arr) => new QuickSort().ArraySort(arr);
    public void TimSorting(int[] arr) => new TimSort().Sorting(arr);
    public void InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var j = i;
            while ((j > 1) && (array[j - 1] > key))
            {
                Swap(ref array[j - 1], ref array[j]);
                j--;
            }

            array[j] = key;
        }

        void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
    }
    public void ShakerSort(int[] array)
    {
        for (var i = 0; i < array.Length / 2; i++)
        {
            var swapFlag = false;
            for (var j = i; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapFlag = true;
                }
            }
            for (var j = array.Length - 2 - i; j > i; j--)
            {
                if (array[j - 1] > array[j])
                {
                    Swap(ref array[j - 1], ref array[j]);
                    swapFlag = true;
                }
            }
            if (!swapFlag)
                break;

            void Swap(ref int e1, ref int e2)
            {
                var temp = e1;
                e1 = e2;
                e2 = temp;
            }
        }
    }
    public void ShellSort(int[] array)
    {
        var d = array.Length / 2;
        while (d >= 1)
        {
            for (var i = d; i < array.Length; i++)
            {
                var j = i;
                while ((j >= d) && (array[j - d] > array[j]))
                {
                    Swap(ref array[j], ref array[j - d]);
                    j -= d;
                }
            }
            d /= 2;
        }

        void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
    }
    public void CombSort(int[] array)
    {
        var arrayLength = array.Length;
        var currentStep = arrayLength - 1;

        while (currentStep > 1)
        {
            for (int i = 0; i + currentStep < array.Length; i++)
            {
                if (array[i] > array[i + currentStep])
                {
                    Swap(ref array[i], ref array[i + currentStep]);
                }
            }

            currentStep = GetNextStep(currentStep);
        }

        for (var i = 1; i < arrayLength; i++)
        {
            var swapFlag = false;
            for (var j = 0; j < arrayLength - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
            {
                break;
            }
        }

        int GetNextStep(int s)
        {
            s *= 1000 / 1247;
            return s > 1 ? s : 1;
        }
        void Swap(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
    public void GnomeSort(int[] unsortedArray)
    {
        var index = 1;
        var nextIndex = index + 1;

        while (index < unsortedArray.Length)
        {
            if (unsortedArray[index - 1] < unsortedArray[index])
            {
                index = nextIndex;
                nextIndex++;
            }
            else
            {
                Swap(ref unsortedArray[index - 1], ref unsortedArray[index]);
                index--;
                if (index == 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
            }
        }

        void Swap(ref int item1, ref int item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
    public void TreeSort(int[] array)
    {
        var treeNode = new TreeNode(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            treeNode.Insert(new TreeNode(array[i]));
        }
        var temp = treeNode.Transform();

        for (int i = 0; i < array.Length; i++)
            array[i] = temp[i];
    }
    public void MergeSort(int[] array)
    {
        MergeSort(array, 0, array.Length - 1);

        void MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }
        }
        void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }
                index++;
            }
            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }
            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }
            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
    }
    class QuickSort
    {
        void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
        int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        int[] Sort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            Sort(array, minIndex, pivotIndex - 1);
            Sort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        public void ArraySort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }
    }
    class TimSort
    {
        const int RUN = 32;

        void InsertionSort(int[] arr, int left, int right)
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
        void Merge(int[] arr, int l, int m, int r)
        {
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
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }
        public void Sorting(int[] arr)
        {
            for (int i = 0; i < arr.Length; i += RUN)
                InsertionSort(arr, i, Math.Min((i + RUN - 1), (arr.Length - 1)));
            for (int size = RUN; size < arr.Length; size = 2 * size)
            {
                for (int left = 0; left < arr.Length; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (arr.Length - 1));
                    if (mid < right)
                        Merge(arr, left, mid, right);
                }
            }
        }
    }
    public class TreeNode
    {
        public TreeNode(int data) => Data = data;
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
                if (Left == null)
                    Left = node;
                else
                    Left.Insert(node);
            else
                if (Right == null)
                    Right = node;
                else
                    Right.Insert(node);
        }
        public int[] Transform(List<int> elements = null)
        {
            if (elements == null)
                elements = new List<int>();

            if (Left != null)
                Left.Transform(elements);

            elements.Add(Data);

            if (Right != null)
                Right.Transform(elements);

            return elements.ToArray();
        }
    }
}
class Matrix
{
    public uint[,] matrix;
    public Matrix(uint n)
    {
        matrix = new uint[n, n];
        RandomFilling();
    }
    void RandomFilling()
    {
        var lenght = matrix.GetLength(0);
        var rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = (uint)rand.Next();
            }
        }
    }
    public static Matrix operator *(Matrix a, Matrix b)
    {
        return new Matrix(1);
    }
}
class VectorOperations
{
    public void ReturnOne(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 1;
        }
    }
    public void ReturnSumm(int[] array)
    {
        ulong summ = 0;
        for (int i = 0; i < array.Length; i++)
        {
            summ += (ulong)array[i];
        }
    }
    public void ReturnMult(int[] array)
    {
        ulong mult = 0;
        for (int i = 0; i < array.Length; i++)
        {
            mult *= (ulong)array[i];
        }
    }
    public void Polinom(int[] array)
    {
        const float x = 1.5f;
        float sum = 0;
        for (int k = 1; k < array.Length; k++)
        {
            sum += array[k] * (float)Math.Pow(x, k - 1);
        }
    }
}

