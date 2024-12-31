namespace TodoList.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
    }
}
