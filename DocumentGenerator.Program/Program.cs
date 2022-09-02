using System;
using BusinessLogic.Services.Documents;

namespace DocumentGenerator.Program
{
    //"G:\\CSHARP\\SoftServe\\MilitaryManager\\MilitaryManager.Attachments.API\\wwwroot\\data\\document_templates\\template_01.xml"
    class Program
    {
        static void Main(string[] args)
        {
            IDocumentGenerationService documentGenerationService = new DocumentGenerationService();

            string exportPath = "G:\\pdfs\\";
            string templateName = "template_01";
            string templateData = "template_01.xml";
            string jsonData = "template_01.json";

            documentGenerationService.GeneratePdfDocument(exportPath, templateName, templateData, jsonData);

            Console.WriteLine("press enter please");
            Console.ReadLine();
        }
    }
}