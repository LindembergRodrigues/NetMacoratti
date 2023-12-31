﻿using NetMacoratti.Models;

namespace NetMacoratti.Repository.Interface
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchePreferido { get; }
        Lanche GetLanche(int id);

    }
}
