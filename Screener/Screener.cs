using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screener
{
    public partial class Screener : Form
    {
        public Screener ()
        {
            InitializeComponent();
            TopMost = true;
        }
        /// <summary>
        /// On First Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load (object sender , EventArgs e)
        {
            Refill();
        }
        private void timer_Tick (object sender , EventArgs e)
        {
            Refill();
        }
        /// <summary>
        /// Refilling Left Table
        /// </summary>
        private async void Refill ()
        {

            var suitableTickerPriceQuantities = await Calculatin.GetListOfSuitableCoins(false);
            List<Task> tasks = new List<Task>();
            mainPanel.Controls.Clear();
            for(int i = 0; i < suitableTickerPriceQuantities.Count; i++)
            {
                tasks.Add(RefillAsync(i,suitableTickerPriceQuantities));
            }
            await Task.WhenAll(tasks);
        }
        /// <summary>
        /// To refill async
        /// </summary>
        /// <param name="i"></param>
        /// <param name="suitableTickerPriceQuantities"></param>
        /// <returns></returns>
        private async Task RefillAsync (int i,List<TickerPriceQuantity> suitableTickerPriceQuantities)
        {
            double a = double.Parse(suitableTickerPriceQuantities[i].price , System.Globalization.CultureInfo.InvariantCulture);
            double b = await Calculatin.GetPrice(suitableTickerPriceQuantities[i].ticker , false);
            if(a > b)
            {
                
                var tmpLable = new LabelPlusTPQ(suitableTickerPriceQuantities[i])
                {
                    Text = (suitableTickerPriceQuantities[i].Cancat() + " Percent: " + Math.Round((a / b * 100 - 100) , 2).ToString() + "%") ,
                    BackColor = Color.Red ,
                    ForeColor = Color.White ,
                    AutoSize = true ,
                    Font = new Font(Font.FontFamily , 8 , FontStyle.Bold)
                };
                tmpLable.Click += TmpLable_Click;
                mainPanel.Controls.Add(tmpLable);
            }
            else
            {
                var tmpLable = new LabelPlusTPQ(suitableTickerPriceQuantities[i])
                {
                    Text = (suitableTickerPriceQuantities[i].Cancat() + " Persent: " + "-" + Math.Round((b / a * 100 - 100) , 2).ToString() + "%") ,
                    BackColor = Color.Green ,
                    ForeColor = Color.White ,
                    AutoSize = true ,
                    Font = new Font(Font.FontFamily , 8 , FontStyle.Bold)
                };
                tmpLable.Click += TmpLable_Click;
                mainPanel.Controls.Add(tmpLable);
            }
        }
        private void TmpLable_Click (object sender , EventArgs e)
        {
            LabelPlusTPQ labelPlusTPQ = new LabelPlusTPQ(((LabelPlusTPQ)sender).TickerPriceQuantity)
            {
                Text = ((LabelPlusTPQ)sender).Text ,
                BackColor = ((LabelPlusTPQ)sender).BackColor ,
                ForeColor = ((LabelPlusTPQ)sender).ForeColor ,
                AutoSize = ((LabelPlusTPQ)sender).AutoSize,
                Font = ((LabelPlusTPQ)sender).Font
            };
            labelPlusTPQ.Click += SecondPanelLabel_Click;
            secondPanel.Controls.Add(labelPlusTPQ);
            
            ((LabelPlusTPQ)secondPanel.Controls[secondPanel.Controls.Count - 1]).Timer.Enabled = true;
            ((LabelPlusTPQ)secondPanel.Controls[secondPanel.Controls.Count - 1]).Timer.Id = (secondPanel.Controls.Count - 1);
            ((LabelPlusTPQ)secondPanel.Controls[secondPanel.Controls.Count - 1]).Timer.Tick += TmpTimer_Tick;
        }

        private void SecondPanelLabel_Click (object sender , EventArgs e)
        {
            for(int i = ((LabelPlusTPQ)sender).Timer.Id+1; i < secondPanel.Controls.Count; i++)
                ((LabelPlusTPQ)secondPanel.Controls[i]).Timer.Id--;
            ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ)sender).Timer.Id]).Timer.Stop();
            ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ)sender).Timer.Id]).Timer.Dispose();
            secondPanel.Controls.Remove((LabelPlusTPQ)sender);
        }

        private async void TmpTimer_Tick (object sender , EventArgs e)
        {
            ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).Timer.Time += 5;

            ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.quantity = await Calculatin.GetQuantityFromPrice(
                ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.ticker ,
                ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.price , false);
            if(!((LabelPlusTPQ.TimerPlusTPQ)sender).Enabled)
                return;
            double a = double.Parse(((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.price , System.Globalization.CultureInfo.InvariantCulture);
            double b = await Calculatin.GetPrice(((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.ticker , false);
            if(!((LabelPlusTPQ.TimerPlusTPQ)sender).Enabled)
                return;
            if(((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.quantity!=null)
            {
                if(a > b)
                {
                    ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).Text =
                    (((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.Cancat()
                    +$" Time:{Math.Round((float)((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).Timer.Time / 60 , 2)}"
                    + " Percent: " + Math.Round((a / b * 100 - 100) , 2).ToString() + "%");
                }
                else
                {
                    ((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).Text =
                    (((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).TickerPriceQuantity.Cancat()
                    + $" Time:{Math.Round((float)((LabelPlusTPQ)secondPanel.Controls[((LabelPlusTPQ.TimerPlusTPQ)sender).Id]).Timer.Time / 60,2)}"
                    + " Persent: " + "-" + Math.Round((b / a * 100 - 100) , 2).ToString() + "%");
                }
            }
        }

        private void clearSecondPanelButton_Click (object sender , EventArgs e)
        {
            
            for(int i = 0; i < secondPanel.Controls.Count; i++)
            {
                ((LabelPlusTPQ)secondPanel.Controls[i]).Timer.Stop();
                ((LabelPlusTPQ)secondPanel.Controls[i]).Timer.Dispose();
            }
            secondPanel.Controls.Clear();
            
        }
        /// <summary>
        /// Label with Ticker Price Quantity
        /// </summary>
        class LabelPlusTPQ : Label
        {
            public LabelPlusTPQ (TickerPriceQuantity tickerPriceQuantity) : base()
            {
                TickerPriceQuantity = tickerPriceQuantity;
                Timer = new TimerPlusTPQ(tickerPriceQuantity) { Enabled = false , Interval = 5000 };
            }
            public TimerPlusTPQ Timer;
            public TickerPriceQuantity TickerPriceQuantity { get; set; }
            public class TimerPlusTPQ:Timer
            {
                public TimerPlusTPQ (TickerPriceQuantity tickerPriceQuantity) :base()
                {
                    TickerPriceQuantity = tickerPriceQuantity;
                }
                public TickerPriceQuantity TickerPriceQuantity { get; set; }
                public int Id { get; set; }
                public uint Time { get; set; } = 0;
            }
        }
        /// <summary>
        /// Set Price to Comparation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged (object sender , EventArgs e)
        {
            double priceToComparation;
            if(double.TryParse(textBox1.Text,out priceToComparation))
                Calculatin.PriceToComparation = priceToComparation;
        }
    }
}
