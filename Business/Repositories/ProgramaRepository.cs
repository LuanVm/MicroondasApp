using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using MicroondasApp.Business.Models;

namespace MicroondasApp.Business.Repositories
{
    public class ProgramaRepository : IProgramaRepository
    {
        private readonly string _caminhoArquivo;

        public ProgramaRepository()
        {
            _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "programas_customizados.json");
        }

        public void SalvarProgramasCustomizados(List<IProgramaAquecimento> programas)
        {
            try
            {
                var json = JsonConvert.SerializeObject(programas, Formatting.Indented);
                File.WriteAllText(_caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar programas: {ex.Message}", ex);
            }
        }

        public List<IProgramaAquecimento> CarregarProgramasCustomizados()
        {
            try
            {
                if (!File.Exists(_caminhoArquivo))
                    return new List<IProgramaAquecimento>();

                var json = File.ReadAllText(_caminhoArquivo);
                return JsonConvert.DeserializeObject<List<IProgramaAquecimento>>(json)
                       ?? new List<IProgramaAquecimento>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar programas: {ex.Message}", ex);
            }
        }
    }
}