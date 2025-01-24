using System;
using System.Linq;
using System.Windows.Forms;

namespace MicroondasApp
{
    public partial class MainForm : Form
    {
        private readonly ControladorMicroondas _controlador;
        private Timer _timer;

        public MainForm()
        {
            InitializeComponent();
            _controlador = new ControladorMicroondas();
            ConfigurarTimer();
            ConfigurarValoresPadrao();
            VincularEventosProgramasPredefinidos();
        }

        private void ConfigurarTimer()
        {
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += (s, e) => AtualizarInterface();
        }

        private void ConfigurarValoresPadrao()
        {
            txtPotencia.Text = "10";
        }

        private void VincularEventosProgramasPredefinidos()
        {
            btnProgramaPipoca.Click += ProgramaPredefinido_Click;
            btnProgramaLeite.Click += ProgramaPredefinido_Click;
            btnProgramaCarne.Click += ProgramaPredefinido_Click;
            btnProgramaFrango.Click += ProgramaPredefinido_Click;
            btnProgramaFeijao.Click += ProgramaPredefinido_Click;
        }

        private void AtualizarInterface()
        {
            if (_controlador.AquecimentoAtual == null) return;

            _controlador.AquecimentoAtual.Atualizar();

            lblMensagens.Text = _controlador.AquecimentoAtual.Progresso;
            lblTempoRestante.Text = Aquecimento.FormatarTempo(_controlador.AquecimentoAtual.TempoRestante);

            if (_controlador.AquecimentoAtual.Concluido)
            {
                _timer.Stop();
                btnPausarCancelar.Enabled = false;
            }
        }

        private void ProgramaPredefinido_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            string nomePrograma = botao.Text;
            IniciarProgramaPredefinido(nomePrograma);
        }

        private void IniciarProgramaPredefinido(string nomePrograma)
        {
            try
            {
                _controlador.IniciarProgramaPredefinido(nomePrograma);
                var programa = _controlador.ListarProgramasPredefinidos().First(p => p.Nome == nomePrograma);

                txtTempo.Text = programa.TempoSegundos.ToString();
                txtPotencia.Text = programa.Potencia.ToString();
                txtTempo.Enabled = false;
                txtPotencia.Enabled = false;

                _timer.Start();
                btnPausarCancelar.Enabled = true;
                lblMensagens.Text = $"Programa {nomePrograma} iniciado";
            }
            catch (Exception ex)
            {
                lblMensagens.Text = ex.Message;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_controlador.AquecimentoAtual?.EmPausa == true)
                {
                    _controlador.AquecimentoAtual.EmPausa = false;
                    _timer.Start();
                    return;
                }

                int tempo = ObterTempoValido();
                int potencia = ObterPotenciaValida();

                _controlador.IniciarAquecimento(tempo, potencia);
                _timer.Start();
                btnPausarCancelar.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                lblMensagens.Text = ex.Message;
            }
        }

        private int ObterTempoValido()
        {
            if (!int.TryParse(txtTempo.Text, out int tempo) || tempo < 1 || tempo > 120)
                throw new ArgumentException("Tempo inválido (1-120 segundos)");
            return tempo;
        }

        private int ObterPotenciaValida()
        {
            if (string.IsNullOrEmpty(txtPotencia.Text)) return 10;
            if (!int.TryParse(txtPotencia.Text, out int potencia) || potencia < 1 || potencia > 10)
                throw new ArgumentException("Potência inválida (1-10)");
            return potencia;
        }

        private void btnInicioRapido_Click(object sender, EventArgs e)
        {
            _controlador.IniciarAquecimento(30, 10);
            _timer.Start();
            btnPausarCancelar.Enabled = true;
            lblMensagens.Text = "Início rápido: 30s na potência 10";
        }

        private void btnPausarCancelar_Click(object sender, EventArgs e)
        {
            if (_controlador.AquecimentoAtual == null)
            {
                lblMensagens.Text = "Nenhum aquecimento em andamento";
                return;
            }

            if (_timer.Enabled)
            {
                _controlador.PausarAquecimento();
                _timer.Stop();
                btnPausarCancelar.Text = "Cancelar";
            }
            else
            {
                _controlador.CancelarAquecimento();
                btnPausarCancelar.Text = "Pausar/Cancelar";
                btnPausarCancelar.Enabled = false;
                lblMensagens.Text = "Aquecimento cancelado";
                txtTempo.Enabled = true;
                txtPotencia.Enabled = true;
            }
        }
        private void btnProgramaPipoca_Click(object sender, EventArgs e)
        {
            // Lógica para o programa de Pipoca
            int tempo = 3; // em minutos
            int potencia = 7;
            string instrucoes = "Observar o barulho de estouros do milho. Caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento.";

            // Chamada para iniciar o aquecimento
            IniciarAquecimento(tempo, potencia, instrucoes);
        }

        private void btnProgramaLeite_Click(object sender, EventArgs e)
        {
            // Lógica para o programa de Leite
            int tempo = 5; // em minutos
            int potencia = 5;
            string instrucoes = "Cuidado com aquecimento de líquidos. O choque térmico e o movimento do recipiente podem causar fervura imediata, provocando risco de queimaduras.";

            // Chamada para iniciar o aquecimento
            IniciarAquecimento(tempo, potencia, instrucoes);
        }

        private void btnProgramaCarne_Click(object sender, EventArgs e)
        {
            // Lógica para o programa de Carne
            int tempo = 14; // em minutos
            int potencia = 4;
            string instrucoes = "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para descongelamento uniforme.";

            // Chamada para iniciar o aquecimento
            IniciarAquecimento(tempo, potencia, instrucoes);
        }

        private void btnProgramaFrango_Click(object sender, EventArgs e)
        {
            // Lógica para o programa de Frango
            int tempo = 8; // em minutos
            int potencia = 7;
            string instrucoes = "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para descongelamento uniforme.";

            // Chamada para iniciar o aquecimento
            IniciarAquecimento(tempo, potencia, instrucoes);
        }

        private void btnProgramaFeijao_Click(object sender, EventArgs e)
        {
            // Lógica para o programa de Feijão
            int tempo = 8; // em minutos
            int potencia = 9;
            string instrucoes = "Deixe o recipiente destampado e, em casos de plástico, cuidado ao retirar o recipiente, pois ele pode perder resistência em altas temperaturas.";

            // Chamada para iniciar o aquecimento
            IniciarAquecimento(tempo, potencia, instrucoes);
        }

        // Método genérico para iniciar o aquecimento
        private void IniciarAquecimento(int tempo, int potencia, string instrucoes)
        {
            // Exibe as informações na interface
            lblMensagens.Text = $"Iniciando... Tempo: {tempo} min, Potência: {potencia}\nInstruções: {instrucoes}";

            // Aqui, você pode adicionar a lógica para controlar o aquecimento de acordo com o tempo e a potência.
            // Exemplo: iniciar o temporizador, ajustar a potência, etc.
        }

    }
}
