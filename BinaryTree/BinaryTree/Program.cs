using System;
using BinaryTree.Tree;

namespace BinaryTree {
	class Program {
		static void Main(string [] args) {
			Class1[] obj = new Class1[ 10 ];
			for (int i = 0 ; i < 10 ; ++i) {
				obj [ i ] = new Class1();
				obj [ i ].value = i;

			}

			Tree<Class1> obj2 = new Tree<Class1>(obj[0]);
			for (int i = 1 ; i < 10 ; ++i) {
				obj2.NewValue( obj [ i ] );
			}


			Console.Read();
		}
	}
}
