namespace InParser
{
    public class Param
    {
        public string Title
        {
            get;
            set;
        }
        public string Data
        {
            get;
            set;
        }
        public Param(string title, string data)
        {
            Title = title;
            Data = data;
        }
    }
}

