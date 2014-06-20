namespace SCRUMTEC
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.crearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoReleaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userStoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aministrarUserStoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BotonCerrarSesion = new System.Windows.Forms.Button();
            this.BotonAtras = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProyectoToolStripMenuItem});
            this.proyectoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.proyectoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            this.proyectoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // nuevoProyectoToolStripMenuItem
            // 
            this.nuevoProyectoToolStripMenuItem.Name = "nuevoProyectoToolStripMenuItem";
            this.nuevoProyectoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevoProyectoToolStripMenuItem.Text = "Nuevo Proyecto";
            this.nuevoProyectoToolStripMenuItem.Click += new System.EventHandler(this.nuevoProyectoToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(37, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 412);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(261, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione un Proyecto o una opción válida para continuar";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(884, 531);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.BorderWidth = 5;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 884;
            this.lineShape1.Y1 = 26;
            this.lineShape1.Y2 = 27;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearUsuarioToolStripMenuItem,
            this.releaseToolStripMenuItem,
            this.userStoryToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(810, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // crearUsuarioToolStripMenuItem
            // 
            this.crearUsuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearUsuarioToolStripMenuItem1});
            this.crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            this.crearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.crearUsuarioToolStripMenuItem.Text = "Usuario";
            this.crearUsuarioToolStripMenuItem.Click += new System.EventHandler(this.opcionesToolStripMenuItem_Click);
            // 
            // crearUsuarioToolStripMenuItem1
            // 
            this.crearUsuarioToolStripMenuItem1.Name = "crearUsuarioToolStripMenuItem1";
            this.crearUsuarioToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.crearUsuarioToolStripMenuItem1.Text = "Nuevo Usuario";
            this.crearUsuarioToolStripMenuItem1.Click += new System.EventHandler(this.crearUsuarioToolStripMenuItem1_Click);
            // 
            // releaseToolStripMenuItem
            // 
            this.releaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoReleaseToolStripMenuItem});
            this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            this.releaseToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.releaseToolStripMenuItem.Text = "Release";
            // 
            // nuevoReleaseToolStripMenuItem
            // 
            this.nuevoReleaseToolStripMenuItem.Name = "nuevoReleaseToolStripMenuItem";
            this.nuevoReleaseToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.nuevoReleaseToolStripMenuItem.Text = "Nuevo Release";
            // 
            // userStoryToolStripMenuItem
            // 
            this.userStoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aministrarUserStoryToolStripMenuItem});
            this.userStoryToolStripMenuItem.Name = "userStoryToolStripMenuItem";
            this.userStoryToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.userStoryToolStripMenuItem.Text = "User Story";
            this.userStoryToolStripMenuItem.Click += new System.EventHandler(this.userStoryToolStripMenuItem_Click);
            // 
            // aministrarUserStoryToolStripMenuItem
            // 
            this.aministrarUserStoryToolStripMenuItem.Name = "aministrarUserStoryToolStripMenuItem";
            this.aministrarUserStoryToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.aministrarUserStoryToolStripMenuItem.Text = "Aministrar User Story";
            this.aministrarUserStoryToolStripMenuItem.Click += new System.EventHandler(this.aministrarUserStoryToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.menuStrip2);
            this.panel2.Location = new System.Drawing.Point(37, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 412);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // BotonCerrarSesion
            // 
            this.BotonCerrarSesion.BackColor = System.Drawing.Color.DarkGray;
            this.BotonCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonCerrarSesion.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCerrarSesion.Location = new System.Drawing.Point(748, 492);
            this.BotonCerrarSesion.Name = "BotonCerrarSesion";
            this.BotonCerrarSesion.Size = new System.Drawing.Size(99, 27);
            this.BotonCerrarSesion.TabIndex = 8;
            this.BotonCerrarSesion.Text = "Cerrar sesión";
            this.BotonCerrarSesion.UseVisualStyleBackColor = false;
            this.BotonCerrarSesion.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BotonAtras
            // 
            this.BotonAtras.BackColor = System.Drawing.Color.DarkGray;
            this.BotonAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonAtras.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonAtras.Location = new System.Drawing.Point(667, 492);
            this.BotonAtras.Name = "BotonAtras";
            this.BotonAtras.Size = new System.Drawing.Size(75, 27);
            this.BotonAtras.TabIndex = 9;
            this.BotonAtras.Text = "Atrás";
            this.BotonAtras.UseVisualStyleBackColor = false;
            this.BotonAtras.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.menuStrip3);
            this.panel3.Location = new System.Drawing.Point(37, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(810, 412);
            this.panel3.TabIndex = 10;
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(810, 24);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.menuStrip4);
            this.panel4.Location = new System.Drawing.Point(37, 74);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(810, 412);
            this.panel4.TabIndex = 11;
            // 
            // menuStrip4
            // 
            this.menuStrip4.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip4.Location = new System.Drawing.Point(0, 0);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(810, 24);
            this.menuStrip4.TabIndex = 0;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.menuStrip5);
            this.panel5.Location = new System.Drawing.Point(37, 74);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(810, 412);
            this.panel5.TabIndex = 12;
            // 
            // menuStrip5
            // 
            this.menuStrip5.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip5.Location = new System.Drawing.Point(0, 0);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Size = new System.Drawing.Size(810, 24);
            this.menuStrip5.TabIndex = 0;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(884, 531);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.BotonAtras);
            this.Controls.Add(this.BotonCerrarSesion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.shapeContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScrumTEC";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoProyectoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem crearUsuarioToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoReleaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userStoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearUsuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aministrarUserStoryToolStripMenuItem;
        private System.Windows.Forms.Button BotonCerrarSesion;
        private System.Windows.Forms.Button BotonAtras;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MenuStrip menuStrip5;
    }
}