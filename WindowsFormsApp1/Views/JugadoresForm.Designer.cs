namespace WindowsFormsApp1.Views
{
    partial class JugadoresForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboEquipos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblErrorGoles = new System.Windows.Forms.Label();
            this.nbGoles = new System.Windows.Forms.NumericUpDown();
            this.lblErrorPos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbGoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboEquipos);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblErrorGoles);
            this.groupBox1.Controls.Add(this.nbGoles);
            this.groupBox1.Controls.Add(this.lblErrorPos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboPos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblErrorNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(775, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar jugador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(76, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Error";
            this.label4.Visible = false;
            // 
            // comboEquipos
            // 
            this.comboEquipos.DisplayMember = "1";
            this.comboEquipos.FormattingEnabled = true;
            this.comboEquipos.Location = new System.Drawing.Point(76, 242);
            this.comboEquipos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboEquipos.Name = "comboEquipos";
            this.comboEquipos.Size = new System.Drawing.Size(693, 24);
            this.comboEquipos.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Equipo:";
            // 
            // lblErrorGoles
            // 
            this.lblErrorGoles.AutoSize = true;
            this.lblErrorGoles.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorGoles.Location = new System.Drawing.Point(76, 204);
            this.lblErrorGoles.Name = "lblErrorGoles";
            this.lblErrorGoles.Size = new System.Drawing.Size(40, 17);
            this.lblErrorGoles.TabIndex = 8;
            this.lblErrorGoles.Text = "Error";
            this.lblErrorGoles.Visible = false;
            // 
            // nbGoles
            // 
            this.nbGoles.Location = new System.Drawing.Point(76, 178);
            this.nbGoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbGoles.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nbGoles.Name = "nbGoles";
            this.nbGoles.Size = new System.Drawing.Size(693, 22);
            this.nbGoles.TabIndex = 7;
            this.nbGoles.Tag = "Goles en la liga";
            // 
            // lblErrorPos
            // 
            this.lblErrorPos.AutoSize = true;
            this.lblErrorPos.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorPos.Location = new System.Drawing.Point(76, 130);
            this.lblErrorPos.Name = "lblErrorPos";
            this.lblErrorPos.Size = new System.Drawing.Size(40, 17);
            this.lblErrorPos.TabIndex = 6;
            this.lblErrorPos.Text = "Error";
            this.lblErrorPos.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Goles:";
            // 
            // comboPos
            // 
            this.comboPos.FormattingEnabled = true;
            this.comboPos.Location = new System.Drawing.Point(76, 103);
            this.comboPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboPos.Name = "comboPos";
            this.comboPos.Size = new System.Drawing.Size(693, 24);
            this.comboPos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Posición:";
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorNombre.Location = new System.Drawing.Point(76, 66);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(40, 17);
            this.lblErrorNombre.TabIndex = 2;
            this.lblErrorNombre.Text = "Error";
            this.lblErrorNombre.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(76, 37);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(693, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(105, 334);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(215, 33);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 386);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(775, 459);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(484, 334);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(215, 33);
            this.btnBorrar.TabIndex = 10;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // JugadoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 851);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAgregar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "JugadoresForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestionar Jugadores";
            this.Load += new System.EventHandler(this.JugadoresForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbGoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblErrorGoles;
        private System.Windows.Forms.NumericUpDown nbGoles;
        private System.Windows.Forms.Label lblErrorPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboEquipos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBorrar;
    }
}