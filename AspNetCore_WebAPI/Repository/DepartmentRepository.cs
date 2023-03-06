using AspNetCore_WebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_WebAPI.Repository
{
  public interface IDepartmentRepository
  {
    Task<IEnumerable<Department>> GetDepartments();
    Task<Department> GetDepartmentByID(int? id);
    Task<Department> InsertDepartment(Department department);
    Task<Department> UpdateDepartment(Department department);
    Task<Department> DeleteDepartment(int id);
  }

  public class DepartmentRepository : IDepartmentRepository
  {
    private readonly APIDbContext _apiDbContext;

    public DepartmentRepository(APIDbContext dbContext)
    {
      _apiDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<Department> DeleteDepartment(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<Department> GetDepartmentByID(int? id)
    {
      string sql = "EXEC USP_GetDepartments @DepartmentId";
      List<SqlParameter> parameters = new List<SqlParameter>()
      {
        new SqlParameter{ ParameterName = "@DepartmentId",Value = id != null ? (object)id : DBNull.Value}
      };

      return await _apiDbContext.Departments.FromSqlRaw<Department>(sql,parameters).FirstOrDefaultAsync();

    }

    public async Task<IEnumerable<Department>> GetDepartments()
    {
      return await _apiDbContext.Departments.FromSqlRaw<Department>("USP_GetDepartments").ToListAsync();
    }

    public Task<Department> InsertDepartment(Department department)
    {
      throw new NotImplementedException();
    }

    public Task<Department> UpdateDepartment(Department department)
    {
      throw new NotImplementedException();
    }
  }
}
