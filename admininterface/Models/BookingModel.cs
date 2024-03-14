using System.ComponentModel.DataAnnotations;

namespace admininterface.Models;

public class BookingModel 
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Vänligen ange datum och tid!")]
    [Display(Name = "Datum för behandlingen")]
    public DateTime DateTime { get; set; }
    [Required(ErrorMessage = "Vänligen ange ditt namn!")]
    [Display(Name = "Namn")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Vänligen ange ditt telefonnummer")]
    [Display(Name = "Telefonummer")]
    public string? PhoneNumber { get; set; }
    public bool Status { get; set; } = false;

    [Required]
    [Display(Name = "Behandling")]
    public int TreatmentId { get; set; }
    public TreatmentModel? Treatment { get; set; }
}