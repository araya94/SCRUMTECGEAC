namespace SCRUMTEC
{
    partial class EditarAsociacionUserUserStory
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
            this.label_nombre_user_story = new System.Windows.Forms.Label();
            this.label_usuarios = new System.Windows.Forms.Label();
            this.listBox_usuarios = new System.Windows.Forms.ListBox();
            this.button_agregar_usuario = new System.Windows.Forms.Button();
            this.button_eliminar_usuario = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_nombre_user_story
            // 
            this.label_nombre_user_story.AutoSize = true;
            this.label_nombre_user_story.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nombre_user_story.Location = new System.Drawing.Point(72, 50);
            this.label_nombre_user_story.Name = "label_nombre_user_story";
            this.label_nombre_user_story.Size = new System.Drawing.Size(206, 20);
            this.label_nombre_user_story.TabIndex = 0;
            this.label_nombre_user_story.Text = "User Story: -----------------";
            // 
            // label_usuarios
            // 
            this.label_usuarios.AutoSize = true;
            this.label_usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuarios.Location = new System.Drawing.Point(72, 102);
            this.label_usuarios.Name = "label_usuarios";
            this.label_usuarios.Size = new System.Drawing.Size(76, 20);
            this.label_usuarios.TabIndex = 1;
            this.label_usuarios.Text = "Usuarios:";
            // 
            // listBox_usuarios
            // 
            this.listBox_usuarios.FormattingEnabled = true;
            this.listBox_usuarios.Location = new System.Drawing.Point(76, 137);
            this.listBox_usuarios.Name = "listBox_usuarios";
            this.listBox_usuarios.Size = new System.Drawing.Size(318, 173);
            this.listBox_usuarios.TabIndex = 2;
            this.listBox_usuarios.SelectedIndexChanged += new System.EventHandler(this.listBox_usuarios_SelectedIndexChanged);
            // 
            // button_agregar_usuario
            // 
            this.button_agregar_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_agregar_usuario.Location = new System.Drawing.Point(76, 378);
            this.button_agregar_usuario.Name = "button_agregar_usuario";
            this.button_agregar_usuario.Size = new System.Drawing.Size(75, 34);
            this.button_agregar_usuario.TabIndex = 3;
            this.button_agregar_usuario.Text = "Agregar";
            this.button_agregar_usuario.UseVisualStyleBackColor = true;
            this.button_agregar_usuario.Click += new System.EventHandler(this.button_agregar_usuario_Click);
            // 
            // button_eliminar_usuario
            // 
            this.button_eliminar_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_eliminar_usuario.Location = new System.Drawing.Point(157, 378);
            this.button_eliminar_usuario.Name = "button_eliminar_usuario";
            this.button_eliminar_usuario.Size = new System.Drawing.Size(75, 34);
            this.button_eliminar_usuario.TabIndex = 4;
            this.button_eliminar_usuario.Text = "Eliminar";
            this.button_eliminar_usuario.UseVisualStyleBackColor = true;
            this.button_eliminar_usuario.Click += new System.EventHandler(this.button_eliminar_usuario_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancelar.Location = new System.Drawing.Point(319, 378);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 34);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.Location = new System.Drawing.Point(238, 378);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 34);
            this.button_refresh.TabIndex = 6;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // EditarAsociacionUserUserStory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 464);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_eliminar_usuario);
            this.Controls.Add(this.button_agregar_usuario);
            this.Controls.Add(this.listBox_usuarios);
            this.Controls.Add(this.label_usuarios);
            this.Controls.Add(this.label_nombre_user_story);
            this.Name = "EditarAsociacionUserUserStory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios del User Story";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nombre_user_story;
        private System.Windows.Forms.Label label_usuarios;
        private System.Windows.Forms.ListBox listBox_usuarios;
        private System.Windows.Forms.Button button_agregar_usuario;
        private System.Windows.Forms.Button button_eliminar_usuario;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_refresh;
    }
}