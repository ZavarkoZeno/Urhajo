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

namespace Urhajo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<UrhajoAdat> urhajok = new List<UrhajoAdat>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void betoltes(object sender, RoutedEventArgs e)
        {
            urhajok.Clear();

            urhajok.Add(new UrhajoAdat("Falcon-9", 7, 550000, 87, "SpaceX", "Sikeres", 2020));
            urhajok.Add(new UrhajoAdat("Orion-X1", 4, 820000, 73, "NASA", "Folyamatban", 2023));
            urhajok.Add(new UrhajoAdat("StarRider", 12, 910000, 66, "Boeing", "Sikeres", 2019));
            urhajok.Add(new UrhajoAdat("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018));
            urhajok.Add(new UrhajoAdat("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022));
            urhajok.Add(new UrhajoAdat("Nova-Prime", 10, 760000, 80, "Roscosmos", "Sikeres", 2017));
            urhajok.Add(new UrhajoAdat("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024));
            urhajok.Add(new UrhajoAdat("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021));
            urhajok.Add(new UrhajoAdat("CosmoJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016));
            urhajok.Add(new UrhajoAdat("Nebula-FX", 11, 870000, 60, "ESA", "Sikeres", 2020));

            dgUrhajok.ItemsSource = null;
            dgUrhajok.ItemsSource = urhajok;
        }

        private void mennyiUrhajo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Űrhajók száma: " + urhajok.Count);
        }

        private void legnagyobbHatotav(object sender, RoutedEventArgs e)
        {
            UrhajoAdat legnagyobb = urhajok[0];

            foreach (UrhajoAdat u in urhajok)
            {
                if (u.MaxHatotav > legnagyobb.MaxHatotav)
                {
                    legnagyobb = u;
                }
            }

            MessageBox.Show("A legnagyobb hatótávú űrhajó: "
                + legnagyobb.Nev + " Hatótáv: "
                + legnagyobb.MaxHatotav);
        }

        private void sikeresKuldetes(object sender, RoutedEventArgs e)
        {
            dgUrhajok.ItemsSource = null;
            dgUrhajok.ItemsSource = urhajok.Where(u =>
                u.KuldetesStatusz == "Sikeres").ToList();
        }

        private void atlagLegenyseg(object sender, RoutedEventArgs e)
        {
            double osszeg = 0;

            foreach (UrhajoAdat u in urhajok)
            {
                osszeg += u.Legenyseg;
            }

            double atlag = osszeg / urhajok.Count;

            MessageBox.Show("Átlagos legénységszám: "
                + Math.Round(atlag, 2));
        }

        private void gyartokCsoport(object sender, RoutedEventArgs e)
        {
            var csoportok = urhajok.GroupBy(u => u.Gyarto);

            string eredmeny = "";

            foreach (var csoport in csoportok)
            {
                eredmeny += csoport.Key + ": "
                    + csoport.Count() + " db ";
            }

            MessageBox.Show(eredmeny, "Gyártók szerinti csoportosítás");
        }

        private void kereses(object sender, RoutedEventArgs e)
        {
            string keresettNev = txtKereses.Text;

            var talalatok = urhajok.Where(u =>
                u.Nev.Contains(keresettNev,
                StringComparison.OrdinalIgnoreCase)).ToList();

            dgUrhajok.ItemsSource = null;
            dgUrhajok.ItemsSource = talalatok;

            if (talalatok.Count == 0)
            {
                txtEredmeny.Text = "Nincs találat!";
            }
            else
            {
                txtEredmeny.Text = "Találatok száma: "
                    + talalatok.Count;
            }
        }
    }
}