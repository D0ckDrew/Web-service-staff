using StaffWebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace StaffWebApplication
{
    public class EFStaffRepository : IStaffRepository
    {
        private EFStaffDBContext Context;

        public EFStaffRepository(EFStaffDBContext context)
        {
            Context = context;
        }

        public Staff Get(int Id)
        {
            return Context.Staff
                .Select(st => new Staff
                {
                    Id = st.Id,
                    Name = st.Name,
                    Surname = st.Surname,
                    Phone = st.Phone,
                    CompanyId = st.CompanyId,
                    Pasport = st.Pasport
                })
                .Where(st => st.Id == Id)
                .FirstOrDefault();
        }

        public int Create(Staff item)
        {
            Context.Staff.Add(item);
            Context.SaveChanges();
            return 0;
        }
        public Staff Delete(int Id)
        {
            Staff staff = Get(Id);

            if (staff != null){
                Context.Staff.Remove(staff);
                Context.SaveChanges();
            }

            return staff;
        }

        public IEnumerable<Staff> GetFromCompany(int companyId)
        {
            IEnumerable<Staff> staffs = Context.Staff
                .Where(st => st.CompanyId == companyId)
                .Select(st => new Staff { 
                    Id = st.Id,
                    Name= st.Name,
                    Surname = st.Surname,
                    Phone = st.Phone,
                    CompanyId = st.CompanyId,
                    Pasport = st.Pasport });
                
            return staffs;
        }

        public void Update(Staff updatedStaff)
        {
            Staff currentItem = Get(updatedStaff.Id);
            if (updatedStaff.Name != null) currentItem.Name = updatedStaff.Name;
            if (updatedStaff.Surname != null) currentItem.Surname = updatedStaff.Surname;
            if (updatedStaff.Phone != null) currentItem.Phone = updatedStaff.Phone;
            if (updatedStaff.Pasport != null)
            {
                if (updatedStaff.Pasport.Number != null) currentItem.Pasport.Number = updatedStaff.Pasport.Number;
                if (updatedStaff.Pasport.Type != null) currentItem.Pasport.Type = updatedStaff.Pasport.Type;
            }
            if (updatedStaff.CompanyId!=0) currentItem.CompanyId = updatedStaff.CompanyId;
            Context.Staff.Update(currentItem);
            Context.SaveChanges();
        }
    }
}
