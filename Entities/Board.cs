using System.Collections.Generic;

namespace NetChan.Entities
{
    public class Board: EntityBase
    {
        public string Title { get; set; }
        public string ShortName { get; set; }
        public bool IsSfw { get; set; }
    }
}