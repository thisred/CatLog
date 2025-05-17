namespace ET.Server
{
    public static class RoundInfoSystem
    {
        public static int GetRoundMaxNum(this RoundInfo roundInfo)
        {
            return roundInfo.Round switch
            {
                1 => 1,
                2 => 3,
                3 => 5,
                _ => 0
            };
        }
    }
}