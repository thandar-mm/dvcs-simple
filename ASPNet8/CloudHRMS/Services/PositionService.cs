using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repostories;

namespace CloudHRMS.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            this._positionRepository = positionRepository;
        }
        public void Create(PositionViewModel positionViewModel)
        {
            try
            {
                var isPositionCodeAlreadyExits = _positionRepository.GetAll().Where(w => w.Code == positionViewModel.Code).Any();
                if (isPositionCodeAlreadyExits)
                {
                    throw new Exception("Code already existsint the System");
                }
                else
                {
                    var position = new PositionEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Code = positionViewModel.Code,
                        Name = positionViewModel.Name,
                        Level = positionViewModel.Level,
                    };
                    _positionRepository.Create(position);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(string Id)
        {
            _positionRepository.Delete(Id);
        }

        public IList<PositionViewModel> GetAll()
        {
            return _positionRepository.GetAll().Select(
                  s => new PositionViewModel
                  {
                      Id = s.Id,
                      Code = s.Code,
                      Name = s.Name,
                      Level = s.Level,
                  }).ToList();
        }

        public PositionViewModel GetByID(string id)
        {
            var positionEntity = _positionRepository.GetById(id);
            return new PositionViewModel()
            {
                Id = positionEntity.Id,
                Code = positionEntity.Code,
                Name = positionEntity.Name,
                Level = positionEntity.Level
            };
        }

        public void Update(PositionViewModel positionViewModel)
        {
            try
            {
                var position = new PositionEntity()
                {
                    Id = positionViewModel.Id,
                    Code = positionViewModel.Code,
                    Name = positionViewModel.Name,
                    Level = positionViewModel.Level,
                    ModifiedAt = DateTime.Now
                };
                _positionRepository.Update(position);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
