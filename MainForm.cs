﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using ЛР3.UsersClasses;

namespace ЛР3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "task_code_development@list.ru";
            textBoxName.Text = "Антон Игоревич";
            comboBoxService.SelectedIndex = 0;
        }
        private bool IsNullOrWhiteSpaceTextBox()
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text)||
            string.IsNullOrWhiteSpace(textBoxName.Text) ||
            string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
            string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполнить все поля!");
                return true;
            }
            return false;
        }
        private void TextBoxIsCleaning()
        {
            DialogResult result = MessageBox.Show("Очистить поля ввода?", "Сообщение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                foreach (TextBox textBox in Controls.OfType<TextBox>())
                    textBox.Text = "";
        }
        private InfoEmail SetInfoEmail(EmailsTypes type)
        {
            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n + " +
            $"{Dns.GetHostName()} \n + " +
            $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
            $"{textBoxBody.Text}";
            if (type == EmailsTypes.Gmail)
                return new InfoGmail(toInfo, subject, body);
            else
                return new InfoMailRu(toInfo, subject, body);
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (IsNullOrWhiteSpaceTextBox())
                return;
            try
            {
                SendingEmail sendingEmail = new SendingEmail(
                SetInfoEmail(comboBoxService.SelectedItem.ToString() == "Gmail" ? EmailsTypes.Gmail : EmailsTypes.MailRu));
                sendingEmail.Send();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Письмо отправлено!");
            TextBoxIsCleaning();
        }
    }
}
