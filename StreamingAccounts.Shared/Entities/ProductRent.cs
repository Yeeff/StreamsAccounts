using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StreamingAccounts.Shared.Entities
{
    public class ProductRent
    {

        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime dateInit { get; set; }

        [Display(Name = "Fecha de Finalizacion")]
        public DateTime dateFinish { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; } = null!;
    }
}
