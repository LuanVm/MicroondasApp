using System;
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
            }
        }

        private void btnProgramaPipoca_Click(object sender, EventArgs e)
        {
            _controlador.IniciarProgramaPredefinido("Pipoca");
            txtTempo.Text = "180";
            txtPotencia.Text = "7";
            txtTempo.Enabled = false;
            txtPotencia.Enabled = false;
            _timer.Start();
        }

        // Implementar handlers similares para outros programas
    }
}