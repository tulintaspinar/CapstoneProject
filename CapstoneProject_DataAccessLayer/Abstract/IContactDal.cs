﻿using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.Abstract
{
    public interface IContactDal
    {
        Contact GetContact();
        void UpdateContact(Contact contact);
    }
}
