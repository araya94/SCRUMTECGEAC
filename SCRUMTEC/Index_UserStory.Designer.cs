namespace SCRUMTEC
{
    partial class Index_UserStory
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevoUserStory = new System.Windows.Forms.Button();
            this.lstUserStory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(243, 170);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar User Story";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(137, 170);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 23);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "EditarUser Story";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevoUserStory
            // 
            this.btnNuevoUserStory.Location = new System.Drawing.Point(12, 14);
            this.btnNuevoUserStory.Name = "btnNuevoUserStory";
            this.btnNuevoUserStory.Size = new System.Drawing.Size(113, 23);
            this.btnNuevoUserStory.TabIndex = 5;
            this.btnNuevoUserStory.Text = "Nueva User Story";
            this.btnNuevoUserStory.UseVisualStyleBackColor = true;
            this.btnNuevoUserStory.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstUserStory
            // 
            this.lstUserStory.FormattingEnabled = true;
            this.lstUserStory.Location = new System.Drawing.Point(12, 43);
            this.lstUserStory.Name = "lstUserStory";
            this.lstUserStory.Size = new System.Drawing.Size(338, 121);
            this.lstUserStory.TabIndex = 4;
            // 
            // Index_UserStory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 207);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevoUserStory);
            this.Controls.Add(this.lstUserStory);
            this.Name = "Index_UserStory";
            this.Text = "IndexUserStory";
            this.Load += new System.EventHandler(this.Index_UserStory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevoUserStory;
        private System.Windows.Forms.ListBox lstUserStory;
    }
}