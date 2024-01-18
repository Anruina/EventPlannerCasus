namespace Library.Models
{

    public class EventType : TableData
    {

        public string? Name {  get; set; }

        public List<Event>? Events {  get; set; }

    }

}
