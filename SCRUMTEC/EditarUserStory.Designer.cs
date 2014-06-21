namespace SCRUMTEC
{
    partial class frmEditarUserStory
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar_Criterios = new System.Windows.Forms.Button();
            this.lstCriterios = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar_Tarea = new System.Windows.Forms.Button();
            this.lstTareas = new System.Windows.Forms.ListBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreUserStorie = new System.Windows.Forms.TextBox();
            this.btnVerTarea = new System.Windows.Forms.Button();
            this.btnVerCriterio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Criterios";
            // 
            // btnAgregar_Criterios
            // 
            this.btnAgregar_Criterios.Location = new System.Drawing.Point(190, 600);
            this.btnAgregar_Criterios.Name = "btnAgregar_Criterios";
            this.btnAgregar_Criterios.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar_Criterios.TabIndex = 28;
            this.btnAgregar_Criterios.Text = "Agregar";
            this.btnAgregar_Criterios.UseVisualStyleBackColor = true;
            this.btnAgregar_Criterios.Click += new System.EventHandler(this.btnAgregar_Criterios_Click);
            // 
            // lstCriterios
            // 
            this.lstCriterios.FormattingEnabled = true;
            this.lstCriterios.Location = new System.Drawing.Point(9, 421);
            this.lstCriterios.Name = "lstCriterios";
            this.lstCriterios.Size = new System.Drawing.Size(256, 173);
            this.lstCriterios.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tareas";
            // 
            // btnAgregar_Tarea
            // 
            this.btnAgregar_Tarea.Location = new System.Drawing.Point(192, 369);
            this.btnAgregar_Tarea.Name = "btnAgregar_Tarea";
            this.btnAgregar_Tarea.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar_Tarea.TabIndex = 24;
            this.btnAgregar_Tarea.Text = "Agregar";
            this.btnAgregar_Tarea.UseVisualStyleBackColor = true;
            this.btnAgregar_Tarea.Click += new System.EventHandler(this.btnAgregar_Tarea_Click);
            // 
            // lstTareas
            // 
            this.lstTareas.FormattingEnabled = true;
            this.lstTareas.Location = new System.Drawing.Point(12, 190);
            this.lstTareas.Name = "lstTareas";
            this.lstTareas.Size = new System.Drawing.Size(256, 173);
            this.lstTareas.TabIndex = 23;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(192, 123);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(12, 97);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(256, 21);
            this.cmbPrioridad.TabIndex = 21;
            this.cmbPrioridad.Tag = "";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(111, 123);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 20;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Prioridad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre del User Storie";
            // 
            // txtNombreUserStorie
            // 
            this.txtNombreUserStorie.Location = new System.Drawing.Point(9, 39);
            this.txtNombreUserStorie.Name = "txtNombreUserStorie";
            this.txtNombreUserStorie.Size = new System.Drawing.Size(259, 20);
            this.txtNombreUserStorie.TabIndex = 17;
            // 
            // btnVerTarea
            // 
            this.btnVerTarea.Location = new System.Drawing.Point(111, 369);
            this.btnVerTarea.Name = "btnVerTarea";
            this.btnVerTarea.Size = new System.Drawing.Size(75, 23);
            this.btnVerTarea.TabIndex = 33;
            this.btnVerTarea.Text = "Ver";
            this.btnVerTarea.UseVisualStyleBackColor = true;
            this.btnVerTarea.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVerCriterio
            // 
            this.btnVerCriterio.Location = new System.Drawing.Point(111, 600);
            this.btnVerCriterio.Name = "btnVerCriterio";
            this.btnVerCriterio.Size = new System.Drawing.Size(75, 23);
            this.btnVerCriterio.TabIndex = 34;
            this.btnVerCriterio.Text = "Ver";
            this.btnVerCriterio.UseVisualStyleBackColor = true;
            this.btnVerCriterio.Click += new System.EventHandler(this.btnVerCriterio_Click);
            // 
            // frmEditarUserStory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 632);
            this.Controls.Add(this.btnVerCriterio);
            this.Controls.Add(this.btnVerTarea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAgregar_Criterios);
            this.Controls.Add(this.lstCriterios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregar_Tarea);
            this.Controls.Add(this.lstTareas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreUserStorie);
            this.Name = "frmEditarUserStory";
            this.Text = "EditarUserStory";
            this.Load += new System.EventHandler(this.EditarUserStory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregar_Criterios;
        private System.Windows.Forms.ListBox lstCriterios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregar_Tarea;
        private System.Windows.Forms.ListBox lstTareas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreUserStorie;
        private System.Windows.Forms.Button btnVerTarea;
        private System.Windows.Forms.Button btnVerCriterio;
    }
}