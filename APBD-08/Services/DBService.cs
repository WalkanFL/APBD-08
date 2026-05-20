using APBD_08.Data;
using APBD_08.DTOs.ComponentDTOs;
using APBD_08.DTOs.PCDTOs;

namespace APBD_08.Services;

public class DBService : IDBService
{
    private readonly AppDBContext _dbContext;

    public DBService(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<PCNoComponentsDTO>> getAllPCsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PCNoComponentsDTO> getPCAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ComponentWAmountDTO>> getPCsComponentsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> addPCAsync(AddPCDTO addPC)
    {
        throw new NotImplementedException();
    }

    public Task<int> updatePCAsync(int id, UpdatePCDTO updatePC)
    {
        throw new NotImplementedException();
    }

    public Task<int> removePCByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}