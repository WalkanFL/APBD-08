using System.ComponentModel.DataAnnotations;

namespace APBD_08.DTOs.PCDTOs;

public class AddPCDTO
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public float Weight { get; set; }
    [Required]
    public int Warranty { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public int Stock { get; set; }
}