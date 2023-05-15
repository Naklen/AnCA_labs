namespace MergeSortNS;

public class MergeSort
{
    public static T[] Sort<T>(T[] source) where T : IComparable
    {
        T[] tmp;
        var currentSrc = source;
        var currentTarget = new T[source.Length];

        var size = 1;
        while (size < source.Length)
        {
            for (var i = 0; i < source.Length; i += 2 * size)
                Merge(currentSrc, i, currentSrc, i + size, currentTarget, i, size);

            tmp = currentSrc;
            currentSrc = currentTarget;
            currentTarget = tmp;

            size *= 2;
        }
        return currentSrc;
    }

    //Merges two sorted arrays into one sorted array
    public static void Merge<T>(
        T[] firstArray, int firstStart,
        T[] secondArray, int secondStart,
        T[] target, int targetStart,
        int size) where T : IComparable
    {
        var index1 = firstStart;
        var index2 = secondStart;

        var firstEnd = Math.Min(firstStart + size, firstArray.Length);
        var secondEnd = Math.Min(secondStart + size, secondArray.Length);

        if (firstStart + size > firstArray.Length)
        {
            for (var i = firstStart; i < firstEnd; i++)
                target[i] = firstArray[i];
            return;
        }

        var iterationCount = firstEnd - firstStart + secondEnd - secondStart;

        for (var i = targetStart; i < targetStart + iterationCount; i++)
        {
            if (index1 < firstEnd && (index2 >= secondEnd || firstArray[index1].CompareTo(secondArray[index2]) <= 0))
            {
                target[i] = firstArray[index1];
                index1++;
            }
            else
            {
                target[i] = secondArray[index2];
                index2++;
            }
        }
    }
}