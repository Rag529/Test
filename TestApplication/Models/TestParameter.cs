using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Models
{
    [NotMapped]
    public class TestParameter
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}