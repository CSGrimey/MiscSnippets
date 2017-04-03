public class InsertionSorter : ISorter {
    public List<T> Sort<T>(List<T> values) where T : IComparable<T> {
        return values.Aggregate(new List<T>(), (accumulator, currentValue) => Insert(accumulator, currentValue));
    }

    private List<T> Insert<T>(List<T> values, T currentValue) where T : IComparable<T> {
        Func<T, T, bool> lessThan = (a, b) => a.CompareTo(b) < 0;

        List<T> leftSide = values.TakeWhile(v => lessThan(v, currentValue)).ToList();
        List<T> rightSide = values.SkipWhile(v => lessThan(v, currentValue)).ToList();

        return leftSide.Concat(new List<T> { currentValue }).Concat(rightSide).ToList();
    }
}
