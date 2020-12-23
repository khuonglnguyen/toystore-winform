
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CTHDBL
    {
        private static CTHDBL Instance;
        public static CTHDBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new CTHDBL();
                }
                return Instance;
            }
        }
        private CTHDBL() { }
        public bool ThemCTHD(DataTable dt, int SOHD, decimal THANHTIEN)
        {
            return CTHDDL.GetInstance.ThemCTHD(dt, SOHD,THANHTIEN);
        }
    }
}
