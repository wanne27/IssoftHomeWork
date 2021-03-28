using System;

namespace Task
{
    public class DiagonalMatrix<T> where T : IComparable<T>
    {
        private readonly T[] _data;

        public readonly int Size;

        public T this[int i, int j]
        {
            get => i == j && IsCorrect(i) ? _data[i] : default(T);
            set
            {
                if (i == j && IsCorrect(i))
                {
                    if (_data[i].CompareTo(value) != 0)
                        OnElementChanged(new ElementChangedEventArgs<T>(i, _data[i], value));

                    _data[i] = value;
                }

                else throw new IndexOutOfRangeException();
            }
        }

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }

        public DiagonalMatrix(params T[] data)
        {
            if (data == null)
            {
                _data = new T[0];
            }
            else
            {
                _data = new T[data.Length];
                data.CopyTo(_data, 0);
                Size = _data.Length;
            }
        }

        public DiagonalMatrix(int lenght)
        {
            if (lenght < 0)
            {
                throw new ArgumentNullException("Аргумент отрицательный!");
            }
            else
            {
                _data = new T[lenght];
                Size = _data.Length;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DiagonalMatrix<T> m) || Size != m.Size)
            {
                return false;
            }

            for (var i = 0; i < _data.Length; i++)
            {
                if (_data[i].CompareTo(m._data[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() => Size.GetHashCode();

        public override string ToString()
        {
            var result = string.Empty;

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    result += $"{this[i, j],-10}";
                }

                result += Environment.NewLine;
            }

            return result;
        }

        private bool IsCorrect(int i) => i >= 0 && i < Size;
    }
}