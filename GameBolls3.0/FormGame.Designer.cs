
namespace GameBolls3._0
{
    partial class FormGame
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
            this.buttonShowScores = new System.Windows.Forms.Button();
            this.labelChooseLevel = new System.Windows.Forms.Label();
            this.buttonLevel1 = new System.Windows.Forms.Button();
            this.buttonLevel2 = new System.Windows.Forms.Button();
            this.buttonLevel3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShowScores
            // 
            this.buttonShowScores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonShowScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowScores.Location = new System.Drawing.Point(245, 363);
            this.buttonShowScores.Name = "buttonShowScores";
            this.buttonShowScores.Size = new System.Drawing.Size(268, 101);
            this.buttonShowScores.TabIndex = 0;
            this.buttonShowScores.Text = "Посмотреть рейтинг";
            this.buttonShowScores.UseVisualStyleBackColor = false;
            this.buttonShowScores.Click += new System.EventHandler(this.buttonShowScores_Click);
            // 
            // labelChooseLevel
            // 
            this.labelChooseLevel.AutoSize = true;
            this.labelChooseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChooseLevel.Location = new System.Drawing.Point(101, 35);
            this.labelChooseLevel.Name = "labelChooseLevel";
            this.labelChooseLevel.Size = new System.Drawing.Size(557, 46);
            this.labelChooseLevel.TabIndex = 1;
            this.labelChooseLevel.Text = "Выбрать уровень сложности";
            // 
            // buttonLevel1
            // 
            this.buttonLevel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLevel1.Location = new System.Drawing.Point(37, 139);
            this.buttonLevel1.Name = "buttonLevel1";
            this.buttonLevel1.Size = new System.Drawing.Size(171, 61);
            this.buttonLevel1.TabIndex = 2;
            this.buttonLevel1.Text = "Лёгкий";
            this.buttonLevel1.UseVisualStyleBackColor = false;
            this.buttonLevel1.Click += new System.EventHandler(this.buttonLevel1_Click);
            // 
            // buttonLevel2
            // 
            this.buttonLevel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonLevel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLevel2.Location = new System.Drawing.Point(283, 235);
            this.buttonLevel2.Name = "buttonLevel2";
            this.buttonLevel2.Size = new System.Drawing.Size(193, 64);
            this.buttonLevel2.TabIndex = 3;
            this.buttonLevel2.Text = "Средний";
            this.buttonLevel2.UseVisualStyleBackColor = false;
            this.buttonLevel2.Click += new System.EventHandler(this.buttonLevel2_Click);
            // 
            // buttonLevel3
            // 
            this.buttonLevel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonLevel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLevel3.Location = new System.Drawing.Point(544, 138);
            this.buttonLevel3.Name = "buttonLevel3";
            this.buttonLevel3.Size = new System.Drawing.Size(185, 62);
            this.buttonLevel3.TabIndex = 4;
            this.buttonLevel3.Text = "Тяжёлый";
            this.buttonLevel3.UseVisualStyleBackColor = false;
            this.buttonLevel3.Click += new System.EventHandler(this.buttonLevel3_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.buttonLevel3);
            this.Controls.Add(this.buttonLevel2);
            this.Controls.Add(this.buttonLevel1);
            this.Controls.Add(this.labelChooseLevel);
            this.Controls.Add(this.buttonShowScores);
            this.Name = "FormGame";
            this.Text = "Игра КОЛБОЧКИ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShowScores;
        private System.Windows.Forms.Label labelChooseLevel;
        private System.Windows.Forms.Button buttonLevel1;
        private System.Windows.Forms.Button buttonLevel2;
        private System.Windows.Forms.Button buttonLevel3;
    }
}

