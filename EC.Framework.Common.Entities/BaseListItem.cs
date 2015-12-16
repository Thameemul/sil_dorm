namespace EC.Framework.Common.Entities
{
    public class BaseListItem<TId, TValue>
    {
        public TId Id { get; set; }

        public TValue Value { get; set; }

        public bool IsSelected { get; set; }
    }
}
