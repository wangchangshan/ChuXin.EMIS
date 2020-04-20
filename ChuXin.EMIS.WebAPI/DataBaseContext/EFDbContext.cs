using ChuXin.EMIS.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuXin.EMIS.WebAPI.DataBaseContext
{
	public class EFDbContext : DbContext
	{
		public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
		{
		}

		public DbSet<Activity> Activities { get; set; }

		public DbSet<ActivityStudent> ActivityStudents { get; set; }

		public DbSet<ActivityImage> ActivityImages { get; set; }

		public DbSet<CoursePackage> CoursePackages { get; set; }

		public DbSet<Holiday> Holidays { get; set; }

		public DbSet<ScheduleTemplate> ScheduleTemplates { get; set; }

		public DbSet<ScheduleTemplateDtl> ScheduleTemplateDtls { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<StudentCourseComment> StudentCourseComments { get; set; }

		public DbSet<StudentCourseExperience> StudentCourseExperiences { get; set; }

		public DbSet<StudentCourseList> StudentCourseList { get; set; }

		public DbSet<StudentCoursePackage> StudentCoursePackages { get; set; }

		public DbSet<StudentCourseSchedule> StudentCourseSchedules { get; set; }

		public DbSet<StudentPortfolio> StudentPortfolios { get; set; }

		public DbSet<StudentPotential> StudentsPotential { get; set; }

		public DbSet<StudentRecommendation> StudentRecommendations { get; set; }

		public DbSet<SysCodeFactory> SysCodeFactories { get; set; }

		public DbSet<SysDictionary> SysDictionaries { get; set; }

		public DbSet<SysMenu> SysMenus { get; set; }

		public DbSet<SysRole> SysRoles { get; set; }

		public DbSet<SysUser> SysUsers { get; set; }

		public DbSet<SysUserLoginRecored> SysUserLoginRecoreds { get; set; }

		public DbSet<SysUserRole> SysUserRoles { get; set; }

		public DbSet<SysUserWechat> SysUsersWechat { get; set; }

		public DbSet<Teacher> Teachers { get; set; }

		public DbSet<TeacherPortfolio> TeacherPortfolios { get; set; }

		public DbSet<TeacherResume> TeacherResumes { get; set; }

		public DbSet<WechatPortfolio> WechatPortfolios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<Student>(entity =>
			//{
			//	entity.HasKey(x => x.Id);
			//	entity.Property(x => x.StudentName).IsRequired();
			//});
		}
	}
}
