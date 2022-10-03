using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Kinect.Toolkit.Interaction;

using System.Windows.Threading;

namespace ControlesDeToolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       
        //Verificar quantos kinects estão conectados
        KinectSensorChooser meuKinect;



        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //tratando a conexão e desconexão do kinect
            meuKinect = new KinectSensorChooser();
            //vai enviar a mensagem
            meuKinect.KinectChanged += meuKinect_KinectChanged;
            //se estiver conectado vai mandar para variavel
            sensorChooserUI.KinectSensorChooser = meuKinect;
            //vai iniciar o kinect
            meuKinect.Start();    
        }

        //verificar conexão
        void meuKinect_KinectChanged(object sender, KinectChangedEventArgs e)
        {
            bool error = true;

            if (e.OldSensor == null)
            {
                try
                {
                    e.OldSensor.DepthStream.Disable();
                    e.OldSensor.SkeletonStream.Disable();
                }
                catch (Exception)
                {
                    error = true;
                }
            }

            if (e.NewSensor == null)
                return;

            try
            {
                //kinect xbox360
                e.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                e.NewSensor.SkeletonStream.Enable();

                try
                {
                    //kinect windows
                    e.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    e.NewSensor.DepthStream.Range = DepthRange.Near;
                    e.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                }
                catch (InvalidOperationException)
                {
                    e.NewSensor.DepthStream.Range = DepthRange.Default;
                    e.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                }
            }
            catch (InvalidOperationException)
            {
                error = true;
            }

            //configurar a região que vamos controlar com o cursor
            ZonaCursor.KinectSensor = e.NewSensor;

        }

        int controle;
        int clique1, clique2, clique3, clique4;
        int correto1, correto2, correto3, correto4;
        int jogada;
        int clicado;

      
        



        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            btn1.IsEnabled = false;
            BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel0.jpg", UriKind.Relative));
            imgbtn1.Source = img;
            
            controle = 5;
            
            

            contador();

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            controle = 3;
            btn2.IsEnabled = false;
            contador();
            BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel0.jpg", UriKind.Relative));
            imgbtn2.Source = img;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            controle = 4;
            btn3.IsEnabled = false;
            contador();
            BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel0.jpg", UriKind.Relative));
            imgbtn3.Source = img;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            controle = 2;
            btn4.IsEnabled = false;
            contador();

            BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel0.jpg", UriKind.Relative));
            imgbtn4.Source = img;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            controle = 1;
            btn5.IsEnabled = false;
            contador();

            BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel0.jpg", UriKind.Relative));
            imgbtn5.Source = img;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            controle = 6;
            btn6.IsEnabled = false;
            contador();
            BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel0.jpg", UriKind.Relative));
            imgbtn6.Source = img;
        }



        private void btnesp1_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img0 = new BitmapImage(new Uri("/img/nivel1/img0.jpg", UriKind.Relative));
            BitmapImage img1 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
            BitmapImage img3 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
            BitmapImage img4 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
            BitmapImage img1e = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
            BitmapImage img2e = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));

            
            switch (clique1)
            {
                case 1:
                    imgesp1.Source = img0;

                   BitmapImage esp1 = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
                    imgbtn1.Source = esp1;
                   

                    btn1.IsEnabled = true;
                    clique1 = 0;
                    break;

                case 2:
                    imgesp1.Source = img0;
                         
                     BitmapImage esp4 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
                    imgbtn4.Source = esp4;             

                    btn4.IsEnabled = true;
                    clique1 = 0;
                    break;

                case 3:
                    imgesp1.Source = img0;

                     BitmapImage esp2 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
                    imgbtn2.Source = esp2;

                    btn2.IsEnabled = true;
                    clique1 = 0;
                    break;

                case 4:
                    imgesp1.Source = img0;

                     BitmapImage esp3 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
                    imgbtn3.Source = esp3;

                    btn3.IsEnabled = true;
                    clique1 = 0;
                    break;

                case 5:
                    imgesp1.Source = img0;
                    BitmapImage esp5 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
                    imgbtn5.Source = esp5;

                    btn5.IsEnabled = true;
                    clique1 = 0;
                    break;

                case 6:
                    imgesp1.Source = img0;
                    BitmapImage esp6 = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));
                    imgbtn6.Source = esp6;
                    btn6.IsEnabled = true;
                    clique1 = 0;
                    break;
            }

            switch (controle)
            {
                case 1:
                    imgesp1.Source = img1;

                    clique1 = 5;

                    correto1 = 1;

                    break;

                case 2:
                    imgesp1.Source = img2;

                    clique1 = 2;

                    correto1 = 0;
                    break;

                case 3:
                    imgesp1.Source = img3;

                    clique1 = 3;
                    correto1 = 0;
                    break;

                case 4:
                    imgesp1.Source = img4;

                    clique1 = 4;
                    correto1 = 0;
                    break;

                case 5:
                    imgesp1.Source = img1e;

                    clique1 = 1;
                    correto1 = 0;
                    break;

                case 6:
                    imgesp1.Source = img2e;

                    clique1 = 6;
                    correto1 = 0;
                    break;
            }

            controle = 0;
            fim();


        }

        private void btnesp2_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img0 = new BitmapImage(new Uri("/img/nivel1/img0.jpg", UriKind.Relative));
            BitmapImage img1 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
            BitmapImage img3 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
            BitmapImage img4 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
            BitmapImage img1e = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
            BitmapImage img2e = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));

            switch (clique2)
            {
                case 1:
                    imgesp2.Source = img0;

                    BitmapImage img = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
                    imgbtn1.Source = img;

                    btn1.IsEnabled = true;
                    clique2 = 0;
                    break;

                case 2:
                    imgesp2.Source = img0;

                    BitmapImage esp4 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
                    imgbtn4.Source = esp4; 
                    btn4.IsEnabled = true;
                    clique2 = 0;
                    break;

                case 3:
                    imgesp2.Source = img0;

                     BitmapImage esp2 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
                    imgbtn2.Source = esp2;

                    btn2.IsEnabled = true;
                    clique2 = 0;
                    break;

                case 4:
                    imgesp2.Source = img0;
                     BitmapImage esp3 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
                    imgbtn3.Source = esp3;

                    btn3.IsEnabled = true;
                    clique2 = 0;
                    break;

                case 5:
                    imgesp2.Source = img0;
                    BitmapImage esp5 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
                    imgbtn5.Source = esp5;
                    btn5.IsEnabled = true;
                    clique2 = 0;
                    break;

                case 6:
                    imgesp2.Source = img0;
                    BitmapImage esp6 = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));
                    imgbtn6.Source = esp6;
                    btn6.IsEnabled = true;
                    clique2 = 0;
                    break;
            }

            switch (controle)
            {
                case 1:
                    imgesp2.Source = img1;

                    clique2 = 5;
                    correto2 = 0;

                    break;

                case 2:
                    imgesp2.Source = img2;

                    clique2 = 2;
                    correto2 = 1;
                    break;

                case 3:
                    imgesp2.Source = img3;

                    clique2 = 3;
                    correto2 = 0;
                    break;

                case 4:
                    imgesp2.Source = img4;

                    clique2 = 4;
                    correto2 = 0;
                    break;

                case 5:
                    imgesp2.Source = img1e;

                    clique2 = 1;
                    correto2 = 0;
                    break;

                case 6:
                    imgesp2.Source = img2e;

                    clique2 = 6;
                    correto2 = 0;
                    break;
            }

            controle = 0;
            fim();

        }

        private void btnesp3_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img0 = new BitmapImage(new Uri("/img/nivel1/img0.jpg", UriKind.Relative));
            BitmapImage img1 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
            BitmapImage img3 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
            BitmapImage img4 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
            BitmapImage img1e = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
            BitmapImage img2e = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));

            switch (clique3)
            {
                case 1:
                    imgesp3.Source = img0;

                    BitmapImage img = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
                    imgbtn1.Source = img;

                    btn1.IsEnabled = true;
                    clique3 = 0;
                    break;

                case 2:
                    imgesp3.Source = img0;

                    BitmapImage esp4 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
                    imgbtn4.Source = esp4; 
                    btn4.IsEnabled = true;
                    clique3 = 0;
                    break;

                case 3:
                    imgesp3.Source = img0;

                     BitmapImage esp2 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
                    imgbtn2.Source = esp2;

                    btn2.IsEnabled = true;
                    clique3 = 0;
                    break;

                case 4:
                    imgesp3.Source = img0;

                     BitmapImage esp3 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
                    imgbtn3.Source = esp3;
                    btn3.IsEnabled = true;
                    clique3 = 0;
                    break;

                case 5:
                    imgesp3.Source = img0;
                    BitmapImage esp5 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
                    imgbtn5.Source = esp5;
                    btn5.IsEnabled = true;
                    clique3 = 0;
                    break;

                case 6:
                    imgesp3.Source = img0;
                    BitmapImage esp6 = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));
                    imgbtn6.Source = esp6;
                    btn6.IsEnabled = true;
                    clique3 = 0;
                    break;
            }

            switch (controle)
            {
                case 1:
                    imgesp3.Source = img1;

                    clique3 = 5;
                    correto3 = 0;

                    break;

                case 2:
                    imgesp3.Source = img2;

                    clique3 = 2;
                    correto3 = 0;
                    break;

                case 3:
                    imgesp3.Source = img3;

                    clique3 = 3;
                    correto3 = 1;

                    break;

                case 4:
                    imgesp3.Source = img4;

                    clique3 = 4;
                    correto3 = 0;

                    break;

                case 5:
                    imgesp3.Source = img1e;

                    clique3 = 1;
                    correto3 = 0;
                    break;

                case 6:
                    imgesp3.Source = img2e;

                    clique3 = 6;
                    correto3 = 0;
                    break;
            }

            controle = 0;
            fim();
        }

        private void btnesp4_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img0 = new BitmapImage(new Uri("/img/nivel1/img0.jpg", UriKind.Relative));
            BitmapImage img1 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
            BitmapImage img3 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
            BitmapImage img4 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
            BitmapImage img1e = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
            BitmapImage img2e = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));

            switch (clique4)
            {
                case 1:
                    imgesp4.Source = img0;

                    BitmapImage img = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
                    imgbtn1.Source = img;

                    btn1.IsEnabled = true;
                    clique4 = 0;

                    break;

                case 2:
                    imgesp4.Source = img0;
                    BitmapImage esp4 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
                    imgbtn4.Source = esp4; 

                    btn4.IsEnabled = true;
                    clique4 = 0;
                    break;

                case 3:
                    imgesp4.Source = img0;

                     BitmapImage esp2 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
                    imgbtn2.Source = esp2;

                    btn2.IsEnabled = true;
                    clique4 = 0;
                    break;

                case 4:
                    imgesp4.Source = img0;
                     BitmapImage esp3 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
                    imgbtn3.Source = esp3;
                    btn3.IsEnabled = true;
                    clique4 = 0;
                    break;

                case 5:
                    imgesp4.Source = img0;
                    BitmapImage esp5 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
                    imgbtn5.Source = esp5;
                    btn5.IsEnabled = true;
                    clique4 = 0;
                    break;

                case 6:
                    imgesp4.Source = img0;
                    BitmapImage esp6 = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));
                    imgbtn6.Source = esp6;
                    btn6.IsEnabled = true;
                    clique4 = 0;
                    break;
            }

            switch (controle)
            {
                case 1:
                    imgesp4.Source = img1;

                    clique4 = 5;
                    correto4 = 0;

                    break;

                case 2:
                    imgesp4.Source = img2;

                    clique4 = 2;
                    correto4 = 0;
                    break;

                case 3:
                    imgesp4.Source = img3;

                    clique4 = 3;
                    correto4 = 0;
                    break;

                case 4:
                    imgesp4.Source = img4;

                    clique4 = 4;
                    correto4 = 1;
                    break;

                case 5:
                    imgesp4.Source = img1e;

                    clique4 = 1;
                    correto4 = 0;
                    break;

                case 6:
                    imgesp4.Source = img2e;

                    clique4 = 6;
                    correto4 = 0;
                    break;
            }

            controle = 0;
            fim();

        }


        public void fim()
        {
            if (correto1 == 1 && correto2 == 1 && correto3 == 1 && correto4 == 1)
            {
                btnesp1.IsEnabled = false;
                btnesp2.IsEnabled = false;
                btnesp3.IsEnabled = false;
                btnesp4.IsEnabled = false;

                BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel0.jpg", UriKind.Relative));
                imgbtn1.Source = img;
                imgbtn2.Source = img;
                imgbtn3.Source = img;
                imgbtn4.Source = img;
                imgbtn5.Source = img;
                imgbtn6.Source = img;


                btn1.IsEnabled = false;
                btn2.IsEnabled = false;
                btn3.IsEnabled = false;
                btn4.IsEnabled = false;
                btn5.IsEnabled = false;
                btn6.IsEnabled = false;

            }
        }

        public void contador()
        {
            jogada++;
            Contador.Content = jogada;
        }


        int mostrar;
        private void KinectCircleButton_Click(object sender, RoutedEventArgs e)
        {
                    

            mostrar++;

            if (mostrar == 1)
            {
                clicado = 1;

                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;

            }

            if (mostrar % 2 == 0)
            {
                BitmapImage img = new BitmapImage(new Uri("/img/nivel1/nivel1.jpg", UriKind.Relative));
                exemplo.Source = img;

               
                           
               
                if (mostrar == 2)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        contador();
                    }
                }

               

            }

            if (mostrar % 2 != 0)
            {
                BitmapImage img = new BitmapImage(new Uri("/img/nivel1/", UriKind.Relative));
                exemplo.Source = img;
                btnexemplo.Label = "Imagem";

            }
          

        }

        private void KinectCircleButton_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void restart()
        {
                    btnesp1.IsEnabled = true;
                    btnesp2.IsEnabled = true;
                    btnesp3.IsEnabled = true;
                    btnesp4.IsEnabled = true;


                    BitmapImage img1 = new BitmapImage(new Uri("/img/nivel1/img0.jpg", UriKind.Relative));
                    imgesp1.Source = img1;
                    imgesp2.Source = img1;
                    imgesp3.Source = img1;
                    imgesp4.Source = img1;



                    btn1.IsEnabled = true;
                    btn2.IsEnabled = true;
                    btn3.IsEnabled = true;
                    btn4.IsEnabled = true;
                    btn5.IsEnabled = true;
                    btn6.IsEnabled = true;

                    BitmapImage img_0 = new BitmapImage(new Uri("/img/nivel1/img0.jpg", UriKind.Relative));
                    BitmapImage img_1 = new BitmapImage(new Uri("/img/nivel1/img1.jpg", UriKind.Relative));
                    BitmapImage img_2 = new BitmapImage(new Uri("/img/nivel1/img2.jpg", UriKind.Relative));
                    BitmapImage img_3 = new BitmapImage(new Uri("/img/nivel1/img3.jpg", UriKind.Relative));
                    BitmapImage img_4 = new BitmapImage(new Uri("/img/nivel1/img4.jpg", UriKind.Relative));
                    BitmapImage img_1e = new BitmapImage(new Uri("/img/nivel1/img1_e.jpg", UriKind.Relative));
                    BitmapImage img_2e = new BitmapImage(new Uri("/img/nivel1/img2_e.jpg", UriKind.Relative));


                    imgbtn1.Source = img_1e;
                    imgbtn2.Source = img_3;
                    imgbtn3.Source = img_4;
                    imgbtn4.Source = img_2;
                    imgbtn5.Source = img_1;
                    imgbtn6.Source = img_2e;



                    clique1 = 0;
                    clique2 = 0;
                    clique3 = 0;
                    clique4 = 0;

                    correto1 = 0;
                    correto2 = 0;
                    correto3 = 0;
                    correto4 = 0;

                    controle = 0;

                    jogada = -1;

                    contador();

                    btnexemplo.Label = "Iniciar";

                    BitmapImage ex = new BitmapImage(new Uri("/img/nivel1/nivel1.jpg", UriKind.Relative));
                    exemplo.Source =ex;
                    mostrar = 0;

                    btn1.IsEnabled = false;
                    btn2.IsEnabled = false;
                    btn3.IsEnabled = false;
                    btn4.IsEnabled = false;
                    btn5.IsEnabled = false;
                    btn6.IsEnabled = false;







        }

        private void btnrestart_Click(object sender, RoutedEventArgs e)
        {
            restart();
        }
     
       

         
    }
}








