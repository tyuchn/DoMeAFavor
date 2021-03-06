﻿
using System.Collections.Generic;

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
        Task AcceptAsync(Mission mission,User user);

        /// <summary>
        /// 添加任务。
        /// </summary>
        Task AddAsync(Mission mission,User user);

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        Task DeleteAsync(Mission mission);
        /// <summary>
        /// 列出未接收的任务
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Mission>> ListUnacceptedAsync();
    }
}
