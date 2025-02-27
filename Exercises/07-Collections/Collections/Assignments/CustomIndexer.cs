using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Assignments
{
    public class PairOfArrays<TLeft, TRight>
    {
        private readonly TLeft[] _left;
        private readonly TRight[] _right;

        public PairOfArrays(
            TLeft[] left, TRight[] right)
        {
            _left = left;
            _right = right;
        }

        public ValueTuple<TLeft, TRight> this[int indexLeft, int indexRight]
        {
            get 
            {
                // Check the bound of index.
                if (indexLeft >= _left.Length || indexRight >= _right.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return new ValueTuple<TLeft, TRight>(_left[indexLeft], _right[indexRight]);
            }
            set
            { 
                // Check the bound of index.
                if (indexLeft >= _left.Length || indexRight >= _right.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                _left[indexLeft] = value.Item1;
                _right[indexRight] = value.Item2;
            }
        }
    }
}
