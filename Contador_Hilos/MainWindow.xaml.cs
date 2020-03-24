using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace Contador_Hilos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAutomatico_Click(object sender, RoutedEventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(contador_Automatico);
            Thread hilo_Automatico = new Thread(threadStart);
            hilo_Automatico.Start();
        }

        public void contador_Automatico()
        {
            int i;
            for (i=0; i<=100; i++)
            {
                TextAutomatico.Dispatcher.Invoke(new Action(() =>
                {
                    TextAutomatico.Text = i.ToString();
                }
                ));                
                Thread.Sleep(1000);
            }
        }

        private void ButtonManual_Click(object sender, RoutedEventArgs e)
        {
            int contador = 0;
            
            if(contador <= 100)
            {
                TextManual.Dispatcher.Invoke(new Action(() =>
               {

                   TextManual.Text = contador.ToString();
                   contador++;

               }));
                Thread.Sleep(1000);

            }           
           
        }
    }
}
