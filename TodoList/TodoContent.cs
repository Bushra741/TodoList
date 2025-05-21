
namespace TodoList
{
    public class TodoContent
    {
        public string Title { get; set; }
        public override string ToString()
        {
            return Title;
        }
        public string Description { get; set; }
    }
}
