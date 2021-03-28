using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Task
{
    public delegate T Map<T>(T matrix1, T matrix2) where T : IComparable<T>;
    public static class DiagonalMatrixHelper
    {
        public static DiagonalMatrix<T> Sum<T>(this DiagonalMatrix<T> a, DiagonalMatrix<T> b, Map<T> map) where T : unmanaged, IComparable<T>
        {
            a ??= new DiagonalMatrix<T>();
            b ??= new DiagonalMatrix<T>();
            map ??= Add;

            if (a.Size < b.Size)
            {
                var tmp = a;
                a = b;
                b = tmp;
            }

            T[] data = new T[a.Size];

            for (var i = 0; i < b.Size; i++)
            {
                var first = a[i, i];
                var second = b[i, i];
                data[i] = map(first, second);
            }

            for (var i = b.Size; i < a.Size; i++)
            {
                data[i] = a[i, i];
            }

            return new DiagonalMatrix<T>(data);
        }

        private static readonly Dictionary<(Type Type, string Op), Delegate> Cache =
            new Dictionary<(Type Type, string Op), Delegate>();

        public static T Add<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);

            if (Cache.TryGetValue((t, nameof(Add)), out var del))
                return del is Func<T, T, T> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(Add));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.Add(leftPar, rightPar);

            var func = Expression.Lambda<Func<T, T, T>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(Add))] = func;

            return func(left, right);
        }
    }
}
