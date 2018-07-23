using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoMeAFavor.DataService.Models
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
        public DbSet<UserMission> UserMissions { get; set; }

        /// <summary>
        /// 数据上下文类构造函数。
        /// </summary>
        /// <param name="options">数据上下文参数。</param>
        public DataContext(DbContextOptions<DataContext> options) : base(
            options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.定义联合主键。
            builder.Entity<UserMission>()
                .HasKey(lc => new { lc.MissioinId, lc.UserId });
        }
    }
}
