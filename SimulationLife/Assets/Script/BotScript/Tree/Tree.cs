using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using UnityEngine;


namespace Tree {
	[Serializable]
	public class Tree<Template> {
		private Knot<Template> _root;
		public int MaxLevel { get; set; }
		private int _borderLevel;
		public Tree(Template value, int borderLevel) {
			_root = new Knot<Template>( value, 0 );
			MaxLevel = 0;
			_borderLevel = borderLevel;
		}

		public void NewValue(Template value) {
			if (_root._value == null) {
				_root._value = value;
				return;
			}

			Knot<Template> valueKnot = _root;
			while (true) {
				if (( (IKnot)value ).CriticalValues() >= valueKnot.CriticalValues()) {
					if (valueKnot.RightKnot == null) {
						valueKnot.RightKnot = new Knot<Template>( value, valueKnot.Level + 1 );
						if (MaxLevel < valueKnot.Level + 1)
							MaxLevel = valueKnot.Level + 1;
						break;
					}
					else {
						valueKnot = valueKnot.RightKnot;
					}
				}
				else {
					if (valueKnot.LeftKnot == null) {
						valueKnot.LeftKnot = new Knot<Template>( value, valueKnot.Level + 1 );
						if (MaxLevel < valueKnot.Level + 1)
							MaxLevel = valueKnot.Level + 1;
						break;
					}
					else {
						valueKnot = valueKnot.LeftKnot;
					}
				}
			}

			if (MaxLevel == _borderLevel) {
				if (MaxLevelReach != null)
					MaxLevelReach();
			}
		}

		public Template RootValue {
			get {
				return _root._value;
			}
			set {
				_root._value = value;
			}
		}

		public Template MaxRightValue() {
			Knot<Template> valueKnot = _root;
			while (true) {
				if (valueKnot.RightKnot != null) {
					valueKnot = valueKnot.RightKnot;
				}
				else {
					return valueKnot._value;
				}
			}
		}

		public Template MaxLeftValue() {
			Knot<Template> valueKnot = _root;
			while (true) {
				if (valueKnot.LeftKnot != null) {
					valueKnot = valueKnot.LeftKnot;
				}
				else {
					return valueKnot._value;
				}
			}
		}

		public delegate void baseMethod();

		public event baseMethod MaxLevelReach;
	}
}																																						 