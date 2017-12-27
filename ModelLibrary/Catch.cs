using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Catch
    {
        public int Id { get; set; }
        public String Navn { get; set; }
        public String Art { get; set; }
        public double Vægt { get; set; }
        public String Sted { get; set; }
        public int Uge { get; set; }

        // Altid have en default constructor
        public Catch()
        {
        }

        public Catch(int id, string navn, string art, double vægt, string sted, int uge)
        {
            Id = id;
            Navn = navn;
            Art = art;
            Vægt = vægt;
            Sted = sted;
            Uge = uge;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Navn)}: {Navn}, {nameof(Art)}: {Art}, {nameof(Vægt)}: {Vægt}, {nameof(Sted)}: {Sted}, {nameof(Uge)}: {Uge}";
        }
    }
}
