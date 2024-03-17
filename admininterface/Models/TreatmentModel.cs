using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace admininterface.Models;

public class TreatmentModel 
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Vänligen skriv in namnet på behandlingen!")]
    [Display(Name = "Namn på behandlingen")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Vänligen skriv en beskrivning!")]
    [Display(Name = "Beskrivning")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Vänligen ange behandlingstiden!")]
    [Display(Name = "Behandlingstid")]
    public TimeSpan TreatmentTime { get; set; }

    [Required(ErrorMessage = "Vänligen ange ett pris!")]
    [Display(Name = "Pris")]
    public int Price { get; set; }

    public ICollection<BookingModel>? Booked { get; }
    [Display(Name = "Behandlingstyp")]
    public int TreatmentTypeId { get; set; }
    [Display(Name = "Behandlingstyp")]
    public TreatmentTypeModel? TreatmentType { get; set; }
}