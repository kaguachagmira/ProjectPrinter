
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuadrado));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.btnContorno = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grafico = new System.Windows.Forms.GroupBox();
            this.picSquareZ = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPerimetro = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picSquareY = new System.Windows.Forms.PictureBox();
            this.picSquareX = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstZx1 = new System.Windows.Forms.ListBox();
            this.lstZy1 = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstZy2 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstZx2 = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstYx1 = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstYy1 = new System.Windows.Forms.ListBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lstYy2 = new System.Windows.Forms.ListBox();
            this.lstYx2 = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lstPunto = new System.Windows.Forms.ListBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lstXx1 = new System.Windows.Forms.ListBox();
            this.lstXy1 = new System.Windows.Forms.ListBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lstXy2 = new System.Windows.Forms.ListBox();
            this.lstXx2 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.Grafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSquareZ)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSquareY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSquareX)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboColor);
            this.groupBox1.Controls.Add(this.btnContorno);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.txtLado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
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
            this.comboColor.Location = new System.Drawing.Point(177, 51);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(55, 21);
            this.comboColor.TabIndex = 9;
            this.comboColor.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnContorno
            // 
            this.btnContorno.ForeColor = System.Drawing.Color.Black;
            this.btnContorno.Location = new System.Drawing.Point(58, 90);
            this.btnContorno.Name = "btnContorno";
            this.btnContorno.Size = new System.Drawing.Size(122, 36);
            this.btnContorno.TabIndex = 7;
            this.btnContorno.Text = "Imprimir contorno";
            this.btnContorno.UseVisualStyleBackColor = true;
            this.btnContorno.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(58, 132);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(122, 36);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(177, 20);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(55, 20);
            this.txtLado.TabIndex = 1;
            this.txtLado.TextChanged += new System.EventHandler(this.txtLado_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
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
            this.Grafico.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Grafico.Location = new System.Drawing.Point(580, 2);
            this.Grafico.Name = "Grafico";
            this.Grafico.Size = new System.Drawing.Size(253, 181);
            this.Grafico.TabIndex = 2;
            this.Grafico.TabStop = false;
            this.Grafico.Text = "Perspectiva Z";
            // 
            // picSquareZ
            // 
            this.picSquareZ.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picSquareZ.Location = new System.Drawing.Point(22, 25);
            this.picSquareZ.Name = "picSquareZ";
            this.picSquareZ.Size = new System.Drawing.Size(212, 150);
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
            this.groupBox4.ForeColor = System.Drawing.Color.Silver;
            this.groupBox4.Location = new System.Drawing.Point(12, 189);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 367);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(14, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 282);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritmo de Bresenham";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 158);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 16);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Perimetro";
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            this.txtPerimetro.Location = new System.Drawing.Point(133, 36);
            this.txtPerimetro.Name = "txtPerimetro";
            this.txtPerimetro.Size = new System.Drawing.Size(68, 20);
            this.txtPerimetro.TabIndex = 3;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(43, 36);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(64, 20);
            this.txtArea.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picSquareY);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(580, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 188);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Perspectiva X";
            // 
            // picSquareY
            // 
            this.picSquareY.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picSquareY.Location = new System.Drawing.Point(22, 20);
            this.picSquareY.Name = "picSquareY";
            this.picSquareY.Size = new System.Drawing.Size(212, 150);
            this.picSquareY.TabIndex = 0;
            this.picSquareY.TabStop = false;
            // 
            // picSquareX
            // 
            this.picSquareX.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picSquareX.Location = new System.Drawing.Point(22, 16);
            this.picSquareX.Name = "picSquareX";
            this.picSquareX.Size = new System.Drawing.Size(209, 150);
            this.picSquareX.TabIndex = 0;
            this.picSquareX.TabStop = false;
            this.picSquareX.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.picSquareX);
            this.groupBox5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox5.Location = new System.Drawing.Point(580, 383);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(253, 173);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Perspectiva Y";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.groupBox10);
            this.groupBox6.ForeColor = System.Drawing.Color.Silver;
            this.groupBox6.Location = new System.Drawing.Point(270, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(304, 181);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Data  Z";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter_1);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.lstZx1);
            this.groupBox9.Controls.Add(this.lstZy1);
            this.groupBox9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox9.Location = new System.Drawing.Point(14, 25);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(122, 149);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Top";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // lstZx1
            // 
            this.lstZx1.FormattingEnabled = true;
            this.lstZx1.Location = new System.Drawing.Point(11, 32);
            this.lstZx1.Name = "lstZx1";
            this.lstZx1.Size = new System.Drawing.Size(40, 95);
            this.lstZx1.TabIndex = 0;
            // 
            // lstZy1
            // 
            this.lstZy1.FormattingEnabled = true;
            this.lstZy1.Location = new System.Drawing.Point(66, 32);
            this.lstZy1.Name = "lstZy1";
            this.lstZy1.Size = new System.Drawing.Size(40, 95);
            this.lstZy1.TabIndex = 1;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.lstZy2);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.lstZx2);
            this.groupBox10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox10.Location = new System.Drawing.Point(142, 25);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(146, 149);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Bot";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Y";
            // 
            // lstZy2
            // 
            this.lstZy2.FormattingEnabled = true;
            this.lstZy2.Location = new System.Drawing.Point(82, 30);
            this.lstZy2.Name = "lstZy2";
            this.lstZy2.Size = new System.Drawing.Size(40, 95);
            this.lstZy2.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "X";
            // 
            // lstZx2
            // 
            this.lstZx2.FormattingEnabled = true;
            this.lstZx2.Location = new System.Drawing.Point(21, 32);
            this.lstZx2.Name = "lstZx2";
            this.lstZx2.Size = new System.Drawing.Size(40, 95);
            this.lstZx2.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox11);
            this.groupBox7.Controls.Add(this.groupBox12);
            this.groupBox7.ForeColor = System.Drawing.Color.Silver;
            this.groupBox7.Location = new System.Drawing.Point(270, 383);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(304, 173);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Data  Y";
            this.groupBox7.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label9);
            this.groupBox11.Controls.Add(this.lstYx1);
            this.groupBox11.Controls.Add(this.label10);
            this.groupBox11.Controls.Add(this.lstYy1);
            this.groupBox11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox11.Location = new System.Drawing.Point(14, 13);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(122, 141);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Top";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Y";
            // 
            // lstYx1
            // 
            this.lstYx1.FormattingEnabled = true;
            this.lstYx1.Location = new System.Drawing.Point(11, 32);
            this.lstYx1.Name = "lstYx1";
            this.lstYx1.Size = new System.Drawing.Size(40, 95);
            this.lstYx1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "X";
            // 
            // lstYy1
            // 
            this.lstYy1.FormattingEnabled = true;
            this.lstYy1.Location = new System.Drawing.Point(66, 32);
            this.lstYy1.Name = "lstYy1";
            this.lstYy1.Size = new System.Drawing.Size(40, 95);
            this.lstYy1.TabIndex = 1;
            this.lstYy1.SelectedIndexChanged += new System.EventHandler(this.lstYy1_SelectedIndexChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label11);
            this.groupBox12.Controls.Add(this.label12);
            this.groupBox12.Controls.Add(this.lstYy2);
            this.groupBox12.Controls.Add(this.lstYx2);
            this.groupBox12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox12.Location = new System.Drawing.Point(142, 13);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(146, 141);
            this.groupBox12.TabIndex = 7;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Bot";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(94, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Y";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "X";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // lstYy2
            // 
            this.lstYy2.FormattingEnabled = true;
            this.lstYy2.Location = new System.Drawing.Point(82, 32);
            this.lstYy2.Name = "lstYy2";
            this.lstYy2.Size = new System.Drawing.Size(40, 95);
            this.lstYy2.TabIndex = 3;
            // 
            // lstYx2
            // 
            this.lstYx2.FormattingEnabled = true;
            this.lstYx2.Location = new System.Drawing.Point(21, 32);
            this.lstYx2.Name = "lstYx2";
            this.lstYx2.Size = new System.Drawing.Size(40, 95);
            this.lstYx2.TabIndex = 2;
            this.lstYx2.SelectedIndexChanged += new System.EventHandler(this.lstYx2_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox15);
            this.groupBox8.Controls.Add(this.groupBox13);
            this.groupBox8.Controls.Add(this.groupBox14);
            this.groupBox8.ForeColor = System.Drawing.Color.Silver;
            this.groupBox8.Location = new System.Drawing.Point(271, 189);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(303, 188);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Data  X";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label18);
            this.groupBox15.Controls.Add(this.lstPunto);
            this.groupBox15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox15.Location = new System.Drawing.Point(223, 24);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(71, 146);
            this.groupBox15.TabIndex = 8;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Pixel";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(27, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "X";
            // 
            // lstPunto
            // 
            this.lstPunto.FormattingEnabled = true;
            this.lstPunto.Location = new System.Drawing.Point(9, 32);
            this.lstPunto.Name = "lstPunto";
            this.lstPunto.Size = new System.Drawing.Size(50, 95);
            this.lstPunto.TabIndex = 2;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label13);
            this.groupBox13.Controls.Add(this.label14);
            this.groupBox13.Controls.Add(this.lstXx1);
            this.groupBox13.Controls.Add(this.lstXy1);
            this.groupBox13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox13.Location = new System.Drawing.Point(13, 24);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(103, 145);
            this.groupBox13.TabIndex = 6;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Izquierda";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(70, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Y";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "X";
            // 
            // lstXx1
            // 
            this.lstXx1.FormattingEnabled = true;
            this.lstXx1.Location = new System.Drawing.Point(13, 32);
            this.lstXx1.Name = "lstXx1";
            this.lstXx1.Size = new System.Drawing.Size(30, 95);
            this.lstXx1.TabIndex = 0;
            // 
            // lstXy1
            // 
            this.lstXy1.FormattingEnabled = true;
            this.lstXy1.Location = new System.Drawing.Point(61, 32);
            this.lstXy1.Name = "lstXy1";
            this.lstXy1.Size = new System.Drawing.Size(30, 95);
            this.lstXy1.TabIndex = 1;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label15);
            this.groupBox14.Controls.Add(this.label16);
            this.groupBox14.Controls.Add(this.lstXy2);
            this.groupBox14.Controls.Add(this.lstXx2);
            this.groupBox14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox14.Location = new System.Drawing.Point(122, 25);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(95, 145);
            this.groupBox14.TabIndex = 7;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Derecha";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(66, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Y";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "X";
            // 
            // lstXy2
            // 
            this.lstXy2.FormattingEnabled = true;
            this.lstXy2.Location = new System.Drawing.Point(52, 32);
            this.lstXy2.Name = "lstXy2";
            this.lstXy2.Size = new System.Drawing.Size(30, 95);
            this.lstXy2.TabIndex = 3;
            // 
            // lstXx2
            // 
            this.lstXx2.FormattingEnabled = true;
            this.lstXx2.Location = new System.Drawing.Point(9, 32);
            this.lstXx2.Name = "lstXx2";
            this.lstXx2.Size = new System.Drawing.Size(30, 95);
            this.lstXx2.TabIndex = 2;
            // 
            // frmCuadrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(844, 563);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
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
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSquareY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSquareX)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Grafico;
        private System.Windows.Forms.PictureBox picSquareZ;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReset;
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lstZy1;
        private System.Windows.Forms.ListBox lstZx1;
        private System.Windows.Forms.ListBox lstZy2;
        private System.Windows.Forms.ListBox lstZx2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ListBox lstYx1;
        private System.Windows.Forms.ListBox lstYy1;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ListBox lstYy2;
        private System.Windows.Forms.ListBox lstYx2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.ListBox lstXx1;
        private System.Windows.Forms.ListBox lstXy1;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.ListBox lstXy2;
        private System.Windows.Forms.ListBox lstXx2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox lstPunto;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}