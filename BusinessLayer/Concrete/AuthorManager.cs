using BusinessLayer.Abstract;
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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authordal;

        Repository<Author> repoauthor = new Repository<Author>();

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }
        public List<Author> GetList()
        {
           return _authordal.List();
        }

        public void AuthorAdd(Author author)
        {
            _authordal.Insert(author);
        }

        public Author GetByID(int id)
        {
            return _authordal.GetById(id);
        }
        public void AuthorUpdate(Author author)
        {
           _authordal.Update(author);
        }

        public void AuthorDelete(Author author)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Author t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Author t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Author t)
        {
            throw new NotImplementedException();
        }
    }
}
