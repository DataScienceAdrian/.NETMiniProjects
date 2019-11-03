using HelixToolkit.Wpf;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WpfApplicationMove3DModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
	/// 
	
    public partial class MainWindow : Window
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Create3DViewPort()
        {
            var hVp3D = new HelixViewport3D();
            var lights = new DefaultLights();
            var teaPot = new Teapot();
            hVp3D.Children.Add(lights);
            hVp3D.Children.Add(teaPot);

            
        } 


        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
        	// TODO: Add event handler implementation here.
            var axis = new Vector3D(0, 0, 1);
             if(RX.IsChecked==true)
             {
                 axis = new Vector3D(1, 0, 0);
             }
             if (RY.IsChecked == true)
             {
                 axis = new Vector3D(0, 1, 0);
             }
             if (RZ.IsChecked == true)
             {
                 axis = new Vector3D(0, 0, 1);

             }
            var angle = rotationSlider.Value;

            var matrix = tea.Transform.Value;
            matrix.Rotate(new Quaternion(axis, angle));

            tea.Transform = new MatrixTransform3D(matrix);
			Console.WriteLine(rotationSlider.Value) ;
        }

        private void NumberTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void Xpos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tea.Position = new Point3D(Xpos.Value, Ypos.Value, Zpos.Value);
        }

     
    }
}
