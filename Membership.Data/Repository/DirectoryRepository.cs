using Membership.Core.Domain.Directory;

namespace Membership.Data.Repository
{
    public class DirectoryRepository : GenericRepository<Directory>
    {
        public DirectoryRepository()
            : base(new DomainEfModel())
        {

        }
    }
}