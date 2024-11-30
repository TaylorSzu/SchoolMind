using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Models;

namespace School_Mind.Repository
{
    public interface ICalendarRepository
    {
        Task<Calendar> newEvent(Calendar calendar);
        Task<Calendar> updateEvent(Calendar calendar);
        Task<ICollection<Calendar>> listEvent();
        Task<Calendar> findById(int id);
        Task deleteEvent(int id);
    }
}