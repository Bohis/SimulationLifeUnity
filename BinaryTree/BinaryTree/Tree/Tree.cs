using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Tree {
	class Tree<Template> {
		private Knot<Template> _root;
		public int MaxLevel { get; set; }
		public Tree(Template value) {
			_root = new Knot<Template>( value, 0 );
			MaxLevel = 0;
		}

		public void NewValue(Template value) {
			Knot<Template> valueKnot = _root;
			while (true) {
				if (( (IKnot)value ).CriticalValues() >= valueKnot.CriticalValues()) {
					if (valueKnot.RightKnot == null) {
						valueKnot.RightKnot = new Knot<Template>( value, valueKnot.Level + 1 );
						if (MaxLevel < valueKnot.Level + 1)
							MaxLevel = valueKnot.Level + 1;
						return;
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
						return;
					}
					else {
						valueKnot = valueKnot.LeftKnot;
					}
				}
			}
		}

		public Template RootValue() {
			return _root.GetValue();
		}

		public Template MaxRightValue() {
			Knot<Template> valueKnot = _root;
			while (true) {
				if (valueKnot.RightKnot != null) {
					valueKnot = valueKnot.RightKnot;
				}
				else {
					return valueKnot.GetValue();
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
					return valueKnot.GetValue();
				}
			}
		}


	}
}																																						 