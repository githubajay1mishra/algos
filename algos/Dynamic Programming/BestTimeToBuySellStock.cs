namespace algos.DynamicProgrammng
{
    public class BestBuySellStockSolution
    {
        public int MaxProfit(int[] prices)
        {
            
            var profit = int.MinValue;
            var bestBuyPriceKnown = int.MaxValue;

            for(int index = 0; index < prices.Length; ++index){
                 if(prices[index] < bestBuyPriceKnown){
                     bestBuyPriceKnown = prices[index];                     
                 }

                 var currentProfit = prices[index] - bestBuyPriceKnown;

                 if(currentProfit > profit){
                     profit = currentProfit;
                 }             

            }

            return profit > 0 ? profit : 0;

        }
    }


}