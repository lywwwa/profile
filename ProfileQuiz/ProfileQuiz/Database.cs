using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProfileQuiz.Model;
using System.Diagnostics;
namespace ProfileQuiz
{
   public class Database
    {
        SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<UserInfo>().Wait();

        }

        public Task<List<UserInfo>> GetUsersInfoAsync()
        {
            return database.Table<UserInfo>().ToListAsync();
        }


        public Task<UserInfo> GetUserInfoAsync(int id)
        {
            return database.Table<UserInfo>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<UserInfo> GetDescUserInfoAsync()
        {
            return database.Table<UserInfo>().OrderByDescending(i => i.Id).FirstOrDefaultAsync();
        }

       



        public Task<int> SaveUserInfoAsync(UserInfo userinfo)
        {
            if (userinfo.Id != 0)
            {
                return database.UpdateAsync(userinfo);
            }
            else
            {
                return database.InsertAsync(userinfo);
            }
        }

       



        public Task<int> DeleteUserInfoAsync(UserInfo userinfo)
        {
            return database.DeleteAsync(userinfo);
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }

    }
}
