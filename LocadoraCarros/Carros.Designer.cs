namespace AppLocadora
{
    partial class Carros
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
            this.lvCarros = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMarca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpcionais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNewCar = new System.Windows.Forms.Button();
            this.colDisponivel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlaca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvCarros
            // 
            this.lvCarros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colMarca,
            this.colModelo,
            this.colAno,
            this.colOpcionais,
            this.colDisponivel,
            this.colPlaca});
            this.lvCarros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCarros.FullRowSelect = true;
            this.lvCarros.GridLines = true;
            this.lvCarros.LabelWrap = false;
            this.lvCarros.Location = new System.Drawing.Point(12, 12);
            this.lvCarros.Name = "lvCarros";
            this.lvCarros.Size = new System.Drawing.Size(700, 209);
            this.lvCarros.TabIndex = 9;
            this.lvCarros.UseCompatibleStateImageBehavior = false;
            this.lvCarros.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "ID";
            // 
            // colMarca
            // 
            this.colMarca.Text = "Marca";
            this.colMarca.Width = 131;
            // 
            // colModelo
            // 
            this.colModelo.Text = "Modelo";
            this.colModelo.Width = 133;
            // 
            // colOpcionais
            // 
            this.colOpcionais.Text = "Opcionais";
            this.colOpcionais.Width = 114;
            // 
            // colAno
            // 
            this.colAno.Text = "Ano";
            this.colAno.Width = 66;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(584, 222);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 31);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnNewCar
            // 
            this.btnNewCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCar.Location = new System.Drawing.Point(436, 222);
            this.btnNewCar.Name = "btnNewCar";
            this.btnNewCar.Size = new System.Drawing.Size(146, 31);
            this.btnNewCar.TabIndex = 10;
            this.btnNewCar.Text = "Novo &Carro";
            this.btnNewCar.UseVisualStyleBackColor = true;
            this.btnNewCar.Click += new System.EventHandler(this.btnNewCar_Click);
            // 
            // colDisponivel
            // 
            this.colDisponivel.Text = "Disponivel";
            this.colDisponivel.Width = 90;
            // 
            // colPlaca
            // 
            this.colPlaca.Text = "Placa";
            // 
            // Carros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(719, 261);
            this.Controls.Add(this.lvCarros);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewCar);
            this.Name = "Carros";
            this.Text = "Carros";
            this.Load += new System.EventHandler(this.CarroEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCarros;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colMarca;
        private System.Windows.Forms.ColumnHeader colModelo;
        private System.Windows.Forms.ColumnHeader colAno;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNewCar;
        private System.Windows.Forms.ColumnHeader colOpcionais;
        private System.Windows.Forms.ColumnHeader colDisponivel;
        private System.Windows.Forms.ColumnHeader colPlaca;
    }
}