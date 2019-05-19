using System.Collections.Generic;

namespace Cafe
{
    public interface IMeal
    {
        decimal Price { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IEnumerable<string> Ingredients { get; set; }
        string ToString();
    }
}