using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace ComplexDataModel.Data.Entities;

[Index(nameof(Value), IsUnique = true)]
    public class LookupEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
