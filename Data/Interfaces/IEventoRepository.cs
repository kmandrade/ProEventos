﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IEventoRepository:IRepository<Evento>
    {
        Task<Evento> BuscarEventoPorLote(string nomeLote);
    }
}
