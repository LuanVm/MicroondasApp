using System.Windows.Forms;

namespace MicroondasApp
{
    partial class CustomProgramForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomProgramForm));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtAlimento = new System.Windows.Forms.TextBox();
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.txtPotencia = new System.Windows.Forms.TextBox();
            this.txtCaractere = new System.Windows.Forms.TextBox();
            this.txtInstrucoes = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelAlimento = new System.Windows.Forms.Label();
            this.labelTempo = new System.Windows.Forms.Label();
            this.labelPotencia = new System.Windows.Forms.Label();
            this.labelCaractere = new System.Windows.Forms.Label();
            this.labelInstrucoes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(120, 20);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 23);
            this.txtNome.TabIndex = 0;
            // 
            // txtAlimento
            // 
            this.txtAlimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlimento.Location = new System.Drawing.Point(120, 55);
            this.txtAlimento.Name = "txtAlimento";
            this.txtAlimento.Size = new System.Drawing.Size(200, 23);
            this.txtAlimento.TabIndex = 1;
            // 
            // txtTempo
            // 
            this.txtTempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempo.Location = new System.Drawing.Point(120, 90);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(80, 23);
            this.txtTempo.TabIndex = 2;
            // 
            // txtPotencia
            // 
            this.txtPotencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPotencia.Location = new System.Drawing.Point(120, 125);
            this.txtPotencia.Name = "txtPotencia";
            this.txtPotencia.Size = new System.Drawing.Size(80, 23);
            this.txtPotencia.TabIndex = 3;
            // 
            // txtCaractere
            // 
            this.txtCaractere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaractere.Location = new System.Drawing.Point(120, 160);
            this.txtCaractere.Name = "txtCaractere";
            this.txtCaractere.Size = new System.Drawing.Size(40, 23);
            this.txtCaractere.TabIndex = 4;
            // 
            // txtInstrucoes
            // 
            this.txtInstrucoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstrucoes.Location = new System.Drawing.Point(120, 195);
            this.txtInstrucoes.Multiline = true;
            this.txtInstrucoes.Name = "txtInstrucoes";
            this.txtInstrucoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInstrucoes.Size = new System.Drawing.Size(200, 80);
            this.txtInstrucoes.TabIndex = 5;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(120, 285);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 32);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(230, 285);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelNome.ForeColor = System.Drawing.Color.DimGray;
            this.labelNome.Location = new System.Drawing.Point(23, 22);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(49, 15);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome*:";
            // 
            // labelAlimento
            // 
            this.labelAlimento.AutoSize = true;
            this.labelAlimento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelAlimento.ForeColor = System.Drawing.Color.DimGray;
            this.labelAlimento.Location = new System.Drawing.Point(23, 57);
            this.labelAlimento.Name = "labelAlimento";
            this.labelAlimento.Size = new System.Drawing.Size(66, 15);
            this.labelAlimento.TabIndex = 1;
            this.labelAlimento.Text = "Alimento*:";
            // 
            // labelTempo
            // 
            this.labelTempo.AutoSize = true;
            this.labelTempo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTempo.ForeColor = System.Drawing.Color.DimGray;
            this.labelTempo.Location = new System.Drawing.Point(23, 92);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(69, 15);
            this.labelTempo.TabIndex = 2;
            this.labelTempo.Text = "Tempo (s)*:";
            this.labelTempo.Click += new System.EventHandler(this.labelTempo_Click);
            // 
            // labelPotencia
            // 
            this.labelPotencia.AutoSize = true;
            this.labelPotencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPotencia.ForeColor = System.Drawing.Color.DimGray;
            this.labelPotencia.Location = new System.Drawing.Point(23, 127);
            this.labelPotencia.Name = "labelPotencia";
            this.labelPotencia.Size = new System.Drawing.Size(63, 15);
            this.labelPotencia.TabIndex = 3;
            this.labelPotencia.Text = "Potência*:";
            // 
            // labelCaractere
            // 
            this.labelCaractere.AutoSize = true;
            this.labelCaractere.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCaractere.ForeColor = System.Drawing.Color.DimGray;
            this.labelCaractere.Location = new System.Drawing.Point(23, 162);
            this.labelCaractere.Name = "labelCaractere";
            this.labelCaractere.Size = new System.Drawing.Size(69, 15);
            this.labelCaractere.TabIndex = 4;
            this.labelCaractere.Text = "Caractere*:";
            // 
            // labelInstrucoes
            // 
            this.labelInstrucoes.AutoSize = true;
            this.labelInstrucoes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelInstrucoes.ForeColor = System.Drawing.Color.DimGray;
            this.labelInstrucoes.Location = new System.Drawing.Point(23, 197);
            this.labelInstrucoes.Name = "labelInstrucoes";
            this.labelInstrucoes.Size = new System.Drawing.Size(90, 30); // Altura aumentada
            this.labelInstrucoes.TabIndex = 5;
            this.labelInstrucoes.Text = "Instruções:\r\n(opcional)";
            this.labelInstrucoes.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // CustomProgramForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(350, 335);
            this.Controls.Add(this.labelInstrucoes);
            this.Controls.Add(this.labelCaractere);
            this.Controls.Add(this.labelPotencia);
            this.Controls.Add(this.labelTempo);
            this.Controls.Add(this.labelAlimento);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtInstrucoes);
            this.Controls.Add(this.txtCaractere);
            this.Controls.Add(this.txtPotencia);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.txtAlimento);
            this.Controls.Add(this.txtNome);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomProgramForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Programa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtNome;
        private TextBox txtAlimento;
        private TextBox txtTempo;
        private TextBox txtPotencia;
        private TextBox txtCaractere;
        private TextBox txtInstrucoes;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label labelNome;
        private Label labelAlimento;
        private Label labelTempo;
        private Label labelPotencia;
        private Label labelCaractere;
        private Label labelInstrucoes;
    }
}