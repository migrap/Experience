using System;

namespace Experience.Models {
	//Inverse Functional Identifier
	public class InverseFunctionalIdentifier {        
        public Mailto Mbox { get; set; }
		public string Shasum { get; set; }
		public string Openid { get; set; }
		public Account Account { get; set; }
	}
}

