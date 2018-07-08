using System;
using System.Collections.Generic;
using System.IO;
using PontoNucleoVendas.Domain;
using PontoNucleoVendas.Domain.Entities;

namespace PontoNucleoVendas.Prompt
{
    class Program
    {
        static void Main(string[] args)
        {            
            ListInFiles();
        }

        public static List<string> ListInFiles()
        {
            var inFiles = new List<InFile>();

            // Caminhos
            var homeDir = Environment.GetEnvironmentVariable("HOMEPATH");
            var inPath = $"{homeDir}\\data\\in";
            var inPathRead = $"{inPath}\\read";

            // Cria as pastas, caso não existam
            if (!Directory.Exists(inPath))
                Directory.CreateDirectory(inPath);

            if (!Directory.Exists(inPathRead))
                Directory.CreateDirectory(inPathRead);
            
            // Lista os arquivos
            foreach (FileInfo file in new DirectoryInfo(inPath).GetFiles())
            {
                // Cria um novo objeto com o arquivo e conteúdo
                var inFile = new InFile(Guid.NewGuid(),
                                        file.FullName,
                                        File.ReadAllText(file.FullName));                              

                inFiles.Add(inFile);
                file.MoveTo($"{inPathRead}\\{file.Name}");

                var outFile = new OutFile(Guid.NewGuid(), inFile);                
            }

            WriteInConsole(inFiles);

            return new List<string>();
        }

        public static void WriteInConsole(List<InFile> inFiles)
        {
            Console.WriteLine($"Files: {inFiles.Count}\n");

            foreach (var inFile in inFiles)
            {                
                Console.WriteLine($"Id: {inFile.Id}");
                Console.WriteLine($"SourcePath: {inFile.SourcePath}");
                Console.WriteLine($"Content: {inFile.Content}\n");

                foreach (var salesman in inFile.Sellers)
                {
                    Console.WriteLine($"Salesman: {salesman.Id}, {salesman.Name}, {salesman.Salary}");
                }

                foreach (var customer in inFile.Customers)
                {
                    Console.WriteLine($"Customer: {customer.Id}, {customer.Name}, {customer.BusinessArea}");
                }

                foreach (var sale in inFile.Sales)
                {
                    Console.WriteLine($"\nSale: {sale.Id}, {sale.SaleId}, {sale.SalesmanId}, {sale.Total()}");
                    foreach (var saleItem in sale.SaleItems)
                    {
                        Console.WriteLine($"    Item: {saleItem.Id}, {saleItem.ProductId}, {saleItem.Quantity}, {saleItem.Price}");
                    }
                }

                var outFile = new OutFile(Guid.NewGuid(), inFile);
                Console.WriteLine();
                Console.WriteLine(outFile.Out);
            }
        }
    }
}
