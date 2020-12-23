using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CTPNBL
    {
        private static CTPNBL Instance;
        public static CTPNBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new CTPNBL();
                }
                return Instance;
            }
        }
        private CTPNBL() { }
        public bool ThemCTPN(DataTable dt, int MAPN)
        {
            return CTPNDL.GetInstance.ThemCTPN(dt, MAPN);
        }
    }
}
