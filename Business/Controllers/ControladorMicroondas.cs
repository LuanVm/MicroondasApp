namespace MicroondasApp.Business.Controllers
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MicroondasApp.Business.Models;
using MicroondasApp.Business.Repositories;
using MicroondasApp.Business.Utils;



/// <summary>
/// Controla as operações do micro-ondas, como iniciar, pausar e cancelar aquecimentos.
/// </summary>
    public class ControladorMicroondas : IControladorMicroondas
    {
        /// <summary>
        /// Obtém o aquecimento atual em andamento.
        /// </summary>
        public Aquecimento AquecimentoAtual { get; private set; }
        private readonly List<ProgramaAquecimento> _programasPredefinidos;
        private List<ProgramaAquecimento> _programasCustomizados;
        private readonly IProgramaRepository _programaRepository;

        public ControladorMicroondas(IProgramaRepository programaRepository)
        {
            _programaRepository = programaRepository ?? throw new ArgumentNullException(nameof(programaRepository));

            _programasPredefinidos = new List<ProgramaAquecimento>
            {
                new ProgramaAquecimento("Pipoca", "Pipoca (de micro-ondas)", 180, 7, '*',
                    "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento."),
                new ProgramaAquecimento("Leite", "Leite", 300, 5, '~',
                    "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras."),
                new ProgramaAquecimento("Carnes", "Carne em pedaço ou fatias", 840, 4, '#',
                    "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
                new ProgramaAquecimento("Frango", "Frango (qualquer corte)", 480, 7, '@',
                    "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
                new ProgramaAquecimento("Feijão", "Feijão congelado", 480, 9, '&',
                    "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.")
            };

            _programasCustomizados = CarregarProgramasCustomizados() ?? new List<ProgramaAquecimento>();
        }

        public List<ProgramaAquecimento> ListarProgramasPredefinidos()
            => new List<ProgramaAquecimento>(_programasPredefinidos);

        public List<ProgramaAquecimento> ListarProgramasCustomizados()
            => new List<ProgramaAquecimento>(_programasCustomizados);

        /// <summary>
        /// Inicia um aquecimento com o tempo e potência especificados.
        /// </summary>
        /// <param name="tempo">Tempo em segundos (1-120).</param>
        /// <param name="potencia">Potência (1-10).</param>
        /// <exception cref="ArgumentException">Lançada se tempo ou potência forem inválidos.</exception>
        public void IniciarAquecimento(int tempo, int potencia)
        {
            Utilitarios.ValidarTempo(tempo);
            Utilitarios.ValidarPotencia(potencia);

            AquecimentoAtual = new Aquecimento(tempo, potencia);
        }

        public bool VerificarCaractereRepetido(char caractere)
        {
            char lowerChar = char.ToLower(caractere);
            var programasParaVerificar = _programasPredefinidos.Concat(_programasCustomizados);
            return programasParaVerificar.Any(p => p != null && char.ToLower(p.CaractereAquecimento) == lowerChar);
        }

        public void IniciarProgramaPredefinido(string nomePrograma)
        {
            var programa = _programasPredefinidos.FirstOrDefault(p => p.Nome == nomePrograma);
            if (programa != null)
            {
                AquecimentoAtual = new Aquecimento(
                    programa.TempoSegundos,
                    programa.Potencia,
                    isPredefinido: true,
                    caractere: programa.CaractereAquecimento
                );
            }
        }

        public void IniciarProgramaCustomizado(string nomePrograma)
        {
            var programa = _programasCustomizados.FirstOrDefault(p => p.Nome == nomePrograma);
            if (programa != null)
            {
                AquecimentoAtual = new Aquecimento(
                    programa.TempoSegundos,
                    programa.Potencia,
                    isPredefinido: true,
                    caractere: programa.CaractereAquecimento
                );
            }
            else
            {
                throw new ArgumentException("Programa customizado não encontrado");
            }
        }

        public void PausarAquecimento()
        {
            if (AquecimentoAtual != null && !AquecimentoAtual.Concluido)
            {
                AquecimentoAtual.EmPausa = true;
            }
        }

        public void CancelarAquecimento()
        {
            AquecimentoAtual = null;
        }

        public void SalvarProgramasCustomizados()
        {
            try
            {
                _programaRepository.SalvarProgramasCustomizados(_programasCustomizados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<ProgramaAquecimento> CarregarProgramasCustomizados()
        {
            try
            {
                var programas = _programaRepository.CarregarProgramasCustomizados();
                programas = programas.Where(p => p != null).ToList();

                // Validação movida para o Controlador
                var todosProgramas = _programasPredefinidos.Concat(programas).ToList();
                foreach (var programa in programas)
                {
                    if (todosProgramas.Any(p =>
                        p != programa &&
                        char.ToLower(p.CaractereAquecimento) == char.ToLower(programa.CaractereAquecimento)))
                    {
                        MessageBox.Show($"Caractere '{programa.CaractereAquecimento}' em conflito!");
                        return new List<ProgramaAquecimento>();
                    }
                }

                return programas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<ProgramaAquecimento>();
            }
        }

        public void AtualizarListaCustomizados()
        {
            _programasCustomizados = CarregarProgramasCustomizados() ?? new List<ProgramaAquecimento>();
        }

        public void AdicionarProgramaCustomizado(ProgramaAquecimento programa)
        {
            if (programa == null)
                throw new ArgumentNullException("Programa não pode ser nulo");

            if (!programa.IsCustomizado)
                throw new ArgumentException("Apenas programas customizados podem ser adicionados");

            if (_programasCustomizados.Any(p => p.Nome.Equals(programa.Nome, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"Já existe um programa com o nome '{programa.Nome}'");

            if (VerificarCaractereRepetido(programa.CaractereAquecimento))
                throw new ArgumentException($"Caractere '{programa.CaractereAquecimento}' já está em uso");

            _programasCustomizados.Add(programa);
            SalvarProgramasCustomizados();
        }

        public void RemoverProgramaCustomizado(string nome)
        {
            var programa = _programasCustomizados.FirstOrDefault(p => p.Nome == nome);
            if (programa != null)
            {
                _programasCustomizados.Remove(programa);
                SalvarProgramasCustomizados();
            }
        }
    }
}