using System.ComponentModel.DataAnnotations;

namespace admininterface.Models;

public class BookingModel 
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Vänligen ange datum och tid!")]
    public DateTime DateTime { get; set; }
    [Required(ErrorMessage = "Vänligen ange ditt namn!")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Vänligen ange ditt telefonnummer")]
    public string? PhoneNumber { get; set; }
    public bool Status { get; set; } = false;

    [Required]
    public int TreatmentId { get; set; }
    public TreatmentModel? Treatment { get; set; }
}