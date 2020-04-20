using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfscraping
{
    class Tender
    {
        string TenderNo;
        string TenderDescription;
        string AwardedTo;
        string Amount;
        int BEE;
        int Points;

        public void SetTender(string pTenderNo, string pTenderDescription, string pAwardedTo, string pAmount, int pBEE, int pPoints)
        {
            TenderNo = pTenderNo;
            TenderDescription = pTenderDescription;
            AwardedTo = pAwardedTo;
            Amount = pAmount;
            BEE = pBEE;
            Points = pPoints;
        }

        public string GetTenderNo()
        {
            return TenderNo;
        }
        public string GetTenderDescription()
        {
            return TenderDescription;
        }
        public string getAwardedTo()
        {
            return AwardedTo;
        }
        public string getAmount()
        {
            return Amount;
        }
        public int getBEE()
        {
            return BEE;
        }
        public int getPoints()
        {
            return Points;
        }

    }
}
