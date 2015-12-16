namespace EC.Framework.Test.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class FakeDbContext : DbContext, IFakeDbContext
    {
        private readonly Dictionary<Type, object> fakeDbSets;

        protected FakeDbContext()
        {
            this.fakeDbSets = new Dictionary<Type, object>();
        }

        public int SaveChanges()
        {
            return default(int);
        }

        public void Dispose() 
        {
        }

        public DbSet<T> Set<T>() where T : class
        {
            return (DbSet<T>)this.fakeDbSets[typeof(T)];
        }

        public void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new()
        {
            var fakeDbSet = Activator.CreateInstance<TFakeDbSet>();
            this.fakeDbSets.Add(typeof(TEntity), fakeDbSet);
        }

        public void Seed<T>(ICollection<T> items) where T : class, new()
        {
            var repo = this.fakeDbSets[typeof(T)];

            ((FakeDbSet<T>)repo).AddRange(items);
        }

		public void Seed<T>(T item) where T : class, new()
		{
			var repo = this.fakeDbSets[typeof(T)];

			((FakeDbSet<T>)repo).Add(item);
		}
    }
}
