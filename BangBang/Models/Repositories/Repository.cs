using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BangBang.Models.Repositories
{
    public class Repository<T> where T : class

    {
        //泛類型接口層
        private DataDbContext context = null;

        protected DbSet<T> Dbset { get; set; }

        public Repository()
        {
            context = new DataDbContext();
            Dbset = context.Set<T>();
        }
        public Repository(DataDbContext passcontext)
        {
            this.context = passcontext;
        }

        public List<T> GetAll()
        {
            return Dbset.ToList();
        }
        public T Get(int id)
        {
            return Dbset.Find(id);
        }
        public void Add(T entity)
        {
            Dbset.Add(entity);
        }
        public void Savechanges() {
            context.SaveChanges();
        }
    }
}