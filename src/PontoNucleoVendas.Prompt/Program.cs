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

            // Lista arquivos
            var homeDir = Environment.GetEnvironmentVariable("HOMEPATH");
            var inPath = $"{homeDir}\\data\\in";

            // Cria a pasta, caso não exista
            
            var dir = new DirectoryInfo($"{homeDir}\\data\\in");        

            foreach (FileInfo file in dir.GetFiles())
            {
                // Armazena caminho e conteudo        
                
                var inFileContent = File.ReadAllText(file.FullName);
                var inFileLines = File.ReadAllLines(file.FullName);
                var inFile = new InFile(Guid.NewGuid(),
                                        file.FullName,
                                        inFileContent);
                inFiles.Add(inFile);                

                foreach (var line in inFileLines)
                {
                    inFile.AddLine(line);
                    switch (line.Substring(0, 3))
                    {
                        case "001":
                            inFile.AddSellers(line);
                            break;
                        case "002":
                            inFile.AddCustomers(line);
                            break;
                        case "003":
                            inFile.AddSales(line);
                            break;
                        default:
                            break;
                    }
                }            
                
                WriteInConsole(inFiles);
                
                // Lê o conteudo

                // Armazena o dat

                // Separa as sessões 001, 002, 003

                // Salva os clientes

                // Salva os vendedores

                // Salva os produtos

                // Salva as vendas

                // Cria a pasta read, caso não exista

                // move o arquido para /read                

            }

            return new List<string>();
        }

        public static void WriteInConsole(List<InFile> inFiles)
        {
            foreach (var inFile in inFiles)
            {                
                Console.WriteLine($"Id: {inFile.Id}");
                Console.WriteLine($"SourcePath: {inFile.SourcePath}");
                Console.WriteLine($"Content:\n\n{inFile.Content}\n");
            }
        }
    }
}
