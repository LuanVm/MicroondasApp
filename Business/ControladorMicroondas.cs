using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MicroondasApp;
using Newtonsoft.Json;

public class ControladorMicroondas : IControladorMicroondas
{
    public Aquecimento AquecimentoAtual { get; private set; }
    private readonly List<ProgramaAquecimento> _programasPredefinidos;
    private List<ProgramaAquecimento> _programasCustomizados;

    public ControladorMicroondas()
    {
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

    public void IniciarAquecimento(int tempo, int potencia)
    {
        if (AquecimentoAtual == null)
        {
            AquecimentoAtual = new Aquecimento(tempo, potencia);
        }
        else if (AquecimentoAtual.EmPausa)
        {
            AquecimentoAtual.EmPausa = false;
        }
        else if (!AquecimentoAtual.IsPredefinido)
        {
            AquecimentoAtual.AdicionarTempo(30);
        }
    }

    public bool VerificarCaractereRepetido(char caractere)
    {
        char lowerChar = char.ToLower(caractere);

        // Garanta que as listas nunca sejam nulas
        var programasParaVerificar = _programasPredefinidos
            .Concat(_programasCustomizados ?? Enumerable.Empty<ProgramaAquecimento>());

        return programasParaVerificar
            .Any(p => p != null && char.ToLower(p.CaractereAquecimento) == lowerChar);
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
            // Marca como predefinido para ignorar o limite de tempo
            AquecimentoAtual = new Aquecimento(
                programa.TempoSegundos,
                programa.Potencia,
                isPredefinido: true, // Ignora validação de 120s
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
            var json = JsonConvert.SerializeObject(_programasCustomizados, Formatting.Indented);
            File.WriteAllText("programas_customizados.json", json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar programas: {ex.Message}");
        }
    }

    public List<ProgramaAquecimento> CarregarProgramasCustomizados()
    {
        var caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "programas_customizados.json");

        if (!File.Exists(caminho))
            return new List<ProgramaAquecimento>();

        try
        {
            var json = File.ReadAllText(caminho);
            var programas = JsonConvert.DeserializeObject<List<ProgramaAquecimento>>(json)
                            ?? new List<ProgramaAquecimento>();
            programas = programas.Where(p => p != null).ToList();

            // Lista combinada de pré-definidos + customizados já carregados
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
            MessageBox.Show($"Erro ao carregar: {ex.Message}");
            return new List<ProgramaAquecimento>();
        }
    }

    public void AtualizarListaCustomizados()
    {
        _programasCustomizados = CarregarProgramasCustomizados() ?? new List<ProgramaAquecimento>();
    }

    public class CharCaseInsensitiveComparer : IEqualityComparer<char>
    {
        public bool Equals(char x, char y) => char.ToLower(x) == char.ToLower(y);
        public int GetHashCode(char c) => char.ToLower(c).GetHashCode();
    }

    public void AdicionarProgramaCustomizado(ProgramaAquecimento programa)
    {
        // Validação reforçada
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
