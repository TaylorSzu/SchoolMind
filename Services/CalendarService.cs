using Microsoft.EntityFrameworkCore;
using School_Mind.Data;
using School_Mind.Models;
using School_Mind.Repository;

namespace School_Mind.Services
{
    public class CalendarService : ICalendarRepository
    {
        private readonly SchoolMindContext schoolMindContext;

        public CalendarService(SchoolMindContext schoolMindContext)
        {
            this.schoolMindContext = schoolMindContext;
        }

        public async Task deleteEvent(int id)
        {
            var calendar = await schoolMindContext.Calendar.FindAsync(id);
            if (calendar == null)
            {
                throw new ArgumentException("O id não pode ser vazio");
            }
            else
            {
                schoolMindContext.Remove(calendar);
                await schoolMindContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Calendar>> listEvent()
        {
            return await schoolMindContext.Calendar.Include(c=>c.Creator).Include(c=>c.Class).ToListAsync();
        }

        public async Task<Calendar> newEvent(Calendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentException("O objeto não pode ser vazio");
            }
            else
            {
                await schoolMindContext.AddAsync(calendar);
                await schoolMindContext.SaveChangesAsync();
            }
            return calendar;
        }

        public async Task<Calendar> updateEvent(Calendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Update(calendar);
                await schoolMindContext.SaveChangesAsync();
            }
            return calendar;
        }

        public async Task<Calendar> findById(int id){
            return await schoolMindContext.Calendar.Include(c=>c.Creator).Include(c=>c.Class).FirstOrDefaultAsync(c=>c.Id == id);
        }
    }
}
