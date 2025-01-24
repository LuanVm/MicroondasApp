using System;
using System.Linq;

namespace MicroondasApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.txtPotencia = new System.Windows.Forms.TextBox();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblPotencia = new System.Windows.Forms.Label();
            this.lblMensagens = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnInicioRapido = new System.Windows.Forms.Button();
            this.btnPausarCancelar = new System.Windows.Forms.Button();
            this.groupBoxConfiguracoes = new System.Windows.Forms.GroupBox();
            this.lblExemploTempo = new System.Windows.Forms.Label();
            this.lblExemploPotencia = new System.Windows.Forms.Label();
            this.groupBoxProgramas = new System.Windows.Forms.GroupBox();
            this.btnProgramaFeijao = new System.Windows.Forms.Button();
            this.btnProgramaFrango = new System.Windows.Forms.Button();
            this.btnProgramaCarne = new System.Windows.Forms.Button();
            this.btnProgramaLeite = new System.Windows.Forms.Button();
            this.btnProgramaPipoca = new System.Windows.Forms.Button();
            this.imgListProgramas = new System.Windows.Forms.ImageList(this.components);
            this.lblTempoRestante = new System.Windows.Forms.Label();
            this.groupBoxConfiguracoes.SuspendLayout();
            this.groupBoxProgramas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTempo
            // 
            this.txtTempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempo.Location = new System.Drawing.Point(20, 50);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(150, 29);
            this.txtTempo.TabIndex = 0;
            this.txtTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPotencia
            // 
            this.txtPotencia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPotencia.Location = new System.Drawing.Point(20, 120);
            this.txtPotencia.Name = "txtPotencia";
            this.txtPotencia.Size = new System.Drawing.Size(150, 29);
            this.txtPotencia.TabIndex = 1;
            this.txtPotencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTempo.Location = new System.Drawing.Point(20, 30);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(55, 19);
            this.lblTempo.TabIndex = 2;
            this.lblTempo.Text = "Tempo";
            // 
            // lblPotencia
            // 
            this.lblPotencia.AutoSize = true;
            this.lblPotencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPotencia.Location = new System.Drawing.Point(20, 100);
            this.lblPotencia.Name = "lblPotencia";
            this.lblPotencia.Size = new System.Drawing.Size(67, 19);
            this.lblPotencia.TabIndex = 3;
            this.lblPotencia.Text = "Potência";
            // 
            // lblMensagens
            // 
            this.lblMensagens.BackColor = System.Drawing.Color.White;
            this.lblMensagens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMensagens.Font = new System.Drawing.Font("Consolas", 12F);
            this.lblMensagens.Location = new System.Drawing.Point(50, 467);
            this.lblMensagens.Name = "lblMensagens";
            this.lblMensagens.Padding = new System.Windows.Forms.Padding(5);
            this.lblMensagens.Size = new System.Drawing.Size(775, 66);
            this.lblMensagens.TabIndex = 4;
            this.lblMensagens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(274, 50);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(150, 40);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnInicioRapido
            // 
            this.btnInicioRapido.BackColor = System.Drawing.Color.Teal;
            this.btnInicioRapido.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnInicioRapido.ForeColor = System.Drawing.Color.White;
            this.btnInicioRapido.Location = new System.Drawing.Point(274, 100);
            this.btnInicioRapido.Name = "btnInicioRapido";
            this.btnInicioRapido.Size = new System.Drawing.Size(150, 40);
            this.btnInicioRapido.TabIndex = 3;
            this.btnInicioRapido.Text = "Início Rápido";
            this.btnInicioRapido.UseVisualStyleBackColor = false;
            this.btnInicioRapido.Click += new System.EventHandler(this.btnInicioRapido_Click);
            // 
            // btnPausarCancelar
            // 
            this.btnPausarCancelar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnPausarCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPausarCancelar.ForeColor = System.Drawing.Color.White;
            this.btnPausarCancelar.Location = new System.Drawing.Point(430, 50);
            this.btnPausarCancelar.Name = "btnPausarCancelar";
            this.btnPausarCancelar.Size = new System.Drawing.Size(150, 40);
            this.btnPausarCancelar.TabIndex = 5;
            this.btnPausarCancelar.Text = "Pausar/Cancelar";
            this.btnPausarCancelar.UseVisualStyleBackColor = false;
            this.btnPausarCancelar.Click += new System.EventHandler(this.btnPausarCancelar_Click);
            // 
            // groupBoxConfiguracoes
            // 
            this.groupBoxConfiguracoes.Controls.Add(this.lblExemploTempo);
            this.groupBoxConfiguracoes.Controls.Add(this.lblExemploPotencia);
            this.groupBoxConfiguracoes.Controls.Add(this.txtTempo);
            this.groupBoxConfiguracoes.Controls.Add(this.lblTempo);
            this.groupBoxConfiguracoes.Controls.Add(this.lblPotencia);
            this.groupBoxConfiguracoes.Controls.Add(this.txtPotencia);
            this.groupBoxConfiguracoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxConfiguracoes.Location = new System.Drawing.Point(50, 30);
            this.groupBoxConfiguracoes.Name = "groupBoxConfiguracoes";
            this.groupBoxConfiguracoes.Size = new System.Drawing.Size(200, 200);
            this.groupBoxConfiguracoes.TabIndex = 6;
            this.groupBoxConfiguracoes.TabStop = false;
            this.groupBoxConfiguracoes.Text = "Configurações";
            // 
            // lblExemploTempo
            // 
            this.lblExemploTempo.AutoSize = true;
            this.lblExemploTempo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExemploTempo.Location = new System.Drawing.Point(20, 80);
            this.lblExemploTempo.Name = "lblExemploTempo";
            this.lblExemploTempo.Size = new System.Drawing.Size(116, 15);
            this.lblExemploTempo.TabIndex = 7;
            this.lblExemploTempo.Text = "Ex.: 60 para 1 minuto";
            // 
            // lblExemploPotencia
            // 
            this.lblExemploPotencia.AutoSize = true;
            this.lblExemploPotencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExemploPotencia.Location = new System.Drawing.Point(20, 150);
            this.lblExemploPotencia.Name = "lblExemploPotencia";
            this.lblExemploPotencia.Size = new System.Drawing.Size(100, 15);
            this.lblExemploPotencia.TabIndex = 8;
            this.lblExemploPotencia.Text = "1 a 10 (padrão 10)";
            // 
            // groupBoxProgramas
            // 
            this.groupBoxProgramas.Controls.Add(this.btnProgramaFeijao);
            this.groupBoxProgramas.Controls.Add(this.btnProgramaFrango);
            this.groupBoxProgramas.Controls.Add(this.btnProgramaCarne);
            this.groupBoxProgramas.Controls.Add(this.btnProgramaLeite);
            this.groupBoxProgramas.Controls.Add(this.btnProgramaPipoca);
            this.groupBoxProgramas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxProgramas.Location = new System.Drawing.Point(50, 250);
            this.groupBoxProgramas.Name = "groupBoxProgramas";
            this.groupBoxProgramas.Size = new System.Drawing.Size(775, 200);
            this.groupBoxProgramas.TabIndex = 7;
            this.groupBoxProgramas.TabStop = false;
            this.groupBoxProgramas.Text = "Programas Pré-definidos";
            // 
            // btnProgramaFeijao
            // 
            this.btnProgramaFeijao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProgramaFeijao.Image = global::MicroondasApp.Properties.Resources.Feijao;
            this.btnProgramaFeijao.Location = new System.Drawing.Point(620, 30);
            this.btnProgramaFeijao.Name = "btnProgramaFeijao";
            this.btnProgramaFeijao.Size = new System.Drawing.Size(140, 150);
            this.btnProgramaFeijao.TabIndex = 4;
            this.btnProgramaFeijao.Text = "Feijão";
            this.btnProgramaFeijao.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnProgramaFeijao.UseVisualStyleBackColor = true;
            this.btnProgramaFeijao.Click += new System.EventHandler(this.btnProgramaFeijao_Click);
            // 
            // btnProgramaFrango
            // 
            this.btnProgramaFrango.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProgramaFrango.Image = global::MicroondasApp.Properties.Resources.Frango;
            this.btnProgramaFrango.Location = new System.Drawing.Point(470, 30);
            this.btnProgramaFrango.Name = "btnProgramaFrango";
            this.btnProgramaFrango.Size = new System.Drawing.Size(140, 150);
            this.btnProgramaFrango.TabIndex = 3;
            this.btnProgramaFrango.Text = "Frango";
            this.btnProgramaFrango.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnProgramaFrango.UseVisualStyleBackColor = true;
            this.btnProgramaFrango.Click += new System.EventHandler(this.btnProgramaFrango_Click);
            // 
            // btnProgramaCarne
            // 
            this.btnProgramaCarne.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProgramaCarne.Image = global::MicroondasApp.Properties.Resources.Carne;
            this.btnProgramaCarne.Location = new System.Drawing.Point(320, 30);
            this.btnProgramaCarne.Name = "btnProgramaCarne";
            this.btnProgramaCarne.Size = new System.Drawing.Size(140, 150);
            this.btnProgramaCarne.TabIndex = 2;
            this.btnProgramaCarne.Text = "Carne";
            this.btnProgramaCarne.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnProgramaCarne.UseVisualStyleBackColor = true;
            this.btnProgramaCarne.Click += new System.EventHandler(this.btnProgramaCarne_Click);
            // 
            // btnProgramaLeite
            // 
            this.btnProgramaLeite.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProgramaLeite.Image = global::MicroondasApp.Properties.Resources.Leite;
            this.btnProgramaLeite.Location = new System.Drawing.Point(170, 30);
            this.btnProgramaLeite.Name = "btnProgramaLeite";
            this.btnProgramaLeite.Size = new System.Drawing.Size(140, 150);
            this.btnProgramaLeite.TabIndex = 1;
            this.btnProgramaLeite.Text = "Leite";
            this.btnProgramaLeite.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnProgramaLeite.UseVisualStyleBackColor = true;
            this.btnProgramaLeite.Click += new System.EventHandler(this.btnProgramaLeite_Click);
            // 
            // btnProgramaPipoca
            // 
            this.btnProgramaPipoca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProgramaPipoca.Image = global::MicroondasApp.Properties.Resources.Pipoca;
            this.btnProgramaPipoca.Location = new System.Drawing.Point(20, 30);
            this.btnProgramaPipoca.Name = "btnProgramaPipoca";
            this.btnProgramaPipoca.Size = new System.Drawing.Size(140, 150);
            this.btnProgramaPipoca.TabIndex = 0;
            this.btnProgramaPipoca.Text = "Pipoca";
            this.btnProgramaPipoca.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnProgramaPipoca.UseVisualStyleBackColor = true;
            this.btnProgramaPipoca.Click += new System.EventHandler(this.btnProgramaPipoca_Click);
            // 
            // lblTempoRestante
            // 
            this.lblTempoRestante.AutoSize = true;
            this.lblTempoRestante.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTempoRestante.Location = new System.Drawing.Point(50, 437);
            this.lblTempoRestante.Name = "lblTempoRestante";
            this.lblTempoRestante.Size = new System.Drawing.Size(133, 21);
            this.lblTempoRestante.TabIndex = 8;
            this.lblTempoRestante.Text = "Tempo restante: 0";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblTempoRestante);
            this.Controls.Add(this.groupBoxProgramas);
            this.Controls.Add(this.groupBoxConfiguracoes);
            this.Controls.Add(this.btnPausarCancelar);
            this.Controls.Add(this.btnInicioRapido);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblMensagens);
            this.Name = "MainForm";
            this.Text = "Microondas Digital";
            this.groupBoxConfiguracoes.ResumeLayout(false);
            this.groupBoxConfiguracoes.PerformLayout();
            this.groupBoxProgramas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.TextBox txtPotencia;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblPotencia;
        private System.Windows.Forms.Label lblMensagens;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnInicioRapido;
        private System.Windows.Forms.Button btnPausarCancelar;
        private System.Windows.Forms.GroupBox groupBoxConfiguracoes;
        private System.Windows.Forms.Label lblExemploTempo;
        private System.Windows.Forms.Label lblExemploPotencia;
        private System.Windows.Forms.GroupBox groupBoxProgramas;
        private System.Windows.Forms.Button btnProgramaFeijao;
        private System.Windows.Forms.Button btnProgramaFrango;
        private System.Windows.Forms.Button btnProgramaCarne;
        private System.Windows.Forms.Button btnProgramaLeite;
        private System.Windows.Forms.Button btnProgramaPipoca;
        private System.Windows.Forms.ImageList imgListProgramas;
        private System.Windows.Forms.Label lblTempoRestante;
    }
}
