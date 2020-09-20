using StaffWebApplication.Models;
using System.Collections.Generic;

namespace StaffWebApplication
{
    public interface IStaffRepository
    {
        Staff Get(int id);
        int Create(Staff item);
        Staff Delete(int staffId);
        IEnumerable<Staff> GetFromCompany(int companyId);
        void Update(Staff item);
    }
}
