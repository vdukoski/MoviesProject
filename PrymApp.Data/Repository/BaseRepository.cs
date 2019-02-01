namespace PrymApp.Data.Repository
{
    public class BaseRepository
    {
        private PrymAppContext _dbContext;

        public PrymAppContext DbContext => _dbContext;

        public BaseRepository()
        {
            _dbContext = new PrymAppContext();
        }
    }
}
