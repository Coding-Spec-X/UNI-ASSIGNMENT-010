using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Transaction_Processing
{
    public partial class Form1 : Form
    {
        string weaponName = "";
        string weaponType = "";
        int weaponDamage = 0;
        double weaponSpeed = 0.0;
        int weaponCount;
        int weaponCount1;
        int weaponCount2;
        double DPS;

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Calculates the damage per second of a weapon.
        /// </summary> 
        private double dPS(int weaponDamage, double weaponSpeed)
        {
            return (double)weaponDamage / weaponSpeed;
        }
        private void processFileButton_Click(object sender, EventArgs e)
        {
            const string FILTER = "Text Files|*.txt|All Files|*.*";
            openFileDialog1.Filter = FILTER;
            try
            {
                //read and write text to and from .txt file
                StreamReader reader;
                StreamWriter writer;
                //if user clicks open/OK open file dialog and allow them to choose designated file
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //read and write info from text files
                        reader = File.OpenText(openFileDialog1.FileName);
                        writer = File.CreateText(saveFileDialog1.FileName);
                        //Set heading for text file and console window
                        Console.WriteLine("Transaction Processing");
                        writer.WriteLine("Transacton Processing");
                        //Set column headers for each column
                        Console.WriteLine("Weapon".PadRight(25) + " " + "Type".PadRight(25) + " " + "Damage".ToString().PadRight(10) + " " + "Speed".ToString().PadRight(10) + "DPS".ToString().PadRight(10));
                        writer.WriteLine("Weapon".PadRight(25) + " " + "Type".PadRight(25) + " " + "Damage".ToString().PadRight(10) + " " + "Speed".ToString().PadRight(10) + "DPS".ToString().PadRight(10));
                        //loop through weapon file
                        while (!reader.EndOfStream)
                        {
                            //Read text from file
                            weaponName = reader.ReadLine();
                            weaponType = reader.ReadLine();
                            weaponDamage = int.Parse(reader.ReadLine());
                            weaponSpeed = double.Parse(reader.ReadLine());
                            DPS = dPS(weaponDamage, weaponSpeed);
                            //Write to text file and console window
                            writer.WriteLine(weaponName.PadRight(25) + " " + weaponType.PadRight(25) + " " + weaponDamage.ToString().PadRight(10) + " " + weaponSpeed.ToString().PadRight(10) + DPS.ToString("n2").PadRight(10));
                            Console.WriteLine(weaponName.PadRight(25) + " " + weaponType.PadRight(25) + " " + weaponDamage.ToString().PadRight(10) + " " + weaponSpeed.ToString().PadRight(10) + DPS.ToString("n2").PadRight(10));
                            //separate weapon counts for the console window and for the .txt file
                            weaponCount++;
                            weaponCount1++;
                            weaponCount2++;
                        }
                        //Display the amount of weapons that have been processed
                        Console.WriteLine(weaponCount + " weapons have been processed.");
                        writer.WriteLine(weaponCount1 + " weapons have been processed.");
                        MessageBox.Show(weaponCount2 + " weapons have been processed.");
                        //close file
                        reader.Close();
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong when processing file: " + ex.Message);
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
