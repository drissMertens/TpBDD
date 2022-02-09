using System;

namespace TP2_vote
{
    public class Candidat
    {
        public int getVote { get; set; }
        public string Name { get; set; }
        public Candidat(string name, int _getVote = 0)
        {
            Name = name;
            getVote = _getVote;
        }

    }
}
