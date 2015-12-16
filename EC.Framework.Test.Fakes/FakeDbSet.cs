namespace EC.Framework.Test.Fakes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class FakeDbSet<TEntity> : DbSet<TEntity>, IDbSet<TEntity> where TEntity : class, new()
    {        
        private readonly ObservableCollection<TEntity> items;
        private readonly IQueryable query;
        
        protected FakeDbSet()
        {
            this.items = new ObservableCollection<TEntity>();
            this.query = this.items.AsQueryable();
        }        

        public Expression Expression
        {
            get
            {
                return this.query.Expression;
            }
        }

        public Type ElementType
        {
            get
            {
                return this.query.ElementType;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return this.query.Provider;
            }
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return this.items; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public override TEntity Add(TEntity entity)
        {
            this.items.Add(entity);
            return entity;
        }

        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                this.items.Add(item);
            }

            return entities;
        }

        public override TEntity Remove(TEntity entity)
        {
            this.items.Remove(entity);
            return entity;
        }

        public override IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                this.items.Remove(item);
            }

            return entities;
        }

        public TEntity Attach(TEntity entity)
        {
            base.Attach(entity);
            return entity;
        }

        public override TEntity Create()
        {
            return new TEntity();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }       
    }
}
