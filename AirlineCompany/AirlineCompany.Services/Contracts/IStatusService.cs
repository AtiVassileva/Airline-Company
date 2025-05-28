namespace AirlineCompany.Services.Contracts
{
    public interface IStatusService
    {
        Task<Guid> GetUpcomingStatusId();
        Task<Guid> GetCancelledStatusId();
        Task<Guid> GetCompletedStatusId();
    }
}