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



namespace Tivia
{
    public partial class Form1 : Form
    {
        StreamReader inputFile;
        String question, a1, a2, a3, a4;
        int answer;
        double numOfRight, total;
        int userAnswer;
        char correctAnswer;
        bool questionAnswered = false; //boolean to check if question has been answered

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                inputFile = File.OpenText(@"Trivia.txt");
                question = inputFile.ReadLine();
                a1 = inputFile.ReadLine();
                a2 = inputFile.ReadLine();
                a3 = inputFile.ReadLine();
                a4 = inputFile.ReadLine();
                answer = Convert.ToInt32(inputFile.ReadLine());
                if (answer == 1)
                    correctAnswer = 'A';
                else if (answer == 2)
                    correctAnswer = 'B';
                else if (answer == 3)
                    correctAnswer = 'C';
                else
                    correctAnswer = 'D';
                lblQuestion.Text = question.ToString();
                lblA1.Text = a1.ToString();
                lblA2.Text = a2.ToString();
                lblA3.Text = a3.ToString();
                lblA4.Text = a4.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            if (questionAnswered == false)
            {
                MessageBox.Show("You must answer this question before moving on");
            }
            else
            {
                //code to display next question
                if (!inputFile.EndOfStream) // checks to make sure you arent at end of file
                {
                    question = inputFile.ReadLine();
                    lblQuestion.Text = question.ToString();
                    a1 = inputFile.ReadLine();
                    a2 = inputFile.ReadLine();
                    a3 = inputFile.ReadLine();
                    a4 = inputFile.ReadLine();
                    answer = Convert.ToInt32(inputFile.ReadLine());
                    if (answer == 1)
                        correctAnswer = 'A';
                    else if (answer == 2)
                        correctAnswer = 'B';
                    else if (answer == 3)
                        correctAnswer = 'C';
                    else
                        correctAnswer = 'D';
                    lblA1.Text = a1.ToString();
                    lblA2.Text = a2.ToString();
                    lblA3.Text = a3.ToString();
                    lblA4.Text = a4.ToString();
                }
                else
                {
                    inputFile.Close();//closes file if the end is reached
                    MessageBox.Show("Thanks for playing! Your final score is: " + (numOfRight/total * 100) + "%");
                    this.Close();
                }
                questionAnswered = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
                MessageBox.Show("You must pick an answer");
            else
            {
                userAnswer = getUserAnswer(); // method call to get users answer

                if (userAnswer == answer) //checks if answer is correct
                {
                    MessageBox.Show("Correct answer!");
                    questionAnswered = true; //changes boolean to true so you are able to move to the next question
                    numOfRight += 1;
                    total += 1;
                }
                else
                {
                    MessageBox.Show("Incorrect answer. Correct answer is: " + correctAnswer);
                    questionAnswered = true;
                    total += 1;
                }
                btnSubmit.Enabled = false;
                MessageBox.Show("Your current score: " + numOfRight.ToString() + " / " + total.ToString());
            }
        }
        private int getUserAnswer()
        {
                if (radioButton1.Checked)
                userAnswer = 1;
            else if (radioButton2.Checked)
                userAnswer = 2;
            else if (radioButton3.Checked)
                userAnswer = 3;
            else if (radioButton4.Checked)
                userAnswer = 4;

                return userAnswer;
         }

        private void btnClear_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
       
    }
}
