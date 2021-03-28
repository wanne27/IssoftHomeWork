using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{   
    public struct Key : IComparable<Key>
    {
        readonly Octave octave;
        readonly Note note;
        readonly Accidental accidental;

        public Key(Octave octave, Note note, Accidental accidental)
        {
            this.octave = octave;
            this.note = note;   
            this.accidental = accidental;
            if(((int)octave + (int)note + (int)accidental) < ((int)Note.A + (int)Accidental.NoSign + (int)Octave.Subcontract) 
                || ((int)octave + (int)note + (int)accidental) > ((int)Note.C + (int)Accidental.NoSign + (int)Octave.Fifth))
            {
                throw new ArgumentException("Wrong arguments!");
            }
            if (!Enum.IsDefined(typeof(Octave), octave) || !Enum.IsDefined(typeof(Note), note)
                || !Enum.IsDefined(typeof(Accidental), accidental))
                throw new ArgumentException("Wrong arguments");
        }
      
        public override string ToString()
        {            
            return $"Octave: {octave}\nNote: {note}\nAccidental: {accidental}";
        }

        public override bool Equals(object obj)
        {                 
            if (obj is Key key && ((int)key.note + (int)key.accidental + (int)key.octave) == ((int)note + (int)accidental + (int)octave))
            {
                return true;
            }
            return false;
        }
              
        public override int GetHashCode()
        {
            return ((int)note + (int)accidental + (int)octave);
        }
       
        public int CompareTo(Key key)
        {
            if (((int)key.note + (int)key.octave + (int)key.accidental) > ((int)note + (int)accidental + (int)octave))
            {
                return -1;
            }
            else if (((int)key.note + (int)key.octave + (int)key.accidental) == ((int)note + (int)accidental + (int)octave))
            {
                return 0;
            }
            else
                return 1;
        }
    }
}
