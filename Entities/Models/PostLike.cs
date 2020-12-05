using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models {
    public class PostLike {

        public int Id { get; set; }
        public string LikedBy { get; set; }
        public DateTime LikedOn { get; set; }
        public int PostId { get; set; }
    }
}
