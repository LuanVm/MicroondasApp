using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class ControladorMicroondas : IControladorMicroondas
{
    public Aquecimento AquecimentoAtual { get; private set; }
    private readonly List<ProgramaAquecimento> _programasPredefinidos;
    private List<ProgramaAquecimento> _programasCustomizados;  // Lista de programas customizados

    public ControladorMicroondas()
    {
        _programasPredefinidos = new List<ProgramaAquecimento>
        {
            new ProgramaAquecimento("Pipoca", "Pipoca (de micro-ondas)", 180, 7, '*', "Observar o barulho de estouros"),
            new ProgramaAquecimento("Leite", "Leite", 300, 5, '~', "Cuidado com fervura instantânea"),
            new ProgramaAquecimento("Carnes", "Carne em pedaços", 840, 4, '#', "Virar na metade do tempo"),
            new ProgramaAquecimento("Frango", "Frango", 480, 7, '@', "Virar na metade do tempo"),
            new ProgramaAquecimento("Feijão", "Feijão congelado", 480, 9, '&', "Recipiente destampado")
        };

        _programasCustomizados = CarregarProgramasCustomizados(); // Carrega programas customizados do arquivo JSON
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
        // Verificando em programas pré-definidos
        if (_programasPredefinidos.Any(p => p.CaractereAquecimento == caractere))
            return true;

        // Verificando em programas customizados
        if (_programasCustomizados.Any(p => p.CaractereAquecimento == caractere))
            return true;

        return false;
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
        var json = JsonConvert.SerializeObject(_programasCustomizados, Formatting.Indented);
        File.WriteAllText("programas_customizados.json", json);
    }

    private List<ProgramaAquecimento> CarregarProgramasCustomizados()
    {
        if (!File.Exists("programas_customizados.json")) return new List<ProgramaAquecimento>();

        var json = File.ReadAllText("programas_customizados.json");
        return JsonConvert.DeserializeObject<List<ProgramaAquecimento>>(json);
    }
}
