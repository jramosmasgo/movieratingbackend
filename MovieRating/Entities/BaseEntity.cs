﻿using System;

namespace MovieRating.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
    }
}
