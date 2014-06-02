namespace SCRUMTEC
{
    partial class CrearProyecto
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
            this.button_CrearProyecto = new System.Windows.Forms.Button();
            this.button_cancelarCrearProyecto = new System.Windows.Forms.Button();
            this.textBox_descripcionProyecto = new System.Windows.Forms.TextBox();
            this.textBox_nombreProyecto = new System.Windows.Forms.TextBox();
            this.label_descripcionProyecto = new System.Windows.Forms.Label();
            this.label_nombreProyecto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_CrearProyecto
            // 
            this.button_CrearProyecto.Location = new System.Drawing.Point(298, 323);
            this.button_CrearProyecto.Name = "button_CrearProyecto";
            this.button_CrearProyecto.Size = new System.Drawing.Size(75, 23);
            this.button_CrearProyecto.TabIndex = 11;
            this.button_CrearProyecto.Text = "Crear";
            this.button_CrearProyecto.UseVisualStyleBackColor = true;
            // 
            // button_cancelarCrearProyecto
            // 
            this.button_cancelarCrearProyecto.Location = new System.Drawing.Point(208, 323);
            this.button_cancelarCrearProyecto.Name = "button_cancelarCrearProyecto";
            this.button_cancelarCrearProyecto.Size = new System.Drawing.Size(75, 23);
            this.button_cancelarCrearProyecto.TabIndex = 10;
            this.button_cancelarCrearProyecto.Text = "Cancelar";
            this.button_cancelarCrearProyecto.UseVisualStyleBackColor = true;
            // 
            // textBox_descripcionProyecto
            // 
            this.textBox_descripcionProyecto.Location = new System.Drawing.Point(155, 183);
            this.textBox_descripcionProyecto.Multiline = true;
            this.textBox_descripcionProyecto.Name = "textBox_descripcionProyecto";
            this.textBox_descripcionProyecto.Size = new System.Drawing.Size(271, 98);
            this.textBox_descripcionProyecto.TabIndex = 9;
            // 
            // textBox_nombreProyecto
            // 
            this.textBox_nombreProyecto.Location = new System.Drawing.Point(155, 90);
            this.textBox_nombreProyecto.Name = "textBox_nombreProyecto";
            this.textBox_nombreProyecto.Size = new System.Drawing.Size(271, 20);
            this.textBox_nombreProyecto.TabIndex = 8;
            // 
            // label_descripcionProyecto
            // 
            this.label_descripcionProyecto.AutoSize = true;
            this.label_descripcionProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_descripcionProyecto.Location = new System.Drawing.Point(77, 151);
            this.label_descripcionProyecto.Name = "label_descripcionProyecto";
            this.label_descripcionProyecto.Size = new System.Drawing.Size(96, 20);
            this.label_descripcionProyecto.TabIndex = 7;
            this.label_descripcionProyecto.Text = "Descripción:";
            // 
            // label_nombreProyecto
            // 
            this.label_nombreProyecto.AutoSize = true;
            this.label_nombreProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nombreProyecto.Location = new System.Drawing.Point(77, 55);
            this.label_nombreProyecto.Name = "label_nombreProyecto";
            this.label_nombreProyecto.Size = new System.Drawing.Size(159, 20);
            this.label_nombreProyecto.TabIndex = 6;
            this.label_nombreProyecto.Text = "Nombre del proyecto:";
            // 
            // CrearProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 412);
            this.Controls.Add(this.button_CrearProyecto);
            this.Controls.Add(this.button_cancelarCrearProyecto);
            this.Controls.Add(this.textBox_descripcionProyecto);
            this.Controls.Add(this.textBox_nombreProyecto);
            this.Controls.Add(this.label_descripcionProyecto);
            this.Controls.Add(this.label_nombreProyecto);
            this.Name = "CrearProyecto";
            this.Text = "CrearProyecto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CrearProyecto;
        private System.Windows.Forms.Button button_cancelarCrearProyecto;
        private System.Windows.Forms.TextBox textBox_descripcionProyecto;
        private System.Windows.Forms.TextBox textBox_nombreProyecto;
        private System.Windows.Forms.Label label_descripcionProyecto;
        private System.Windows.Forms.Label label_nombreProyecto;
    }
}