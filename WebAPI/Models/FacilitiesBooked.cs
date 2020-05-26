namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FacilitiesBooked")]
    public partial class FacilitiesBooked
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }

        public int Fk_Facility { get; set; }

        public int Fk_Organizer { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual Organizer Organizer { get; set; }
    }
}
