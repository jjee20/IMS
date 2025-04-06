using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Presenters.Base
{
    public abstract class CrudPresenter<TView, TEntity> : BasePresenter<TView>
        where TView : ICrudView<TEntity>
        where TEntity : class, new()
    {
        protected IRepository<TEntity> _repository;

        protected CrudPresenter(TView view, IUnitOfWork unitOfWork, IRepository<TEntity> repository)
            : base(view, unitOfWork)
        {
            _repository = repository;
        }

        public virtual async Task LoadAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            try
            {
                var list = await _repository.GetAllAsync();
                if (predicate != null)
                    list = list.Where(predicate.Compile());

                _view.Items = list;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public virtual async Task SaveAsync(TEntity model, bool isEdit)
        {
            try
            {
                if (isEdit)
                    _repository.Update(model);
                else
                    await _repository.AddAsync(model);

                await _unitOfWork.SaveAsync();
                SetSuccess(isEdit ? "Updated successfully." : "Added successfully.");
                await LoadAllAsync();
                _view.ClearFields();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public virtual async Task DeleteAsync()
        {
            try
            {
                if (_view.SelectedItem == null)
                {
                    SetFailure("Please select an item to delete.");
                    return;
                }

                _repository.Remove(_view.SelectedItem);
                await _unitOfWork.SaveAsync();
                SetSuccess("Deleted successfully.");
                await LoadAllAsync();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public virtual async Task SearchAsync()
        {
            await LoadAllAsync(e => SearchPredicate(e, _view.SearchValue));
        }

        protected abstract bool SearchPredicate(TEntity entity, string searchText);
    }
}
