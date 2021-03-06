﻿namespace FiboneedNet
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNumber = new System.Windows.Forms.Label();
            this.bntCalcular = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(12, 18);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(211, 18);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Número base para calcular";
            // 
            // bntCalcular
            // 
            this.bntCalcular.Location = new System.Drawing.Point(314, 41);
            this.bntCalcular.Name = "bntCalcular";
            this.bntCalcular.Size = new System.Drawing.Size(101, 22);
            this.bntCalcular.TabIndex = 2;
            this.bntCalcular.Text = "Calcular";
            this.bntCalcular.UseVisualStyleBackColor = true;
            this.bntCalcular.Click += new System.EventHandler(this.bntCalcular_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultado.Location = new System.Drawing.Point(12, 70);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(403, 117);
            this.lblResultado.TabIndex = 0;
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(230, 15);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(185, 20);
            this.tbNumber.TabIndex = 3;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 39);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(211, 23);
            this.progressBar.TabIndex = 4;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 197);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.bntCalcular);
            this.Controls.Add(this.lblNumber);
            this.Name = "frmMenu";
            this.Text = "FiboneedNet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button bntCalcular;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox tbNumber;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

