﻿using Microsoft.EntityFrameworkCore;

namespace pruebaApiPSP.model;

public class PlayerContext : DbContext
{
    public PlayerContext(DbContextOptions<PlayerContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; } = null!;
}