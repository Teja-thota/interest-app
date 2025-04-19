namespace interest_app.Models
{
    public class InterestCal
    {
        public double Principal { get; set; }
        public double Rate { get; set; }
        public double Time { get; set; }
        public double SimpleInterest => (Principal * Time * Rate) / 100;

    }
   
}
