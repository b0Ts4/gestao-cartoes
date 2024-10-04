using Microsoft.EntityFrameworkCore;

namespace gestao_cartoes_bancarios.Models;

public class DetalhesCartaoContext:DbContext
{
    public DetalhesCartaoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<DetalhesCartao> DetalhesCartao { get; set; }
}
