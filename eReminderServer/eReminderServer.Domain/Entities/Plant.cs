namespace eReminderServer.Domain.Entities
{
    public sealed class Plant
    {
        public Plant()
        {
            Id = Guid.NewGuid();   
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
