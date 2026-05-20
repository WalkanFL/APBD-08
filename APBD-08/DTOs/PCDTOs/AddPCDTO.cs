namespace APBD_08.DTOs.PCDTOs;

public class AddPCDTO
{
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}