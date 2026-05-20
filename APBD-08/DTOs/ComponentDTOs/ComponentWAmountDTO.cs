namespace APBD_08.DTOs.ComponentDTOs;

public class ComponentWAmountDTO
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }
    public int Amount { get; set; }
}