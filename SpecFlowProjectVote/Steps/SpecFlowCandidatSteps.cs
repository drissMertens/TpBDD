using TP2_vote;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowCandidat.Steps
{
    [Binding]
    public class SpecFlowCandidatSteps
    {
        /*
        private readonly ISpecFlowOutputHelper _Log;
        public SpecFlowCandidateSteps(ISpecFlowOutputHelper outputHelper)
        {
            _Log = outputHelper;
        }
        */
        
        Election elec = new Election();
        Candidat winner;
        float blancScore;

        public SpecFlowCandidatSteps(Election elec)
        {
            this.elec = elec;
        }

        [Given(@"(.*) have (.*) vote")]
        public void GivenSwanHaveVote(string name, int nbVote)
        {
            if (elec.candidats_2sdT.Count == 0)
            {
                var candidat = elec.candidats.Find(ca => ca.Name == name);
                if (candidat != null)
                {
                    candidat.getVote = nbVote;
                }
                else
                {
                    var current_candidat = new Candidat(name, nbVote);
                    elec.candidats.Add(current_candidat);
                }
            }
            else
            {
                var candidat = elec.candidats_2sdT.Find(ca => ca.Name == name);
                if (candidat != null)
                {
                    candidat.getVote = nbVote;
                }
                else
                {
                    var current_candidat = new Candidat(name, nbVote);
                    elec.candidats_2sdT.Add(current_candidat);
                }

            }
        }

        [When(@"Score is equal or more than (.*)%")]
        public void WhenScoreIsEqualOrMoreThan(int score)
        {
            elec.winScore = score;
            return;
        }

        [Then(@"(.*) have à score of (.*)%")]
        public void WhenSwanHaveAScoreOf(string name, float score)
        {
            if (elec.candidats_2sdT.Count == 0)
            {
                var candidat = elec.candidats.Find(ca => ca.Name == name);
                if (candidat != null)
                {
                    elec.candidatScore(candidat);
                    return;
                }
            }
            else
            {
                var candidat = elec.candidats_2sdT.Find(ca => ca.Name == name);
                if (candidat != null)
                {
                    elec.candidatScore(candidat);
                    return;
                }

            }
        }

        [Then(@"winner is (.*)")]
        public void ThenWinnerIs(string nameWinner)
        {
            var candidat = elec.getFistTurnWinner();
            if (candidat != null)
            {
                if (nameWinner == candidat.Name)
                {
                    winner = candidat;
                    return;
                }
            }
            return;
        }

        [When(@"second turn with (.*) and (.*)")]
        public void WhenSecondTurnWith(string nameC1, string nameC2)
        {
            var candidate_2sdT = elec.getSecondTurn();
            if (candidate_2sdT.Find(c => c.Name == nameC1) != null && candidate_2sdT.Find(c => c.Name == nameC2) != null)
            {
                return;
            }
            return;
        }

        [Then(@"scond turn winner is (.*)")]
        public void ThenScondTurnWinnerIs(string nameWinner)
        {
            var candidat = elec.getSecondWinnerTurn();
            if (candidat != null)
            {
                if (nameWinner == candidat.Name)
                {
                    winner = candidat;
                    return;
                }
            }
            return;

        }

        [When(@"Score of VoteBlanc equal or more than (.*)%")]
        public void WhenScoreOfVoteBlancEqualOrMoreThan(int score)
        {
            elec.maxBlanc = score;
        }

        [Then(@"is to mutch VoteBlanc the election winner is cancel (.*)")]
        public void IsThenToMutchVoteBlancTheElectionWinnerIsCancel(bool cancel)
        {
            if (elec.isBlancMax() == cancel)
            {
                return;
            }
            elec.getSecondTurn();
        }


    }
}
