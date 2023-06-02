using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library_system.Models;
using System.Linq;

namespace library_system.Repository
{
    public class Repository
    {
        private library_systemEntities2 db;
        public List<SelectallBooks_Result> RetriveDataFromStordProcedure()
        {
            using (db = new library_systemEntities2())
            {
                List<SelectallBooks_Result> lib_data = db.SelectallBooks().ToList();
                CommonDataMapper mapper = new CommonDataMapper();
                var data = mapper.MainBookDetailsMapper(lib_data);
                return data;
            }
        }

        public List<master_book_information> RetriveDataFromEFModel()
        {
            using (db = new library_systemEntities2())
            {
                List<master_book_information> booksData = (from x in db.master_book_information select x ).ToList();
                CommonDataMapper mapper = new CommonDataMapper();
                var data = mapper.MainBookDetailsEFMapper(booksData);
                return data;
            }
        }

        public List<SubCategoryModel> SubCategoryById(int id)
        {
            using (db = new library_systemEntities2())
            {
                CommonDataMapper mapper = new CommonDataMapper();
                List<SubCategoryModel> subcategory = mapper.SubCategoryMapper((from x in db.sub_category where x.main_category_id == id select x).ToList());

                return subcategory;
            }
        }

        public List<category_details> GetAllCategoryDetails()
        {
            using (db = new library_systemEntities2())
            {
                var all_category = (from x in db.category_details select x).ToList();
                return all_category;
            }
        }
    }
}