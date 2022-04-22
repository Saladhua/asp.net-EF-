using APIModel;
namespace APIDemo.info.Model
{
    /// <summary>
    /// 课程表
    /// </summary>
    public class Course : BaseModel
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        public string CourseType { get; set; }
        /// <summary>
        /// 教练
        /// </summary>
        public string Name { get; set; }

    }
}
