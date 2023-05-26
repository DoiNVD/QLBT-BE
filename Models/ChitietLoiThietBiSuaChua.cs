/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE3.Models
{
    public class ChiTietLoiThietBiSuaChua : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("ThietBiSuaChua")]
        public Guid ThietBiSuaChua_Id { get; set; }
        public ThietBiSuaChua ThietBiSuaChua { get; set; }

        [ForeignKey("LoiThietBiSuaChua")]
        public Guid LoiThietBiSuaChua_Id { get; set; }
        public LoiThietBiSuaChua LoiThietBiSuaChua { get; set; }

    }
}
*/