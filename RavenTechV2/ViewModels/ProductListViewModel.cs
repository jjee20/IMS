using System.Collections.ObjectModel;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using DomainLayer.ViewModels.Inventory;
using RavenTechV2.Contracts.ViewModels;
using ServiceLayer.Services.IRepositories;

namespace RavenTechV2.ViewModels;

public partial class ProductListViewModel : ObservableRecipient, INavigationAware

{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ObservableCollection<ProductViewModel> Source { get; } = new ObservableCollection<ProductViewModel>();

    public ProductListViewModel()
    {
        _unitOfWork = App.GetService<IUnitOfWork>();
        _mapper = App.GetService<IMapper>();
    }

    public async void OnNavigatedTo(object parameter)
    {
        await ReloadAsync();
    }
    public async Task ReloadAsync()
    {
        Source.Clear();
        var data = _mapper.Map<IEnumerable<ProductViewModel>>(await _unitOfWork.Product.Value.GetAllAsync(includeProperties: "UnitOfMeasure,Branch"));
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }
    public void OnNavigatedFrom()
    {
    }

}
