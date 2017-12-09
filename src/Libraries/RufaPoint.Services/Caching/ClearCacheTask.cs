using RufaPoint.Core.Caching;
using RufaPoint.Services.Tasks;

namespace RufaPoint.Services.Caching
{
    /// <summary>
    /// Clear cache scheduled task implementation
    /// </summary>
    public partial class ClearCacheTask : IScheduleTask
    {
        private readonly IStaticCacheManager _staticCacheManager;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="staticCacheManager">Cache manager</param>
        public ClearCacheTask(IStaticCacheManager staticCacheManager)
        {
            this._staticCacheManager = staticCacheManager;
        }

        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            _staticCacheManager.Clear();
        }
    }
}
