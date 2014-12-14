// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiverView.xaml.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for ReceiverView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using FirstFloor.ModernUI.Presentation;

namespace BluetoothSample.Views
{
    /// <summary>
    /// Interaction logic for ReceiverView.xaml.
    /// </summary>
    public partial class ReceiverView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverView"/> class.
        /// </summary>
        /// 

        PowerpointController _pptController;

        MyHttpServer _listener;
        Thread _httpThread;

        void btnOpenClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == true)
            {
                string path = openDlg.FileName;
                ProcessDocument(path);
            }
        }
        string _filePath;

        private void ProcessDocument(string path) {
            if (File.Exists(path) == false) {
                return;
            }

            if (_pptController.Load(path) == false) {
                return;
            }
            this.FilePath = path;
        }

        public string FilePath
        {
            get { return this._filePath; }

            set
            {
                if (this._filePath == value)
                {
                    return;
                }

                this._filePath = value;
            }
        }

        public ReceiverView()
        {
            InitializeComponent();
            this._pptController = new PowerpointController();
            
            SetupHttpServer();
            
        }

        void ReceiverVIew_Closed(object sender, EventArgs e) {
            ReleaseSocketResource();
        }

        private void ReleaseSocketResource() {
            try
            {
                if (_listener != null)
                {
                    _listener.Dispose();
                }
            }
            catch { }
            _listener = null;

            try
            {
                if (_httpThread != null)
                {
                    _httpThread.Abort();
                }
            }
            catch { }
            _httpThread = null;
        }

        private void SetupHttpServer() {
            _listener = new MyHttpServer(this._pptController, 5022);
            _httpThread = new Thread(_listener.listen);
            _httpThread.IsBackground = true;
            _httpThread.Start();
        }
    }
}
