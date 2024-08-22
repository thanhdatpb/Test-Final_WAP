namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Bookld { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        [StringLength(250)]
        public string PublishHouse { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Authorld { get; set; }

        public virtual Author Author { get; set; }

        public virtual Author Author1 { get; set; }
    }
}
