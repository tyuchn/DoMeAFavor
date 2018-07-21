using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMeAFavor.DB
{
    /// <summary>
    /// 数据上下文类
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// 用户表。
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 任务表。
        /// </summary>
        public DbSet<Mission> Missions { get; set; }

        /// <summary>
        /// 完成的任务表。
        /// </summary>
        public DbSet<CompletedMission> CompletedMissions { get; set; }

        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer
        }

        /// <summary>
        /// 数据上下文类构造函数。
        /// </summary>
        /// <param name="options">数据上下文参数。</param>
        public DataContext(DbContextOptions<DataContext> options) : base(
            options)
        { }
    }
}
