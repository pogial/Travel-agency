using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface IAgencyRepository
    {
        public Task SaveAgency(Agency agency);
    }
}
