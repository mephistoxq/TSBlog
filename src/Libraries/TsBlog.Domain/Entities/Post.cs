using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Domain.Entities
{
    /// <summary>
    /// 博文实体类
    /// </summary>
    [SugarTable("tb_post")]        //SqlSugar
    public class Post
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]           //SqlSugar
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        /// <summary>
        /// 是否标识已删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 是否允许展示
        /// </summary>
        public bool AllowShow { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int ViewCount { get; set; }
    }
}
