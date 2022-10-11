using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{

    public enum Status
    {
        Pending, Done, Delegated
    }


    public class Todo
    {
        

        public int Id { get; set; }

        [Required] // means non-null
        [StringLength(100)] // nvarchar(50)
        // validation  only letters, digits, space ./,;-+)(*! allowed
        public string Task { get; set; }

        public int Difficulty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DueDate { get; set; }

        public Status Status { get; set; }
    }
}