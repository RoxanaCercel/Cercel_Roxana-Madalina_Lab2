using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Cercel_Roxana_Madalina_Lab2
{
    class DoughnutMachine
    {
        //4
        private DoughnutType mFlavor;
        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        //5 
        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;
        //6
        DispatcherTimer doughnutTimer;
        //7
        private void InitializeComponent()
        {
            this.doughnutTimer = new DispatcherTimer();
            this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }
        //8
        public DoughnutMachine()
        {
            InitializeComponent();
        }
        //9
        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            DoughnutComplete();
        }
        //10
        public bool Enabled
        {
            set
            {
                doughnutTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                doughnutTimer.Interval = new TimeSpan(0, 0, value);
            }
        }
        //11
        public void MakeDoughnuts(DoughnutType dFlavor)
        {

            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }

    }
    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }
    //3
    class Doughnut
    {
        private DoughnutType mFlavor;

        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }

        }
        public Doughnut(DoughnutType aFlavor) // constructor
        {
            mTimeOfCreation = DateTime.Now;
            mFlavor = aFlavor;
        }
    }

}
