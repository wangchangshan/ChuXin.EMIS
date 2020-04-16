using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.Entities;
using System;
using System.Linq;

namespace ChuXin.EMIS.WebAPI.Helpers
{
    public class TableCodeHelper
	{
        public static IServiceProvider ServiceProvider { get; set; }

        public static string GenerateCode(string tableName, string columnName, DateTime time)
        {
            string result = string.Empty;
            string perfix = string.Empty;
            int length = 3;
            switch (tableName.ToLower())
            {
                case "student":
                    {
                        perfix = "BJ-" + time.ToString("yyyyMM");
                        length = 3;
                        break;
                    }
                case "teacher":
                    {
                        perfix = "T-";
                        length = 6;
                        break;
                    }
                case "sys_course_package":
                    {
                        perfix = "P-";
                        length = 6;
                        break;
                    }
                case "sys_course_arrange_template":
                    {
                        perfix = "AT-";
                        length = 3;
                        break;
                    }
            }

            var dbContext = ServiceProvider.GetService(typeof(EFDbContext)) as EFDbContext;

            var codeFactory = dbContext.SysCodeFactory.Where(f => f.TableName == tableName
                                                     && f.ColumnName == columnName
                                                     && f.Prefix == perfix)
                                         .FirstOrDefault();

            if (codeFactory != null)
            {
                int nextNum = codeFactory.CurrentNum + 1;
                result = perfix + nextNum.ToString().PadLeft(length, '0');

                codeFactory.CurrentNum += 1;
                dbContext.SaveChanges();
            }
            else
            {
                SysCodeFactory factory = new SysCodeFactory
                {
                    TableName = tableName,
                    ColumnName = columnName,
                    Prefix = perfix,
                    SequenceLength = length,
                    CurrentNum = 1
                };
                dbContext.SysCodeFactory.Add(factory);
                dbContext.SaveChanges();

                result = perfix + "1".PadLeft(length, '0');
            }
            return result;
        }
    }
}
