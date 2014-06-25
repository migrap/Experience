using System;

namespace Experience.Models {
    public class Attachment {
        public Language Display { get; set; }
        public Language Description { get; set; }
        public string ContentType { get; set; }
        public int Length { get; set; }
        public string Sha2 { get; set; }
        public Uri FileUrl { get; set; }
    }
}
