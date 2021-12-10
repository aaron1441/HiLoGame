using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HiLoGame
{
    public partial class MainPage : ContentPage
    {
        // global variables
        Random random;
        const string GAMES_PLAYED_TEXT = "Games Played: ";
        const string GAMES_WON_TEXT = "Games Won: ";
        int currentNum;
        int startNum;
        int numToCheck;
        int higherOrLower;
        int gamesWon = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            currentNum = random.Next(12);
            checkHighOrLow();
            LblCurrentNumber.Text = currentNum.ToString();
            IBNewCard.IsEnabled = false;
            numToCheck = currentNum;
        }

        private void BtnStartNewGame_Clicked(object sender, EventArgs e)
        {
            if (random == null) random = new Random();
            LblGamesPlayed.Text = GAMES_PLAYED_TEXT + "--";
            startNum = random.Next(12);
            numToCheck = startNum;
            LblCurrentNumber.Text = startNum.ToString();
            IBNewCard.IsEnabled = true;
        }

        private void BtnLower_Clicked(object sender, EventArgs e)
        {
            higherOrLower = -1;
            IBNewCard.IsEnabled = true;
        }

        private void BtnHigher_Clicked(object sender, EventArgs e)
        {
            higherOrLower = 1;
            IBNewCard.IsEnabled = true;
        }

        private async void checkHighOrLow()
        {
            if(higherOrLower == -1 && currentNum < numToCheck)
            {
                await DisplayAlert("Correct", "The number " + currentNum + " is lower than " + numToCheck, "OK");
                gamesWon++;
                LblGamesWon.Text = GAMES_WON_TEXT + gamesWon.ToString();
            }
            else if (higherOrLower == -1 && currentNum > numToCheck)
            {
                await DisplayAlert("Wrong", "The number " + currentNum + " is not lower than " + numToCheck, "OK");
            }
            else if (higherOrLower == 1 && currentNum > numToCheck)
            {
                await DisplayAlert("Correct", "The number " + currentNum + " is higher than " + numToCheck, "OK");
                gamesWon++;
                LblGamesWon.Text = GAMES_WON_TEXT + gamesWon.ToString();
            }
            else if (higherOrLower == 1 && currentNum < numToCheck)
            {
                await DisplayAlert("Wrong", "The number " + currentNum + " is not higher than " + numToCheck, "OK");
            }
        }
        
    }
}
