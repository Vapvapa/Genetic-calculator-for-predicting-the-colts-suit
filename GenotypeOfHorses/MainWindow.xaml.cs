using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenotypeOfHorses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] horseSuitGrandfather { get; }
        public string[] horseSuitGrandmother { get; }
        public string[] horseSuitFather { get; }
        public string[] horseSuitMother { get; }
        public string[] horseSuitChild { get; }
        public int[] genotypeFather { get; set; }
        public int[] genotypeMother { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            horseSuitGrandfather = new string[] { "Неизвестно", "Рыжий", "Вороной", "Гнедой", "Буланый", "Соловый", "Изабелловый" };
            horseSuitGrandmother = new string[] { "Неизвестно", "Рыжая", "Вороная", "Гнедая", "Буланая", "Соловая", "Изабелловая" };
            horseSuitFather = new string[] { "Рыжий", "Вороной", "Гнедой", "Буланый", "Соловый", "Изабелловый" };
            horseSuitMother = new string[] { "Рыжая", "Вороная", "Гнедая", "Буланая", "Соловая", "Изабелловая" };
            horseSuitChild = new string[] { "Неизвестно", "Рыжий", "Вороной", "Гнедой", "Буланый", "Соловый", "Изабелловый" };

            genotypeFather = new int[] { 3, 3, 3, 3, 3, 3 };
            genotypeMother = new int[] { 3, 3, 3, 3, 3, 3 };

            DataContext = this;
        }

        void SelectionChangedFather(object sender, SelectionChangedEventArgs args)
        {
            if (comboBoxFather.SelectedIndex == 0) { genotypeFather = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxFather.SelectedIndex == 1) { genotypeFather = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxFather.SelectedIndex == 2) { genotypeFather = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxFather.SelectedIndex == 3) { genotypeFather = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxFather.SelectedIndex == 4) { genotypeFather = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxFather.SelectedIndex == 5) { genotypeFather = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC

            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void SelectionChangedMother(object sender, SelectionChangedEventArgs args)
        {
            if (comboBoxMother.SelectedIndex == 0) { genotypeMother = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxMother.SelectedIndex == 1) { genotypeMother = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxMother.SelectedIndex == 2) { genotypeMother = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxMother.SelectedIndex == 3) { genotypeMother = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxMother.SelectedIndex == 4) { genotypeMother = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxMother.SelectedIndex == 5) { genotypeMother = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC

            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void SelectionChangedGrandfatherFather(object sender, SelectionChangedEventArgs args)
        {
            int[] genotypeGrandfatherFather = new int[] {0, 0, 0, 0, 0, 0};
            if (comboBoxGrandfatherFather.SelectedIndex == 0) { genotypeGrandfatherFather = new int[] { 3, 3, 3, 3, 3, 3 }; }//неизвестная масть, даны значения, не попадающие в if
            else if (comboBoxGrandfatherFather.SelectedIndex == 1) { genotypeGrandfatherFather = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 2) { genotypeGrandfatherFather = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxGrandfatherFather.SelectedIndex == 3) { genotypeGrandfatherFather = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 4) { genotypeGrandfatherFather = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 5) { genotypeGrandfatherFather = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 6) { genotypeGrandfatherFather = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC

            GenotypeFatherRefinement(genotypeGrandfatherFather);
            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void SelectionChangedGrandmotherFather(object sender, SelectionChangedEventArgs args)
        {
            int[] genotypeGrandmotherFather = new int[] { 0, 0, 0, 0, 0, 0 };
            if (comboBoxGrandmotherFather.SelectedIndex == 0) { genotypeGrandmotherFather = new int[] { 3, 3, 3, 3, 3, 3 }; }//неизвестная масть, даны значения, не попадающие в if
            else if (comboBoxGrandmotherFather.SelectedIndex == 1) { genotypeGrandmotherFather = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxGrandmotherFather.SelectedIndex == 2) { genotypeGrandmotherFather = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxGrandmotherFather.SelectedIndex == 3) { genotypeGrandmotherFather = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxGrandmotherFather.SelectedIndex == 4) { genotypeGrandmotherFather = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxGrandmotherFather.SelectedIndex == 5) { genotypeGrandmotherFather = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxGrandmotherFather.SelectedIndex == 6) { genotypeGrandmotherFather = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC

            GenotypeFatherRefinement(genotypeGrandmotherFather);
            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void SelectionChangedGrandfatherMother(object sender, SelectionChangedEventArgs args)
        {
            int[] genotypeGrandfatherMother = new int[] { 0, 0, 0, 0, 0, 0 };
            if (comboBoxGrandfatherFather.SelectedIndex == 0) { genotypeGrandfatherMother = new int[] { 3, 3, 3, 3, 3, 3 }; }//неизвестная масть, даны значения, не попадающие в if
            else if (comboBoxGrandfatherFather.SelectedIndex == 1) { genotypeGrandfatherMother = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 2) { genotypeGrandfatherMother = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxGrandfatherFather.SelectedIndex == 3) { genotypeGrandfatherMother = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 4) { genotypeGrandfatherMother = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 5) { genotypeGrandfatherMother = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxGrandfatherFather.SelectedIndex == 6) { genotypeGrandfatherMother = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC
            
            GenotypeMotherRefinement(genotypeGrandfatherMother);
            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void SelectionChangedGrandmotherMother(object sender, SelectionChangedEventArgs args)
        {
            int[] genotypeGrandmotherMother = new int[] { 0, 0, 0, 0, 0, 0 };
            if (comboBoxGrandmotherMother.SelectedIndex == 0) { genotypeGrandmotherMother = new int[] { 3, 3, 3, 3, 3, 3 }; }//неизвестная масть, даны значения, не попадающие в if
            else if (comboBoxGrandmotherMother.SelectedIndex == 1) { genotypeGrandmotherMother = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 2) { genotypeGrandmotherMother = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxGrandmotherMother.SelectedIndex == 3) { genotypeGrandmotherMother = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 4) { genotypeGrandmotherMother = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 5) { genotypeGrandmotherMother = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 6) { genotypeGrandmotherMother = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC

            GenotypeMotherRefinement(genotypeGrandmotherMother);
            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void SelectionChangedChildFather(object sender, SelectionChangedEventArgs args)
        {
            int[] genotypeChildFather = new int[] { 0, 0, 0, 0, 0, 0 };
            if (comboBoxGrandmotherMother.SelectedIndex == 0) { genotypeChildFather = new int[] { 3, 3, 3, 3, 3, 3 }; }//неизвестная масть, даны значения, не попадающие в if
            else if (comboBoxGrandmotherMother.SelectedIndex == 1) { genotypeChildFather = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 2) { genotypeChildFather = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxGrandmotherMother.SelectedIndex == 3) { genotypeChildFather = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 4) { genotypeChildFather = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 5) { genotypeChildFather = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 6) { genotypeChildFather = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC

            GenotypeFatherRefinement(genotypeChildFather);
            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void SelectionChangedChildMother(object sender, SelectionChangedEventArgs args)
        {
            int[] genotypeChildMother = new int[] { 0, 0, 0, 0, 0, 0 };
            if (comboBoxGrandmotherMother.SelectedIndex == 0) { genotypeChildMother = new int[] { 3, 3, 3, 3, 3, 3 }; }//неизвестная масть, даны значения, не попадающие в if
            else if (comboBoxGrandmotherMother.SelectedIndex == 1) { genotypeChildMother = new int[] { 0, 0, 50, 50, 0, 0 }; }//рыжая масть ee -- cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 2) { genotypeChildMother = new int[] { 100, 50, 0, 0, 50, 0 }; }//вороная масть E- aa c-
            else if (comboBoxGrandmotherMother.SelectedIndex == 3) { genotypeChildMother = new int[] { 100, 50, 100, 50, 0, 0 }; }//гнедая масть E- A- cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 4) { genotypeChildMother = new int[] { 100, 50, 100, 50, 100, 0 }; }//буланая масть E- A- Cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 5) { genotypeChildMother = new int[] { 0, 0, 100, 50, 100, 0 }; }//соловая масть ee -- Cc
            else if (comboBoxGrandmotherMother.SelectedIndex == 6) { genotypeChildMother = new int[] { 50, 50, 50, 50, 100, 100 }; }//изабелловая масть -- -- CC

            GenotypeMotherRefinement(genotypeChildMother);
            CalculateGenotypeChild(genotypeFather, genotypeMother);
        }

        void CalculateGenotypeChild(int[] genotypeFather, int[] genotypeMother)
        {
            //ДЛЯ EE:
            int ED1 = genotypeFather[0];
            int ED2 = genotypeFather[1];
            int EM1 = genotypeMother[0];
            int EM2 = genotypeMother[1];

            int summa = 200;
            int Ed = ED1 + ED2;
            int ed = summa - Ed;
            int Em = EM1 + EM2;
            int em = summa - Em;

            int denominator = summa * 2;
            float EE = (float)(Ed * Em) / denominator;
            float Ee = (float)(Ed * em + ed * Em) / denominator;
            float ee = (float)(em * ed) / denominator;

            ///ДЛЯ AA:
            int AD1 = genotypeFather[2];
            int AD2 = genotypeFather[3];
            int AM1 = genotypeMother[2];
            int AM2 = genotypeMother[3];

            int AD = AD1 + AD2;
            int aD = summa - AD;
            int AM = AM1 + AM2;
            int aM = summa - AM;

            float AA = (float)(AD * AM) / denominator;
            float Aa = (float)(AD * aM + aD * AM) / denominator;
            float aa = (float)(aM * aD) / denominator;

            ///ДЛЯ CC:
            int CD1 = genotypeFather[4];
            int CD2 = genotypeFather[5];
            int CM1 = genotypeMother[4];
            int CM2 = genotypeMother[5];

            int CD = CD1 + CD2;
            int cD = summa - CD;
            int CM = CM1 + CM2;
            int cM = summa - CM;

            float CC = (float)(CD * CM) / denominator;
            float Cc = (float)(CD * cM + cD * CM) / denominator;
            float cc = (float)(cM * cD) / denominator;

            float EEAACC = EE * AA * CC / 10000;
            float EEAACc = EE * AA * Cc / 10000;
            float EEAAcc = EE * AA * cc / 10000;
            float EEAaCC = EE * Aa * CC / 10000;
            float EEAaCc = EE * Aa * Cc / 10000;
            float EEAacc = EE * Aa * cc / 10000;
            float EEaaCC = EE * aa * CC / 10000;
            float EEaaCc = EE * aa * Cc / 10000;
            float EEaacc = EE * aa * cc / 10000;

            float EeAACC = Ee * AA * CC / 10000;
            float EeAACc = Ee * AA * Cc / 10000;
            float EeAAcc = Ee * AA * cc / 10000;
            float EeAaCC = Ee * Aa * CC / 10000;
            float EeAaCc = Ee * Aa * Cc / 10000;
            float EeAacc = Ee * Aa * cc / 10000;
            float EeaaCC = Ee * aa * CC / 10000;
            float EeaaCc = Ee * aa * Cc / 10000;
            float Eeaacc = Ee * aa * cc / 10000;

            float eeAACC = ee * AA * CC / 10000;
            float eeAACc = ee * AA * Cc / 10000;
            float eeAAcc = ee * AA * cc / 10000;
            float eeAaCC = ee * Aa * CC / 10000;
            float eeAaCc = ee * Aa * Cc / 10000;
            float eeAacc = ee * Aa * cc / 10000;
            float eeaaCC = ee * aa * CC / 10000;
            float eeaaCc = ee * aa * Cc / 10000;
            float eeaacc = ee * aa * cc / 10000;

            textBoxRed.Text = "Рыжий: " + Math.Round(eeAAcc + eeAacc + eeaacc, 2) + "%";
            textBoxBlack.Text = "Вороной: " + Math.Round(EEaaCc + EEaacc + EeaaCc + Eeaacc, 2) + "%";
            textBoxChestnut.Text = "Гнедой: " + Math.Round(EEAAcc + EEAacc + EeAAcc + EeAacc, 2) + "%";
            textBoxBulan.Text = "Буланый: " + Math.Round(EEAACc + EEAaCc + EeAACc + EeAaCc, 2) + "%";
            textBoxNightingale.Text = "Соловый: " + Math.Round(eeAACc + eeAaCc + eeaaCc, 2) + "%";
            textBoxIsabella.Text = "Изабелловый: " + Math.Round(EEAACC + EEAaCC + EEaaCC + EeAACC +
            EeAaCC + EeaaCC + eeAACC + eeAaCC + eeaaCC, 2) + "%";
        }

        void GenotypeFatherRefinement(int[] genotypeFathersRelative)
        {
            for (int i = 0; i < 6; i += 2)
            {
                if (genotypeFathersRelative[i] == 0 && genotypeFathersRelative[i + 1] == 0)
                {
                    if (genotypeFather[i] == 100 && genotypeFather[i + 1] == 100
                            || genotypeFather[i] == 100 && genotypeFather[i + 1] == 50)
                    {
                        genotypeFather[i] = 50;
                        genotypeFather[i + 1] = 50;
                    }
                    if (genotypeFather[i] == 100 && genotypeFather[i + 1] == 50
                        || genotypeFather[i] == 50 && genotypeFather[i + 1] == 0)
                    {
                        genotypeFather[i] = 50;
                        genotypeFather[i + 1] = 0;
                    }
                    if (genotypeFather[i] == 0 && genotypeFather[i + 1] == 0)
                    {
                        genotypeFather[i] = 0;
                        genotypeFather[i + 1] = 0;
                    }
                }
            }
        }

        void GenotypeMotherRefinement(int[] genotypeMothersRelative)
        {
            for (int i = 0; i < 6; i += 2)
            {
                if (genotypeMothersRelative[i] == 0 && genotypeMothersRelative[i + 1] == 0)
                {
                    if (genotypeMother[i] == 100 && genotypeMother[i + 1] == 100
                            || genotypeMother[i] == 100 && genotypeMother[i + 1] == 50)
                    {
                        genotypeMother[i] = 50;
                        genotypeMother[i + 1] = 50;
                    }
                    if (genotypeMother[i] == 100 && genotypeMother[i + 1] == 50
                        || genotypeMother[i] == 50 && genotypeMother[i + 1] == 0)
                    {
                        genotypeMother[i] = 50;
                        genotypeMother[i + 1] = 0;
                    }
                    if (genotypeMother[i] == 0 && genotypeMother[i + 1] == 0)
                    {
                        genotypeMother[i] = 0;
                        genotypeMother[i + 1] = 0;
                    }
                }
            }
        }
    }
}
