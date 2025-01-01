﻿using AlQaim.Lms.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlQaim.Lms.Domain
{
    public class Course: EntityBase, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Poster {  get; set; } = string.Empty;
        public string VideoUrl {  get; set; } = string.Empty; 
    }
}
