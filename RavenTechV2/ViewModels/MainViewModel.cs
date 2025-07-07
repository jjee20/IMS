using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RavenTechV2.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    // --- Dropdowns ---
    public ObservableCollection<int> Years { get; } = new ObservableCollection<int> { 2023, 2024, 2025 };
    public ObservableCollection<string> Months
    {
        get;
    } = new ObservableCollection<string>
            { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    private int _selectedYear;
    public int SelectedYear
    {
        get => _selectedYear;
        set => SetProperty(ref _selectedYear, value);
    }

    private string _selectedMonth;
    public string SelectedMonth
    {
        get => _selectedMonth;
        set => SetProperty(ref _selectedMonth, value);
    }

    // --- Summary Cards ---
    private double _grossProfit = 99999;
    public double GrossProfit
    {
        get => _grossProfit;
        set => SetProperty(ref _grossProfit, value);
    }

    private double _salesProfit = 99999;
    public double SalesProfit
    {
        get => _salesProfit;
        set => SetProperty(ref _salesProfit, value);
    }

    private double _expenses = 99999;
    public double Expenses
    {
        get => _expenses;
        set => SetProperty(ref _expenses, value);
    }

    // --- Metrics Row ---
    private double _salesToday = 99999;
    public double SalesToday
    {
        get => _salesToday;
        set => SetProperty(ref _salesToday, value);
    }

    private double _itemsSoldToday = 99999;
    public double ItemsSoldToday
    {
        get => _itemsSoldToday;
        set => SetProperty(ref _itemsSoldToday, value);
    }

    private double _expenseToday = 99999;
    public double ExpenseToday
    {
        get => _expenseToday;
        set => SetProperty(ref _expenseToday, value);
    }

    // --- Chart Data (Demo classes, use your real data models) ---
    public ObservableCollection<ItemSales> TopSellingItems
    {
        get;
    } = new()
        {
            new ItemSales { Name="Item A", Value=150 },
            new ItemSales { Name="Item B", Value=100 },
            new ItemSales { Name="Item C", Value=90 }
        };

    public ObservableCollection<SalesTrend> DailySales
    {
        get;
    } = new()
        {
            new SalesTrend { Day=1, Value=100 },
            new SalesTrend { Day=2, Value=120 },
            new SalesTrend { Day=3, Value=140 },
            // ... etc
        };

    public ObservableCollection<ProjectExpense> ProjectExpenses
    {
        get;
    } = new()
        {
            new ProjectExpense { Project="ER MALL", Amount=40000 },
            new ProjectExpense { Project="G611 CAGAYAN", Amount=30000 },
            new ProjectExpense { Project="SOLICAR", Amount=20000 }
        };

    public ObservableCollection<MonthlySalesData> MonthlySales
    {
        get;
    } = new()
        {
            new MonthlySalesData { Month="January", Sales=10000, Expenses=7000 },
            new MonthlySalesData { Month="February", Sales=12000, Expenses=8000 },
            // ... etc
        };

    // Constructor
    public MainViewModel()
    {
        SelectedYear = Years[0];
        SelectedMonth = Months[0];
    }

    // --- Demo data models for charts (replace as needed) ---
    public class ItemSales
    {
        public string Name
        {
            get; set;
        }
        public double Value
        {
            get; set;
        }
    }

    public class SalesTrend
    {
        public int Day
        {
            get; set;
        }
        public double Value
        {
            get; set;
        }
    }

    public class ProjectExpense
    {
        public string Project
        {
            get; set;
        }
        public double Amount
        {
            get; set;
        }
    }

    public class MonthlySalesData
    {
        public string Month
        {
            get; set;
        }
        public double Sales
        {
            get; set;
        }
        public double Expenses
        {
            get; set;
        }
    }
}
