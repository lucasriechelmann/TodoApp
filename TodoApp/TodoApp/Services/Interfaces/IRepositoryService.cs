using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services.Interfaces
{
    public interface IRepositoryService
    {
        Task<T> Get<T>(int id) where T : new();
        Task<IList<T>> Get<T>() where T : new();
        Task<IList<T>> Get<T>(Expression<Func<T, bool>> filter) where T : new();
        Task Save<T>(T obj) where T : new();
        Task Update<T>(T obj) where T : new();
        Task Insert<T>(T obj) where T : new();
        Task Delete<T>(T obj) where T : new();
        Task Delete<T>(int id) where T : new();
    }
}
