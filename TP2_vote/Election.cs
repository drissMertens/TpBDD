
using System;
using TP2_vote;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP2_vote
{
   public class Election
    {
        public List<Candidat> candidats = new List<Candidat>();
        public List<Candidat> candidats_2sdT = new List<Candidat>();

        public int winScore = 0;
        public int maxBlanc = 0;

        public Election()
        {
            initCandidat();
        }

        public void initCandidat()
        {
            candidats.Add(new Candidat("Zemmour"));
            candidats.Add(new Candidat("Mélanchon"));
            candidats.Add(new Candidat("Macron"));
            candidats.Add(new Candidat("Le Pen"));
        }
        public int totalVote()
        {
            int nbVote = 0;
            foreach (var candidat in candidats)
            {
                nbVote += candidat.getVote;
            }
            return nbVote;
        }

        public float candidatScore(Candidat c)
        {
            return c.getVote * 100 / totalVote();
        }

        public Candidat getFistTurnWinner()
        {
            foreach (var candidat in candidats.ToList())
            {
                if (candidatScore(candidat) >= winScore)
                {
                    return candidat;
                }
            }
            return null;
        }

        public List<Candidat> getSecondTurn()
        {
            return candidats_2sdT = candidats.OrderByDescending(c => candidatScore(c)).Take(2).ToList();
        }

        public Candidat getSecondWinnerTurn()
        {
            if (candidatScore(candidats_2sdT.FirstOrDefault()) == candidatScore(candidats_2sdT.LastOrDefault()))
            {
                return null;
            }
            return candidats_2sdT.OrderByDescending(c => candidatScore(c)).FirstOrDefault();
        }

        public float getVoteNull()
        {
            var blanc = candidats.Find(c => c.Name == "VoteBlanc");
            return candidatScore(blanc);
        }

        public Boolean isBlancMax()
        {
            if (getVoteNull() >= maxBlanc)
            {
                return true;
            }
            return false;
        }

    }
}
