using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMeAFavor.Models;

namespace DoMeAFavor.Services
{
    public interface IMissionService
    {
        /// <summary>
        /// 列出所有任务。
        /// </summary>
        /// <returns>所有任务。</returns>
        Task<IEnumerable<Mission>> ListAsync();

        /// <summary>
        /// 更新任务信息。
        /// </summary>
        /// <param name="mission">要更新的任务。</param>
        Task UpdateAsync(Mission mission);

        /// <summary>
        /// 添加任务。
        /// </summary>
        Task AddAsync(Mission mission);
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        Task DeleteAsync(Mission mission);
    }
}
