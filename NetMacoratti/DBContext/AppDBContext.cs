﻿using Microsoft.EntityFrameworkCore;
using NetMacoratti.Models;
using System;

namespace NetMacoratti.DBContent
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}
