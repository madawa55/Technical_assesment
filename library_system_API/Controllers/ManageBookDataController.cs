using library_system_API.Models;
using library_system_API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library_system_API.Controllers
{
    
    [ApiController]
    public class ManageBookDataController : ControllerBase
    {
        public readonly IRepository _Repository;

        public ManageBookDataController(IRepository repository)
        {
            _Repository = repository;
        }


        [Route("api/manage-book-information")]
        [HttpGet]
        public List<MasterBookInformation> Get()
        {
            return _Repository.GetAllBookDetails();
        }

        [Route("api/manage-book-information/get-value")]
        [HttpPost]
        public MasterBookInformation GetDataByID(MasterBookinfoRequest book)
        {
            return _Repository.GetAllBookDetailsByValue(book);
        }

        [Route("api/manage-book-information/add-book")]
        [HttpPost]
        public bool AddBook(MasterBookinfoRequest book)
        {
            return _Repository.AddBookInformation(book);
        }

        [Route("api/manage-book-information/update-book/{ISBN}")]
        [HttpPut]
        public bool UpdateBook(string ISBN, MasterBookinfoUpdateRequest book)
        {
            return _Repository.UpdateBookInformation(ISBN,book);
        }

        [Route("api/manage-book-information/delete-book/{ISBN}")]
        [HttpDelete]
        public bool UpdateBook(string ISBN)
        {
            return _Repository.DeleteBookInformation(ISBN);
        }


    }
}
