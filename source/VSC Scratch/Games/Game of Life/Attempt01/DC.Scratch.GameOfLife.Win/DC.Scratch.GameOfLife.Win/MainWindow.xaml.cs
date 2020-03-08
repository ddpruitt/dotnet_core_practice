using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DC.Scratch.GameOfLife.Win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Core.Grid GolGrid { get; set; }
        public Timer Timer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //InitilzeGameOfLife(250,250);
            InitilzeGameOfLife(100, 100);
            //InitilzeGameOfLife(1000,1000);

            Timer = new Timer(100);
            Timer.Elapsed += Timer_Elapsed;
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GolGrid.AdvanceToNextGeneration();
        }

        private void InitilzeGameOfLife(int rows, int columns)
        {
            for (var i = 0; i < rows; i++)
                GameOfLifeGrid.RowDefinitions.Add(new RowDefinition());

            for (var i = 0; i < columns; i++)
                GameOfLifeGrid.ColumnDefinitions.Add(new ColumnDefinition());

            GolGrid = Core.Grid.Initialize(rows, columns);
            

            for (int i = 0; i < rows; i++)
            {
                
                for (int j = 0; j < columns; j++)
                {
                    GolGrid.GetCell(i, j).IsAlive = i*j%3==0;
                    
                    var ellipse = new Ellipse
                        {
                            DataContext = GolGrid.GetCell(i, j),
                            Style = Resources["lifeStyle"] as Style
                        };
                    Grid.SetColumn(ellipse, j);
                    Grid.SetRow(ellipse, i);
                    GameOfLifeGrid.Children.Add(ellipse);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Timer.Start();
        }

        private void StopButtonClick(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }
    }
}
