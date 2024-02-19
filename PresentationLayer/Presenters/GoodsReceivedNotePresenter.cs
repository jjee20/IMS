using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class GoodsReceivedNotePresenter
    {
        public IGoodsReceivedNoteView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource GoodsReceivedNoteBindingSource;
        private IEnumerable<GoodsReceivedNote> GoodsReceivedNoteList;
        public GoodsReceivedNotePresenter(IGoodsReceivedNoteView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            GoodsReceivedNoteBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetGoodsReceivedNoteListBindingSource(GoodsReceivedNoteBindingSource);

            //Load

            LoadAllGoodsReceivedNoteList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            try
            {
                // Check if the GoodsReceivedNote already exists by name
                var existingEntity = _unitOfWork.GoodsReceivedNote.Get(c => c.GoodsReceivedNoteName == _view.GoodsReceivedNoteName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.GoodsReceivedNoteId != _view.GoodsReceivedNoteId)
                        {
                            _view.Message = "Another Customer type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Customer type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the GoodsReceivedNote entity
                GoodsReceivedNote entity;
                if (_view.GoodsReceivedNoteId == 0)
                {
                    entity = new GoodsReceivedNote()
                    {
                        GoodsReceivedNoteName = _view.GoodsReceivedNoteName,
                        //Description = _view.Description
                    };
                    _unitOfWork.GoodsReceivedNote.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.GoodsReceivedNote.Get(c => c.GoodsReceivedNoteId == _view.GoodsReceivedNoteId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.GoodsReceivedNoteName = _view.GoodsReceivedNoteName;
                    //entity.Description = _view.Description;
                    _unitOfWork.GoodsReceivedNote.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Customer type edited successfully" : "Customer type added successfully";
                _view.IsSuccessful = true;

                // Clear view fields
                CleanviewFields();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        //private void Save(object? sender, EventArgs e)
        //{
        //   var Entity = _unitOfWork.GoodsReceivedNote.Get(c => c.GoodsReceivedNoteName == _view.GoodsReceivedNoteName);
        //   if (Entity != null && _view.GoodsReceivedNoteId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.GoodsReceivedNoteId == 0)
        //        {

        //        Entity = new GoodsReceivedNote()
        //        {
        //            GoodsReceivedNoteId = _view.GoodsReceivedNoteId,
        //            GoodsReceivedNoteName = _view.GoodsReceivedNoteName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.GoodsReceivedNoteName = _view.GoodsReceivedNoteName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.GoodsReceivedNote.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.GoodsReceivedNote.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type added sucessfully";
        //            }
        //            _view.IsSuccessful = true;
        //            CleanviewFields();
        //        }
        //        catch (Exception ex)
        //        {
        //            _view.IsSuccessful = false;
        //            _view.Message = ex.Message;
        //        }
        //}
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            if (emptyValue == false)
            {
                GoodsReceivedNoteList = _unitOfWork.GoodsReceivedNote.GetAll(c => c.GoodsReceivedNoteName.Contains(_view.SearchValue));
                GoodsReceivedNoteBindingSource.DataSource = GoodsReceivedNoteList;
            }
            else
            {
                GoodsReceivedNoteList = _unitOfWork.GoodsReceivedNote.GetAll();
                GoodsReceivedNoteBindingSource.DataSource = GoodsReceivedNoteList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (GoodsReceivedNote)GoodsReceivedNoteBindingSource.Current;
            _view.GoodsReceivedNoteId = entity.GoodsReceivedNoteId;
            _view.GoodsReceivedNoteName = entity.GoodsReceivedNoteName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (GoodsReceivedNote)GoodsReceivedNoteBindingSource.Current;
                _unitOfWork.GoodsReceivedNote.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllGoodsReceivedNoteList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "GoodsReceivedNoteListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("GoodsReceivedNoteList", GoodsReceivedNoteList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllGoodsReceivedNoteList();
        }
        private void CleanviewFields()
        {
            LoadAllGoodsReceivedNoteList();
            _view.GoodsReceivedNoteId = 0;
            _view.GoodsReceivedNoteName = "";
            _view.Description = "";
        }
        
        private void LoadAllGoodsReceivedNoteList()
        {
            GoodsReceivedNoteList = _unitOfWork.GoodsReceivedNote.GetAll();
            GoodsReceivedNoteBindingSource.DataSource = GoodsReceivedNoteList;//Set data source.
        }
    }
}
