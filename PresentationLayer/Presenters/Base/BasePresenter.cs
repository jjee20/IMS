using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Presenters.Base
{
    public abstract class BasePresenter<TView>
    {
        protected readonly TView _view;
        protected readonly IUnitOfWork _unitOfWork;

        protected BasePresenter(TView view, IUnitOfWork unitOfWork)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected void ShowError(Exception ex)
        {
            if (_view is IViewWithMessage messageView)
            {
                messageView.Message = $"An error occurred: {ex.Message}";
                messageView.IsSuccessful = false;
            }
        }

        protected void SetSuccess(string message)
        {
            if (_view is IViewWithMessage messageView)
            {
                messageView.Message = message;
                messageView.IsSuccessful = true;
            }
        }

        protected void SetFailure(string message)
        {
            if (_view is IViewWithMessage messageView)
            {
                messageView.Message = message;
                messageView.IsSuccessful = false;
            }
        }
    }

    public interface IViewWithMessage
    {
        string Message { get; set; }
        bool IsSuccessful { get; set; }
    }
}
