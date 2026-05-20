using APBD_08.DTOs.ComponentDTOs;
using APBD_08.DTOs.PCDTOs;

namespace APBD_08.Services;

public interface IDBService
{
    public async Task<IEnumerable<PCNoComponentsDTO>> getAllPCsAsync()
    {
        return null;
    }

    public async Task<PCNoComponentsDTO> getPCAsync(int id)
    {
        return null;
    }
    
    public async Task<IEnumerable<ComponentWAmountDTO>> getPCsComponentsAsync(int id)
    {
        return null;
    }

    public async Task<int> addPCAsync(AddPCDTO addPC)
    {
        return -1;
    }

    public async Task<int> updatePCAsync(int id, UpdatePCDTO updatePC)
    {
        return -1;
    }

    public async Task<int> removePCByIdAsync(int id)
    {
        return -1;
    }

}