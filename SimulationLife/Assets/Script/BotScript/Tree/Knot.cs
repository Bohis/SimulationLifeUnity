using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using UnityEngine;
using System;


namespace Tree {
	[Serializable]
	class Knot<Template> :IKnot{
		public Template _value { get; set; }
		private Knot<Template> _rightKnot;
		private Knot<Template> _leftKnot;
		public int Level { get; set; }

		public Knot(Template baseValue,int newLevel) {
			_value = baseValue;
			_rightKnot = null;
			_leftKnot = null;
			Level = newLevel;
		}

		public Knot<Template> RightKnot {
			get { return _rightKnot; }
			set { _rightKnot = value; }
		}

		public Knot<Template> LeftKnot {
			get { return _leftKnot; }
			set { _leftKnot = value; }
		}

		public float CriticalValues() {
			return ((IKnot)_value).CriticalValues();
		}		 
	}
}
