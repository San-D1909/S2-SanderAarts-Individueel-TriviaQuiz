namespace BusinessManager.Business
{
    public class CalculateScore
    {
        public static int Calculation(double timeUsed,double maxTime)
        {
            double score = ((maxTime - timeUsed) / maxTime) * 100;
            if (timeUsed >= 5 && timeUsed <= 20)
            {
                score = score / 1.5;
                return (int)score;
            }
            else
            {
                return (int)score / 2;
            }
        }
    }
}