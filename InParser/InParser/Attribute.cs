using System.Collections.Generic;

namespace InParser
{
    public class Attribute
    {
        public List<float> Values;
        public string Title
        {
            get;
            set;
        }
        public string Hint
        {
            get;
            set;
        }
        public Attribute(string title)
        {
            Title = title;
            Hint = string.Empty;
        }
    }
}
