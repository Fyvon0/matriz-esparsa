namespace Matriz_Esparsa
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxCriarMatriz = new System.Windows.Forms.GroupBox();
            this.nudCriarGridView = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nudCriarColunas = new System.Windows.Forms.NumericUpDown();
            this.nudCriarLinhas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxOperacoes = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.cbxGrids = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nudColunas = new System.Windows.Forms.NumericUpDown();
            this.nudLinhas = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbxCriarMatriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriarGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriarColunas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriarLinhas)).BeginInit();
            this.gbxOperacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColunas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCriarMatriz
            // 
            this.gbxCriarMatriz.Controls.Add(this.nudCriarGridView);
            this.gbxCriarMatriz.Controls.Add(this.label6);
            this.gbxCriarMatriz.Controls.Add(this.button1);
            this.gbxCriarMatriz.Controls.Add(this.nudCriarColunas);
            this.gbxCriarMatriz.Controls.Add(this.nudCriarLinhas);
            this.gbxCriarMatriz.Controls.Add(this.label2);
            this.gbxCriarMatriz.Controls.Add(this.label1);
            this.gbxCriarMatriz.Location = new System.Drawing.Point(12, 12);
            this.gbxCriarMatriz.Name = "gbxCriarMatriz";
            this.gbxCriarMatriz.Size = new System.Drawing.Size(123, 117);
            this.gbxCriarMatriz.TabIndex = 0;
            this.gbxCriarMatriz.TabStop = false;
            this.gbxCriarMatriz.Text = "Criar Matriz";
            // 
            // nudCriarGridView
            // 
            this.nudCriarGridView.Location = new System.Drawing.Point(48, 62);
            this.nudCriarGridView.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCriarGridView.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCriarGridView.Name = "nudCriarGridView";
            this.nudCriarGridView.Size = new System.Drawing.Size(58, 20);
            this.nudCriarGridView.TabIndex = 6;
            this.nudCriarGridView.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "GridView";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Criar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudCriarColunas
            // 
            this.nudCriarColunas.Location = new System.Drawing.Point(48, 37);
            this.nudCriarColunas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCriarColunas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCriarColunas.Name = "nudCriarColunas";
            this.nudCriarColunas.Size = new System.Drawing.Size(58, 20);
            this.nudCriarColunas.TabIndex = 4;
            this.nudCriarColunas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudCriarLinhas
            // 
            this.nudCriarLinhas.Location = new System.Drawing.Point(48, 14);
            this.nudCriarLinhas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCriarLinhas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCriarLinhas.Name = "nudCriarLinhas";
            this.nudCriarLinhas.Size = new System.Drawing.Size(58, 20);
            this.nudCriarLinhas.TabIndex = 3;
            this.nudCriarLinhas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Colunas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Linhas";
            // 
            // gbxOperacoes
            // 
            this.gbxOperacoes.Controls.Add(this.button9);
            this.gbxOperacoes.Controls.Add(this.button8);
            this.gbxOperacoes.Controls.Add(this.button7);
            this.gbxOperacoes.Controls.Add(this.button6);
            this.gbxOperacoes.Controls.Add(this.cbxGrids);
            this.gbxOperacoes.Controls.Add(this.label7);
            this.gbxOperacoes.Controls.Add(this.button5);
            this.gbxOperacoes.Controls.Add(this.button4);
            this.gbxOperacoes.Controls.Add(this.nudValor);
            this.gbxOperacoes.Controls.Add(this.label5);
            this.gbxOperacoes.Controls.Add(this.button3);
            this.gbxOperacoes.Controls.Add(this.button2);
            this.gbxOperacoes.Controls.Add(this.nudColunas);
            this.gbxOperacoes.Controls.Add(this.nudLinhas);
            this.gbxOperacoes.Controls.Add(this.label3);
            this.gbxOperacoes.Controls.Add(this.label4);
            this.gbxOperacoes.Enabled = false;
            this.gbxOperacoes.Location = new System.Drawing.Point(12, 135);
            this.gbxOperacoes.Name = "gbxOperacoes";
            this.gbxOperacoes.Size = new System.Drawing.Size(123, 518);
            this.gbxOperacoes.TabIndex = 1;
            this.gbxOperacoes.TabStop = false;
            this.gbxOperacoes.Text = "Operações";
            this.gbxOperacoes.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(9, 351);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(97, 23);
            this.button9.TabIndex = 18;
            this.button9.Text = "Somar";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(9, 322);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(97, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "Multiplicar";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(9, 293);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(97, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "Ler Arquivo";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(9, 264);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Limpar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cbxGrids
            // 
            this.cbxGrids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGrids.FormattingEnabled = true;
            this.cbxGrids.Location = new System.Drawing.Point(48, 82);
            this.cbxGrids.Name = "cbxGrids";
            this.cbxGrids.Size = new System.Drawing.Size(58, 21);
            this.cbxGrids.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "GridView";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(9, 235);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "SomaEmColuna";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 206);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Remover";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // nudValor
            // 
            this.nudValor.DecimalPlaces = 2;
            this.nudValor.Location = new System.Drawing.Point(43, 60);
            this.nudValor.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudValor.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.nudValor.Name = "nudValor";
            this.nudValor.Size = new System.Drawing.Size(63, 20);
            this.nudValor.TabIndex = 11;
            this.nudValor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Valor";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Inserir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "ValorDe";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nudColunas
            // 
            this.nudColunas.Location = new System.Drawing.Point(48, 37);
            this.nudColunas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudColunas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColunas.Name = "nudColunas";
            this.nudColunas.Size = new System.Drawing.Size(58, 20);
            this.nudColunas.TabIndex = 8;
            this.nudColunas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudLinhas
            // 
            this.nudLinhas.Location = new System.Drawing.Point(48, 14);
            this.nudLinhas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudLinhas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLinhas.Name = "nudLinhas";
            this.nudLinhas.Size = new System.Drawing.Size(58, 20);
            this.nudLinhas.TabIndex = 7;
            this.nudLinhas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Colunas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Linhas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(156, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(950, 204);
            this.dataGridView1.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(156, 229);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(950, 214);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(156, 449);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(950, 204);
            this.dataGridView3.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 665);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbxOperacoes);
            this.Controls.Add(this.gbxCriarMatriz);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxCriarMatriz.ResumeLayout(false);
            this.gbxCriarMatriz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriarGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriarColunas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriarLinhas)).EndInit();
            this.gbxOperacoes.ResumeLayout(false);
            this.gbxOperacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColunas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCriarMatriz;
        private System.Windows.Forms.NumericUpDown nudCriarColunas;
        private System.Windows.Forms.NumericUpDown nudCriarLinhas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbxOperacoes;
        private System.Windows.Forms.NumericUpDown nudColunas;
        private System.Windows.Forms.NumericUpDown nudLinhas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown nudValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown nudCriarGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.ComboBox cbxGrids;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

