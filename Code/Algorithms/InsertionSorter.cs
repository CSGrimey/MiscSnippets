 public class InsertionSorter : ISorter {
    public List<T> Sort<T>(List<T> values) where T : IComparable<T> {
        Func<T, T, bool> lessThan = (a, b) => a.CompareTo(b) < 0;

        return values.Aggregate(new List<T>(), (accumulator, currentValue) => Insert(accumulator, currentValue, lessThan));
    }

    private List<T> Insert<T>(List<T> values, T currentValue, Func<T, T, bool> comparisonFunction) where T : IComparable<T> {
        List<T> leftSide = values.TakeWhile(v => comparisonFunction(v, currentValue)).ToList();
        List<T> rightSide = values.SkipWhile(v => comparisonFunction(v, currentValue)).ToList();

        return leftSide.Concat(new List<T> { currentValue }).Concat(rightSide).ToList();
    }
}
