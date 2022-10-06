namespace Muñequito
{
    partial class DetalleArticulo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOrdenarasc = new System.Windows.Forms.Button();
            this.btnOrdenardes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resultados...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 32);
            this.label2.TabIndex = 1;
            // 
            // btnOrdenarasc
            // 
            this.btnOrdenarasc.Location = new System.Drawing.Point(206, 346);
            this.btnOrdenarasc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenarasc.Name = "btnOrdenarasc";
            this.btnOrdenarasc.Size = new System.Drawing.Size(145, 75);
            this.btnOrdenarasc.TabIndex = 4;
            this.btnOrdenarasc.Text = "Ordenar ascendentemente por precio";
            this.btnOrdenarasc.UseVisualStyleBackColor = true;
            this.btnOrdenarasc.Click += new System.EventHandler(this.btnOrdenarasc_Click);
            // 
            // btnOrdenardes
            // 
            this.btnOrdenardes.Location = new System.Drawing.Point(381, 348);
            this.btnOrdenardes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenardes.Name = "btnOrdenardes";
            this.btnOrdenardes.Size = new System.Drawing.Size(145, 71);
            this.btnOrdenardes.TabIndex = 5;
            this.btnOrdenardes.Text = "Ordenar descendentemente por precio";
            this.btnOrdenardes.UseVisualStyleBackColor = true;
            this.btnOrdenardes.Click += new System.EventHandler(this.btnOrdenardes_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(19, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 240);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // DetalleArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOrdenardes);
            this.Controls.Add(this.btnOrdenarasc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DetalleArticulo";
            this.Text = "DetalleArticulo";
            this.Load += new System.EventHandler(this.DetalleArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOrdenarasc;
        private System.Windows.Forms.Button btnOrdenardes;
        private System.Windows.Forms.Panel panel1;
    }
}