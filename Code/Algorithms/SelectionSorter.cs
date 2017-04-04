public class SelectionSorter : ISorter {
    public List<T> Sort<T>(List<T> values) where T : IComparable<T> {
        Func<T, T, bool> greaterThan = (a, b) => a.CompareTo(b) > 0;

        return Helper(values, accumulator: new List<T>(), comparisonFunction: greaterThan);
    }

    private List<T> Helper<T>(List<T> values, List<T> accumulator, Func<T, T, bool> comparisonFunction) where T : IComparable<T> {
        if (values.Any()) {
            List<T> listWithMaximumAsHead = GetWithMaximumAsHead(values, comparisonFunction);
            T head = listWithMaximumAsHead[0];
            List<T> tail = listWithMaximumAsHead.Skip(1).ToList();

            return Helper(tail, new List<T> { head }.Concat(accumulator).ToList(), comparisonFunction);
        } else return accumulator;
    }

    private List<T> GetWithMaximumAsHead<T>(List<T> values, Func<T, T, bool> comparisonFunction) where T : IComparable<T> =>
        values.Aggregate(new List<T>(), (accumulator, currentValue) => {
            if (accumulator.Any() == false || comparisonFunction(currentValue, accumulator[0])) return new List<T> { currentValue }.Concat(accumulator).ToList();
            else return new List<T> { accumulator[0] }.Concat(new List<T> { currentValue }).Concat(accumulator.Skip(1)).ToList();
        });
}
