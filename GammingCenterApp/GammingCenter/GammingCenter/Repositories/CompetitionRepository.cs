using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class CompetitionRepository
    {
        private GammingCenterContext context;


        public CompetitionRepository(GammingCenterContext _context)
        {
            context = _context;
        }


        // Add
        public void CreateCompetition(Competition competition)
        {

            context.Competitions.Add(competition);

            context.SaveChanges();

        }


    }
}
