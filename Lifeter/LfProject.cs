using System.Collections.Generic;

namespace Lifeter
{
    public class LfProject
    {
        public List<LfItem> Items { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LfProject(string name, string desc="")
        {
            Name = name;
            Description = desc;
            Items = new List<LfItem>();
        }
        public LfProject() { }
    }
}
