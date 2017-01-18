using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using kNN.Views;

namespace kNN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            var scatterPlot = new PercentVideoGameVsIceCreamPerYearScatterPlot();
            scatterPlot.Show();

            var scatterPlot2 = new FreqFlyerVsPercentVideoGameScatterPlot();
            scatterPlot2.Show();
        }
    }
}
