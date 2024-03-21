using domain.Common.Abstractions;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Contracts.Persistences.Common
{
    public interface IHumanRepository<T> : IGenericRepository<T> where T : Human
    {
        Task<T> GetByEmailAsync(Email email);
        Task<IEnumerable<T>> GetByNameAsync(Name name);
        Task<IEnumerable<T>> GetByYearOfBirthAsync(int birthOfYear);
        Task<IEnumerable<T>> GetByGenderAsync(Gender gender);
    }
}
