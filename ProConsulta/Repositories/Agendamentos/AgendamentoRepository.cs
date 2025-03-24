using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Agendamento agendamento)
        {
            await _context
                .Agendamentos
                .AddAsync(agendamento);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var agendamento = await GetByIdAsync(id);

            if (agendamento != null)
            {
                _context.Remove(agendamento);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Agendamento>> GetAllAsync()
        {
            return await _context
                .Agendamentos
                .Include(x => x.Paciente)
                .Include(x => x.Medico)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Agendamento>? GetByIdAsync(int id)
        {
            return await _context
                .Agendamentos
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
