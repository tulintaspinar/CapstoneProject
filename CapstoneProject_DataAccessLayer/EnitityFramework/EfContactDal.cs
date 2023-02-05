using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.EnitityFramework
{
    public class EfContactDal : IContactDal
    {
        public Contact GetContact()
        {
            using(var context =new Context())
            {
                return context.Contacts.FirstOrDefault();
            }
        }

        public void UpdateContact(Contact contact)
        {
           using(var context = new Context())
            {
                context.Contacts.Update(contact);
                context.SaveChanges();
            }
        }
    }
}
