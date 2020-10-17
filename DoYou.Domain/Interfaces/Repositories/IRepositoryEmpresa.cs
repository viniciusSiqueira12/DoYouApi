using DoYou.Domain.Entities;
using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using DoYou.Domain.Interfaces.Repositories.Base;
using System;

namespace DoYou.Domain.Interfaces.Repositories
{
    public interface IRepositoryEmpresa : IRepositoryBase<Empresa, Guid>
    {
        public DataTableResponseBase<Empresa> EmpresasDataTable(DataTableBase<Empresa> dataTableBase, EnumCategoria categoria);
    }
}
