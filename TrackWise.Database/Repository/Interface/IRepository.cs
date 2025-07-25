﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        public  IEnumerable<T> GetAll();
        public T Get(Expression<Func<T,bool>> filter);
        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> filter);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void Save();
        public Task SaveAsync();
    }
}
