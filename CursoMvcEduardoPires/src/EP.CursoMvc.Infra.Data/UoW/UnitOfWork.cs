using EP.CursoMvc.Infra.Data.Context;

namespace EP.CursoMvc.Infra.Data.UoW
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CursoMvcContext _context;

        public UnitOfWork(CursoMvcContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
