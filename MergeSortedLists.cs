using NUnit.Framework;

public class MergeSortedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        var resultHead = new ListNode();
        if (list1 == null && list2 == null) return null;
        int? nextValue = GetNextValue(ref list1, ref list2);
        resultHead.val = nextValue.Value;
        var previous = resultHead;
        while (list1 != null || list2 != null)
        {
            var value = GetNextValue(ref list1, ref list2);
            var nextHead = new ListNode
            {
                val = value
            };
            previous.next = nextHead;
            previous = nextHead;
        }

        return resultHead;
    }

    private static int GetNextValue(ref ListNode? list1, ref ListNode? list2)
    {
        bool isFirstList;
        int value;
        if (list1 == null)
        {
            value = list2.val;
            isFirstList = false;
        }
        else if (list2 == null)
        {
            value = list1.val;
            isFirstList = true;
        }
        else
        {
            isFirstList = list1.val <= list2.val;
            value = isFirstList ? list1.val : list2.val;
        }

        if (isFirstList)
        {
            list1 = list1?.next;
        }
        else
        {
            list2 = list2?.next;
        }

        return value;
    }

    public static ListNode ArrayToList(int[] arr)
    {
        if (arr.Length == 0) return null;
        ListNode head = new ListNode(arr[0]);
        ListNode current = head;
        for (int i = 1; i < arr.Length; i++)
        {
            current.next = new ListNode(arr[i]);
            current = current.next;
        }
        return head;
    }

    public static int[] ListToArray(ListNode head)
    {
        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        return list.ToArray();
    }
}

[TestFixture]
public class MergeSortedListsTests
{
    private MergeSortedLists _merger;

    [SetUp]
    public void Setup()
    {
        _merger = new MergeSortedLists();
    }

    [Test]
    [TestCase(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
    [TestCase(new int[] { }, new int[] { }, new int[] { })]
    [TestCase(new int[] { }, new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 5, 6, 7 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3, 5, 6, 7 })]
    [TestCase(new[] { 1 }, new[] { 2, 3, 4 }, new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 1, 3, 5 }, new[] { 2, 4, 6 }, new[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new[] { -3, -2, -1 }, new[] { 1, 2, 3 }, new[] { -3, -2, -1, 1, 2, 3 })]
    public void MergeTwoLists_ShouldReturnExpectedResults(int[] list1Arr, int[] list2Arr, int[] expected)
    {
        var list1 = MergeSortedLists.ArrayToList(list1Arr);
        var list2 = MergeSortedLists.ArrayToList(list2Arr);

        var result = _merger.MergeTwoLists(list1, list2);
        var resultArray = MergeSortedLists.ListToArray(result);

        Assert.That(resultArray, Is.EqualTo(expected));
    }
}