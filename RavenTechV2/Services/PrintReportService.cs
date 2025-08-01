using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.XlsIO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RavenTechV2.Services;
public class PrintReportService
{
    /// <summary>
    /// Generates a PDF report with a title, optional subtitle, and a table.
    /// </summary>
    /// <param name="title">Main report title</param>
    /// <param name="subtitle">Subtitle/date, etc. (optional)</param>
    /// <param name="tableData">List of objects for the PdfGrid</param>
    /// <param name="autoOpen">If true, opens the PDF after saving</param>
    /// <returns>Path to saved PDF file</returns>
    public async Task<string> GeneratePdfReportAsync(
    string title, string subtitle, string date, IEnumerable<object> tableData, bool autoOpen = true)
    {
        using var document = new PdfDocument();
        var page = document.Pages.Add();
        var gfx = page.Graphics;
        var margin = 20f;
        var pageWidth = page.GetClientSize().Width;

        // Fonts
        var logoLabelFont = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
        var titleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 20, PdfFontStyle.Bold);
        var subtitleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
        var spacing = 4;
        var textBlockHeight = titleFont.Height + subtitleFont.Height + spacing;

        // 1. Draw Logo (height same as text block)
        var logoHeight = textBlockHeight;
        var logoWidth = textBlockHeight;
        var exePath = AppContext.BaseDirectory;
        var logoPath = Path.Combine(exePath, "Assets", "RavenTech.png");
        using (var logoStream = File.OpenRead(logoPath))
        {
            var logo = new PdfBitmap(logoStream);
            gfx.DrawImage(logo, margin, margin, logoWidth, logoHeight);
        }

        // 2. Draw "RavenTech" text beside logo (vertically centered)
        var logoLabel = "RavenTech";
        var logoLabelWidth = logoLabelFont.MeasureString(logoLabel).Width;
        var logoLabelX = margin + logoWidth + 10; // 10px gap after logo
        var logoLabelY = margin + (logoHeight - logoLabelFont.Height) / 2;
        gfx.DrawString(logoLabel, logoLabelFont, PdfBrushes.DarkSlateGray, new Syncfusion.Drawing.PointF(logoLabelX, logoLabelY));

        // 3. Draw Title & Subtitle upper right, right-aligned
        var titleWidth = titleFont.MeasureString(title).Width;
        var subtitleWidth = subtitleFont.MeasureString(subtitle).Width;
        var textRight = pageWidth - margin;
        var textY = margin;
        gfx.DrawString(title, titleFont, PdfBrushes.DarkBlue, new Syncfusion.Drawing.PointF(textRight - titleWidth, textY));
        textY += titleFont.Height + spacing;
        gfx.DrawString(subtitle, subtitleFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(textRight - subtitleWidth, textY));

        // 4. Set Y after header row (logo or text block height, they are equal now)
        var y = margin + textBlockHeight + 10;

        // 5. Centered Date
        var dateFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11);
        var dateWidth = dateFont.MeasureString(date).Width;
        gfx.DrawString(date, dateFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF((pageWidth - dateWidth) / 2, y));
        y += dateFont.Height + 12;

        // 6. Separator
        gfx.DrawLine(new PdfPen(PdfBrushes.Black, 1.5f), margin, y, pageWidth - margin, y);
        y += 8;

        // 7. Draw grid, aligned to both margins
        if (tableData != null)
        {
            var grid = new PdfGrid();
            grid.DataSource = tableData;
            grid.Style.CellPadding = new PdfPaddings(5, 5, 5, 5);
            grid.Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 11);

            // Force first column header to "Id"
            if (grid.Columns.Count > 0 && grid.Headers.Count > 0)
                grid.Headers[0].Cells[0].Value = "Id";

            // Fit grid to page margins
            var gridWidth = pageWidth - margin * 2;
            var colCount = grid.Columns.Count;
            var colWidth = gridWidth / colCount;
            foreach (PdfGridColumn col in grid.Columns)
                col.Width = colWidth;

            grid.Draw(page, new Syncfusion.Drawing.PointF(margin, y));
        }

        // 8. Add footer with page x of y to all pages
        var pageCount = document.Pages.Count;
        for (var i = 0; i < pageCount; i++)
        {
            var footerPage = document.Pages[i];
            var gfxFooter = footerPage.Graphics;

            var pageLabel = $"Page {i + 1} of {pageCount}";
            var footerFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
            var labelWidth = footerFont.MeasureString(pageLabel).Width;

            var footerY = footerPage.GetClientSize().Height - margin + 5;
            gfxFooter.DrawString(
                pageLabel,
                footerFont,
                PdfBrushes.Gray,
                new Syncfusion.Drawing.PointF((pageWidth - labelWidth) / 2, footerY)
            );
        }

        // 9. Save document
        var fileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

        using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            document.Save(fs);

        if (autoOpen)
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

        return filePath;
    }

    public async Task<string> GenerateExcelReportAsync(IEnumerable<object> tableData, string reportTitle)
    {
        using (var excelEngine = new ExcelEngine())
        {
            var app = excelEngine.Excel;
            app.DefaultVersion = ExcelVersion.Xlsx;

            // Create a workbook and worksheet
            var workbook = app.Workbooks.Create(1);
            var worksheet = workbook.Worksheets[0];
            worksheet.Name = reportTitle;

            var customerList = tableData.ToList();
            if (!customerList.Any())
                throw new InvalidOperationException("No data to export.");

            // Write headers
            var properties = customerList[0].GetType().GetProperties();
            for (int col = 0; col < properties.Length; col++)
            {
                worksheet.Range[1, col + 1].Text = properties[col].Name;
                worksheet.Range[1, col + 1].CellStyle.Font.Bold = true;
            }

            // Write data rows
            for (int row = 0; row < customerList.Count; row++)
            {
                for (int col = 0; col < properties.Length; col++)
                {
                    var value = properties[col].GetValue(customerList[row]);
                    worksheet.Range[row + 2, col + 1].Text = value?.ToString() ?? "";
                }
            }

            worksheet.UsedRange.AutofitColumns();

            // Save to Documents folder
            var fileName = $"{reportTitle.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            // Save the workbook to a file stream
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.SaveAs(fileStream);
            }

            // Optionally, open after saving
            await Task.Delay(100); // Just to ensure file is saved
            return filePath;
        }
    }
}
