namespace CellularAutomaton
{
    partial class Menu
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
            this.btnFireSymulation = new System.Windows.Forms.Button();
            this.btnSymulationGameOfLife = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFireSymulation
            // 
            this.btnFireSymulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFireSymulation.Location = new System.Drawing.Point(39, 50);
            this.btnFireSymulation.Name = "btnFireSymulation";
            this.btnFireSymulation.Size = new System.Drawing.Size(198, 34);
            this.btnFireSymulation.TabIndex = 0;
            this.btnFireSymulation.Text = "Symulacja pożaru w lesie";
            this.btnFireSymulation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFireSymulation.UseVisualStyleBackColor = true;
            // 
            // btnSymulationGameOfLife
            // 
            this.btnSymulationGameOfLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSymulationGameOfLife.Location = new System.Drawing.Point(39, 130);
            this.btnSymulationGameOfLife.Name = "btnSymulationGameOfLife";
            this.btnSymulationGameOfLife.Size = new System.Drawing.Size(198, 34);
            this.btnSymulationGameOfLife.TabIndex = 1;
            this.btnSymulationGameOfLife.Text = "Symulacja \"Gry w życie\"";
            this.btnSymulationGameOfLife.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSymulationGameOfLife);
            this.Controls.Add(this.btnFireSymulation);
            this.Name = "Menu";
            this.Text = "Automaty komórkowe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFireSymulation;
        private System.Windows.Forms.Button btnSymulationGameOfLife;
    }
}