using System.ComponentModel.DataAnnotations;

namespace admininterface.Models; 

public class TreatmentTypeModel 
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Vänligen ange ett namn på behandlingstypen!")]
    [Display(Name = "Namn på behandlingstyp")]
    public string? Name { get; set; }
    
    public ICollection<TreatmentModel>? Treatments { get; set; }
}