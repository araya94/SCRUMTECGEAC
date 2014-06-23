namespace SCRUMTEC
{
    partial class AsociarUserAUserStory
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
            this.label_developers = new System.Windows.Forms.Label();
            this.label_testers = new System.Windows.Forms.Label();
            this.comboBox_developers = new System.Windows.Forms.ComboBox();
            this.comboBox_testers = new System.Windows.Forms.ComboBox();
            this.button_asociar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_developers
            // 
            this.label_developers.AutoSize = true;
            this.label_developers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_developers.Location = new System.Drawing.Point(73, 53);
            this.label_developers.Name = "label_developers";
            this.label_developers.Size = new System.Drawing.Size(282, 20);
            this.label_developers.TabIndex = 0;
            this.label_developers.Text = "Developers asociados a este proyecto:";
            // 
            // label_testers
            // 
            this.label_testers.AutoSize = true;
            this.label_testers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_testers.Location = new System.Drawing.Point(73, 155);
            this.label_testers.Name = "label_testers";
            this.label_testers.Size = new System.Drawing.Size(255, 20);
            this.label_testers.TabIndex = 1;
            this.label_testers.Text = "Testers asociados a este proyecto:";
            // 
            // comboBox_developers
            // 
            this.comboBox_developers.FormattingEnabled = true;
            this.comboBox_developers.Location = new System.Drawing.Point(75, 76);
            this.comboBox_developers.Name = "comboBox_developers";
            this.comboBox_developers.Size = new System.Drawing.Size(280, 21);
            this.comboBox_developers.TabIndex = 2;
            // 
            // comboBox_testers
            // 
            this.comboBox_testers.FormattingEnabled = true;
            this.comboBox_testers.Location = new System.Drawing.Point(75, 178);
            this.comboBox_testers.Name = "comboBox_testers";
            this.comboBox_testers.Size = new System.Drawing.Size(280, 21);
            this.comboBox_testers.TabIndex = 3;
            // 
            // button_asociar
            // 
            this.button_asociar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_asociar.Location = new System.Drawing.Point(113, 262);
            this.button_asociar.Name = "button_asociar";
            this.button_asociar.Size = new System.Drawing.Size(84, 34);
            this.button_asociar.TabIndex = 4;
            this.button_asociar.Text = "Asociar";
            this.button_asociar.UseVisualStyleBackColor = true;
            this.button_asociar.Click += new System.EventHandler(this.button_asociar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancelar.Location = new System.Drawing.Point(213, 262);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(84, 34);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // AsociarUserAUserStory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 339);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_asociar);
            this.Controls.Add(this.comboBox_testers);
            this.Controls.Add(this.comboBox_developers);
            this.Controls.Add(this.label_testers);
            this.Controls.Add(this.label_developers);
            this.Name = "AsociarUserAUserStory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asociar un usuario a un user story";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_developers;
        private System.Windows.Forms.Label label_testers;
        private System.Windows.Forms.ComboBox comboBox_developers;
        private System.Windows.Forms.ComboBox comboBox_testers;
        private System.Windows.Forms.Button button_asociar;
        private System.Windows.Forms.Button button_cancelar;
    }
}