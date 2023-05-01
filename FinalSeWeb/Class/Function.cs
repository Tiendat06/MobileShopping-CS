using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalSeWeb.Models;

namespace FinalSeWeb.Class
{
	
	public static class Function
	{
		private static FINAL_SEEntities db = new FINAL_SEEntities();
		//Ham tang id cho Agent
		public static string AUTOID_AGENT()
		{
			string res = null;
			string maxAgentId = db.AGENTs.Max(a => a.Agent_ID);
			if (maxAgentId == null)
			{
				res = "AG" + "000000001";
			}
			else
			{
				int temp = int.Parse(maxAgentId.Substring(2, 9));
				temp++;
				res = String.Format("AG{0:000000000}", temp);
			}
			return res;
		}
	}
}