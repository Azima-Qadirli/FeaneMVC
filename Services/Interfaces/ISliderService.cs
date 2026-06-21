using Feane.ViewModels.Slider;

namespace Feane.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<SliderGetVM>> GetAllAsync();
        Task <SliderUpdateVM> GetByIdAsync(int id);
        Task CreateAsync(SliderCeateVM vm );
        Task Update (SliderUpdateVM vm );
        Task DeleteAsync(int id);

    }
}
