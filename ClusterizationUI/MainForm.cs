﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterizationUI
{
    public partial class MainForm : Form
    {
        Cluster whole_set;

        public MainForm()
        {
            InitializeComponent();

            whole_set = Cluster.Load("out.txt");
        }
    }
}