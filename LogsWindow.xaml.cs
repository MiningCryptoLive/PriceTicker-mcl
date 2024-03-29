﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace PriceTicker
{
    /// <summary>
    /// Logique d'interaction pour LogsWindow.xaml
    /// </summary>
    public partial class LogsWindow : Window
    {

        public static LogsWindow? gui;
        
        public LogsWindow()
        {
            InitializeComponent();
            gui = this;
            UpdateLogsTxt();
        }

        public void UpdateLogsTxt()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Logs.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {   
                    Dispatcher.Invoke(new Action(() => {
                        LogBox.Text = "";
                        string s = "";
                    while ((s = sr.ReadLine()) != null)
                        {
                        LogBox.Text += s + "\n";
                            
                        }
                    }), DispatcherPriority.Background);
                }
            }
        }
    }
}