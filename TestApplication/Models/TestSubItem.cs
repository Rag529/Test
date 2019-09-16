using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Models
{
    [Table("TestSubItem")]
    public class TestSubItem
    {
        public TestSubItem()
        {
        }

        [Key, Column(Order = 1), Required]
        public long TestItemId { get; set; }

        [Key, Column(Order = 2), Required]
        public string Name { get; set; }

        [Key, Column(Order = 3), Required]
        public int Code { get; set; }

        [Required]
        public string SubName { get; set; }

        //public virtual TestItem TestItem { get; set; }
    }
}