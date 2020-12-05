using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models {
    public class Post {

        public int Id { get; set; }
        public string Body { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
