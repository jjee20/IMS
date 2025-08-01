using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Helpers;
public class PagerHelper<T> : INotifyPropertyChanged
{
    public ObservableCollection<T> PageItems { get; } = new();
    private List<T> _allItems = new();
    private int _pageSize = 10;
    private int _pageIndex = 0;
    public IEnumerable<T> AllItems => _allItems;

    public event PropertyChangedEventHandler PropertyChanged;

    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (_pageSize != value && value > 0)
            {
                _pageSize = value;
                _pageIndex = 0;
                Refresh();
                OnPropertyChanged(nameof(PageSize));
            }
        }
    }

    public int PageIndex
    {
        get => _pageIndex;
        set
        {
            if (_pageIndex != value && value >= 0 && value < TotalPages)
            {
                _pageIndex = value;
                Refresh();
                OnPropertyChanged(nameof(PageIndex));
                OnPropertyChanged(nameof(PageDisplay));
            }
        }
    }

    public int TotalPages => (_allItems.Count + PageSize - 1) / PageSize;

    public string PageDisplay => TotalPages > 0
        ? $"Page {PageIndex + 1} / {TotalPages}"
        : "Page 0 / 0";

    public void SetItems(IEnumerable<T> items)
    {
        _allItems = items?.ToList() ?? new List<T>();
        _pageIndex = 0;
        Refresh();
        OnPropertyChanged(nameof(TotalPages));
        OnPropertyChanged(nameof(PageDisplay));
    }

    public void Refresh()
    {
        PageItems.Clear();
        foreach (var item in _allItems.Skip(PageIndex * PageSize).Take(PageSize))
            PageItems.Add(item);
        OnPropertyChanged(nameof(PageDisplay));
    }

    public void FirstPage()
    {
        PageIndex = 0;
    }

    public void LastPage()
    {
        PageIndex = Math.Max(0, TotalPages - 1);
    }

    public void PrevPage()
    {
        if (PageIndex > 0)
            PageIndex--;
    }

    public void NextPage()
    {
        if (PageIndex < TotalPages - 1)
            PageIndex++;
    }

    protected void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
