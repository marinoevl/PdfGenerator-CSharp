using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Mustache;

namespace App.Shared.Extensions;

public static class StringExtensions
{
    public static string GetMergeTemplateWithData(this string templateContent, Dictionary<string, object> data)
    {
        var compiler = new FormatCompiler();
        return compiler
            .Compile(templateContent)
            .Render(data);
    }

    public static byte[] ConvertHtmlStringToPdf(this string value)
    {
        var sr = new StringReader(value);
        byte[] bytes;
        var pdfFile = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        var htmlparser = new HTMLWorker(pdfFile);
        using var memoryStream = new MemoryStream();
        PdfWriter.GetInstance(pdfFile, memoryStream);
        pdfFile.Open();
        htmlparser.Parse(sr);
        pdfFile.Close();
        bytes = memoryStream.ToArray();

        return bytes;
    }

    public static string FromBase64ToString(this string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) return value;
        return Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}