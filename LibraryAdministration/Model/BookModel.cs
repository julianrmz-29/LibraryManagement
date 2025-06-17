using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdministration.Model
{
    public class BookModel
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int PublicationYear { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, PublicationYear: {PublicationYear}";
        }
    }

    
}
