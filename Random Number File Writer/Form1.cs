//John Fade IV 2307363
//I worked alone on this assignment
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

//Create an application that writes a series of random numbers to a file.
//Each random number should be in the range of 1 through 100. 
//The application should let the user specify how many random numbers the file will hold 
//  and should use a SaveFileDialog control to let the user specify the file’s name and location.

namespace Random_Number_File_Writer
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //clears the ListBox upon clicking save
                outputListBox.Items.Clear();
            
            int rNum; //stored as the number entered by the user. 

            rNum = int.Parse(randTextBox.Text); //parses the user entry and assigns it to rNum.
            Random rand = new Random(); // initilizes the random variable

            //variables for reading and writing
            StreamWriter outputFile; //writer
            StreamReader inputFile; //reader

            if (saveFile.ShowDialog() == DialogResult.OK);
            {
                outputFile = File.CreateText(saveFile.FileName);

                for (int count = 0; count < rNum; count++) //initilizes a forloop to count up to the value entered by the user
                {
                    
                    int number; //holds a new random number each time it loops.

                    number = rand.Next(1, 100); // the new random number ranging from 1 - 100

                    outputFile.WriteLine(number); //writes a new line in the text file using the new random number

                }

                //closes the file
                outputFile.Close();

                //Opens and reads the text
                inputFile = File.OpenText(saveFile.FileName);

                //the counter for each line read
                int lineCounter = 0;

                //when not at the end of the file and the line counter is less than 10 
                    //adds and displays the first 10 numbers to the ListBox
                while (!inputFile.EndOfStream && lineCounter < 10)
                {

                        lineCounter++;
                        outputListBox.Items.Add(inputFile.ReadLine());
                    
                        
                }
                //closes the file
                inputFile.Close();



            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
