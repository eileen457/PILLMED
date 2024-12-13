namespace ver
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReloj = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDosis = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMusica = new System.Windows.Forms.Button();
            this.cbSL = new System.Windows.Forms.CheckBox();
            this.cbLun = new System.Windows.Forms.CheckBox();
            this.cbMar = new System.Windows.Forms.CheckBox();
            this.cbMierc = new System.Windows.Forms.CheckBox();
            this.cbJue = new System.Windows.Forms.CheckBox();
            this.cbVier = new System.Windows.Forms.CheckBox();
            this.cbSab = new System.Windows.Forms.CheckBox();
            this.cbDom = new System.Windows.Forms.CheckBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnguardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(31, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 20);
            this.label17.TabIndex = 43;
            this.label17.Text = "Minutos";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(39, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 20);
            this.label16.TabIndex = 42;
            this.label16.Text = "Hora";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(118, 146);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 41;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(188, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 39;
            this.label15.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(145, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 20);
            this.label14.TabIndex = 38;
            this.label14.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(205, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 20);
            this.label13.TabIndex = 37;
            this.label13.Text = "00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(160, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(114, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(136, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "Alarma";
            // 
            // btnReloj
            // 
            this.btnReloj.BackColor = System.Drawing.Color.LightPink;
            this.btnReloj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloj.Location = new System.Drawing.Point(367, 93);
            this.btnReloj.Name = "btnReloj";
            this.btnReloj.Size = new System.Drawing.Size(113, 39);
            this.btnReloj.TabIndex = 33;
            this.btnReloj.Text = "Start";
            this.btnReloj.UseVisualStyleBackColor = false;
            this.btnReloj.Click += new System.EventHandler(this.btnReloj_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Nombre";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(364, 151);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(113, 39);
            this.btnStop.TabIndex = 47;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(187, 355);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(155, 27);
            this.txtNombre.TabIndex = 48;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "Total pastillas";
            // 
            // txtDosis
            // 
            this.txtDosis.Location = new System.Drawing.Point(187, 393);
            this.txtDosis.Multiline = true;
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(155, 27);
            this.txtDosis.TabIndex = 56;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(377, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 36);
            this.button1.TabIndex = 57;
            this.button1.Text = "Ver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMusica
            // 
            this.btnMusica.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnMusica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusica.Location = new System.Drawing.Point(329, 18);
            this.btnMusica.Name = "btnMusica";
            this.btnMusica.Size = new System.Drawing.Size(151, 65);
            this.btnMusica.TabIndex = 58;
            this.btnMusica.Text = "Seleccionar sonido";
            this.btnMusica.UseVisualStyleBackColor = false;
            this.btnMusica.Click += new System.EventHandler(this.btnMusica_Click);
            // 
            // cbSL
            // 
            this.cbSL.AutoSize = true;
            this.cbSL.Location = new System.Drawing.Point(22, 238);
            this.cbSL.Name = "cbSL";
            this.cbSL.Size = new System.Drawing.Size(108, 20);
            this.cbSL.TabIndex = 59;
            this.cbSL.Text = "Marcar todos";
            this.cbSL.UseVisualStyleBackColor = true;
            this.cbSL.CheckedChanged += new System.EventHandler(this.cbSL_CheckedChanged);
            // 
            // cbLun
            // 
            this.cbLun.AutoSize = true;
            this.cbLun.Location = new System.Drawing.Point(153, 238);
            this.cbLun.Name = "cbLun";
            this.cbLun.Size = new System.Drawing.Size(65, 20);
            this.cbLun.TabIndex = 60;
            this.cbLun.Text = "Lunes";
            this.cbLun.UseVisualStyleBackColor = true;
            this.cbLun.CheckedChanged += new System.EventHandler(this.cbLun_CheckedChanged);
            // 
            // cbMar
            // 
            this.cbMar.AutoSize = true;
            this.cbMar.Location = new System.Drawing.Point(255, 238);
            this.cbMar.Name = "cbMar";
            this.cbMar.Size = new System.Drawing.Size(70, 20);
            this.cbMar.TabIndex = 61;
            this.cbMar.Text = "Martes";
            this.cbMar.UseVisualStyleBackColor = true;
            // 
            // cbMierc
            // 
            this.cbMierc.AutoSize = true;
            this.cbMierc.Location = new System.Drawing.Point(377, 238);
            this.cbMierc.Name = "cbMierc";
            this.cbMierc.Size = new System.Drawing.Size(88, 20);
            this.cbMierc.TabIndex = 62;
            this.cbMierc.Text = "Miercoles";
            this.cbMierc.UseVisualStyleBackColor = true;
            // 
            // cbJue
            // 
            this.cbJue.AutoSize = true;
            this.cbJue.Location = new System.Drawing.Point(22, 291);
            this.cbJue.Name = "cbJue";
            this.cbJue.Size = new System.Drawing.Size(73, 20);
            this.cbJue.TabIndex = 63;
            this.cbJue.Text = "Jueves";
            this.cbJue.UseVisualStyleBackColor = true;
            // 
            // cbVier
            // 
            this.cbVier.AutoSize = true;
            this.cbVier.Location = new System.Drawing.Point(153, 291);
            this.cbVier.Name = "cbVier";
            this.cbVier.Size = new System.Drawing.Size(75, 20);
            this.cbVier.TabIndex = 64;
            this.cbVier.Text = "Viernes";
            this.cbVier.UseVisualStyleBackColor = true;
            // 
            // cbSab
            // 
            this.cbSab.AutoSize = true;
            this.cbSab.Location = new System.Drawing.Point(255, 291);
            this.cbSab.Name = "cbSab";
            this.cbSab.Size = new System.Drawing.Size(78, 20);
            this.cbSab.TabIndex = 65;
            this.cbSab.Text = "Sabado";
            this.cbSab.UseVisualStyleBackColor = true;
            // 
            // cbDom
            // 
            this.cbDom.AutoSize = true;
            this.cbDom.Location = new System.Drawing.Point(377, 291);
            this.cbDom.Name = "cbDom";
            this.cbDom.Size = new System.Drawing.Size(84, 20);
            this.cbDom.TabIndex = 66;
            this.cbDom.Text = "Domingo";
            this.cbDom.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(506, 106);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(194, 194);
            this.axWindowsMediaPlayer1.TabIndex = 44;
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.LightCoral;
            this.btnguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.Location = new System.Drawing.Point(4, 337);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(59, 27);
            this.btnguardar.TabIndex = 67;
            this.btnguardar.Text = "guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Visible = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(492, 448);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.cbDom);
            this.Controls.Add(this.cbSab);
            this.Controls.Add(this.cbVier);
            this.Controls.Add(this.cbJue);
            this.Controls.Add(this.cbMierc);
            this.Controls.Add(this.cbMar);
            this.Controls.Add(this.cbLun);
            this.Controls.Add(this.cbSL);
            this.Controls.Add(this.btnMusica);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDosis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnReloj);
            this.Name = "Form5";
            this.Text = "Alarma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form5_FormClosing);
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReloj;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDosis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMusica;
        private System.Windows.Forms.CheckBox cbSL;
        private System.Windows.Forms.CheckBox cbLun;
        private System.Windows.Forms.CheckBox cbMar;
        private System.Windows.Forms.CheckBox cbMierc;
        private System.Windows.Forms.CheckBox cbJue;
        private System.Windows.Forms.CheckBox cbVier;
        private System.Windows.Forms.CheckBox cbSab;
        private System.Windows.Forms.CheckBox cbDom;
        private System.Windows.Forms.Button btnguardar;
    }
}