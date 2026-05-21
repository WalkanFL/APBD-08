using System.ComponentModel.DataAnnotations;

namespace APBD_08.DTOs.PCDTOs;

public class UpdatePCDTO
{
    [MaxLength(50)]
    public string? Name { get; set; }
    public float? Weight { get; set; }
    public int? Warranty { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? Stock { get; set; }
}