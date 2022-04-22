using System;
using System.ComponentModel.DataAnnotations;

namespace APIModel
{
    /// <summary>
    /// 基础类
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 创建人
        /// </summary>
        [Required(AllowEmptyStrings = true), StringLength(50)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(50)]
        public string ModifyBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; } = false;
    }
}