using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data.Model
{
    public class Client
    {
        public Client()
        {
            LogTimeForm = new HashSet<LogTimeForm>();
        }
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<LogTimeForm> LogTimeForm { get; set; }
    }
}
