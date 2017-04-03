public class BubbleSorter : ISorter {
    public List<T> Sort<T>(List<T> values) where T : IComparable<T> {
        Func<T, T, bool> compare = (a, b) => a.CompareTo(b) > 0;

        if (values.Count > 1) {
            T head = values[0];
            List<T> tail = values.Skip(1).ToList();
            T tailHead = tail[0];

            if (compare(head, tailHead))
                return Sort(new List<T> { tailHead, head }.Concat(tail.Skip(1)).ToList());
            else {
                List<T> sortResult = Sort(tail);
                T sortResultHead = sortResult[0];
                List<T> sortResultTail = sortResult.Skip(1).ToList();

                if (compare(head, sortResultHead))
                    return Sort(new List<T> { sortResultHead, head }.Concat(sortResultTail).ToList());
                else return new List<T> { head }.Concat(sortResult).ToList();
            }
        } else return values;
    }
}
