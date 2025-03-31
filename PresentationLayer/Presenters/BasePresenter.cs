using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Presenters
{
    public abstract class BasePresenter<TView, TModel>
    where TView : class
    where TModel : class
    {
        protected TView _view;
        protected IUnitOfWork _unitOfWork;
        protected BindingSource BindingSource;
        protected IEnumerable<TModel> ModelList;

        public BasePresenter(TView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            BindingSource = new BindingSource();

            LoadAllData();
            BindData();
            RegisterEvents();
        }

        protected abstract void LoadAllData();
        protected abstract void BindData();
        protected abstract TModel GetModel();
        protected abstract void SetViewModel(TModel model);
        protected abstract void SaveModel(TModel model);

        private void RegisterEvents()
        {
            if (_view is ICrudView)
            {
                var crudView = _view as ICrudView;
                crudView.AddNewEvent += AddNew;
                crudView.SaveEvent += Save;
                crudView.EditEvent += Edit;
                crudView.DeleteEvent += Delete;
                crudView.SearchEvent += Search;
                crudView.PrintEvent += Print;
                crudView.RefreshEvent += Refresh;
            }
        }

        private void AddNew(object? sender, EventArgs e)
        {
            (_view as ICrudView).IsEdit = false;
            SetViewModel(Activator.CreateInstance<TModel>());
        }

        private void Save(object? sender, EventArgs e)
        {
            var model = GetModel();
            SaveModel(model);
        }

        private void Edit(object? sender, EventArgs e)
        {
            if (BindingSource.Current is TModel selectedModel)
            {
                SetViewModel(selectedModel);
            }
        }

        private void Delete(object? sender, EventArgs e)
        {
            if (BindingSource.Current is TModel selectedModel)
            {
                //_unitOfWork.GetRepository<TModel>().Remove(selectedModel);
                _unitOfWork.Save();
                LoadAllData();
            }
        }

        private void Search(object? sender, EventArgs e)
        {
            LoadAllData();
        }

        private void Print(object? sender, EventArgs e)
        {
            // Implement Print Logic
        }

        private void Refresh(object? sender, EventArgs e)
        {
            LoadAllData();
        }
    }

}
