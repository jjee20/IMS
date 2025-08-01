﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DomainLayer.Models.ThinkEE;
public class ExamResultChoice
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("ExamResult")]
    public int ExamResultId { get; set; }
    public virtual ExamResult ExamResult { get; set; }

    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public  virtual Question Question { get; set; }


    [ForeignKey("Choice")]
    public int ChoiceId { get; set; }
    public virtual Choice Choice { get; set; }
}
