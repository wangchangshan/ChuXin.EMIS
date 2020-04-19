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

		public DbSet<StudentPotential> StudentsPotential { get; set; }

		public DbSet<StudentRecommendation> StudentRecommendation { get; set; }

		public DbSet<StudentCoursePackage> StudentCoursePackage { get; set; }

		public DbSet<StudentCourseSchedule> StudentCourseSchedule { get; set; }

		public DbSet<StudentCourseList> StudentCourseList { get; set; }

		public DbSet<StudentArtwork> StudentArtwork { get; set; }

		public DbSet<StudentCourseComment> StudentCourseComment { get; set; }

		public DbSet<Activity> Activities { get; set; }

		public DbSet<ActivityStudent> ActivityStudents { get; set; }

		public DbSet<ActivityImage> ActivityImages { get; set; }

		public DbSet<ScheduleTemplate> ScheduleTemplates { get; set; }

		public DbSet<ScheduleTemplateDtl> ScheduleTemplateDtls { get; set; }

		public DbSet<CoursePackage> CoursePackages { get; set; }

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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Student>(entity =>
			{
				entity.HasKey(x => x.Id);
				entity.Property(x => x.StudentName).IsRequired();
			});
		}
	}
}
