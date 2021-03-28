using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    sealed class Segment
    {
        public int Left { get; }
        public int Right { get; }
        public int Lenght { get => Right - Left; }

        public Segment(int left, int right)
        {
            if (left > right)
            {
                (left,right) = (right,left);               
            }
            Left = left;
            Right = right;            
        }

        public static Segment operator +(Segment s1, Segment s2)
        {
            return new Segment(s1.Left+s2.Left,s1.Right+s2.Right);
        }

        public static explicit operator uint(Segment segment)
        {
            return (uint)segment.Lenght;
        }

        public static implicit operator Segment((int x, int y) tuple)
        {
            return new Segment(tuple.x, tuple.y);
        }

        public override string ToString()
        {
            return $" Left: {Left}\n Right: {Right}\n Lenght: {Lenght}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj.ToString() == ToString();
        }

        public override int GetHashCode()
        {
            return Lenght.GetHashCode();
        }
    }
}
