using QubitWith.Auth.Data.Models.Entities.Statistics;

namespace QubitWith.Auth.Data.Persistence.Contracts
{
    public interface IStatisticsRepository
    {
        Task<StatisticsAdmin> GetAdminStatistics();
    }
}
