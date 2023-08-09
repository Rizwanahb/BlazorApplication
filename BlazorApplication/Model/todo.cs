namespace BlazorApplication.Model
{
    public class ToDo
    {

        public int id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public Guid userId { get; set; }
    }
}
