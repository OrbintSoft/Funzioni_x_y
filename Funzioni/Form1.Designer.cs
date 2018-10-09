using System;
namespace Funzioni
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private String Funzione
        {
            get
            {
                return funzione;
            }
            set
            {
                funzione = value;
            }
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.SellaLabel = new System.Windows.Forms.Label();
            this.MassimiLabel = new System.Windows.Forms.Label();
            this.MinimiLabel = new System.Windows.Forms.Label();
            this.SellaComboBox = new System.Windows.Forms.ComboBox();
            this.MassimiComboBox = new System.Windows.Forms.ComboBox();
            this.MinimiComboBox = new System.Windows.Forms.ComboBox();
            this.RangeColoriPanel = new System.Windows.Forms.Panel();
            this.ZMaxColLabel = new System.Windows.Forms.Label();
            this.ZminColLabel = new System.Windows.Forms.Label();
            this.ZMinLabel = new System.Windows.Forms.Label();
            this.ZMaxLabel = new System.Windows.Forms.Label();
            this.MinZTextBox = new System.Windows.Forms.TextBox();
            this.MaxZTextBox = new System.Windows.Forms.TextBox();
            this.PassoYLabel = new System.Windows.Forms.Label();
            this.PassoXLabel = new System.Windows.Forms.Label();
            this.PassoYTextBox = new System.Windows.Forms.TextBox();
            this.PassoXTextBox = new System.Windows.Forms.TextBox();
            this.ZLabel = new System.Windows.Forms.Label();
            this.RangeYLabel = new System.Windows.Forms.Label();
            this.RangeXLabel = new System.Windows.Forms.Label();
            this.MaxYTextBox = new System.Windows.Forms.TextBox();
            this.FunzioneTextBox = new System.Windows.Forms.TextBox();
            this.MinYTextBox = new System.Windows.Forms.TextBox();
            this.MaxXTextBox = new System.Windows.Forms.TextBox();
            this.DisegnaButton = new System.Windows.Forms.Button();
            this.MinXTextBox = new System.Windows.Forms.TextBox();
            this.CoordinateLabel = new System.Windows.Forms.Label();
            this.grafico = new Funzioni.Grafico();
            this.PuntiStazionariButton = new System.Windows.Forms.Button();
            this.SettingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingPanel
            // 
            this.SettingPanel.AutoSize = true;
            this.SettingPanel.Controls.Add(this.PuntiStazionariButton);
            this.SettingPanel.Controls.Add(this.SellaLabel);
            this.SettingPanel.Controls.Add(this.MassimiLabel);
            this.SettingPanel.Controls.Add(this.MinimiLabel);
            this.SettingPanel.Controls.Add(this.SellaComboBox);
            this.SettingPanel.Controls.Add(this.MassimiComboBox);
            this.SettingPanel.Controls.Add(this.MinimiComboBox);
            this.SettingPanel.Controls.Add(this.RangeColoriPanel);
            this.SettingPanel.Controls.Add(this.ZMaxColLabel);
            this.SettingPanel.Controls.Add(this.ZminColLabel);
            this.SettingPanel.Controls.Add(this.ZMinLabel);
            this.SettingPanel.Controls.Add(this.ZMaxLabel);
            this.SettingPanel.Controls.Add(this.MinZTextBox);
            this.SettingPanel.Controls.Add(this.MaxZTextBox);
            this.SettingPanel.Controls.Add(this.PassoYLabel);
            this.SettingPanel.Controls.Add(this.PassoXLabel);
            this.SettingPanel.Controls.Add(this.PassoYTextBox);
            this.SettingPanel.Controls.Add(this.PassoXTextBox);
            this.SettingPanel.Controls.Add(this.ZLabel);
            this.SettingPanel.Controls.Add(this.RangeYLabel);
            this.SettingPanel.Controls.Add(this.RangeXLabel);
            this.SettingPanel.Controls.Add(this.MaxYTextBox);
            this.SettingPanel.Controls.Add(this.FunzioneTextBox);
            this.SettingPanel.Controls.Add(this.MinYTextBox);
            this.SettingPanel.Controls.Add(this.MaxXTextBox);
            this.SettingPanel.Controls.Add(this.DisegnaButton);
            this.SettingPanel.Controls.Add(this.MinXTextBox);
            this.SettingPanel.Location = new System.Drawing.Point(12, 522);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(891, 187);
            this.SettingPanel.TabIndex = 1;
            // 
            // SellaLabel
            // 
            this.SellaLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.SellaLabel.AutoSize = true;
            this.SellaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellaLabel.Location = new System.Drawing.Point(795, 75);
            this.SellaLabel.Name = "SellaLabel";
            this.SellaLabel.Size = new System.Drawing.Size(44, 16);
            this.SellaLabel.TabIndex = 24;
            this.SellaLabel.Text = "Sella";
            // 
            // MassimiLabel
            // 
            this.MassimiLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MassimiLabel.AutoSize = true;
            this.MassimiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MassimiLabel.Location = new System.Drawing.Point(795, 37);
            this.MassimiLabel.Name = "MassimiLabel";
            this.MassimiLabel.Size = new System.Drawing.Size(65, 16);
            this.MassimiLabel.TabIndex = 23;
            this.MassimiLabel.Text = "Massimi";
            // 
            // MinimiLabel
            // 
            this.MinimiLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MinimiLabel.AutoSize = true;
            this.MinimiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimiLabel.Location = new System.Drawing.Point(795, 3);
            this.MinimiLabel.Name = "MinimiLabel";
            this.MinimiLabel.Size = new System.Drawing.Size(52, 16);
            this.MinimiLabel.TabIndex = 22;
            this.MinimiLabel.Text = "Minimi";
            // 
            // SellaComboBox
            // 
            this.SellaComboBox.FormattingEnabled = true;
            this.SellaComboBox.Location = new System.Drawing.Point(672, 70);
            this.SellaComboBox.Name = "SellaComboBox";
            this.SellaComboBox.Size = new System.Drawing.Size(117, 21);
            this.SellaComboBox.TabIndex = 21;
            // 
            // MassimiComboBox
            // 
            this.MassimiComboBox.FormattingEnabled = true;
            this.MassimiComboBox.Location = new System.Drawing.Point(673, 36);
            this.MassimiComboBox.Name = "MassimiComboBox";
            this.MassimiComboBox.Size = new System.Drawing.Size(116, 21);
            this.MassimiComboBox.TabIndex = 20;
            // 
            // MinimiComboBox
            // 
            this.MinimiComboBox.FormattingEnabled = true;
            this.MinimiComboBox.Location = new System.Drawing.Point(672, 3);
            this.MinimiComboBox.Name = "MinimiComboBox";
            this.MinimiComboBox.Size = new System.Drawing.Size(117, 21);
            this.MinimiComboBox.TabIndex = 19;
            // 
            // RangeColoriPanel
            // 
            this.RangeColoriPanel.Location = new System.Drawing.Point(73, 150);
            this.RangeColoriPanel.Name = "RangeColoriPanel";
            this.RangeColoriPanel.Size = new System.Drawing.Size(167, 22);
            this.RangeColoriPanel.TabIndex = 18;
            this.RangeColoriPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RangeColoriPanel_Paint);
            // 
            // ZMaxColLabel
            // 
            this.ZMaxColLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ZMaxColLabel.AutoSize = true;
            this.ZMaxColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZMaxColLabel.Location = new System.Drawing.Point(237, 157);
            this.ZMaxColLabel.Name = "ZMaxColLabel";
            this.ZMaxColLabel.Size = new System.Drawing.Size(49, 16);
            this.ZMaxColLabel.TabIndex = 17;
            this.ZMaxColLabel.Text = "Z Max";
            // 
            // ZminColLabel
            // 
            this.ZminColLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ZminColLabel.AutoSize = true;
            this.ZminColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZminColLabel.Location = new System.Drawing.Point(24, 157);
            this.ZminColLabel.Name = "ZminColLabel";
            this.ZminColLabel.Size = new System.Drawing.Size(45, 16);
            this.ZminColLabel.TabIndex = 16;
            this.ZminColLabel.Text = "Z Min";
            // 
            // ZMinLabel
            // 
            this.ZMinLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ZMinLabel.AutoSize = true;
            this.ZMinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZMinLabel.Location = new System.Drawing.Point(781, 122);
            this.ZMinLabel.Name = "ZMinLabel";
            this.ZMinLabel.Size = new System.Drawing.Size(107, 16);
            this.ZMinLabel.TabIndex = 15;
            this.ZMinLabel.Text = "Valore Minimo";
            // 
            // ZMaxLabel
            // 
            this.ZMaxLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ZMaxLabel.AutoSize = true;
            this.ZMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZMaxLabel.Location = new System.Drawing.Point(655, 122);
            this.ZMaxLabel.Name = "ZMaxLabel";
            this.ZMaxLabel.Size = new System.Drawing.Size(120, 16);
            this.ZMaxLabel.TabIndex = 14;
            this.ZMaxLabel.Text = "Valore Massimo";
            // 
            // MinZTextBox
            // 
            this.MinZTextBox.Location = new System.Drawing.Point(792, 141);
            this.MinZTextBox.Name = "MinZTextBox";
            this.MinZTextBox.Size = new System.Drawing.Size(96, 20);
            this.MinZTextBox.TabIndex = 13;
            // 
            // MaxZTextBox
            // 
            this.MaxZTextBox.Location = new System.Drawing.Point(672, 141);
            this.MaxZTextBox.Name = "MaxZTextBox";
            this.MaxZTextBox.Size = new System.Drawing.Size(96, 20);
            this.MaxZTextBox.TabIndex = 12;
            // 
            // PassoYLabel
            // 
            this.PassoYLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.PassoYLabel.AutoSize = true;
            this.PassoYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassoYLabel.Location = new System.Drawing.Point(568, 69);
            this.PassoYLabel.Name = "PassoYLabel";
            this.PassoYLabel.Size = new System.Drawing.Size(66, 16);
            this.PassoYLabel.TabIndex = 11;
            this.PassoYLabel.Text = "Passo Y";
            // 
            // PassoXLabel
            // 
            this.PassoXLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.PassoXLabel.AutoSize = true;
            this.PassoXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassoXLabel.Location = new System.Drawing.Point(568, 34);
            this.PassoXLabel.Name = "PassoXLabel";
            this.PassoXLabel.Size = new System.Drawing.Size(65, 16);
            this.PassoXLabel.TabIndex = 10;
            this.PassoXLabel.Text = "Passo X";
            // 
            // PassoYTextBox
            // 
            this.PassoYTextBox.Location = new System.Drawing.Point(433, 67);
            this.PassoYTextBox.Name = "PassoYTextBox";
            this.PassoYTextBox.Size = new System.Drawing.Size(118, 20);
            this.PassoYTextBox.TabIndex = 9;
            this.PassoYTextBox.TextChanged += new System.EventHandler(this.PassoYTextBox_TextChanged);
            // 
            // PassoXTextBox
            // 
            this.PassoXTextBox.Location = new System.Drawing.Point(433, 30);
            this.PassoXTextBox.Name = "PassoXTextBox";
            this.PassoXTextBox.Size = new System.Drawing.Size(118, 20);
            this.PassoXTextBox.TabIndex = 8;
            this.PassoXTextBox.TextChanged += new System.EventHandler(this.PassoXTextBox_TextChanged);
            // 
            // ZLabel
            // 
            this.ZLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ZLabel.AutoSize = true;
            this.ZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZLabel.Location = new System.Drawing.Point(-3, 28);
            this.ZLabel.Name = "ZLabel";
            this.ZLabel.Size = new System.Drawing.Size(30, 20);
            this.ZLabel.TabIndex = 7;
            this.ZLabel.Text = "Z=";
            // 
            // RangeYLabel
            // 
            this.RangeYLabel.AutoSize = true;
            this.RangeYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeYLabel.Location = new System.Drawing.Point(288, 107);
            this.RangeYLabel.Name = "RangeYLabel";
            this.RangeYLabel.Size = new System.Drawing.Size(88, 16);
            this.RangeYLabel.TabIndex = 7;
            this.RangeYLabel.Text = "Y [Min,Max]";
            // 
            // RangeXLabel
            // 
            this.RangeXLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.RangeXLabel.AutoSize = true;
            this.RangeXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeXLabel.Location = new System.Drawing.Point(288, 71);
            this.RangeXLabel.Name = "RangeXLabel";
            this.RangeXLabel.Size = new System.Drawing.Size(87, 16);
            this.RangeXLabel.TabIndex = 6;
            this.RangeXLabel.Text = "X [Min,Max]";
            // 
            // MaxYTextBox
            // 
            this.MaxYTextBox.Location = new System.Drawing.Point(155, 104);
            this.MaxYTextBox.Name = "MaxYTextBox";
            this.MaxYTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxYTextBox.TabIndex = 5;
            this.MaxYTextBox.TextChanged += new System.EventHandler(this.MaxYTextBox_TextChanged);
            // 
            // FunzioneTextBox
            // 
            this.FunzioneTextBox.Location = new System.Drawing.Point(27, 28);
            this.FunzioneTextBox.Name = "FunzioneTextBox";
            this.FunzioneTextBox.Size = new System.Drawing.Size(228, 20);
            this.FunzioneTextBox.TabIndex = 1;
            this.FunzioneTextBox.TextChanged += new System.EventHandler(this.FunzioneTextBox_TextChanged);
            // 
            // MinYTextBox
            // 
            this.MinYTextBox.Location = new System.Drawing.Point(27, 104);
            this.MinYTextBox.Name = "MinYTextBox";
            this.MinYTextBox.Size = new System.Drawing.Size(100, 20);
            this.MinYTextBox.TabIndex = 4;
            this.MinYTextBox.TextChanged += new System.EventHandler(this.MinYTextBox_TextChanged);
            // 
            // MaxXTextBox
            // 
            this.MaxXTextBox.Location = new System.Drawing.Point(155, 68);
            this.MaxXTextBox.Name = "MaxXTextBox";
            this.MaxXTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxXTextBox.TabIndex = 3;
            this.MaxXTextBox.TextChanged += new System.EventHandler(this.MaxXTextBox_TextChanged);
            // 
            // DisegnaButton
            // 
            this.DisegnaButton.Location = new System.Drawing.Point(276, 25);
            this.DisegnaButton.Name = "DisegnaButton";
            this.DisegnaButton.Size = new System.Drawing.Size(101, 32);
            this.DisegnaButton.TabIndex = 1;
            this.DisegnaButton.Text = "Disegna";
            this.DisegnaButton.UseVisualStyleBackColor = true;
            this.DisegnaButton.Click += new System.EventHandler(this.DisegnaButton_Click);
            // 
            // MinXTextBox
            // 
            this.MinXTextBox.Location = new System.Drawing.Point(27, 68);
            this.MinXTextBox.Name = "MinXTextBox";
            this.MinXTextBox.Size = new System.Drawing.Size(100, 20);
            this.MinXTextBox.TabIndex = 2;
            this.MinXTextBox.TextChanged += new System.EventHandler(this.MinXTextBox_TextChanged);
            // 
            // CoordinateLabel
            // 
            this.CoordinateLabel.AutoSize = true;
            this.CoordinateLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.CoordinateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoordinateLabel.ForeColor = System.Drawing.Color.White;
            this.CoordinateLabel.Location = new System.Drawing.Point(12, 506);
            this.CoordinateLabel.Name = "CoordinateLabel";
            this.CoordinateLabel.Size = new System.Drawing.Size(0, 16);
            this.CoordinateLabel.TabIndex = 21;
            this.CoordinateLabel.Visible = false;
            // 
            // grafico
            // 
            this.grafico.AllowDrop = true;
            this.grafico.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grafico.BackColor = System.Drawing.SystemColors.ControlText;
            this.grafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grafico.ColoreEtichetta = System.Drawing.Color.White;
            this.grafico.Funzioni = new Funzioni.Funzione[0];
            this.grafico.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grafico.Location = new System.Drawing.Point(12, 12);
            this.grafico.MaxX = 10F;
            this.grafico.MaxY = 10F;
            this.grafico.MinX = -10F;
            this.grafico.MinY = -10F;
            this.grafico.Name = "grafico";
            this.grafico.Passo = 0.08F;
            this.grafico.Precisione = 5;
            this.grafico.Punti = new Funzioni.Punto[0];
            this.grafico.Size = new System.Drawing.Size(891, 489);
            this.grafico.TabIndex = 0;
            this.grafico.MouseLeave += new System.EventHandler(this.grafico_MouseLeave);
            this.grafico.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grafico_MouseMove);
            this.grafico.MouseHover += new System.EventHandler(this.grafico_MouseHover);
            this.grafico.MouseEnter += new System.EventHandler(this.grafico_MouseEnter);
            // 
            // PuntiStazionariButton
            // 
            this.PuntiStazionariButton.Location = new System.Drawing.Point(433, 99);
            this.PuntiStazionariButton.Name = "PuntiStazionariButton";
            this.PuntiStazionariButton.Size = new System.Drawing.Size(145, 32);
            this.PuntiStazionariButton.TabIndex = 25;
            this.PuntiStazionariButton.Text = "Trova Punti Stazionari";
            this.PuntiStazionariButton.UseVisualStyleBackColor = true;
            this.PuntiStazionariButton.Click += new System.EventHandler(this.PuntiStazionariButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 721);
            this.Controls.Add(this.CoordinateLabel);
            this.Controls.Add(this.SettingPanel);
            this.Controls.Add(this.grafico);
            this.Name = "MainForm";
            this.Text = "F(x,y)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private String funzione;
        private Grafico grafico;
        private Single PassoX;
        private Single PassoY;
        private System.Windows.Forms.Panel SettingPanel;
        private System.Windows.Forms.TextBox MaxYTextBox;
        private System.Windows.Forms.TextBox MinYTextBox;
        private System.Windows.Forms.TextBox MaxXTextBox;
        private System.Windows.Forms.TextBox MinXTextBox;
        private System.Windows.Forms.Button DisegnaButton;
        private System.Windows.Forms.TextBox FunzioneTextBox;
        private System.Windows.Forms.Label RangeYLabel;
        private System.Windows.Forms.Label RangeXLabel;
        private System.Windows.Forms.Label ZLabel;
        private System.Windows.Forms.TextBox PassoXTextBox;
        private System.Windows.Forms.TextBox PassoYTextBox;
        private System.Windows.Forms.Label PassoYLabel;
        private System.Windows.Forms.Label PassoXLabel;
        private System.Windows.Forms.Label ZMinLabel;
        private System.Windows.Forms.Label ZMaxLabel;
        private System.Windows.Forms.TextBox MinZTextBox;
        private System.Windows.Forms.TextBox MaxZTextBox;
        private System.Windows.Forms.Label ZminColLabel;
        private System.Windows.Forms.Panel RangeColoriPanel;
        private System.Windows.Forms.Label ZMaxColLabel;
        private System.Windows.Forms.Label CoordinateLabel;
        private System.Windows.Forms.Label SellaLabel;
        private System.Windows.Forms.Label MassimiLabel;
        private System.Windows.Forms.Label MinimiLabel;
        private System.Windows.Forms.ComboBox SellaComboBox;
        private System.Windows.Forms.ComboBox MassimiComboBox;
        private System.Windows.Forms.ComboBox MinimiComboBox;
        private System.Windows.Forms.Button PuntiStazionariButton;
    }
}

