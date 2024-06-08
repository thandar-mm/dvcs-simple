using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IPositionService
    {
        void Create(PositionViewModel positionViewModel);
        IList<PositionViewModel> GetAll();

        PositionViewModel GetByID(string id);

        void Update(PositionViewModel positionViewModel);

        void Delete(string Id);
    }
}
