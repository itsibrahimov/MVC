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
    public class BlogManager:IBlogService
    {
        IBlogDal _blogDal;

        Repository<Blog> repoblog = new Repository<Blog>();

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetBlogByID(int id) 
        {
            return _blogDal.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x=>x.AuthorID == id);
        }
        public List<Blog>GetBlogByCategory(int id)
        {
            return repoblog.List(x=>x.CategoryID == id);
        }
        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void BlogAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public Blog GetByID(int id)
        {
            return _blogDal.GetById(id);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public void TAdd(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }
    }
}