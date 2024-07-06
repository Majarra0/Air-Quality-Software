using WebApplication8.Data;
using WebApplication8.Repository.IRepository;

namespace WebApplication8.Repository
{
    public class MessageRepository : Imessage
    {

        private readonly dbContext _context;
        public MessageRepository(dbContext dbContext)
        {
            _context = dbContext;
        }

        public string postMessage(string message)
        {
            return message;
        }
    }
}
