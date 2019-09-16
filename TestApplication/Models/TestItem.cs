using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Models
{
    public enum States
    {
        Not_Running,
        Running,
        Completed
    }

    [Table("TestItem")]
    public class TestItem
    {
        public TestItem()
        {
            TestSubItems = new List<TestSubItem>();
        }

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public States State { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public int Retry { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

        public virtual List<TestSubItem> TestSubItems { get; set; }
    }
}