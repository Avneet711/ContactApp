namespace EvolentApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Data layer model
    /// </summary>
    public partial class Contact
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Column(Order = 1)]
        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [Column(Order = 2)]
        [StringLength(200)]
        public string Email { get; set; }

        public long? PhoneNumber { get; set; }

        public bool ContactStatus { get; set; }
    }
}
