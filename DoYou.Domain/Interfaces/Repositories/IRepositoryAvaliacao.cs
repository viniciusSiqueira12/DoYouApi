using DoYou.Domain.Entities;
using DoYou.Domain.Entities.Base;
using DoYou.Domain.Interfaces.Repositories.Base;
using System;

namespace DoYou.Domain.Interfaces.Repositories
{
    public interface IRepositoryAvaliacao : IRepositoryBase<Avaliacao, Guid>
    {
        public DataTableResponseBase<Avaliacao> AvaliacoesEmpresaDataTable(DataTableBase<Avaliacao> dataTableBase, Guid FkEmpresa);
    }
}
