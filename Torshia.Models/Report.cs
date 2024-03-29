﻿using System;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class Report
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime ReportedOn { get; set; }
        public Task Task { get; set; }
        public User Reporter { get; set; }

    }
}
