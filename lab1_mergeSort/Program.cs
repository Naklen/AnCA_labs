using aca_lab1_merge_sort;

var arr = new int[] { 1, 5, 3, 85, 3, 8, 1, 44, 8, 3, 744, 8, 56654, 897, 4, 879, 46, 6, 58, 6, 49, 8, 8654, 65, 4984, 6565, 4 };

foreach (var e in MergeSort.Sort(arr))
    Console.Write($"{e} ");

