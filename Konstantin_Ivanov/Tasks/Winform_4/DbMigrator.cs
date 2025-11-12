using System.IO;
using System.Threading.Tasks;
using System;

namespace Winform_4
{
    public static class DbMigrator
    {
        public static void ApplyMigrations(IDbService db)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations");

            foreach (var file in Directory.GetFiles(path, "*.sql"))
            {
                string sql;
                using (var reader = new StreamReader(file))
                {
                    sql = reader.ReadToEnd();
                }
                db.ExecuteNonQuery(sql);
            }
        }
    }
}
