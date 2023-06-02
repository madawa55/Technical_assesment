using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using library_system.Models;

namespace library_system.Repository
{
    public class CommonDataMapper
    {
        public List<SelectallBooks_Result> MainBookDetailsMapper(List<SelectallBooks_Result> book_information)
        {
            List<SelectallBooks_Result> bookDetails = new List<SelectallBooks_Result>();
            foreach (var book in book_information)
            {
                bookDetails.Add(new SelectallBooks_Result()
                {
                    id = book.id,
                    isbn = book.isbn,
                    book_name = book.book_name,
                    category_id = book.category_id,
                    sub_category_id = book.sub_category_id,
                    author_id = book.author_id,
                });
            }

            return bookDetails;
        }

        public List<master_book_information> MainBookDetailsEFMapper(List<master_book_information> book_information)
        {
            List<master_book_information> bookDetails = new List<master_book_information>();
            foreach (var book in book_information)
            {
                bookDetails.Add(new master_book_information()
                {
                    id = book.id,
                    isbn = book.isbn,
                    book_name = book.book_name,
                    category_id = book.category_id,
                    sub_category_id = book.sub_category_id,
                    author_id = book.author_id,
                });
            }

            return bookDetails;
        }

        public List<SubCategoryModel> SubCategoryMapper(List<sub_category> subCategory)
        {
            List<SubCategoryModel> subcategory = new List<SubCategoryModel>();
            foreach (var category in subCategory)
            {
                subcategory.Add(new SubCategoryModel()
                {
                    id = category.id,
                    main_category_id = category.main_category_id,
                    sub_category_name = category.sub_category_name
                });
            }

            return subcategory;
        }
    }
}