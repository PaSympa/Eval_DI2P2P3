using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Api.Repositories.Context;

public class PasswordManagerDbContext : DbContext
{
    public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options) : base(options)
    {
    }
}