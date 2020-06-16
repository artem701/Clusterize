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
        
        /*
        // Цвета назначаемые отображаемым кластерам
        Color[] cluster_colors = { Color.Red, Color.Green, Color.Yellow, Color.Blue,
                                   Color.Violet, Color.Orange, Color.Brown, Color.DarkSeaGreen };
        */

        // Фактическая высота и ширина поля отображения
        int map_border;

        // Значения каких координат проецируются на оси x и y
        int x_axis, y_axis;

        // Стек с состояниями камеры
        List<Camera> view_history;

        // Радиус отображаемых точек
        float thickness = 3;

        // Задает возможность отрисовки
        bool allow_draw;

        public MainForm()
        {
            InitializeComponent();

            map_border = mapBox.Width;
            allow_draw = false;
        }

        private void snapshot(List<Point> points, Camera cam, ref Graphics g, Color color)
        {
            foreach(Point p in points)
            {
                double x = p[x_axis], y = p[y_axis];
                // Проеряем, попадает ли точка в рассматриваемую область
                if ((x < cam.left)   || (x > (cam.left + cam.size)) ||
                    (y < cam.bottom) || (y > (cam.bottom + cam.size)))
                    continue;

                int rx, ry;
                rx = (int)(map_border * (x - cam.left) / cam.size);
                ry = map_border - (int)(map_border * (y - cam.bottom) / cam.size);
                g.FillEllipse(new SolidBrush(color), rx - thickness, ry - thickness, 2 * thickness, 2 * thickness);
            }
        }

        private Color get_color(int i)
        {
            ++i;

            const int br = 200;

            int r = (int)(Math.Abs(Math.Sin(83 * i * i)) * 255);
            int x = br * br - r * r;
            int g = (int)(Math.Abs(Math.Sin(53 * i)) * 255) % ((255*br - 77*r)/150);
            int b = (255 * br - 77 * r - 150 * g) / 28 % 255;

            Color color = Color.FromArgb(r, g, b);
            return color;
        }

        private void drawMap()
        {
            if (!allow_draw)
                return;

            Bitmap bmp = new Bitmap(map_border, map_border);
            mapBox.Image = (Image)bmp;
            Graphics gr = Graphics.FromImage(mapBox.Image);
            gr.FillRectangle(new SolidBrush(Color.Black), 0, 0, map_border, map_border);
            for (int i = 0; i < vizualizingClusters.Count; ++i)
            {
                snapshot(vizualizingClusters[i].toList(), view_history[0], ref gr, get_color(i));
            }
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
                if (System.IO.File.Exists(fd.FileName + ".out.txt"))
                    filename = fd.FileName + ".out.txt";
                else
                {
                    try
                    {
                        Process proc = new Process();
                        proc.StartInfo.FileName = "Clusterize.exe";
                        proc.StartInfo.Arguments = "\"" + fd.FileName + "\" \"" + fd.FileName + ".out.txt\"";
                        proc.Start();
                        proc.WaitForExit();
                    }catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка запуска вычислительной подпрограммы: " + ex.Message);
                        return;
                    }
                    filename = fd.FileName + ".out.txt";
                }
            }

            try
            {
                head_cluster = Cluster.Load(filename);
            }catch(Exception ex)
            {
                MessageBox.Show("Ошибка чтения из файла: " + ex.Message);
                return;
            }

            // На начальном этапе отображаем только один кластер, всю выборку
            vizualizingClusters = new List<Cluster>() { head_cluster };

            // Заполняем переключатели проекций
            xAxisBox.Items.Clear();
            yAxisBox.Items.Clear();
            int i = head_cluster.dimensions();
            int dim = i;
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
            clustNumInc.Enabled = true;
            clustNumDec.Enabled = true;
            if (dim > 1)
            {
                xAxisBox.Enabled = true;
                yAxisBox.Enabled = true;
            }
            
            resetCamera();

            allow_draw = true;
            drawMap();
        }

        // Находит наикрупнейший кластер из рассматриваемых
        // и разделяет его на два. Повторяет процесс при необходимости
        private void divideClusters(int times = 1)
        {
            if (times < 1)
                return;

            // Поиск крупнейшего кластера из текущих представленных (его нужно разделить на 2)
            // Пропускаем листья
            int i = 0;
            while (i < vizualizingClusters.Count && vizualizingClusters[i] is Leave)
            {
                ++i;
            }

            // Если все текущие кластеры — листья и немогут быть разделены
            if (i == vizualizingClusters.Count)
                return;

            int max = i, maxcount = vizualizingClusters[i].Count;
            
            for (i = i + 1; i < vizualizingClusters.Count; ++i)
            {
                if (vizualizingClusters[i] is Leave)
                    continue;

                int count = vizualizingClusters[i].Count;
                if (count > maxcount)
                {
                    maxcount = count;
                    max = i;
                }
            }

            // Поскольку мы совершили все проверки типов,
            // мы уверены, что найденный кластер является веткой
            Branch dividing = (Branch)vizualizingClusters[max];
            int left = dividing.left.Count, right = maxcount - left;
            // Большую ветвь оставим на месте родителя,
            // меньшую вставим в конец списка
            vizualizingClusters[max] = (left > right) ? dividing.left : dividing.right;
            vizualizingClusters.Add((left > right) ? dividing.right  : dividing.left);

            divideClusters(times - 1);
        }

        private void xAxisBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            x_axis = int.Parse(xAxisBox.Text) - 1;
            resetCamera();
            drawMap();
        }

        private void yAxisBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            y_axis = int.Parse(yAxisBox.Text) - 1;
            resetCamera();
            drawMap();
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

            drawMap();
        }

        private void resetScaleButton_Click(object sender, EventArgs e)
        {
            resetCamera();
            drawMap();
        }

        private void mapBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!allow_draw)
                return;

            const double k = 2, softener = 0.9;

            // Отдаление
            if (e.Button == MouseButtons.Right)
            {

                if (view_history.Count > 1)
                {
                    //thickness = (int)(thickness / (k * softener));

                    view_history.RemoveAt(0);
                    if (view_history.Count == 1)
                        resetScaleButton.Enabled = false;
                }
            }
            // Приближение
            else if (e.Button == MouseButtons.Left)
            {
                resetScaleButton.Enabled = true;

                //thickness = (int)(thickness * (k*softener));

                Camera old = view_history[0];
                Camera cam = new Camera(old.size / k, 
                    e.X*old.size/map_border + old.left   - old.size / (2*k), 
                    (map_border - e.Y)*old.size/map_border + old.bottom - old.size / (2*k));
                view_history.Insert(0, cam);
            }

            drawMap();
        }

        private int get_clust_num()
        {
            int num;
            if (!int.TryParse(clustersNumBox.Text, out num))
            {
                num = 1;
            }
            num = Math.Max(num, 1);
            return num;
        }

        private void clustersNumBox_TextChanged(object sender, EventArgs e)
        {
            int old_num = vizualizingClusters.Count;
            int new_num = get_clust_num();

            // Доразбиваем имеющиеся кластеры
            if (new_num > old_num)
                divideClusters(new_num - old_num);
            // Или возвращаемся к исходному состоянию и разбиваем кластеры заново
            else
            {
                vizualizingClusters = new List<Cluster>() { head_cluster };
                divideClusters(new_num - 1);
            }

            drawMap();
        }

        private void clustNumInc_Click(object sender, EventArgs e)
        {
            clustersNumBox.Text = (get_clust_num() + 1).ToString();
        }

        private void clustNumDec_Click(object sender, EventArgs e)
        {
            int num = get_clust_num();
            --num;
            num = Math.Max(num, 1);
            clustersNumBox.Text = num.ToString();
        }

        // recalculate определяет, нужно ли рассчитывать исходное состояние камеры
        // или достаточно очистить стек масштабирования
        private void resetCamera(bool recalculate = true)
        {
            resetScaleButton.Enabled = false;

            // Если пересчет не требуется
            if (!recalculate)
            {
                while (view_history.Count != 1)
                    view_history.RemoveAt(0);
                return;
            }

            // Иначе исходное положение рассчитывается с нуля
            // Найдём разброс точек по проекции на XOY
            List<Point> all_points = head_cluster.toList();
            Point p = all_points[0];
            double min_x = p[x_axis], max_x = p[x_axis],
                   min_y = p[y_axis], max_y = p[y_axis];

            foreach (Point point in all_points)
            {
                double x = point[x_axis], y = point[y_axis];
                if (x < min_x)
                    min_x = x;
                else if (x > max_x)
                    max_x = x;

                if (y < min_y)
                    min_y = y;
                else if (y > max_y)
                    max_y = y;
            }

            // Разброс
            double dif_x = max_x - min_x, dif_y = max_y - min_y;
            double dif = Math.Max(dif_x, dif_y);
            // Чуть увеличим масштаб, чтобы все точки было хорошо видно
            dif += dif * 0.1;

            view_history = new List<Camera>();
            view_history.Add(new Camera(dif, min_x - (dif - dif_x)/2, min_y - (dif - dif_y) / 2));
        }
    }
}
