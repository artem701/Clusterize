using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace ClusterizationUI
{
    public partial class MainForm : Form
    {
        // Основной кластер, содержащий всю выборку целиком
        Cluster head_cluster;

        // Разбиение основного кластера на непересекающиеся кластеры,
        // которые в данный момент отображаются на форме
        List<Cluster> vizualizingClusters;
        
        // Цвета назначаемые отображаемым кластерам
        Color[] cluster_colors = { Color.Red, Color.Green, Color.Yellow, Color.Blue,
                                   Color.Violet, Color.Orange, Color.Brown, Color.DarkSeaGreen };

        // Фактическая высота и ширина поля отображения
        int map_border;

        // Значения каких координат проецируются на оси x и y
        int x_axis, y_axis;

        public MainForm()
        {
            InitializeComponent();

            map_border = mapBox.Width;
        }

        private void drawMap()
        {

            // САМОЕ ГЛАВНОЕ!
        }

        // Событие по нажатию кнопки "Открыть..."
        // Загружает данные о кластеризации или применяет вычислительную субпрограмму
        // и загружает результат ее работы.
        // Настраивает исходное состояние интерфейса
        private void startButton_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();

            fd.Title = "Выберите файл с входными или выходными данными кластеризации";
            fd.CheckFileExists = true;
            if (fd.ShowDialog() == DialogResult.Cancel)
                return;

            string filename;

            if (fd.FileName.EndsWith("out.txt"))
                filename = fd.FileName;
            else
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "Clusterize.exe";
                proc.StartInfo.Arguments = fd.FileName + " " + fd.FileName + ".out.txt";
                proc.Start();
                proc.WaitForExit();

                filename = fd.FileName + ".out.txt";
            }

            try
            {
                head_cluster = Cluster.Load(fd.FileName);
            }catch(Exception ex)
            {
                MessageBox.Show("Ошибка чтения из файла: " + ex.Message);
                return;
            }

            // На начальном этапе отображаем только один кластер, всю выборку
            vizualizingClusters = new List<Cluster>() { head_cluster };

            // Вычисляем максимальное количество отображаемых кластеров,
            // добавляем соответствующие числа в ComboBox
            clustersNumBox.Items.Clear();
            int i = Math.Min(cluster_colors.Length, head_cluster.Count);
            for (; i > 0; --i)
                clustersNumBox.Items.Add(i);

            // Заполняем переключатели проекций
            xAxisBox.Items.Clear();
            yAxisBox.Items.Clear();
            int dim = i = head_cluster.dimensions();
            for (; i > 0; --i)
            {
                xAxisBox.Items.Add(i);
                yAxisBox.Items.Add(i);
            }

            // Расположение по умолчанию
            clustersNumBox.Text = "1";
            xAxisBox.Text = "1";
            yAxisBox.Text = (dim > 1) ? "2" : "1";

            // Включаем элементы управления
            clustersNumBox.Enabled = true;
            if (dim > 1)
            {
                xAxisBox.Enabled = true;
                yAxisBox.Enabled = true;
            }
        }

        // Находит наикрупнейший кластер из рассматриваемых
        // и разделяет его на два. Повторяет процесс при необходимости
        private void divideClusters(int times = 1)
        {
            if (times < 0)
                return;

            // Поиск крупнейшего
            int max = 0, maxcount = vizualizingClusters[0].Count;
            int count = maxcount;
            for (int i = 1; i < vizualizingClusters.Count; ++i)
            {
                count = vizualizingClusters[i].Count;
                if (count > maxcount)
                {
                    maxcount = count;
                    max = i;
                }
            }

            // Поскольку мы контролируем введенное количество кластеров на уровне UI,
            // мы уверены, что найденный кластер является веткой
            Branch dividing = (Branch)vizualizingClusters[max];
            int left = dividing.left.Count, right = count - left;
            // Большую ветвь оставим на месте родителя,
            // меньшую вставим в конец списка
            vizualizingClusters[max] = (left > right) ? dividing.left : dividing.right;
            vizualizingClusters.Add((right < left) ? dividing.right : dividing.left);

            divideClusters(times - 1);
        }

        private void xAxisBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            x_axis = int.Parse(xAxisBox.Text);
        }

        private void yAxisBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            y_axis = int.Parse(yAxisBox.Text);
        }

        // Изменено кол-во отображаемых кластеров
        private void clustersNumBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int old_num = vizualizingClusters.Count;
            int new_num = int.Parse(clustersNumBox.Text);

            // Доразбиваем имеющиеся кластеры
            if (new_num > old_num)
                divideClusters(new_num - old_num);
            // Или возвращаемся к исходному состоянию и разбиваем кластеры заново
            else
            {
                vizualizingClusters = new List<Cluster>() { head_cluster };
                divideClusters(new_num - 1);
            }
        }
    }
}
