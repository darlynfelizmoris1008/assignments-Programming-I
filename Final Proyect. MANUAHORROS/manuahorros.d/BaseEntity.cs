namespace manuahorros.D
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
