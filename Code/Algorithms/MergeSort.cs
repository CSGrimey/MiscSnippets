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
                T leftHead = leftSide[0];
                T rightHead = rightSide[0];

                if (leftHead.CompareTo(rightHead) < 0) {
                    List<T> leftTail = leftSide.Skip(1).ToList();

                    return new List<T> { leftHead }.Concat(Merge(leftTail, rightSide)).ToList();
                } else {
                    List<T> rightTail = rightSide.Skip(1).ToList();

                    return new List<T> { rightHead }.Concat(Merge(rightTail, leftSide)).ToList();
                }
            }
        }
    }
}
