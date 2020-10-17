using DoYou.Domain.Entities;
using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using DoYou.Domain.Interfaces.Repositories.Base;
using System;

namespace DoYou.Domain.Interfaces.Repositories
{
    public interface IRepositoryItem : IRepositoryBase<Item, Guid>
    {
        public DataTableResponseBase<Item> ItensEmpresaDatatable(DataTableBase<Item> dataTableBase, Guid FkEmpresa, EnumTipoItem item);

        public DataTableResponseBase<Item> CardapioMesaDataTable(DataTableBase<Item> dataTableBase, Guid FkEMpresa, EnumTipoItem item);
    }
}
