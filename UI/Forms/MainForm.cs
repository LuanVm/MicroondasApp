using System;
using System.Drawing;
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
            _controlador = new ControladorMicroondas(new ProgramaRepository()); // Injeção de dependência
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

        private void btnProgramaPipoca_Click(object sender, EventArgs e)
        {
            IniciarProgramaPredefinido("Pipoca");
        }

        private void btnProgramaLeite_Click(object sender, EventArgs e)
        {
            IniciarProgramaPredefinido("Leite");
        }

        private void btnProgramaCarne_Click(object sender, EventArgs e)
        {
            IniciarProgramaPredefinido("Carnes");
        }

        private void btnProgramaFrango_Click(object sender, EventArgs e)
        {
            IniciarProgramaPredefinido("Frango");
        }

        private void btnProgramaFeijao_Click(object sender, EventArgs e)
        {
            IniciarProgramaPredefinido("Feijão");
        }

        private void AtualizarInterface()
        {
            if (_controlador.AquecimentoAtual == null) return;

            _controlador.AquecimentoAtual.Atualizar();

            lblMensagens.Text = _controlador.AquecimentoAtual.Progresso;
            lblTempoRestante.Text = _controlador.AquecimentoAtual.Concluido
                ? "00:00 Restantes"
                : $"{Aquecimento.FormatarTempo(_controlador.AquecimentoAtual.TempoRestante)} Restantes";

            if (_controlador.AquecimentoAtual.Concluido)
            {
                btnPausarCancelar.Enabled = false;
                txtTempo.Enabled = true;
                txtPotencia.Enabled = true;
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

                // Exibir as instruções no label
                lblInstrucoes.Text = programa.Instrucoes;

                _timer.Start();
                btnPausarCancelar.Enabled = true;
                lblMensagens.Text = $"Programa {nomePrograma} iniciado";
            }
            catch (Exception ex)
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
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_controlador.AquecimentoAtual?.EmPausa == true)
                {
                    _controlador.AquecimentoAtual.EmPausa = false;
                    _timer.Start();
                    btnPausarCancelar.Text = "Pausar/Cancelar";
                    return;
                }

                int tempo = ObterTempoValido();
                int potencia = ObterPotenciaValida();

                _controlador.IniciarAquecimento(tempo, potencia);
                _timer.Start();
                btnPausarCancelar.Enabled = true;
                txtTempo.Enabled = false;
                txtPotencia.Enabled = false;
            }
            catch (ArgumentException ex)
            {
                lblMensagens.Text = ex.Message;
            }
        }

        private void btnInicioRapido_Click(object sender, EventArgs e)
        {
            _controlador.IniciarAquecimento(30, 10);
            _timer.Start();
            btnPausarCancelar.Enabled = true;
            txtTempo.Text = "30";
            txtPotencia.Text = "10";
            txtTempo.Enabled = false;
            txtPotencia.Enabled = false;
            lblMensagens.Text = "Início rápido: 30s na potência 10";
        }

        private void btnPausarCancelar_Click(object sender, EventArgs e)
        {
            if (_controlador.AquecimentoAtual == null) return;

            if (_timer.Enabled)
            {
                _controlador.PausarAquecimento();
                _timer.Stop();
                btnPausarCancelar.Text = "Cancelar";
                lblMensagens.Text = "Aquecimento pausado";
            }
            else
            {
                _controlador.CancelarAquecimento();
                _timer.Stop();
                lblMensagens.Text = "Aquecimento cancelado";
                btnPausarCancelar.Text = "Pausar/Cancelar";
                btnPausarCancelar.Enabled = false;
                lblInstrucoes.Text = "";
                txtTempo.Enabled = true;
                txtPotencia.Enabled = true;
                txtTempo.Clear();
                txtPotencia.Text = "10";
                lblTempoRestante.Text = "00:00 Restantes";
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _controlador.AtualizarListaCustomizados();
                CarregarProgramasCustomizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro crítico: {ex.Message}");
            }
        }

        private void CarregarProgramasCustomizados()
        {
            flowProgramas.Controls.Clear();

            foreach (var programa in _controlador.ListarProgramasCustomizados())
            {
                var btn = new Button
                {
                    Text = programa.Nome,
                    Tag = programa,
                    Size = new Size(140, 150),
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    TextImageRelation = TextImageRelation.TextAboveImage,
                    Image = programa.Imagem ?? null
                };
                btn.Click += ProgramaCustomizado_Click;

                var toolTip = new ToolTip();
                toolTip.SetToolTip(btn, programa.Instrucoes);

                flowProgramas.Controls.Add(btn);
            }

            flowProgramas.Refresh();
        }

        private void btnNovoPrograma_Click(object sender, EventArgs e)
        {
            using (var form = new CustomProgramForm(_controlador))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Recarrega TUDO do zero
                    _controlador.AtualizarListaCustomizados();
                    CarregarProgramasCustomizados();

                    flowProgramas.PerformLayout();
                    this.Update();
                    this.Refresh();
                }
            }
        }

        private void ProgramaCustomizado_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            var programa = (ProgramaAquecimento)botao.Tag;

            if (programa == null)
            {
                lblMensagens.Text = "Programa inválido.";
                return;
            }

            try
            {
                // Verifica se o programa está na lista (evita null)
                if (!_controlador.ListarProgramasCustomizados()?.Any(p => p.Nome == programa.Nome) ?? true)
                    throw new ArgumentException("Programa não encontrado.");

                _controlador.IniciarProgramaCustomizado(programa.Nome);

                // Atualiza interface
                txtTempo.Text = programa.TempoSegundos.ToString();
                txtPotencia.Text = programa.Potencia.ToString();
                txtTempo.Enabled = false;
                txtPotencia.Enabled = false;

                lblInstrucoes.Text = programa.Instrucoes;
                _timer.Start();
                btnPausarCancelar.Enabled = true;
                lblMensagens.Text = $"Programa {programa.Nome} iniciado";
            }
            catch (Exception ex)
            {
                lblMensagens.Text = $"Erro: {ex.Message}";
            }
        }



        private void lblExemploTempo_Click(object sender, EventArgs e)
        {

        }

        private void flowProgramas_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}