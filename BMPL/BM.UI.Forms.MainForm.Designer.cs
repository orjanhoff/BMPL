﻿namespace BMApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВТрейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настрокаСоединенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключитьсяКСерверуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьсяОтСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администраторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.словариToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шаблоныСообщенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.реестрAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.интеграцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.администраторToolStripMenuItem,
            this.управлениеToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1303, 28);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свернутьВТрейToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("файлToolStripMenuItem.Image")));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // свернутьВТрейToolStripMenuItem
            // 
            this.свернутьВТрейToolStripMenuItem.Image = global::BMApp.Properties.Resources.tray;
            this.свернутьВТрейToolStripMenuItem.Name = "свернутьВТрейToolStripMenuItem";
            this.свернутьВТрейToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.свернутьВТрейToolStripMenuItem.Text = "Свернуть в трей";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::BMApp.Properties.Resources.power;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настрокаСоединенияToolStripMenuItem,
            this.подключитьсяКСерверуToolStripMenuItem,
            this.отключитьсяОтСервераToolStripMenuItem});
            this.сервисToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сервисToolStripMenuItem.Image")));
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // настрокаСоединенияToolStripMenuItem
            // 
            this.настрокаСоединенияToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("настрокаСоединенияToolStripMenuItem.Image")));
            this.настрокаСоединенияToolStripMenuItem.Name = "настрокаСоединенияToolStripMenuItem";
            this.настрокаСоединенияToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.настрокаСоединенияToolStripMenuItem.Text = "Настройка";
            // 
            // подключитьсяКСерверуToolStripMenuItem
            // 
            this.подключитьсяКСерверуToolStripMenuItem.Image = global::BMApp.Properties.Resources.import;
            this.подключитьсяКСерверуToolStripMenuItem.Name = "подключитьсяКСерверуToolStripMenuItem";
            this.подключитьсяКСерверуToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.подключитьсяКСерверуToolStripMenuItem.Text = "Обновления";
            // 
            // отключитьсяОтСервераToolStripMenuItem
            // 
            this.отключитьсяОтСервераToolStripMenuItem.Image = global::BMApp.Properties.Resources.console;
            this.отключитьсяОтСервераToolStripMenuItem.Name = "отключитьсяОтСервераToolStripMenuItem";
            this.отключитьсяОтСервераToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.отключитьсяОтСервераToolStripMenuItem.Text = "Консоль";
            // 
            // администраторToolStripMenuItem
            // 
            this.администраторToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.словариToolStripMenuItem,
            this.шаблоныСообщенийToolStripMenuItem,
            this.пользователяToolStripMenuItem,
            this.реестрAPIToolStripMenuItem});
            this.администраторToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("администраторToolStripMenuItem.Image")));
            this.администраторToolStripMenuItem.Name = "администраторToolStripMenuItem";
            this.администраторToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.администраторToolStripMenuItem.Text = "Администратор";
            // 
            // словариToolStripMenuItem
            // 
            this.словариToolStripMenuItem.Image = global::BMApp.Properties.Resources.dictionary;
            this.словариToolStripMenuItem.Name = "словариToolStripMenuItem";
            this.словариToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.словариToolStripMenuItem.Text = "Справочники";
            this.словариToolStripMenuItem.Click += new System.EventHandler(this.словариToolStripMenuItem_Click);
            // 
            // шаблоныСообщенийToolStripMenuItem
            // 
            this.шаблоныСообщенийToolStripMenuItem.Image = global::BMApp.Properties.Resources.message;
            this.шаблоныСообщенийToolStripMenuItem.Name = "шаблоныСообщенийToolStripMenuItem";
            this.шаблоныСообщенийToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.шаблоныСообщенийToolStripMenuItem.Text = "Сообщения";
            // 
            // пользователяToolStripMenuItem
            // 
            this.пользователяToolStripMenuItem.Image = global::BMApp.Properties.Resources.users;
            this.пользователяToolStripMenuItem.Name = "пользователяToolStripMenuItem";
            this.пользователяToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.пользователяToolStripMenuItem.Text = "Пользователи";
            this.пользователяToolStripMenuItem.Click += new System.EventHandler(this.пользователиToolStripMenuItem_Click);
            // 
            // реестрAPIToolStripMenuItem
            // 
            this.реестрAPIToolStripMenuItem.Image = global::BMApp.Properties.Resources.api;
            this.реестрAPIToolStripMenuItem.Name = "реестрAPIToolStripMenuItem";
            this.реестрAPIToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.реестрAPIToolStripMenuItem.Text = "Реестр API";
            this.реестрAPIToolStripMenuItem.Click += new System.EventHandler(this.реестрAPIToolStripMenuItem_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.журналыToolStripMenuItem,
            this.интеграцияToolStripMenuItem});
            this.управлениеToolStripMenuItem.Image = global::BMApp.Properties.Resources.management;
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.управлениеToolStripMenuItem.Text = "Управление";
            // 
            // журналыToolStripMenuItem
            // 
            this.журналыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.логToolStripMenuItem});
            this.журналыToolStripMenuItem.Image = global::BMApp.Properties.Resources.report;
            this.журналыToolStripMenuItem.Name = "журналыToolStripMenuItem";
            this.журналыToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.журналыToolStripMenuItem.Text = "Журналы";
            // 
            // логToolStripMenuItem
            // 
            this.логToolStripMenuItem.Image = global::BMApp.Properties.Resources.log;
            this.логToolStripMenuItem.Name = "логToolStripMenuItem";
            this.логToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.логToolStripMenuItem.Text = "Журнал лога";
            this.логToolStripMenuItem.Click += new System.EventHandler(this.логToolStripMenuItem_Click);
            // 
            // интеграцияToolStripMenuItem
            // 
            this.интеграцияToolStripMenuItem.Image = global::BMApp.Properties.Resources.integration;
            this.интеграцияToolStripMenuItem.Name = "интеграцияToolStripMenuItem";
            this.интеграцияToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.интеграцияToolStripMenuItem.Text = "Интеграция";
            this.интеграцияToolStripMenuItem.Click += new System.EventHandler(this.интеграцияToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.руководствоПользователяToolStripMenuItem});
            this.справкаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("справкаToolStripMenuItem.Image")));
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = global::BMApp.Properties.Resources._operator;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // руководствоПользователяToolStripMenuItem
            // 
            this.руководствоПользователяToolStripMenuItem.Image = global::BMApp.Properties.Resources.wtpower;
            this.руководствоПользователяToolStripMenuItem.Name = "руководствоПользователяToolStripMenuItem";
            this.руководствоПользователяToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.руководствоПользователяToolStripMenuItem.Text = "Руководство пользователя";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1303, 490);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Бизнес Механика";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настрокаСоединенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяКСерверуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьсяОтСервераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem администраторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem словариToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шаблоныСообщенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem реестрAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВТрейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem интеграцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem логToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
    }
}

