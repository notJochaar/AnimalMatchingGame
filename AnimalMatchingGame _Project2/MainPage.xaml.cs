namespace AnimalMatchingGame__Project2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            AnimalButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;

            List<string> animalEmoji = [
                "🐭", "🐯", "🦁", "🐮", "🐷", "🐸", "🐵", "🦄",
                "🐭", "🐯", "🦁", "🐮", "🐷", "🐸", "🐵", "🦄"
            ];

            foreach (var button in AnimalButtons.Children.OfType<Button>())
            {
                int index = Random.Shared.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }

           // Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);
        }

        Button LastClicked;
        int MatchesFound;
        bool FindingMatch = false;

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button clickedButton)
            {
                

                if (!string.IsNullOrWhiteSpace(clickedButton.Text) && (FindingMatch == false))
                {
                    clickedButton.BackgroundColor = Colors.Red;
                    LastClicked = clickedButton;
                    FindingMatch = true;
                }
                else
                {
                    if (clickedButton != LastClicked && (clickedButton.Text == LastClicked.Text )
                        && !string.IsNullOrWhiteSpace(clickedButton.Text))
                    {
                        MatchesFound++;
                        MatchesFoundLabel.Text = $"Matches Found: {MatchesFound}";
                        LastClicked.Text = string.Empty;
                        clickedButton.Text = string.Empty;
                    }
                    LastClicked.BackgroundColor = Colors.LightBlue;
                    clickedButton.BackgroundColor = Colors.LightBlue;
                    FindingMatch = false;
                }

                if (MatchesFound == 8)
                {
                    AnimalButtons.IsVisible = false;
                    PlayAgainButton.IsVisible = true;
                    MatchesFound = 0;
                }
            }

        }
    }

}
