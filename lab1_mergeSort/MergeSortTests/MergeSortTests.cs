using MergeSortNS;

namespace MergeSortTestsNS;

public class MergeSortTests
{
    [Theory]
    [MemberData("ArraysData")]
    public void SortTest<T>(T[] arr, T[] sortedArr)
        where T : IComparable
    {
        var result = MergeSort.Sort(arr);

        Assert.Equal<T>(sortedArr, result);
    }

    [Fact]
    public void StabilityTest()
    {
        var arr = new TestObject[]
        {
            new TestObject() { Rank = 3, Class = 'a' },
            new TestObject() { Rank = 5, Class = ' ' },
            new TestObject() { Rank = 7, Class = ' ' },
            new TestObject() { Rank = 3, Class = 'e' },
            new TestObject() { Rank = 10, Class = 'q' },
            new TestObject() { Rank = 6, Class = ' ' },
            new TestObject() { Rank = 10, Class = 'r' },
            new TestObject() { Rank = 2, Class = ' ' }
        };

        var result = MergeSort.Sort(arr);

        Assert.Equal('a', result[1].Class);
        Assert.Equal('e', result[2].Class);
        Assert.Equal('q', result[6].Class);
        Assert.Equal('r', result[7].Class);
    }

    public static IEnumerable<object[]> ArraysData()
    {
        yield return new object[]
        {
            new int[] { 2, 5, 9, 4, 1, 4, 7, 9, 2 },
            new int[] { 1, 2, 2, 4, 4, 5, 7, 9, 9 }
        };
        yield return new object[]
        {
            new int[] {15, 78, 89, 9, 12, 12546, 8, 879, 16, 54, 1},
            new int[] {1, 8, 9, 12, 15, 16, 54, 78, 89, 879, 12546}
        };
        yield return new object[] 
        {
            new string[] { "enfgh", "sgasf", "asdg", "ksd", "asa", "bhj", "ksgd", "assa", "bhdfj" },
            new string[] { "asa", "asdg", "assa", "bhdfj", "bhj", "enfgh", "ksd", "ksgd", "sgasf" }
        };
    }
}

class TestObject : IComparable
{
    public int Rank { get; set; }
    public char Class { get; set; }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        if (obj is TestObject otherObject)
            return this.Rank.CompareTo(otherObject.Rank);
        else
            throw new ArgumentException("Object is not a TestObject");
    }
}