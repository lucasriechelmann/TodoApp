using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Services.Classes
{
    public class RepositoryService : IRepositoryService
    {
        readonly SQLiteAsyncConnection _database;

        public RepositoryService()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "todoapp.db3"));
            _database.CreateTableAsync<Item>().Wait();
        }

        public async Task Delete<T>(T obj) where T : new()
        {
            await _database.DeleteAsync(obj);
        }

        public async Task Delete<T>(int id) where T : new()
        {
            await _database.DeleteAsync<T>(id);
        }

        public async Task<T> Get<T>(int id) where T : new()
        {
            return await _database.GetAsync<T>(id);
        }

        public async Task<IList<T>> Get<T>() where T : new()
        {
            return await _database.Table<T>().ToListAsync();
        }

        public async Task<IList<T>> Get<T>(Expression<Func<T, bool>> filter) where T : new()
        {
            return await _database.Table<T>().Where(filter).ToListAsync();
        }

        public async Task Insert<T>(T obj) where T : new()
        {
            await _database.InsertAsync(obj);
        }

        public async Task Save<T>(T obj) where T : new()
        {
            if ((obj as BaseEntity).Id > 0)
                await Update(obj);
            else
                await Insert(obj);
        }

        public async Task Update<T>(T obj) where T : new()
        {
            await _database.UpdateAsync(obj);
        }
    }
}
