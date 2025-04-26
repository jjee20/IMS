using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services.Helpers
{
    public abstract class DataGridHelper
    {
        public static void ApplyDisplayNames<T>(BindingSource bindingSource, DataGridView dataGridView)
        {
            // Bind the data
            dataGridView.DataSource = bindingSource;

            // Iterate through each property of the model type T
            foreach (var property in typeof(T).GetProperties())
            {
                var displayAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), true)
                                               .FirstOrDefault() as DisplayAttribute;

                // If the property has a Display attribute, set the header text in the DataGridView
                if (displayAttribute != null)
                {
                    var column = dataGridView.Columns[property.Name];
                    if (column != null)
                    {
                        column.HeaderText = displayAttribute.Name;
                    }
                }
            }
        }
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
