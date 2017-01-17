﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace kNN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            var scatterPlot = new ScatterPlot();
            scatterPlot.Show();

            var classifierTest = new DatingClassifierTest();
            classifierTest.Show();
        }
    }
}
