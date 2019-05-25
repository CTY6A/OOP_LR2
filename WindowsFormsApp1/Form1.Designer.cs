namespace OOP_2
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboBoxCreate = new System.Windows.Forms.ComboBox();
            this.ComboBoxObjects = new System.Windows.Forms.ComboBox();
            this.LabelObjects = new System.Windows.Forms.Label();
            this.LabelCreate = new System.Windows.Forms.Label();
            this.ButtonUpdateObject = new System.Windows.Forms.Button();
            this.ButtonDeleteObject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxCreate
            // 
            this.ComboBoxCreate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCreate.FormattingEnabled = true;
            this.ComboBoxCreate.Location = new System.Drawing.Point(24, 37);
            this.ComboBoxCreate.Name = "ComboBoxCreate";
            this.ComboBoxCreate.Size = new System.Drawing.Size(226, 24);
            this.ComboBoxCreate.TabIndex = 0;
            this.ComboBoxCreate.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxCreate_SelectionChangeCommitted);
            // 
            // ComboBoxObjects
            // 
            this.ComboBoxObjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxObjects.FormattingEnabled = true;
            this.ComboBoxObjects.Location = new System.Drawing.Point(24, 112);
            this.ComboBoxObjects.Name = "ComboBoxObjects";
            this.ComboBoxObjects.Size = new System.Drawing.Size(226, 24);
            this.ComboBoxObjects.TabIndex = 3;
            // 
            // LabelObjects
            // 
            this.LabelObjects.AutoSize = true;
            this.LabelObjects.Location = new System.Drawing.Point(21, 92);
            this.LabelObjects.Name = "LabelObjects";
            this.LabelObjects.Size = new System.Drawing.Size(72, 17);
            this.LabelObjects.TabIndex = 4;
            this.LabelObjects.Text = "Объекты:";
            // 
            // LabelCreate
            // 
            this.LabelCreate.AutoSize = true;
            this.LabelCreate.Location = new System.Drawing.Point(21, 17);
            this.LabelCreate.Name = "LabelCreate";
            this.LabelCreate.Size = new System.Drawing.Size(117, 17);
            this.LabelCreate.TabIndex = 5;
            this.LabelCreate.Text = "Создать объект:";
            // 
            // ButtonUpdateObject
            // 
            this.ButtonUpdateObject.Location = new System.Drawing.Point(24, 142);
            this.ButtonUpdateObject.Name = "ButtonUpdateObject";
            this.ButtonUpdateObject.Size = new System.Drawing.Size(134, 23);
            this.ButtonUpdateObject.TabIndex = 6;
            this.ButtonUpdateObject.Text = "Редактировать";
            this.ButtonUpdateObject.UseVisualStyleBackColor = true;
            this.ButtonUpdateObject.Click += new System.EventHandler(this.ButtonUpdateObject_Click);
            // 
            // ButtonDeleteObject
            // 
            this.ButtonDeleteObject.Location = new System.Drawing.Point(164, 142);
            this.ButtonDeleteObject.Name = "ButtonDeleteObject";
            this.ButtonDeleteObject.Size = new System.Drawing.Size(86, 23);
            this.ButtonDeleteObject.TabIndex = 7;
            this.ButtonDeleteObject.Text = "Удалить";
            this.ButtonDeleteObject.UseVisualStyleBackColor = true;
            this.ButtonDeleteObject.Click += new System.EventHandler(this.ButtonDeleteObject_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 194);
            this.Controls.Add(this.ButtonDeleteObject);
            this.Controls.Add(this.ButtonUpdateObject);
            this.Controls.Add(this.LabelCreate);
            this.Controls.Add(this.LabelObjects);
            this.Controls.Add(this.ComboBoxObjects);
            this.Controls.Add(this.ComboBoxCreate);
            this.Name = "FormMain";
            this.Text = "CRUD";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxCreate;
        public System.Windows.Forms.ComboBox ComboBoxObjects;
        private System.Windows.Forms.Label LabelObjects;
        private System.Windows.Forms.Label LabelCreate;
        private System.Windows.Forms.Button ButtonUpdateObject;
        private System.Windows.Forms.Button ButtonDeleteObject;
    }
}

