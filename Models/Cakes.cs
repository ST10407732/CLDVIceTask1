namespace CakeApplication.Models

{

    using System.ComponentModel.DataAnnotations;

 
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cakes
    {
        public int Id { get; set; }
        public string? Title { get; set; }


        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]

        public DateTime OrderDate { get; set; }
        public string? Flavour { get; set; }
        public decimal Price { get; set; }
    }
}