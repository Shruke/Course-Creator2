﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDevProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public virtual Module Module { get; set; }
        public ICollection<Question> questionList { get; set; }
        public bool isMultipleChoice { get; set; }
        public string questionString { get; set; }
        public string multipleChoice1 { get; set; }
        public string multipleChoice2 { get; set; }
        public string multipleChoice3 { get; set; }
        public string multipleChoice4 { get; set; }
        public int correctMultipleChoice { get; set; }
        public string correctCodeAnswer { get; set; }
    }
}
