using System.Collections.Generic;

namespace CommonModel
{
    public class IndexViewtweet
    {
        public IEnumerable<tweets> List { get; set; }
        public tweets Details { get; set; }
    }
}