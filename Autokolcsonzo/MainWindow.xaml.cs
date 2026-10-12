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

namespace Autokolcsonzo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nev = txtNev.Text;

            if (nev == "")
            {
                MessageBox.Show("A név nem lehet üres!");
                return;
            }

            if (nev.Length < 3)
            {
                MessageBox.Show("A névnek legalább 3 karakter hosszúnak kell lennie!");
                return;
            }

            int kor;

            try
            {
                kor = int.Parse(txtKor.Text);
            }
            catch
            {
                MessageBox.Show("Az életkor mezőnek számnak kell lennie!");
                return;
            }

            if (kor < 18)
            {
                MessageBox.Show("A bérléshez legalább 18 évesnek kell lennie!");
                return;
            }

            if (kor > 100)
            {
                MessageBox.Show("Maximum 100 éves lehet a bérlő!");
                return;
            }

            string jogositvanySzam = txtJogositvanySzam.Text;

            if (jogositvanySzam == "")
            {
                MessageBox.Show("A jogosítvány szám mező nem lehet üres!");
                return;
            }

            if (jogositvanySzam.Length < 6)
            {
                MessageBox.Show("A jogosítvány számnak legalább 6 karakternek kell lennie!");
                return;
            }

            if (cmbAutok.SelectedIndex == -1)
            {
                MessageBox.Show("Kérlek válassz autót!");
                return;
            }

            string auto = "";
            int autoAr = 0;

            if (cmbAutok.SelectedIndex == 0)
            {
                auto = "Suzuki Swift";
                autoAr = 12000;
            }
            else if (cmbAutok.SelectedIndex == 1)
            {
                auto = "Toyota Corolla";
                autoAr = 18000;
            }
            else if (cmbAutok.SelectedIndex == 2)
            {
                auto = "BMW 3";
                autoAr = 30000;
            }
            else if (cmbAutok.SelectedIndex == 3)
            {
                auto = "Tesla Model 3";
                autoAr = 35000;
            }

            int BerlesiIdo;

            try
            {
                BerlesiIdo = int.Parse(txtBerlesIdotartama.Text);

            }
            catch
            {
                MessageBox.Show("A bérlési idő mezőnek számnak kell lennie!");
                return;
            }

            if (!int.TryParse(txtBerlesIdotartama.Text, out BerlesiIdo))
            {
                MessageBox.Show("A bérlési idő csak egész szám lehet!");
                return;
            }

            if (BerlesiIdo < 1)
            {
                MessageBox.Show("A bérlési időnek legalább 1 napnak kell lennie!");
                return;
            }

            if (BerlesiIdo > 30)
            {
                MessageBox.Show("A bérlési idő maximum 30 nap lehet!");
                return;
            }

            string biztositas = "";
            int biztositasAr = 0;

            if (rbIngyen.IsChecked == true)
            {
                biztositas = "Ingyenes biztosítás";
                biztositasAr = 0;
            }
            else if (rbExtra.IsChecked == true)
            {
                biztositas = "Extra biztosítás";
                biztositasAr = 3000;
            }
            else if (rbTeljes.IsChecked == true)
            {
                biztositas = "Teljes körű biztosítás";
                biztositasAr = 6000;
            }
            else
            {
                MessageBox.Show("Kérlek válassz biztosítási opciót!");
                return;
            }

            string extrak = "";
            int extrakAr = 0;

            if (chkGPS.IsChecked == true)
            {
                extrak += "GPS, ";
                extrakAr += 1000;
            }

            if (chkGyerekUles.IsChecked == true)
            {
                extrak += "Gyerekülés, ";
                extrakAr += 1500;
            }
            if (chkExtraSofor.IsChecked == true)
            {
                extrak += "Extra sofőr, ";
                extrakAr += 2500;
            }
            if (chkAutopalyaMatrica.IsChecked == true)
            {
                extrak += "Autópálya matrica, ";
                extrakAr += 5000;
            }
            if (extrak == "")
            {
                extrak = "Nincs";
            }
            else
            {
                extrak = extrak.Substring(0, extrak.Length - 2);
            }
            
            string fizetesiMod = "";

            if (rbKeszpenz.IsChecked == true)
            {
                fizetesiMod = "Készpénz";
            }
            else if (rbBankkartya.IsChecked == true)
            {
                fizetesiMod = "Bankkártya";
            }
            else
            {
                MessageBox.Show("Kérlek válassz fizetési módot!");
                return;
            }
            
            string feltetek = "";

            if (chkFeltetelek.IsChecked == true)
            {
                feltetek = "Elfogadva";
            }
            else
            {
                MessageBox.Show("Kérlek fogadd el a feltételeket!");
                return;
            }
            int vegosszeg = autoAr* BerlesiIdo + biztositasAr * BerlesiIdo + extrakAr * BerlesiIdo;

            MessageBox.Show($"Sikeres bérlés!\n Ügyfél: {nev}\n Autó: {auto}\nBérlési idő: {BerlesiIdo} nap\nBiztosítás: {biztositas}\nExtrák: {extrak}\nFizetési mód: {fizetesiMod}\nVégösszeg: {vegosszeg} Ft");
        }
    }
}