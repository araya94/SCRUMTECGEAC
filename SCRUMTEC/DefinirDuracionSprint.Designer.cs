namespace SCRUMTEC
{
    partial class DefinirDuracionSprint
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDefinir = new System.Windows.Forms.Button();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(185, 41);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDefinir
            // 
            this.btnDefinir.Location = new System.Drawing.Point(185, 12);
            this.btnDefinir.Name = "btnDefinir";
            this.btnDefinir.Size = new System.Drawing.Size(75, 23);
            this.btnDefinir.TabIndex = 30;
            this.btnDefinir.Text = "Definir";
            this.btnDefinir.UseVisualStyleBackColor = true;
            this.btnDefinir.Click += new System.EventHandler(this.btnDefinir_Click);
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(18, 27);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(56, 13);
            this.lblDuracion.TabIndex = 32;
            this.lblDuracion.Text = "Duración: ";
            this.lblDuracion.Click += new System.EventHandler(this.lblDuracion_Click);
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(74, 24);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(70, 20);
            this.txtDuracion.TabIndex = 33;
            this.txtDuracion.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "hrs.";
            // 
            // DefinirDuracionSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 74);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDefinir);
            this.Name = "DefinirDuracionSprint";
            this.Text = "DefinirDuracionSprint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnDefinir;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label label1;
    }
}