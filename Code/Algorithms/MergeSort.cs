namespace MiscSnippets.Code.Algorithms {
    public class MergeSorter {
        public List<T> MergeSort<T>(List<T> values) where T : IComparable<T> {
            int n = values.Count() / 2;

            if (n == 0) return values;
            else {
                List<T> leftSide = values.Take(n).ToList();
                List<T> rightSide = values.Skip(n).ToList();

                return Merge(MergeSort(leftSide), MergeSort(rightSide));
            }
        }

        private List<T> Merge<T>(List<T> leftSide, List<T> rightSide) where T : IComparable<T> {
            if (leftSide.Any() && rightSide.Any() == false) return leftSide;
            else if (leftSide.Any() == false && rightSide.Any()) return rightSide;
            else {
                if (leftSide.ElementAt(0).CompareTo(rightSide.ElementAt(0)) < 0) return new List<T> { leftSide.ElementAt(0) }.Concat(Merge(leftSide.Skip(1).ToList(), rightSide)).ToList();
                else return new List<T> { rightSide.ElementAt(0) }.Concat(Merge(rightSide.Skip(1).ToList(), leftSide)).ToList();
            }
        }
    }
}
