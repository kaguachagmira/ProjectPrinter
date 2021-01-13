
namespace ProjectPrinter
{
    partial class frmCuadrado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.btnContorno = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grafico = new System.Windows.Forms.GroupBox();
            this.picSquareZ = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPerimetro = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picSquareX = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.picSquareY = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.Grafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSquareZ)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSquareX)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSquareY)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboColor);
            this.groupBox1.Controls.Add(this.btnContorno);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnGraficar);
            this.groupBox1.Controls.Add(this.txtLado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seleccionar color";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboColor
            // 
            this.comboColor.BackColor = System.Drawing.SystemColors.Window;
            this.comboColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Items.AddRange(new object[] {
            "Azul",
            "Rojo",
            "Amarillo",
            "Verde",
            "Café"});
            this.comboColor.Location = new System.Drawing.Point(191, 51);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(100, 21);
            this.comboColor.TabIndex = 9;
            this.comboColor.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnContorno
            // 
            this.btnContorno.Location = new System.Drawing.Point(20, 95);
            this.btnContorno.Name = "btnContorno";
            this.btnContorno.Size = new System.Drawing.Size(100, 23);
            this.btnContorno.TabIndex = 7;
            this.btnContorno.Text = "Imprimir contorno";
            this.btnContorno.UseVisualStyleBackColor = true;
            this.btnContorno.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(20, 154);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(20, 124);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(100, 23);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Imprimir relleno";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(191, 20);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(100, 20);
            this.txtLado.TabIndex = 1;
            this.txtLado.TextChanged += new System.EventHandler(this.txtLado_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el lado del cuadrado";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Grafico
            // 
            this.Grafico.Controls.Add(this.picSquareZ);
            this.Grafico.Location = new System.Drawing.Point(812, 13);
            this.Grafico.Name = "Grafico";
            this.Grafico.Size = new System.Drawing.Size(297, 216);
            this.Grafico.TabIndex = 2;
            this.Grafico.TabStop = false;
            this.Grafico.Text = "Perspectiva Z";
            // 
            // picSquareZ
            // 
            this.picSquareZ.Location = new System.Drawing.Point(22, 25);
            this.picSquareZ.Name = "picSquareZ";
            this.picSquareZ.Size = new System.Drawing.Size(253, 172);
            this.picSquareZ.TabIndex = 0;
            this.picSquareZ.TabStop = false;
            this.picSquareZ.Click += new System.EventHandler(this.picSquare_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtPerimetro);
            this.groupBox4.Controls.Add(this.txtArea);
            this.groupBox4.Location = new System.Drawing.Point(25, 234);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 465);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(21, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 378);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 21);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Perimetro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 16);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Area";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtPerimetro
            // 
            this.txtPerimetro.Location = new System.Drawing.Point(192, 37);
            this.txtPerimetro.Name = "txtPerimetro";
            this.txtPerimetro.Size = new System.Drawing.Size(100, 20);
            this.txtPerimetro.TabIndex = 3;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(21, 37);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(112, 20);
            this.txtArea.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picSquareY);
            this.groupBox3.Location = new System.Drawing.Point(812, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 216);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Perspectiva X";
            // 
            // picSquareX
            // 
            this.picSquareX.Location = new System.Drawing.Point(22, 28);
            this.picSquareX.Name = "picSquareX";
            this.picSquareX.Size = new System.Drawing.Size(253, 172);
            this.picSquareX.TabIndex = 0;
            this.picSquareX.TabStop = false;
            this.picSquareX.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.picSquareX);
            this.groupBox5.Location = new System.Drawing.Point(812, 466);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(297, 216);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Perspectiva Y";
            // 
            // picSquareY
            // 
            this.picSquareY.Location = new System.Drawing.Point(22, 20);
            this.picSquareY.Name = "picSquareY";
            this.picSquareY.Size = new System.Drawing.Size(253, 172);
            this.picSquareY.TabIndex = 0;
            this.picSquareY.TabStop = false;
            // 
            // frmCuadrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 711);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Grafico);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCuadrado";
            this.Text = "frmCuadrado";
            this.Load += new System.EventHandler(this.frmCuadrado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Grafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSquareZ)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSquareX)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSquareY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Grafico;
        private System.Windows.Forms.PictureBox picSquareZ;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtPerimetro;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picSquareX;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox picSquareY;
        private System.Windows.Forms.Button btnContorno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}