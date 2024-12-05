namespace ver
{
    partial class Form9
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
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnV = new System.Windows.Forms.Button();
            this.btnA = new System.Windows.Forms.Button();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtTipoM = new System.Windows.Forms.TextBox();
            this.txtDosis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(193, 68);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(375, 27);
            this.txtB.TabIndex = 14;
            this.txtB.TextChanged += new System.EventHandler(this.txtB_TextChanged);
            // 
            // btnV
            // 
            this.btnV.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV.Location = new System.Drawing.Point(476, 382);
            this.btnV.Name = "btnV";
            this.btnV.Size = new System.Drawing.Size(131, 37);
            this.btnV.TabIndex = 33;
            this.btnV.Text = "Volver";
            this.btnV.UseVisualStyleBackColor = false;
            this.btnV.Click += new System.EventHandler(this.btnV_Click);
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.Color.LightPink;
            this.btnA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA.Location = new System.Drawing.Point(634, 382);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(131, 37);
            this.btnA.TabIndex = 34;
            this.btnA.Text = "Agregar";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(58, 163);
            this.txtDescrip.Multiline = true;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(687, 62);
            this.txtDescrip.TabIndex = 35;
            // 
            // txtTipoM
            // 
            this.txtTipoM.Location = new System.Drawing.Point(58, 267);
            this.txtTipoM.Multiline = true;
            this.txtTipoM.Name = "txtTipoM";
            this.txtTipoM.Size = new System.Drawing.Size(304, 62);
            this.txtTipoM.TabIndex = 36;
            // 
            // txtDosis
            // 
            this.txtDosis.Location = new System.Drawing.Point(414, 267);
            this.txtDosis.Multiline = true;
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(304, 62);
            this.txtDosis.TabIndex = 37;
            this.txtDosis.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Medicamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(481, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Dosis recomendada";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(622, 68);
            this.txtNumero.Multiline = true;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(155, 27);
            this.txtNumero.TabIndex = 49;
            this.txtNumero.Visible = false;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDosis);
            this.Controls.Add(this.txtTipoM);
            this.Controls.Add(this.txtDescrip);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.btnV);
            this.Controls.Add(this.txtB);
            this.Name = "Form9";
            this.Text = "Descripcion del medicamento";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnV;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtTipoM;
        private System.Windows.Forms.TextBox txtDosis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumero;
    }
}