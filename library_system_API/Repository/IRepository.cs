using library_system_API.Models;

namespace library_system_API.Repository
{
    public interface IRepository
    {
        public List<MasterBookInformation> GetAllBookDetails();
        public MasterBookInformation GetAllBookDetailsByValue(MasterBookinfoRequest bookdetail);
        public bool AddBookInformation(MasterBookinfoRequest bookdetail);
        public bool UpdateBookInformation(string ISBN, MasterBookinfoUpdateRequest bookdetail);
        public bool DeleteBookInformation(string ISBN);
    }
}
