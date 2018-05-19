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
using Factorialiser.Classes;

namespace Factorialiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            logger.Trace("Main Window Opened");
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            logger.Trace("Main Window Closed");
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Task Summary
                // check if textboxInput.Text is empty (or only contains white space), 
                // if this is the case then throw a NullValueException
                //declare a variable here called input or datatype int
                #endregion
                if (String.IsNullOrWhiteSpace(textBoxInput.Text.ToString()) == true)
                    throw new NullValueException();
                
                int input;

                try
                {
                    #region Task Summary
                    // try and parse the text input into textboxInput into an integer and assign it to input
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input successfully parsed"
                    #endregion
                    input = int.Parse(textBoxInput.Text.ToString());
                    logger.Debug("MainForm.buttonCalculate_Click: 'input'(" + 
                        (textBoxInput.Text.ToString()) + ") successfully parsed");
                }
                catch
                {
                    #region Task Summary
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input parse failed"
                    // throw a NotIntegerException 
                    #endregion
                    logger.Debug("MainForm.buttonCalculate_Click: 'input'(" + (textBoxInput.Text.ToString()) + ") parse failed");
                    throw new NotIntegerException(textBoxInput.Text.ToString());
                }

                #region Task Summary
                // pass the input to the Calculator.Factorial method and store the retuen value in a variable
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: Calculate.Factorial suceeded"
                // change the text of labelOutput to reflect
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: labelOutput successfully updated"
                #endregion
                int output = Calculator.Factorial(input);
                logger.Debug("MainForm.buttonCalculate_Click: Calculate.Factorial suceeded");       
                labelOutput.Content = output;
                logger.Debug("MainForm.buttonCalculate_Click: 'labelOutput'(" + (output.ToString()) + ") successfully updated");
            }
            catch (NullValueException)
            {
                #region Task Summary
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Nothing Entered - Please enter an integer")
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"
                #endregion
                labelOutput.Content = "";
                textBoxInput.Clear();
                MessageBox.Show("Nothing Entered - Please enter an integer");
                logger.Error("MainForm.buttonCalculate_Click: NullValueException message displayed");
            }
            #region Task Summary
            // ###########
            // add additional catches here, one for each of your custom exception types, in each one
            // clear the labelOutput text and the textboxInput.Text
            // display an approprate message box message and log the event as an Error level
            // using the same format as used in the NullValueException catch
            // ##########
            #endregion
            catch (NotIntegerException)
            {
                labelOutput.Content = "";
                textBoxInput.Clear();
                MessageBox.Show("Invalid Input - Please enter an integer");
                logger.Error("MainForm.buttonCalculate_Click: NullValueException message displayed");
            }
            catch (NumberTooHighException)
            {
                labelOutput.Content = "";
                textBoxInput.Clear();
                MessageBox.Show("Input Too High - Please enter an valid integer");
                logger.Error("MainForm.buttonCalculate_Click: NumberTooHighException message displayed");
            }
            catch (NumberTooLowException)
            {
                labelOutput.Content = "";
                textBoxInput.Clear();
                MessageBox.Show("Input Too Low - Please enter an valid integer");
                logger.Error("MainForm.buttonCalculate_Click: NumberTooLowException message displayed");
            }
            catch (Exception ex)
            {
                #region Task Summary
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Unknown Error")
                // log the event as an Fatal Level log 
                // with the message ("MainForm.buttonCalculate_Click: Unknown Error : " + ex.message)
                #endregion
                labelOutput.Content = "";
                textBoxInput.Clear();
                MessageBox.Show("Unknown Error");
                logger.Fatal("MainForm.buttonCalculate_Click: Unknown Error : " + ex);
            }
        }
    }
}
