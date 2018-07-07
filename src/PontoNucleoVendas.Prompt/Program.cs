using System;
using System.Collections.Generic;
using System.IO;
using PontoNucleoVendas.Domain;

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
            var filesIn = new List<string>();

            // Lista arquivos
            var homeDir = Environment.GetEnvironmentVariable("HOMEPATH");
            var inPath = $"{homeDir}\\data\\in";

            // Cria a pasta, caso não exista

            Console.WriteLine($"Files in {homeDir}\\data\\in"); 
            

            var dir = new DirectoryInfo($"{homeDir}\\data\\in");

            

            foreach (FileInfo file in dir.GetFiles())
            {
                // Armazena caminho completo               
                Console.WriteLine(file.FullName);
                
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
    }
}
