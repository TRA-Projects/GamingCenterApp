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
        // ==== Get All Competition ====
        public List<Competition> GetAllCompetition()
        {
            return context.Competitions.ToList();
        }


        public Competition GetCompetitionById(int id)
        {
            return context.Competitions
                .FirstOrDefault(c => c.CompetitionId == id);
        }

        // ==== Create Competition =====
        public void CreateCompetition(Competition competition)
        {

            context.Competitions.Add(competition);

            context.SaveChanges();

        }

        // ==== Update Competition ====
        public void UpdateCompetition()
        {
            context.SaveChanges();
        }

        // ==== Cancel Competition ====
        public void CancelCompetition()
        {
            context.SaveChanges();
        }

    }
}
