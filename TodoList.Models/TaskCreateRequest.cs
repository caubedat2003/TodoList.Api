using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models.Enums;

namespace TodoList.Models
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(20, ErrorMessage ="Task name has over 20 characters")]
        [Required(ErrorMessage ="Please enter task name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please select a priority")]
        public Priority? Priority { get; set; }
    }
}
