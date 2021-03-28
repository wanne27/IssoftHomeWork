using System;
using Task;

var m = new DiagonalMatrix<int>(1, 1, 1, 1, 1);
var m1 = new DiagonalMatrix<int>(1, 1, 1, 1, 1);
var mTrack = new MatrixTracker<int>(m);
Map<int> map = DiagonalMatrixHelper.Add;  
DiagonalMatrix<int> m2 = m.Sum<int>(m1,map);
    

Console.WriteLine(m.Equals(m1));
Console.WriteLine(m.GetHashCode());

m.ElementChanged += (_, e) => Console.WriteLine($"Index = {e.Index}, Old = {e.Old}, New = {e.New}");
m[1, 1] = 2;
m[2, 2] = 3;
mTrack.Undo();
Console.WriteLine(m);
Console.WriteLine(m1);
Console.WriteLine(m2);
