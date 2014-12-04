using System.Collections.Generic;

namespace InParser
{
    public class Curve
    {
        public List<float> Values;
        public string Title { get; set; }
        public string Hint { get; set; }
        public Curve(string title)
        {
            Title = title;
            Hint = string.Empty;
        }
    }
}
