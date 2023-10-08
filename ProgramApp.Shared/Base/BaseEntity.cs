namespace ProgramApp.Shared.Base
{
    public abstract class BaseEntity<T> : BaseEntity
    {
        public T Id { get; set; }

        public BaseEntity() : base() { }
    }

    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }

}
