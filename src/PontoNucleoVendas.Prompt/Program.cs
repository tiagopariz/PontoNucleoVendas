using System;
using System.Collections.Generic;
using System.IO;
using PontoNucleoVendas.Domain.Entities;

namespace PontoNucleoVendas.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            { 
                Console.WriteLine("\nPress CTRL + C to stop.");               
                ProcessFiles();
                Waiting(10);
            }
        }

        public static void ProcessFiles()
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
            
            var files = new DirectoryInfo(inPath).GetFiles("*.dat");
            if (files.Length < 1)
            {
                Console.WriteLine($"{inPath} is empty.");
                return;
            }
            // Lista os arquivos
            foreach (var file in new DirectoryInfo(inPath).GetFiles("*.dat"))
            {
                // Cria um novo objeto com o arquivo e conteúdo
                var inFile = new InFile(Guid.NewGuid(),
                                        file.FullName,
                                        File.ReadAllText(file.FullName));                              

                inFiles.Add(inFile);
                file.MoveTo($"{inPathRead}\\{file.Name}");

                var outFile = new OutFile(Guid.NewGuid(), inFile);
                var outPath = $"{homeDir}\\data\\out";

                // Criar o arquivo de saída
                File.WriteAllText($"{outPath}\\" + file.Name.Replace(".dat", "_report.dat") , outFile.Out);                  
            }

            WriteInConsole(inFiles);
        }

        public static void WriteInConsole(List<InFile> inFiles)
        {
            Console.ForegroundColor = ConsoleColor.Green;
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
                    Console.WriteLine($"\nSale: {sale.Id}, {sale.SaleId}, {sale.SalesmanId}, {sale.Total}");
                    foreach (var saleItem in sale.SaleItems)
                    {
                        Console.WriteLine($"    Item: {saleItem.Id}, {saleItem.ProductId}, {saleItem.Quantity}, {saleItem.Price}");
                    }
                }

                var outFile = new OutFile(Guid.NewGuid(), inFile);
                Console.WriteLine();
                Console.WriteLine(outFile.Out);
                Console.ResetColor();
            }
        }

        private static void Waiting(int seconds)
        {
            Console.Write($"Waiting {seconds} seconds.");
            for (int i = 0; i < seconds; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");                
            }   
        }
    }
}
