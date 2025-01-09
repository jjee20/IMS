namespace PresentationLayer.Views.IViews
{
    public interface IGoodsReceivedNoteView
    {
        int GoodsReceivedNoteId { get; set; }
        string GoodsReceivedNoteName { get; set; }
        int PurchaseOrderId { get; set; }
        DateTimeOffset GRNDate { get; set; }
        string VendorDONumber { get; set; }
        string VendorInvoiceNumber { get; set; }
        int WarehouseId { get; set; }
        bool IsFullReceive { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        //void SetAddressBindingSource(List<string> barangayBindingSource,
        //                             List<string> municipalityBindingSource, 
        //                             List<string> provinceBindingSource, 
        //                             List<string> regionBindingSource);
        void SetGoodsReceivedNoteListBindingSource(BindingSource GoodsReceivedNoteList);
        void SetPurchaseOrderListBindingSource(BindingSource PurchaseOrderBindingSource);
        void SetWarehouseListBindingSource(BindingSource WarehouseBindingSource);
    }
}