using ChuXin.EMIS.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuXin.EMIS.WebAPI.DataBaseContext
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<StudentTemp> StudentTemp { get; set; }

        public DbSet<StudentRecommend> StudentRecommend { get; set; }

        public DbSet<StudentActivity> StudentActivity { get; set; }

        public DbSet<StudentActivityImage> StudentActivityImage { get; set; }

        public DbSet<StudentArtwork> StudentArtwork { get; set; }

        public DbSet<StudentCourseArrange> StudentCourseArrange { get; set; }

        public DbSet<StudentCourseList> StudentCourseList { get; set; }

        public DbSet<StudentCourseComment> StudentCourseComment { get; set; }

        public DbSet<StudentCoursePackage> StudentCoursePackage { get; set; }

        public DbSet<SysActivity> SysActivity { get; set; }

        public DbSet<SysCourseArrangeTemplate> SysCourseArrangeTemplate { get; set; }

        public DbSet<SysCourseArrangeTemplateDetail> SysCourseArrangeTemplateDetail { get; set; }

        public DbSet<SysCoursePackage> SysCoursePackage { get; set; }

        public DbSet<SysDictionary> SysDictionary { get; set; }

        public DbSet<SysCodeFactory> SysCodeFactory { get; set; }

        public DbSet<SysHoliday> SysHoliday { get; set; }

        public DbSet<SysUser> SysUser { get; set; }

        public DbSet<SysMenu> SysMenu { get; set; }

        public DbSet<SysWxUser> SysWxUser { get; set; }

        public DbSet<SysLoginHistory> SysLoginHistory { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<TeacherRole> TeacherRole { get; set; }

        public DbSet<WxPicture> WxPicture { get; set; }
    }
}
