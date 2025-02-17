using QubitWith.Auth.Data.Models.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QubitWith.Auth.Components.Utilities
{
    public class AdmissionLetter:IDocument
    {
        private Student student = new();
        public AdmissionLetter(Student _student)
        {
            student = _student;
        }

        

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Height(100).Background(Colors.Grey.Lighten1);
                     page.Content().Background(Colors.Grey.Lighten3);
                    page.Footer().Height(50).Background(Colors.Grey.Lighten1);
                });
        }
    }
}
