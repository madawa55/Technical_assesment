using library_system_API.Models;
using System.Data;
using System.Reflection;
using Microsoft.Identity.Client;

namespace library_system_API.Repository
{
    public class Repository : IRepository
    {
        private LibrarySystemContext db;

        //Retrive All Book Details
        public List<MasterBookInformation> GetAllBookDetails()
        {
            List<MasterBookInformation> bookDetails = new List<MasterBookInformation>();
            using (db = new LibrarySystemContext())
            {
                bookDetails = (from x in db.MasterBookInformations select x).ToList();
                return bookDetails;
            }

        }

        //Retrive book information using parameter
        public MasterBookInformation GetAllBookDetailsByValue(MasterBookinfoRequest bookdetail)
        {
            MasterBookInformation selectedBookInformation = new MasterBookInformation();
            Type type = typeof(MasterBookinfoRequest);
            PropertyInfo[] properties = type.GetProperties();
            if (bookdetail is not null)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo property = properties[i];
                    if (property.Name == "Id")
                    {
                        continue;
                    }
                    else
                    {
                        using (db = new LibrarySystemContext())
                        {
                            if (bookdetail.GetType().GetProperty(property.Name).GetValue(bookdetail) != null)
                            {
                                var allbookinformation = (from b in db.MasterBookInformations select b).ToList();
                                selectedBookInformation = allbookinformation.Where(x =>
                                                        x.GetType().GetProperty(property.Name).GetValue(x).ToString().ToLower() ==
                                                        bookdetail.GetType().GetProperty(property.Name).GetValue(bookdetail).ToString()
                                                        .ToLower()).FirstOrDefault();
                            }
                        }
                    }


                }
            }

            return selectedBookInformation;

        }

        //Insert Book information
        public bool AddBookInformation(MasterBookinfoRequest bookdetail)
        {
            try
            {
                using (db = new LibrarySystemContext())
                {
                    MasterBookInformation book = new MasterBookInformation();
                    book.Isbn = bookdetail.Isbn;
                    book.BookName = bookdetail.BookName;
                    book.CategoryId = bookdetail.CategoryId;
                    book.SubCategoryId = bookdetail.SubCategoryId;
                    book.AuthorId = bookdetail.AuthorId;
                    book.PublishedYear = bookdetail.PublishedYear;
                    db.MasterBookInformations.Add(book);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Update Book information
        public bool UpdateBookInformation(string ISBN, MasterBookinfoUpdateRequest bookdetail)
        {
            try
            {
                using (db = new LibrarySystemContext())
                {
                    var book = (from x in db.MasterBookInformations where x.Isbn == ISBN select x).FirstOrDefault();
                    book.BookName = bookdetail.BookName ?? book.BookName;
                    book.CategoryId = bookdetail.CategoryId ?? book.CategoryId;
                    book.SubCategoryId = bookdetail.SubCategoryId ?? book.SubCategoryId;
                    book.AuthorId = bookdetail.AuthorId ?? book.AuthorId;
                    book.PublishedYear = bookdetail.PublishedYear ?? book.PublishedYear;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //Delete Book information
        public bool DeleteBookInformation(string ISBN)
        {
            try
            {
                using (db = new LibrarySystemContext())
                {
                    var book = (from x in db.MasterBookInformations where x.Isbn == ISBN select x).FirstOrDefault();
                    db.MasterBookInformations.Remove(book);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Retrive all Category Details
        public List<CategoryDetail> GetCategoryDetail()
        {
            List<CategoryDetail> categorydetails = new List<CategoryDetail>();
            using (db = new LibrarySystemContext())
            {
                categorydetails = (from x in db.CategoryDetails select x).ToList();
                return categorydetails;
            }
        }

        //Retrive category information using parameter
        public CategoryDetail GetCategoryDetailsByValue(CategoryDetail categorydetail)
        {
            CategoryDetail selectedCategoryDetails = new CategoryDetail();
            Type type = typeof(CategoryDetail);
            PropertyInfo[] properties = type.GetProperties();
            if (categorydetail is not null)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo property = properties[i];
                    if (property.Name == "Id")
                    {
                        continue;
                    }
                    else
                    {
                        using (db = new LibrarySystemContext())
                        {
                            if (categorydetail.GetType().GetProperty(property.Name).GetValue(categorydetail) != null)
                            {
                                var allcategorydata = (from b in db.CategoryDetails select b).ToList();
                                selectedCategoryDetails = allcategorydata.Where(x =>
                                    x.GetType().GetProperty(property.Name).GetValue(x).ToString().ToLower() ==
                                    categorydetail.GetType().GetProperty(property.Name).GetValue(categorydetail).ToString()
                                        .ToLower()).FirstOrDefault();
                            }
                        }
                    }


                }
            }

            return selectedCategoryDetails;

        }

        //Add Category Details
        public bool AddCategoryDetaisl(CategoryDetail categorydetail)
        {
            try
            {
                using (db = new LibrarySystemContext())
                {
                    CategoryDetail category = new CategoryDetail();
                    category.CategoryName = categorydetail.CategoryName;
                    db.CategoryDetails.Add(category);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Update Category Details
        public bool UpdateCategoryDetails(int Id, CategoryDetail category)
        {
            try
            {
                using (db = new LibrarySystemContext())
                {
                    var categorydetails = (from x in db.CategoryDetails where x.Id == Id select x).FirstOrDefault();
                    categorydetails.CategoryName = category.CategoryName ?? categorydetails.CategoryName;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Delete Category Details
        public bool DeleteCategoryDetails(int Id)
        {
            try
            {
                using (db = new LibrarySystemContext())
                {
                    var category = (from x in db.CategoryDetails where x.Id == Id select x).FirstOrDefault();
                    db.CategoryDetails.Remove(category);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
