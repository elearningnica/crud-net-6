using crud_net_6.Models;

namespace crud_net_6.Data.Repositories
{
    public class StudentRepository : GenericRepository<TblStudent>
    {
        public StudentRepository(CrudNet6Context context) : base(context)
        {

        }
    }
}
