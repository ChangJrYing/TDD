// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// create a bowling game as a class
// it should have a roll method that takes in an int
// it needs to calculate the score after each roll
// and there is a bonus for spares and strikes
// it should have a score method that returns an int
public class BowlingGame
{
    private int[] rolls = new int[21];
    private int currentRoll = 0;

    public void Roll(int pins)
    {
        rolls[currentRoll++] = pins;
    }

    public int Score()
    {
        int score = 0;
        int frameIndex = 0;
        List<int> frameScores = new List<int>(); // to store each frame's score

        for (int frame = 0; frame < 10; frame++)
        {
            if (IsStrike(frameIndex)) // strike
            {
                int frameScore = 10 + StrikeBonus(frameIndex);
                frameScores.Add(frameScore);
                score += frameScore;
                frameIndex++;
            }
            else if (IsSpare(frameIndex)) // spare
            {
                int frameScore = 10 + SpareBonus(frameIndex);
                frameScores.Add(frameScore);
                score += frameScore;
                frameIndex += 2;
            }
            else
            {
                int frameScore = SumOfBallsInFrame(frameIndex);
                frameScores.Add(frameScore);
                score += frameScore;
                frameIndex += 2;
            }
        }

        // Now you have each frame's score in frameScores list
        // You can print it or use it for debugging
        Console.WriteLine(string.Join(", ", frameScores));

        return score;
    }

    private bool IsStrike(int frameIndex)
    {
        return rolls[frameIndex] == 10;
    }

    private int SumOfBallsInFrame(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1];
    }

    private int SpareBonus(int frameIndex)
    {
        return rolls[frameIndex + 2];
    }

    private int StrikeBonus(int frameIndex)
    {
        return rolls[frameIndex + 1] + rolls[frameIndex + 2];
    }

    private bool IsSpare(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }
}
