using WarehouseManagementSystem.Shared.Database.Context;

namespace WarehouseManagementSystem.Implementation.Services
{
    public abstract class ServiceBase
    {
        protected WHManagmentSystemContext DbContext { get; set; }

        public ServiceBase(WHManagmentSystemContext context)
        {
            DbContext = context;
        }
    }
}
