namespace ver
{
    partial class Form8
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
            this.btnM = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnV = new System.Windows.Forms.Button();
            this.btnA = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(79, 66);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(375, 27);
            this.txtB.TabIndex = 13;
            // 
            // btnM
            // 
            this.btnM.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM.Location = new System.Drawing.Point(476, 60);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(131, 37);
            this.btnM.TabIndex = 30;
            this.btnM.Text = "Search";
            this.btnM.UseVisualStyleBackColor = false;
            this.btnM.Click += new System.EventHandler(this.btnM_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(113, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(406, 190);
            this.dataGridView1.TabIndex = 31;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Medicamento";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // btnV
            // 
            this.btnV.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV.Location = new System.Drawing.Point(323, 374);
            this.btnV.Name = "btnV";
            this.btnV.Size = new System.Drawing.Size(131, 37);
            this.btnV.TabIndex = 32;
            this.btnV.Text = "Volver";
            this.btnV.UseVisualStyleBackColor = false;
            this.btnV.Click += new System.EventHandler(this.btnV_Click);
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.Color.LightCoral;
            this.btnA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA.Location = new System.Drawing.Point(631, 374);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(131, 37);
            this.btnA.TabIndex = 33;
            this.btnA.Text = "Agregar";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.Color.LightPink;
            this.btnD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnD.Location = new System.Drawing.Point(476, 374);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(149, 37);
            this.btnD.TabIndex = 34;
            this.btnD.Text = "Descripcion";
            this.btnD.UseVisualStyleBackColor = false;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(592, 150);
            this.txtNumero.Multiline = true;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(155, 27);
            this.txtNumero.TabIndex = 48;
            this.txtNumero.Visible = false;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.btnV);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.txtB);
            this.Name = "Form8";
            this.Text = "Busqueda de medicamentos";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnM;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnV;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox txtNumero;
    }
}