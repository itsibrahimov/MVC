﻿using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager:IContactService
    {
        IContactDal _contactDal;

        Repository<Contact> repocontact = new Repository<Contact>();

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public List<Contact> GetList()
        {
           return _contactDal.List();
        }

        public void TAdd(Contact t)
        {
            _contactDal.Insert(t);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Find(x => x.ContactID == id);
        }

        public void TDelete(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
