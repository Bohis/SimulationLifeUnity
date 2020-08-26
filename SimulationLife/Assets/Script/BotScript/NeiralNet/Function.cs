using System;

namespace NeiralNet {
	///<summary> 
	///Класс, содержащий активационную функцию и распределение гаусса 
	///</summary>
	static class Function {
		/// <summary>
		/// Распределение гаусса
		/// </summary> 
		static public double Gauss(double x) {
			return new Random((int)DateTime.Now.Ticks).NextDouble();
		}
		/// <summary>
		///  Активационая функция
		/// </summary>				 
		static public double Sigmoid(double x) {
			return 1.0 / ( 1.0 + Math.Exp( -0.1 * x ) );
		}
	}
}