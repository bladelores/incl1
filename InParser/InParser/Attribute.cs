namespace InParser
{
    public class Attribute
    {
        public string Title { get; set; }
        public string Data { get; set; }
        public Attribute(string title, string data)
        {
            Title = title;
            Data = data;
        }
    }
}

