namespace eReminderServer.Domain.Entities
{
    public sealed class Reminder
    {
        public Reminder()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid GardenerId { get; set; }
        public Gardener? Gardener { get; set; }
        public Guid PlantId { get; set; }
        public Plant? Plant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}
