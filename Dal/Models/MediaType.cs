﻿using System.ComponentModel.DataAnnotations;

namespace Dal.Models
{
    public class MediaType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;// gpj, jpg, png, mp4, etc
        public string Extension { get; set; } = null!;// .gpj, .jpg, .png, .mp4, etc    
        public string BaseUri { get; set; } = null!;// ex: /media/files on the server 
        public ICollection<Media> Media { get; set; } = null!;
    }
}
