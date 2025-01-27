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

        public void SalvarProgramasCustomizados(List<ProgramaAquecimento> programas)
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

        public List<ProgramaAquecimento> CarregarProgramasCustomizados()
        {
            try
            {
                if (!File.Exists(_caminhoArquivo))
                    return new List<ProgramaAquecimento>();

                var json = File.ReadAllText(_caminhoArquivo);
                return JsonConvert.DeserializeObject<List<ProgramaAquecimento>>(json)
                       ?? new List<ProgramaAquecimento>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar programas: {ex.Message}", ex);
            }
        }
    }
}