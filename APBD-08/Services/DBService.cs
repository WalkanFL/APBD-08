using APBD_08.Data;
using APBD_08.DTOs.ComponentDTOs;
using APBD_08.DTOs.PCDTOs;
using APBD_08.Entities;
using APBD_08.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD_08.Services;

public class DBService : IDBService
{
    private readonly AppDBContext _dbContext;

    public DBService(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PCNoComponentsDTO>> getAllPCsAsync()
    {
        var result = await _dbContext.PCs
            .Select(p => new PCNoComponentsDTO
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
        
        if (result == null)
        {
            throw new NotFoundException("No PCs found");
        }
        
        return result;
    }

    public async Task<PCNoComponentsDTO> getPCAsync(int id)
    {
        var result = await _dbContext.PCs
            .Where(p => p.Id == id)
            .Select(p => new PCNoComponentsDTO
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .FirstOrDefaultAsync();
        
        if(result == null)
        {
            throw new NotFoundException("No PC of that Id found");
        }

        return result;
    }

    public async Task<IEnumerable<ComponentWAmountDTO>> getPCsComponentsAsync(int id)
    {
        var result = await _dbContext.PCComponents
            .Where(pcc => pcc.PCId == id)
            .Join(_dbContext.Components, pcc => pcc.ComponentCode, comp => comp.Code,
                (pcc, comp) => new ComponentWAmountDTO
                {
                    Code = comp.Code,
                    Name = comp.Name,
                    Description = comp.Description,
                    ComponentManufacturersId = comp.ComponentManufacturerId,
                    ComponentTypesId = comp.ComponentTypeId,
                    Amount = pcc.Amount
                })
            .ToListAsync();
        
        if (result == null)
        {
            throw new NotFoundException("No PC of that Id found");
        }
        return result;
    }

    public async Task<PC> addPCAsync(AddPCDTO addPC)
    {
        var pc = new PC()
        {
            Name = addPC.Name,
            Weight = addPC.Weight,
            Warranty = addPC.Warranty,
            CreatedAt = addPC.CreatedAt,
            Stock = addPC.Stock
        };
        await _dbContext.AddAsync(pc);
        await _dbContext.SaveChangesAsync();
        
        return pc;
    }

    public async Task<int> updatePCAsync(int id, UpdatePCDTO updatePC)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException("No PC of that Id found");
        }
        if (updatePC.Name != null){ pc.Name = updatePC.Name;}
        if (updatePC.Weight != null){pc.Weight = updatePC.Weight.Value;}
        if (updatePC.Warranty != null){pc.Warranty = updatePC.Warranty.Value;}
        if (updatePC.CreatedAt != null){pc.CreatedAt = updatePC.CreatedAt.Value;}
        if (updatePC.Stock != null){pc.Stock = updatePC.Stock.Value;}

        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> removePCByIdAsync(int id)
    {
        var affectedRows = await _dbContext.PCs.Where(p => p.Id == id).ExecuteDeleteAsync();
        if (affectedRows == 0)
        {
            throw new NotFoundException("No PC of that Id found");
        }
        return affectedRows;
    }
}