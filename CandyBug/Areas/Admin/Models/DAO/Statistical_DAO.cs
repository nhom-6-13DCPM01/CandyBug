using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CandyBug.Models;

namespace CandyBug.Areas.Admin.Models.DAO
{
    public class Statistical_DAO
    {
        CandybugOnlineEntities DBCandyBug;
        
        public Statistical_DAO() { DBCandyBug = new CandybugOnlineEntities(); }


    }
}