namespace CRM.Application.Common.Interfaces
{
    public interface IReadDbContext
    {
        IQueryable<Tentity> GetBaseQuery<Tentity>() where Tentity : class;
    }
}
