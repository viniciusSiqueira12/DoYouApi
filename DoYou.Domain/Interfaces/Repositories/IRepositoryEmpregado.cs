﻿using DoYou.Domain.Entities;
using DoYou.Domain.Interfaces.Repositories.Base;
using System;

namespace DoYou.Domain.Interfaces.Repositories
{
    public interface IRepositoryEmpregado : IRepositoryBase<Empregado, Guid>
    {
    }
}
