namespace BlazorApplication.Model
{
    public class todo
    {

        public int id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DateTime;
        public bool IsDone { get; set; }

        Guid userId { get; set; }
    }
}
